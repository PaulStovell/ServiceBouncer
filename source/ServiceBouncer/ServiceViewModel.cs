using System;
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
            StartupType = controller.StartUpType();
        }

        public async void Start()
        {
            if (controller.Status == ServiceControllerStatus.Stopped || controller.Status == ServiceControllerStatus.Paused)
            {
                await Task.Run(() => controller.Start());
                Refresh();
            }
        }

        public async void Restart()
        {
            if (controller.Status == ServiceControllerStatus.Running)
            {
                await Task.Run(() =>
                {
                    controller.Stop();
                    controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                    controller.Start();
                });

                Refresh();
            }
        }

        public async void Stop()
        {
            if (controller.Status == ServiceControllerStatus.Running)
            {
                await Task.Run(() => controller.Stop());
                Refresh();
            }
        }

        public async void Delete()
        {
            if (controller.Status == ServiceControllerStatus.Running)
            {
                await Task.Run(() => controller.Stop());
            }
            await Task.Run(() => Process.Start("sc.exe", "delete \"" + ServiceName + "\""));
        }

        public async void SetStartupType(ServiceStartMode newType)
        {
            await Task.Run(() => controller.SetStartupType(newType));
            Refresh();
        }

        public async void Refresh()
        {
            try
            {
                await Task.Run(() =>
                {
                    controller.Refresh();

                    if (Name != controller.DisplayName)
                    {
                        Name = controller.DisplayName;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                    }

                    if (ServiceName != controller.ServiceName)
                    {
                        ServiceName = controller.ServiceName;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ServiceName"));
                    }


                    var statusText = controller.Status.ToString();
                    if (Status != statusText)
                    {
                        Status = controller.Status.ToString();
                        StatusIcon = GetIcon(Status);
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StatusIcon"));
                    }

                    var startup = controller.StartUpType();
                    if (StartupType != startup)
                    {
                        StartupType = startup;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartupType"));
                    }
                });
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