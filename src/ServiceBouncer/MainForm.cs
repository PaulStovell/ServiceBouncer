using ServiceBouncer.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceBouncer
{
    public partial class MainForm : Form
    {
        private readonly BindingList<ServiceViewModel> services = new SortableBindingList<ServiceViewModel>();
        private bool isActive;

        public MainForm()
        {
            isActive = true;
            InitializeComponent();
            serviceViewModelBindingSource.DataSource = services;
        }

        private void RefreshTimerTicked(object sender, EventArgs e)
        {
            if (isActive)
            {
                PerformOperation(x => x.Refresh(), services.ToList());
                SetTitle();
            }
        }

        private void FormActivated(object sender, EventArgs e)
        {
            isActive = true;
        }

        private void FormDeactivated(object sender, EventArgs e)
        {
            isActive = false;
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            Reload();
        }

        private void RefreshClicked(object sender, EventArgs e)
        {
            Reload();
        }

        private void FilterBoxTextChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void StartClicked(object sender, EventArgs e)
        {
            PerformOperation(async x => await x.Start());
        }

        private void RestartClicked(object sender, EventArgs e)
        {
            PerformOperation(async x => await x.Restart());
        }

        private void StopClicked(object sender, EventArgs e)
        {
            PerformOperation(async x => await x.Stop());
        }

        private void PauseClicked(object sender, EventArgs e)
        {
            PerformOperation(async x => await x.Pause());
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            PerformOperation(async x =>
            {
                if (MessageBox.Show($"Are you sure you want to delete the '{x.Name}'", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    await x.Delete();
                    Thread.Sleep(500);
                    Reload();
                }
            });
        }

        private void StartupAutomaticClicked(object sender, EventArgs e)
        {
            PerformOperation(async x => await x.SetStartupType(ServiceStartMode.Automatic));
        }

        private void StartupManualClicked(object sender, EventArgs e)
        {
            PerformOperation(async x => await x.SetStartupType(ServiceStartMode.Manual));
        }

        private void StartupDisabledClick(object sender, EventArgs e)
        {
            PerformOperation(async x => await x.SetStartupType(ServiceStartMode.Disabled));
        }

        private async void Reload()
        {
            var systemServices = await Task.Run(() => ServiceController.GetServices().Where(service => service.DisplayName.IndexOf(filterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0));
            services.Clear();
            foreach (var model in systemServices.Select(service => new ServiceViewModel(service)).OrderBy(x => x.Name))
            {
                services.Add(model);
            }

            SetTitle();
        }

        private void SetTitle()
        {
            var titles = services.GroupBy(s => s.Status).Select(s => (string.IsNullOrWhiteSpace(s.Key) ? "Unknown" : s.Key) + ": " + s.Count());
            Text = "Total: " + services.Count + ", " + string.Join(", ", titles);
        }

        private void PerformOperation(Func<ServiceViewModel, Task> actionToPerform)
        {
            var selectedServices = servicesDataGridView.SelectedRows.OfType<DataGridViewRow>().Select(g => g.DataBoundItem).OfType<ServiceViewModel>().ToList();
            PerformOperation(actionToPerform, selectedServices);
        }

        private async void PerformOperation(Func<ServiceViewModel, Task> actionToPerform, List<ServiceViewModel> servicesToAction)
        {
            foreach (var model in servicesToAction)
            {
                try
                {
                    await actionToPerform(model);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"An Error Occured Interacting With Service: {model.Name}\nError Message: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
