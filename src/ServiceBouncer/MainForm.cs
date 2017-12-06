using Microsoft.Win32;
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
        private string machineHostname;

        public MainForm()
        {
            isActive = true;
            machineHostname = Environment.MachineName;
            InitializeComponent();
            serviceViewModelBindingSource.DataSource = services;
            toolStripConnectToTextBox.Text = machineHostname;

#if NET45
            dataGridStatupType.HeaderText = $"{dataGridStatupType.HeaderText} (No Auto Refresh)";
#endif
        }

        private void RefreshTimerTicked(object sender, EventArgs e)
        {
            if (isActive)
            {
                PerformOperation(x => x.Refresh(true), services.ToList());
                SetTitle();
            }
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            Reload();

            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                var releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                if (releaseKey < 394254)
                {
                    MessageBox.Show("ServiceBouncer required .net 4.6.1 or higher to be installed", "Framework Upgrade Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
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
            new InstallationForm().ShowDialog();
            Reload();
        }

        private void ConnectButtonClick(object sender, EventArgs e)
        {
            if ((string)toolStripConnectButton.Tag == "Connected") // If the machine name hasn't changed and the disconnect button is pressed disconnect
            {
                Disconnect();
            }
            else // If the button tag is not set as "Connected" then connect.
            {
                // Disable the button and the textbox so that you cannot create multiple requests at the time.
                toolStripConnectToTextBox.Enabled = false;
                toolStripConnectButton.Enabled = false;
                servicesDataGridView.Enabled = false;
                toolStripStatusLabel.Text = $"Connecting to: {machineHostname}";

                machineHostname = toolStripConnectToTextBox.Text;
                Reload();
            }
        }

        private void ConnectTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            //Only listen for the Enter key
            if (e.KeyCode == Keys.Enter)
            {
                // Disable the button and the textbox so that you cannot create multiple requests at the time.
                toolStripConnectToTextBox.Enabled = false;
                toolStripConnectButton.Enabled = false;
                servicesDataGridView.Enabled = false;
                toolStripStatusLabel.Text = $"Connecting to {toolStripConnectToTextBox.Text}.";

                machineHostname = toolStripConnectToTextBox.Text;
                Reload();

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

        private async void Reload()
        {
            try
            {
                var systemServices = await Task.Run(() => ServiceController.GetServices(machineHostname).Where(service => service.DisplayName.IndexOf(toolStripFilterBox.Text, StringComparison.OrdinalIgnoreCase) >= 0));
                Connect();
                services.Clear();

                foreach (var model in systemServices.Select(service => new ServiceViewModel(service)).OrderBy(x => x.Name))
                {
                    services.Add(model);
                }

                SetTitle();
            }
            catch (Exception e)
            {
                Disconnect();
                MessageBox.Show($"Unable to retrieve the services from {toolStripConnectToTextBox.Text}.\nMessage: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Connect()
        {
            toolStripConnectButton.Text = "Disconnect";
            toolStripConnectButton.ToolTipText = "Disconnect";
            toolStripConnectButton.Tag = "Connected";
            toolStripConnectButton.Enabled = true;
            toolStripConnectButton.Image = Properties.Resources.Connected;
            servicesDataGridView.Enabled = true;
            toolStripConnectToTextBox.Enabled = true;
            toolStripStatusLabel.Text = $"Connected to {machineHostname}.";
        }

        private void Disconnect()
        {
            toolStripConnectButton.Text = "Connect";
            toolStripConnectButton.ToolTipText = "Connect";
            toolStripConnectButton.Tag = "Disconnected";
            toolStripConnectButton.Image = Properties.Resources.Disconnected;
            toolStripConnectButton.Enabled = true;
            servicesDataGridView.Enabled = true;
            toolStripConnectToTextBox.Enabled = true;
            toolStripStatusLabel.Text = "Disconnected";
            services.Clear();
        }

        private void SetTitle()
        {
            if (services.Any())
            {
                var titles = services.GroupBy(s => s.Status).Select(s => (string.IsNullOrWhiteSpace(s.Key) ? "Unknown" : s.Key) + ": " + s.Count());
                Text = "Total: " + services.Count + ", " + string.Join(", ", titles);
            }
            else
            {
                Text = "Total: 0";
            }
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
                    MessageBox.Show($"An error occured interacting with service '{model.Name}'\nMessage: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
