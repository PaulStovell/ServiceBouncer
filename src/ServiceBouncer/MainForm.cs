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
        private readonly List<ServiceViewModel> services;
        private bool isActive;
        private string machineHostname;

        public MainForm()
        {
            InitializeComponent();
            isActive = true;
            machineHostname = Environment.MachineName;
            toolStripConnectToTextBox.Text = machineHostname;
            services = new List<ServiceViewModel>();
#if NET45
            //In NET45 startup type requires WMI, so it doesn't auto refresh
            dataGridStatupType.HeaderText = $"{dataGridStatupType.HeaderText} (No Auto Refresh)";
#endif
        }

        private async void RefreshTimerTicked(object sender, EventArgs e)
        {
            if (isActive)
            {
#if NET45
                //Only refresh things which do not use WMI
                await PerformBackgroundOperation(x => x.Refresh(ServiceViewModel.RefreshData.DisplayName, ServiceViewModel.RefreshData.ServiceName, ServiceViewModel.RefreshData.Status));
#elif NET461
                await PerformBackgroundOperation(x => x.Refresh(ServiceViewModel.RefreshData.DisplayName, ServiceViewModel.RefreshData.ServiceName, ServiceViewModel.RefreshData.Status, ServiceViewModel.RefreshData.Startup));
#endif
                SetTitle();
            }
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            await PerformAction(async () =>
            {
                FrameworkChecker.CheckFrameworkValid();
                await Connect();
                dataGridView.Sort(dataGridName, ListSortDirection.Ascending);
            });
        }

        private void FormActivated(object sender, EventArgs e)
        {
            isActive = true;
            SetTitle();
        }

        private void FormDeactivated(object sender, EventArgs e)
        {
            isActive = false;
            SetTitle();
        }

        private async void RefreshClicked(object sender, EventArgs e)
        {
            await PerformAction(async () => await Reload());
        }

        private void FilterBoxTextChanged(object sender, EventArgs e)
        {
            PopulateFilteredDataview();
        }

        private async void StartClicked(object sender, EventArgs e)
        {
            await PerformOperation(async x => await x.Start());
        }

        private async void RestartClicked(object sender, EventArgs e)
        {
            await PerformOperation(async x => await x.Restart());
        }

        private async void StopClicked(object sender, EventArgs e)
        {
            await PerformOperation(async x => await x.Stop());
        }

        private async void PauseClicked(object sender, EventArgs e)
        {
            await PerformOperation(async x => await x.Pause());
        }

        private async void DeleteClicked(object sender, EventArgs e)
        {
            await PerformOperation(async x =>
            {
                if (MessageBox.Show($@"Are you sure you want to delete the '{x.Name}'", @"Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    await x.Delete();
                    Thread.Sleep(500);
                    await Reload();
                }
            });
        }

        private async void StartupAutomaticClicked(object sender, EventArgs e)
        {
            await PerformOperation(async x => await x.SetStartupType(ServiceStartMode.Automatic));
        }

        private async void StartupManualClicked(object sender, EventArgs e)
        {
            await PerformOperation(async x => await x.SetStartupType(ServiceStartMode.Manual));
        }

        private async void StartupDisabledClick(object sender, EventArgs e)
        {
            await PerformOperation(async x => await x.SetStartupType(ServiceStartMode.Disabled));
        }

        private async void OpenServiceLocationClick(object sender, EventArgs e)
        {
            await PerformOperation(async x => await x.OpenServiceInExplorer());
        }

        private async void AssemblyInfoClick(object sender, EventArgs e)
        {
            await PerformOperation(async x =>
            {
                var value = await x.GetAssemblyInfo();
                MessageBox.Show($@"Service '{x.Name}' assembly info:\n{value}", @"Assembly Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private async void InstallClicked(object sender, EventArgs e)
        {
            await PerformAction(async () =>
            {
                new InstallationForm().ShowDialog();
                await Reload();
            });
        }

        private async void ConnectButtonClick(object sender, EventArgs e)
        {
            await PerformAction(async () =>
            {
                if ((string)toolStripConnectButton.Tag == @"Connected")
                {
                    Disconnect();
                }
                else
                {
                    await Connect();
                }
            });
        }

        private async void ConnectTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await PerformAction(async () => { await Connect(); });
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private async Task<bool> Reload()
        {
            try
            {
                var systemServices = await Task.Run(() => ServiceController.GetServices(machineHostname));
                services.Clear();

                foreach (var model in systemServices.Select(service => new ServiceViewModel(service)))
                {
                    services.Add(model);
                }

                await PerformBackgroundOperation(x => x.Refresh(ServiceViewModel.RefreshData.DisplayName, ServiceViewModel.RefreshData.ServiceName, ServiceViewModel.RefreshData.Status, ServiceViewModel.RefreshData.Startup));
                PopulateFilteredDataview();
                SetTitle();
                return true;
            }
            catch (Exception e)
            {
                Disconnect();
                MessageBox.Show($@"Unable to retrieve the services from {toolStripConnectToTextBox.Text}.\nMessage: {e.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void PopulateFilteredDataview()
        {
            var sortColumn = dataGridView.SortedColumn;
            var sortOrder = ListSortDirection.Ascending;
            if (dataGridView.SortOrder == SortOrder.Descending) sortOrder = ListSortDirection.Descending;

            if (!string.IsNullOrWhiteSpace(toolStripFilterBox.Text))
            {
                dataGridView.DataSource = new SortableBindingList<ServiceViewModel>(services.Where(service => service.Name.IndexOf(toolStripFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList());
            }
            else
            {
                dataGridView.DataSource = new SortableBindingList<ServiceViewModel>(services);
            }

            dataGridView.Refresh();
            if (sortColumn != null)
            {
                dataGridView.Sort(sortColumn, sortOrder);
            }
        }

        private async Task Connect()
        {
            machineHostname = toolStripConnectToTextBox.Text;
            toolStripStatusLabel.Text = $@"Connecting to {machineHostname}.";

            if (await Reload())
            {
                toolStripConnectButton.Text = @"Disconnect";
                toolStripConnectButton.ToolTipText = @"Disconnect";
                toolStripConnectButton.Tag = @"Connected";
                toolStripConnectButton.Image = Properties.Resources.Disconnect;

                var backgroundRefreshSeconds = machineHostname == Environment.MachineName ? 1 : 30;
                var backgroundRefreshTimeText = backgroundRefreshSeconds == 1 ? "1 second" : $"{backgroundRefreshSeconds} seconds";
                refreshTimer.Enabled = true;
                refreshTimer.Interval = backgroundRefreshSeconds * 1000;
                toolStripStatusLabel.Text = $@"Connected to {machineHostname}. - Background refresh every {backgroundRefreshTimeText}";

                foreach (ToolStripItem toolStripItem in toolStrip.Items)
                {
                    toolStripItem.Visible = true;
                }

                toolStripConnectToTextBox.Visible = false;
            }
        }

        private void Disconnect()
        {
            toolStripConnectButton.Text = @"Connect";
            toolStripConnectButton.ToolTipText = @"Connect";
            toolStripConnectButton.Tag = @"Disconnected";
            toolStripConnectButton.Image = Properties.Resources.Connect;
            toolStripStatusLabel.Text = @"Disconnected";
            services.Clear();
            PopulateFilteredDataview();

            foreach (ToolStripItem toolStripItem in toolStrip.Items)
            {
                toolStripItem.Visible = false;
            }

            toolStripConnectToTextBox.Visible = true;
            toolStripConnectButton.Visible = true;
            refreshTimer.Enabled = false;
        }

        private void SetTitle()
        {
            if (isActive && services.Any())
            {
                var titles = services.GroupBy(s => s.Status).Select(s => (string.IsNullOrWhiteSpace(s.Key) ? "Unknown" : s.Key) + ": " + s.Count());
                Text = $@"Service Bouncer - Total: {services.Count}, {string.Join(", ", titles)}";
            }
            else
            {
                Text = @"Service Bouncer";
            }
        }

        private async Task PerformOperation(Func<ServiceViewModel, Task> actionToPerform)
        {
            var selectedServices = dataGridView.SelectedRows.OfType<DataGridViewRow>().Select(g => g.DataBoundItem).OfType<ServiceViewModel>().ToList();
            await PerformOperation(actionToPerform, selectedServices, true);
        }

        private async Task PerformBackgroundOperation(Func<ServiceViewModel, Task> actionToPerform)
        {
            await PerformOperation(actionToPerform, services.ToList(), false);
        }

        private async Task PerformOperation(Func<ServiceViewModel, Task> actionToPerform, IReadOnlyCollection<ServiceViewModel> servicesToAction, bool disableToolstrip)
        {
            await PerformAction(async () =>
            {
                async Task WrappedFunction(ServiceViewModel model)
                {
                    try
                    {
                        await actionToPerform(model);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($@"An error occured interacting with service '{model.Name}'\nMessage: {e.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                var tasks = new List<Task>();
                foreach (var model in servicesToAction)
                {
                    tasks.Add(WrappedFunction(model));
                }

                await Task.WhenAll(tasks);
            }, disableToolstrip);
        }


        private async Task PerformAction(Func<Task> actionToPerform, bool disableToolstrip = true)
        {
            if (disableToolstrip)
            {
                foreach (ToolStripItem toolStripItem in toolStrip.Items)
                {
                    toolStripItem.Enabled = false;
                }
            }

            await actionToPerform();

            if (disableToolstrip)
            {
                foreach (ToolStripItem toolStripItem in toolStrip.Items)
                {
                    toolStripItem.Enabled = true;
                }
            }
        }
    }
}
