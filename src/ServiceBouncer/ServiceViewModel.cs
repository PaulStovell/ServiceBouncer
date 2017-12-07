using ServiceBouncer.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBouncer
{
    public sealed class ServiceViewModel : INotifyPropertyChanged
    {
        private readonly ServiceController controller;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; private set; }
        public string ServiceName { get; private set; }
        public string Description { get; private set; } 
        public string Status { get; private set; }
        public string StartupType { get; private set; }
        public Image StatusIcon { get; private set; }

        public ServiceViewModel(ServiceController controller)
        {
            this.controller = controller;
            Name = controller.DisplayName;
            ServiceName = controller.ServiceName;
            Status = controller.Status.ToString();
            StatusIcon = GetIcon(Status);
            StartupType = controller.StartType.ToString();
            Description = "";

            GetDescription();
        }

        public async Task GetDescription()
        {
            await Task.Run(() => Description = controller.GetServiceDescription());
        }

        public async Task Start()
        {
            if (controller.Status == ServiceControllerStatus.Stopped)
            {
                await Task.Run(() => controller.Start());
                await Refresh();
            }
            else if (controller.Status == ServiceControllerStatus.Paused)
            {
                await Task.Run(() => controller.Continue());
                await Refresh();
            }
        }

        public async Task Restart()
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

                await Refresh();
            }
        }

        public async Task Stop()
        {
            if (controller.Status == ServiceControllerStatus.Running || controller.Status == ServiceControllerStatus.Paused)
            {
                await Task.Run(() => controller.Stop());
                await Refresh();
            }
        }

        public async Task Pause()
        {
            if (controller.Status == ServiceControllerStatus.Running)
            {
                if (controller.CanPauseAndContinue)
                {
                    await Task.Run(() => controller.Pause());
                    await Refresh();
                }
                else
                {
                    throw new Exception("Cannot pause this service");
                }
            }
        }

        public async Task Delete()
        {
            if (controller.Status == ServiceControllerStatus.Running)
            {
                await Task.Run(() => controller.Stop());
            }
            await Task.Run(() => Process.Start("sc.exe", "delete \"" + ServiceName + "\""));
        }

        public async Task SetStartupType(ServiceStartMode newType)
        {
            await Task.Run(() => controller.SetStartupType(newType));
            await Refresh();
        }

        public async Task OpenServiceInExplorer()
        {
            await Task.Run(() =>
            {
                var path = controller.GetExecutablePath();
                Process.Start("explorer.exe", $"/select, \"{path.FullName}\"");
            });
        }

        public async Task<string> GetAssemblyInfo()
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

        private string BuildAssemblyInfoText(Assembly assembly)
        {
            var title = assembly.GetCustomAttribute<AssemblyTitleAttribute>();
            var description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();
            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            var product = assembly.GetCustomAttribute<AssemblyProductAttribute>();
            var copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>();
            var version = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();

            var output = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(title?.Title)) output.AppendLine($"* Title: {title.Title}");
            if (!string.IsNullOrWhiteSpace(description?.Description)) output.AppendLine($"* Description: {description.Description}");
            if (!string.IsNullOrWhiteSpace(company?.Company)) output.AppendLine($"* Company: {company.Company}");
            if (!string.IsNullOrWhiteSpace(product?.Product)) output.AppendLine($"* Product: {product.Product}");
            if (!string.IsNullOrWhiteSpace(copyright?.Copyright)) output.AppendLine($"* Copyright: {copyright.Copyright}");
            if (!string.IsNullOrWhiteSpace(version?.Version)) output.AppendLine($"* Version: {version.Version}");

            return output.ToString();
        }

        private string BuildAssemblyInfoText(FileVersionInfo fileVersion)
        {
            var output = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(fileVersion.FileDescription)) output.AppendLine($"* Description: {fileVersion.FileDescription}");
            if (!string.IsNullOrWhiteSpace(fileVersion.CompanyName)) output.AppendLine($"* Company: {fileVersion.CompanyName}");
            if (!string.IsNullOrWhiteSpace(fileVersion.ProductName)) output.AppendLine($"* Product: {fileVersion.ProductName}");
            if (!string.IsNullOrWhiteSpace(fileVersion.LegalCopyright)) output.AppendLine($"* Copyright: {fileVersion.LegalCopyright}");
            if (!string.IsNullOrWhiteSpace(fileVersion.FileVersion)) output.AppendLine($"* Version: {fileVersion.FileVersion}");

            return output.ToString();
        }

        public async Task Refresh()
        {
            try
            {
                var changed = await Task.Run(() =>
                {
                    var changedEvents = new List<string>();

                    try
                    {
                        controller.Refresh();

                        if (Name != controller.DisplayName)
                        {
                            Name = controller.DisplayName;
                            changedEvents.Add("Name");
                        }

                        if (ServiceName != controller.ServiceName)
                        {
                            ServiceName = controller.ServiceName;
                            changedEvents.Add("ServiceName");
                        }

                        var statusText = controller.Status.ToString();
                        if (Status != statusText)
                        {
                            Status = controller.Status.ToString();
                            StatusIcon = GetIcon(Status);
                            changedEvents.Add("Status");
                            changedEvents.Add("StatusIcon");
                        }

                        var startup = controller.StartType.ToString();
                        if (StartupType != startup)
                        {
                            StartupType = startup;
                            changedEvents.Add("StartupType");
                        }
                    }
                    catch (Exception)
                    {
                        //Ignored
                    }

                    return changedEvents;
                });

                foreach (var item in changed)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(item));
                }
            }
            catch (Exception)
            {
                //Ignored
            }
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
    }
}