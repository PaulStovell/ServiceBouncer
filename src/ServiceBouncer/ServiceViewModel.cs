using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace ServiceBouncer
{
    public sealed class ServiceViewModel : INotifyPropertyChanged
    {
        private readonly ServiceController controller;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; private set; }
        public string ServiceName { get; private set; }
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