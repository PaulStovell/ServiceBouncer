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
            if (controller.Status == ServiceControllerStatus.Stopped || controller.Status == ServiceControllerStatus.Paused)
            {
                await Task.Run(() => controller.Start());
                await Refresh();
            }
        }

        public async Task Restart()
        {
            if (controller.Status == ServiceControllerStatus.Running)
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
            if (controller.Status == ServiceControllerStatus.Running)
            {
                await Task.Run(() => controller.Stop());
                await Refresh();
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
                    controller.Refresh();

                    var changedEvents = new List<string>();

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
            string colour;
            switch (status.ToLower())
            {
                case "running":
                    colour = "#00ff45";
                    break;
                case "stopped":
                    colour = "#db5b5b";
                    break;
                default:
                    colour = "#ff9a00";
                    break;
            }

            var bitmap = new Bitmap(20, 20);

            using (var g = Graphics.FromImage(bitmap))
            {
                using (Brush b = new SolidBrush(ColorTranslator.FromHtml(colour)))
                {
                    g.FillEllipse(b, 0, 0, 19, 19);
                }
            }

            return bitmap;
        }
    }
}