using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

namespace ServiceBouncer
{
    using System;

    public sealed class ServiceViewModel : INotifyPropertyChanged
    {
        private readonly ServiceController controller;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; private set; }
        public string ServiceName { get; private set; }
        public string Status { get; private set; }
        public string StartupType { get; private set; }

        public ServiceViewModel(ServiceController controller)
        {
            this.controller = controller;
        }

        public void Start()
        {
            if (controller.Status == ServiceControllerStatus.Stopped || controller.Status == ServiceControllerStatus.Paused)
            {
                controller.Start();
                Refresh();
            }
        }

        public void Restart()
        {
            if (controller.Status == ServiceControllerStatus.Running)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    controller.Stop();
                    controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                    controller.Start();
                    Refresh();
                });
            }
        }

        public void Stop()
        {
            if (controller.Status == ServiceControllerStatus.Running)
            {
                controller.Stop();
                Refresh();
            }
        }

        public void Delete()
        {
            if (controller.Status == ServiceControllerStatus.Running)
            {
                controller.Stop();
            }
            Process.Start("sc.exe", "delete \"" + ServiceName + "\"");
        }

        public void SetStartupType(ServiceStartMode newType)
        {
            controller.SetStartupType(newType);
            Refresh();
        }

        public void Refresh()
        {
            controller.Refresh();
            Name = controller.DisplayName;
            ServiceName = controller.ServiceName;
            Status = controller.Status.ToString();
            StartupType = controller.StartUpType();

            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ServiceName"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartupType"));
            }
            catch (Exception)
            {
                //Ignored
            }
        }
    }
}