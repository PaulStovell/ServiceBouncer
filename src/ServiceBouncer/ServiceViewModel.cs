using ServiceBouncer.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBouncer
{
    public sealed class ServiceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; private set; }
        public string ServiceName { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set; }
        public string StartupType { get; private set; }
        public string LogOnAs { get; private set; }
        public Image StatusIcon { get; private set; }
        public string MachineName { get; private set; }

        private const string LOCAL_SYSTEM_ACCOUNT_NAME = "LocalSystem";

        public ServiceViewModel(string machineName, ManagementBaseObject wmiObject)
        {
            MachineName = machineName;
            FillFromWmiObject(wmiObject);
        }

        private void FillFromWmiObject(ManagementBaseObject wmiObject)
        {
            Name = wmiObject["DisplayName"]?.ToString();
            ServiceName = wmiObject["Name"]?.ToString();
            Description = wmiObject["Description"]?.ToString();
            Status = wmiObject["State"].ToString();
            StatusIcon = GetIcon(Status);
            StartupType = wmiObject["StartMode"].ToString();

            LogOnAs = wmiObject["StartName"]?.ToString();
            if (string.IsNullOrWhiteSpace(LogOnAs) || LogOnAs.Equals(LOCAL_SYSTEM_ACCOUNT_NAME, StringComparison.OrdinalIgnoreCase))
            {
                LogOnAs = LOCAL_SYSTEM_ACCOUNT_NAME;
            }
        }

        public async Task Start()
        {
            using (var controller = new ServiceController(Name, MachineName))
            {
                if (controller.Status == ServiceControllerStatus.Stopped)
                    await Task.Run(() => controller.Start());
                else if (controller.Status == ServiceControllerStatus.Paused)
                    await Task.Run(() => controller.Continue());
            }
        }

        public async Task Restart()
        {
            using (var controller = new ServiceController(Name, MachineName))
            {
                if (controller.Status == ServiceControllerStatus.Running || controller.Status == ServiceControllerStatus.Paused)
                {
                    await Task.Run(() =>
                    {
                        controller.Stop();
                        controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(60));

                        if (controller.Status != ServiceControllerStatus.Stopped)
                        {
                            throw new Exception("The service did not stop within 60 seconds, you will need to start manually");
                        }

                        controller.Start();
                    });
                }
            }
        }

        public async Task Stop()
        {
            using (var controller = new ServiceController(Name, MachineName))
            {
                if (controller.Status == ServiceControllerStatus.Running || controller.Status == ServiceControllerStatus.Paused)
                {
                    await Task.Run(() => controller.Stop());
                }
            }
        }

        public async Task Pause()
        {
            using (var controller = new ServiceController(Name, MachineName))
            {
                if (controller.Status == ServiceControllerStatus.Running)
                {
                    if (controller.CanPauseAndContinue)
                    {
                        await Task.Run(() => controller.Pause());
                    }
                    else
                    {
                        throw new Exception("Cannot pause this service");
                    }
                }
            }
        }

        public async Task Delete()
        {
            using (var controller = new ServiceController(Name, MachineName))
            {
                // TODO: log bug.  This needs to be disabled for remote machines since the process is only executed locally.
                if (controller.Status == ServiceControllerStatus.Running)
                {
                    await Task.Run(() => controller.Stop());
                }
                await Task.Run(() => Process.Start("sc.exe", "delete \"" + ServiceName + "\""));
            }
        }

        public async Task SetStartupType(ServiceStartMode newType)
        {
            using (var controller = new ServiceController(Name, MachineName))
            {
                await Task.Run(() => controller.SetStartupType(newType));
            }
        }

        public async Task OpenServiceInExplorer()
        {
            using (var controller = new ServiceController(Name, MachineName))
            {
                await Task.Run(() =>
                {
                    var path = controller.GetExecutablePath();
                    Process.Start("explorer.exe", $"/select, \"{path.FullName}\"");
                });
            }
        }

        public async Task<string> GetAssemblyInfo()
        {
            using (var controller = new ServiceController(Name, MachineName))
            {
                return await Task.Run(() =>
                {
                    var path = controller.GetExecutablePath();
                    try
                    {
                        var assembly = Assembly.LoadFrom(path.FullName);
                        return BuildAssemblyInfoText(assembly);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            var versionInfo = FileVersionInfo.GetVersionInfo(path.FullName);
                            return BuildAssemblyInfoText(versionInfo);
                        }
                        catch (Exception)
                        {
                            throw new Exception("Unable to find property values");
                        }
                    }
                });
            }
        }

        private string BuildAssemblyInfoText(Assembly assembly)
        {
            var title = assembly.GetCustomAttribute<AssemblyTitleAttribute>();
            var description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();
            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            var product = assembly.GetCustomAttribute<AssemblyProductAttribute>();
            var copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>();
            var version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();

            var output = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(title?.Title)) output.AppendLine($@"* Title: {title.Title}");
            if (!string.IsNullOrWhiteSpace(description?.Description)) output.AppendLine($@"* Description: {description.Description}");
            if (!string.IsNullOrWhiteSpace(company?.Company)) output.AppendLine($@"* Company: {company.Company}");
            if (!string.IsNullOrWhiteSpace(product?.Product)) output.AppendLine($@"* Product: {product.Product}");
            if (!string.IsNullOrWhiteSpace(copyright?.Copyright)) output.AppendLine($@"* Copyright: {copyright.Copyright}");
            if (!string.IsNullOrWhiteSpace(version?.Version)) output.AppendLine($@"* Version: {version.Version}");

            return output.ToString();
        }

        private string BuildAssemblyInfoText(FileVersionInfo fileVersion)
        {
            var output = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(fileVersion.FileDescription)) output.AppendLine($@"* Description: {fileVersion.FileDescription}");
            if (!string.IsNullOrWhiteSpace(fileVersion.CompanyName)) output.AppendLine($@"* Company: {fileVersion.CompanyName}");
            if (!string.IsNullOrWhiteSpace(fileVersion.ProductName)) output.AppendLine($@"* Product: {fileVersion.ProductName}");
            if (!string.IsNullOrWhiteSpace(fileVersion.LegalCopyright)) output.AppendLine($@"* Copyright: {fileVersion.LegalCopyright}");
            if (!string.IsNullOrWhiteSpace(fileVersion.FileVersion)) output.AppendLine($@"* Version: {fileVersion.FileVersion}");

            return output.ToString();
        }

        public enum RefreshData
        {
            DisplayName,
            ServiceName,
            Description,
            Status,
            Startup,
            LogOnAs,
        }
        private Image GetIcon(string status)
        {
            switch (status.ToLower())
            {
                case "running":
                    return Properties.Resources.Running_State_Running;
                case "stopped":
                    return Properties.Resources.Running_State_Stopped;
                case "startpending":
                    return Properties.Resources.Running_State_StartPending;
                case "stoppending":
                    return Properties.Resources.Running_State_StopPending;
                case "paused":
                    return Properties.Resources.Running_State_Paused;
                default:
                    return Properties.Resources.Running_State_Unknown;
            }
        }

        internal void UpdateFromWmi(ManagementBaseObject targetInstance)
        {
            var changedEvents = new List<string>();

            try
            {
                var name = targetInstance["DisplayName"]?.ToString();
                if (Name != name)
                {
                    Name = name;
                    changedEvents.Add("Name");
                }

                var serviceName = targetInstance["Name"]?.ToString();
                if (ServiceName != serviceName)
                {
                    ServiceName = serviceName;
                    changedEvents.Add("ServiceName");
                }

                var description = targetInstance["Description"]?.ToString();
                if (Description != description)
                {
                    Description = description;
                    changedEvents.Add("Description");
                }

                var status = targetInstance["State"].ToString();
                if (Status != status)
                {
                    Status = status;
                    StatusIcon = GetIcon(Status);
                    changedEvents.Add("Status");
                    changedEvents.Add("StatusIcon");
                }

                var startupType = targetInstance["StartMode"].ToString();
                if (StartupType != startupType)
                {
                    StartupType = startupType;
                    changedEvents.Add("StartupType");
                }

                var logOnAs = targetInstance["StartName"]?.ToString();
                if (string.IsNullOrWhiteSpace(logOnAs) || logOnAs.Equals(LOCAL_SYSTEM_ACCOUNT_NAME, StringComparison.OrdinalIgnoreCase))
                {
                    logOnAs = LOCAL_SYSTEM_ACCOUNT_NAME;
                }
                if (LogOnAs != logOnAs)
                {
                    LogOnAs = logOnAs;
                    changedEvents.Add("LogOnAs");
                }
            }
            catch (Exception)
            {
                //Ignored
            }

            foreach (var item in changedEvents)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(item));
            }
        }
    }
}