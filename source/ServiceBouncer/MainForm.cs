using ServiceBouncer.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceBouncer
{

    public partial class MainForm : Form
    {
        private readonly BindingList<ServiceViewModel> services = new SortableBindingList<ServiceViewModel>();

        public MainForm()
        {
            InitializeComponent();
            serviceViewModelBindingSource.DataSource = services;
        }

        private void RefreshTimerTicked(object sender, EventArgs e)
        {
            PerformOperation(x => x.Refresh(), services.ToList());

            var titles = services.GroupBy(s => s.Status).Select(s => (string.IsNullOrWhiteSpace(s.Key) ? "Unknown" : s.Key) + ": " + s.Count());
            Text = string.Join(", ", titles);
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
            PerformOperation(x => x.Start());
        }

        private void RestartClicked(object sender, EventArgs e)
        {
            PerformOperation(x => x.Restart());
        }

        private void StopClicked(object sender, EventArgs e)
        {
            PerformOperation(x => x.Stop());
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            PerformOperation(x =>
            {
                if (MessageBox.Show($"Are you sure you want to delete the '{x.Name}'", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    x.Delete();
                }
            });

            Reload();
        }

        private void StartupAutomaticClicked(object sender, EventArgs e)
        {
            PerformOperation(x => x.SetStartupType(ServiceStartMode.Automatic));
        }

        private void StartupManualClicked(object sender, EventArgs e)
        {
            PerformOperation(x => x.SetStartupType(ServiceStartMode.Manual));
        }

        private void StartupDisabledClick(object sender, EventArgs e)
        {
            PerformOperation(x => x.SetStartupType(ServiceStartMode.Disabled));
        }

        private void Reload()
        {
            PerformOperation(async () =>
            {
                var systemServices = await Task.Run(() => ServiceController.GetServices().Where(service => service.DisplayName.IndexOf(filterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0));
                services.Clear();
                foreach (var model in systemServices.Select(service => new ServiceViewModel(service)).OrderBy(x => x.Name))
                {
                    services.Add(model);
                }
            });
        }

        private void PerformOperation(Action<ServiceViewModel> actionToPerform)
        {
            PerformOperation(() =>
            {
                var selectedServices = servicesDataGridView.SelectedRows.OfType<DataGridViewRow>().Select(g => g.DataBoundItem).OfType<ServiceViewModel>().ToList();
                PerformOperation(actionToPerform, selectedServices);
            });
        }

        private async void PerformOperation(Action<ServiceViewModel> actionToPerform, List<ServiceViewModel> servicesToAction)
        {
            foreach (var model in servicesToAction)
            {
                try
                {
                    await Task.Run(() => actionToPerform(model));
                }
                catch (Exception e)
                {
                    MessageBox.Show($"An Error Occured\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PerformOperation(Action actionToPerform)
        {
            contextMenuStrip1.Enabled = false;
            toolStrip1.Enabled = false;
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Enabled = false;
            }

            actionToPerform();

            contextMenuStrip1.Enabled = true;
            toolStrip1.Enabled = true;
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Enabled = true;
            }
        }
    }
}
