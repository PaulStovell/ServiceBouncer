using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;
using ServiceBouncer.ComponentModel;

namespace ServiceBouncer
{

    public partial class MainForm : Form
    {
        readonly BindingList<ServiceViewModel> services = new SortableBindingList<ServiceViewModel>();

        public MainForm()
        {
            InitializeComponent();
            serviceViewModelBindingSource.DataSource = services;
        }

        private void RefreshTimerTicked(object sender, EventArgs e)
        {
            foreach (var item in services)
            {
                item.Refresh();
            }

            var titles = services.GroupBy(s => s.Status).Select(s => s.Key + ": " + s.Count());
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

        private void Reload()
        {
            services.Clear();
            var systemServices = ServiceController.GetServices().Where(service => service.DisplayName.IndexOf(filterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            foreach (var model in systemServices.Select(service => new ServiceViewModel(service)))
            {
                services.Add(model);
            }

            servicesDataGridView.Sort(servicesDataGridView.Columns[0], ListSortDirection.Ascending);
        }

        private void StartClicked(object sender, EventArgs e)
        {
            var servicesToStart = GetSelectedServices();
            foreach (var model in servicesToStart)
            {
                model.Start();
            }
        }

        private void RestartClicked(object sender, EventArgs e)
        {
            var servicesToRestart = GetSelectedServices();
            foreach (var model in servicesToRestart)
            {
                model.Restart();
            }
        }

        private void StopClicked(object sender, EventArgs e)
        {
            var servicesToStop = GetSelectedServices();
            foreach (var model in servicesToStop)
            {
                model.Stop();
            }
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            var servicesToDelete = GetSelectedServices();
            if (
                MessageBox.Show("Are you sure you want to delete the following services: " +
                    string.Concat(servicesToDelete.Select(s => Environment.NewLine + s.Name)),
                    "Confirm delete", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                foreach (var service in servicesToDelete)
                {
                    Process.Start("sc.exe", "delete \"" + service.ServiceName + "\"");
                }
            }
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var servicesToSetStartup = GetSelectedServices();
            foreach (var model in servicesToSetStartup)
            {
                model.StartupType=ServiceStartMode.Automatic.ToString();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var servicesToSetStartup = GetSelectedServices();
            foreach (var model in servicesToSetStartup)
            {
                model.StartupType = ServiceStartMode.Manual.ToString();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var servicesToSetStartup = GetSelectedServices();
            foreach (var model in servicesToSetStartup)
            {
                model.StartupType = ServiceStartMode.Disabled.ToString();
            }
        }

        private IEnumerable<ServiceViewModel> GetSelectedServices()
        {
            return servicesDataGridView.SelectedRows.OfType<DataGridViewRow>().Select(g => g.DataBoundItem).OfType<ServiceViewModel>().ToList();
        }
    }
}
