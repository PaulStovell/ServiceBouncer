using Microsoft.Win32;
using ServiceBouncer.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceBouncer
{
    public partial class MainForm : Form
    {
        private readonly SortableBindingList<ServiceViewModel> services;
        private bool isActive;
        private string machineHostname;

        public MainForm()
        {
            InitializeComponent();
            isActive = true;
            machineHostname = Environment.MachineName;
            toolStripConnectToTextBox.Text = machineHostname;
            services = new SortableBindingList<ServiceViewModel>();

#if NET45
            //In NET45 startup type requires WMI, so it doesn't auto refresh
            dataGridStatupType.HeaderText = $"{dataGridStatupType.HeaderText} (No Auto Refresh)";
#endif
        }

        private void RefreshTimerTicked(object sender, EventArgs e)
        {
            if (isActive)
            {
                //Only refresh things which do not use WMI
#if NET45
                PerformBackgroundOperation(x => x.Refresh(ServiceViewModel.RefreshData.DisplayName, ServiceViewModel.RefreshData.ServiceName, ServiceViewModel.RefreshData.Status), services.ToList());
#elif NET461
                PerformBackgroundOperation(x => x.Refresh(ServiceViewModel.RefreshData.DisplayName, ServiceViewModel.RefreshData.ServiceName, ServiceViewModel.RefreshData.Status, ServiceViewModel.RefreshData.Startup), services.ToList());
#endif
                SetTitle();
            }
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            PerformAction(async () =>
            {
                CheckFrameworkValid();
                await Reload();
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

        private void RefreshClicked(object sender, EventArgs e)
        {
            PerformAction(async () => await Reload());
        }

        private void FilterBoxTextChanged(object sender, EventArgs e)
        {
            PopulateFilteredDataview();
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

        private void OpenServiceLocationClick(object sender, EventArgs e)
        {
            PerformOperation(async x => await x.OpenServiceInExplorer());
        }

        private void AssemblyInfoClick(object sender, EventArgs e)
        {
            PerformOperation(async x =>
            {
                var value = await x.GetAssemblyInfo();
                MessageBox.Show($"Service '{x.Name}' assembly info:\n{value}", "Assembly Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void InstallClicked(object sender, EventArgs e)
        {
            PerformAction(async () =>
            {
                new InstallationForm().ShowDialog();
                await Reload();
            });
        }

        private void ConnectButtonClick(object sender, EventArgs e)
        {
            PerformAction(async () =>
            {
                if ((string)toolStripConnectButton.Tag == "Connected") // If the machine name hasn't changed and the disconnect button is pressed disconnect
                {
                    Disconnect();
                }
                else // If the button tag is not set as "Connected" then connect.
                {
                    toolStripStatusLabel.Text = $"Connecting to: {machineHostname}";
                    machineHostname = toolStripConnectToTextBox.Text;
                    await Reload();
                    Connect();
                }
            });
        }

        private void ConnectTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            //Only listen for the Enter key
            if (e.KeyCode == Keys.Enter)
            {
                PerformAction(async () =>
                {
                    toolStripStatusLabel.Text = $"Connecting to {toolStripConnectToTextBox.Text}.";
                    machineHostname = toolStripConnectToTextBox.Text;
                    await Reload();
                });

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ConnectTextBoxChanged(object sender, EventArgs e)
        {
            if ((string)toolStripConnectButton.Tag == "Connected")
            {
                toolStripConnectButton.Text = "Reconnect";
                toolStripConnectButton.ToolTipText = "Reconnect";
                toolStripConnectButton.Image = Properties.Resources.Reconnect;
                toolStripConnectButton.Tag = "NewConnection";
            }
        }

#if NET45
        private void CheckFrameworkValid()
        {
            var validFramework = true;
            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                if (ndpKey == null)
                {
                    validFramework = false;
                }
                else
                {
                    var releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                    if (releaseKey < 378389)
                    {
                        validFramework = false;
                    }
                }
            }

            if (!validFramework)
            {
                MessageBox.Show("ServiceBouncer required .net 4.5 or higher to be installed", "Framework Upgrade Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
#elif NET461
        private void CheckFrameworkValid()
        {
            var validFramework = true;
            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                if (ndpKey == null)
                {
                    validFramework = false;
                }
                else
                {
                    var releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                    if (releaseKey < 394254)
                    {
                        validFramework = false;
                    }
                }
            }

            if (!validFramework)
            {
                MessageBox.Show("ServiceBouncer required .net 4.6.1 or higher to be installed", "Framework Upgrade Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
#endif
        private async Task Reload()
        {
            try
            {
                var systemServices = await Task.Run(() => ServiceController.GetServices(machineHostname));
                services.Clear();

                foreach (var model in systemServices.Select(service => new ServiceViewModel(service)))
                {
                    await model.Refresh(ServiceViewModel.RefreshData.DisplayName, ServiceViewModel.RefreshData.ServiceName, ServiceViewModel.RefreshData.Status, ServiceViewModel.RefreshData.Startup);
                    services.Add(model);
                }

                PopulateFilteredDataview();
                SetTitle();
            }
            catch (Exception e)
            {
                Disconnect();
                MessageBox.Show($"Unable to retrieve the services from {toolStripConnectToTextBox.Text}.\nMessage: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateFilteredDataview()
        {
            if (!string.IsNullOrWhiteSpace(toolStripFilterBox.Text))
            {
                servicesDataGridView.DataSource = services.Where(service => service.Name.IndexOf(toolStripFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0).OrderBy(x => x.Name).ToList();
            }
            else
            {
                servicesDataGridView.DataSource = services;
            }

            servicesDataGridView.Refresh();
        }

        private void Connect()
        {
            toolStripConnectButton.Text = "Disconnect";
            toolStripConnectButton.ToolTipText = "Disconnect";
            toolStripConnectButton.Tag = "Connected";
            toolStripConnectButton.Image = Properties.Resources.Connected;
            toolStripStatusLabel.Text = $"Connected to {machineHostname}.";
        }

        private void Disconnect()
        {
            toolStripConnectButton.Text = "Connect";
            toolStripConnectButton.ToolTipText = "Connect";
            toolStripConnectButton.Tag = "Disconnected";
            toolStripConnectButton.Image = Properties.Resources.Disconnected;
            toolStripStatusLabel.Text = "Disconnected";
            services.Clear();
            PopulateFilteredDataview();
        }

        private void SetTitle()
        {
            if (isActive)
            {
                if (services.Any())
                {
                    var titles = services.GroupBy(s => s.Status).Select(s => (string.IsNullOrWhiteSpace(s.Key) ? "Unknown" : s.Key) + ": " + s.Count());
                    Text = "Service Bouncer - Total: " + services.Count + ", " + string.Join(", ", titles);
                }
                else
                {
                    Text = "Service Bouncer - Total: 0";
                }
            }
            else
            {
                Text = "Service Bouncer";
            }
        }

        private void PerformOperation(Func<ServiceViewModel, Task> actionToPerform)
        {
            var selectedServices = servicesDataGridView.SelectedRows.OfType<DataGridViewRow>().Select(g => g.DataBoundItem).OfType<ServiceViewModel>().ToList();
            PerformOperation(actionToPerform, selectedServices);
        }

        private void PerformOperation(Func<ServiceViewModel, Task> actionToPerform, List<ServiceViewModel> servicesToAction)
        {
            PerformAction(async () =>
            {
                foreach (var model in servicesToAction)
                {
                    try
                    {
                        await actionToPerform(model);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"An error occured interacting with service '{model.Name}'\nMessage: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            });
        }

        private void PerformBackgroundOperation(Func<ServiceViewModel, Task> actionToPerform, List<ServiceViewModel> servicesToAction)
        {

            PerformAction(async () =>
            {
                foreach (var model in servicesToAction)
                {
                    try
                    {
                        await actionToPerform(model);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"An error occured interacting with service '{model.Name}'\nMessage: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }, false);
        }

        private async void PerformAction(Func<Task> actionToPerform, bool disableToolstrip = true)
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
