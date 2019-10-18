using CredentialManagement;
using ServiceBouncer.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DialogResult = System.Windows.Forms.DialogResult;

namespace ServiceBouncer
{
    public partial class MainForm : Form
    {
        private readonly List<ServiceViewModel> services;
        private string machineHostname;
        private int backgroundRefreshSeconds;
        private DateTime? machineLockedTime;
        private DateTime? appDeactivatedTime;
        private bool IsActive => machineLockedTime == null || appDeactivatedTime == null;

        public MainForm(string machine)
        {
            InitializeComponent();
            backgroundRefreshSeconds = 1;
            machineHostname = machine;
            toolStripConnectToTextBox.Text = machineHostname;
            services = new List<ServiceViewModel>();
            Microsoft.Win32.SystemEvents.SessionSwitch += SessionSwitch;

#if NET45
            //In NET45 startup type requires WMI, so it doesn't auto refresh
            dataGridStatupType.HeaderText = $@"{dataGridStatupType.HeaderText} (No Auto Refresh)";
#endif
        }

        private void AppTerminationTimerTick(object sender, EventArgs e)
        {
            if (machineLockedTime.HasValue && DateTime.Now.Subtract(machineLockedTime.Value) > TimeSpan.FromMinutes(30))
            {
                Application.Exit();
            }

            if (appDeactivatedTime.HasValue && DateTime.Now.Subtract(appDeactivatedTime.Value) > TimeSpan.FromMinutes(60))
            {
                Application.Exit();
            }
        }

        private async void RefreshTimerTicked(object sender, EventArgs e)
        {
            if (IsActive)
            {
#if NET45
                //Only refresh things which do not use WMI (i.e. Startup Type, Description, and Log On As are not refreshed)
                await PerformBackgroundOperation(x => x.Refresh(ServiceViewModel.RefreshData.DisplayName, ServiceViewModel.RefreshData.ServiceName, ServiceViewModel.RefreshData.Status));
#elif NET461
                //Only refresh things which do not use WMI (i.e. Description and Log On As are not refreshed)
                await PerformBackgroundOperation(x => x.Refresh(ServiceViewModel.RefreshData.DisplayName, ServiceViewModel.RefreshData.ServiceName, ServiceViewModel.RefreshData.Status, ServiceViewModel.RefreshData.Startup));
#endif
                SetTitle();
            }
        }

        // PC Locked
        private void SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == Microsoft.Win32.SessionSwitchReason.SessionLock || e.Reason == Microsoft.Win32.SessionSwitchReason.RemoteDisconnect)
            {
                machineLockedTime = DateTime.Now;
            }
            else if (e.Reason == Microsoft.Win32.SessionSwitchReason.SessionUnlock || e.Reason == Microsoft.Win32.SessionSwitchReason.RemoteConnect)
            {
                machineLockedTime = null;
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

            toolStripFilterBox.Focus();
        }

        private void FormActivated(object sender, EventArgs e)
        {
            appDeactivatedTime = null;
            SetTitle();
            SetConnectedStatusBar();
        }

        private void FormDeactivated(object sender, EventArgs e)
        {
            appDeactivatedTime = DateTime.Now;
            SetTitle();
            SetConnectedStatusBar();
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
            await PerformOperationWithCheck(s =>
                {
                    if (s.Count > 1)
                        return MessageBox.Show($@"You have selected {s.Count} services(s) to delete, are you sure you want to delete them all?", @"Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes;

                    var service = s.FirstOrDefault();
                    if (service != null)
                        return MessageBox.Show($@"Are you sure you want to delete the '{service.Name}'", @"Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes;

                    return false;
                },
                async x =>
                {
                    await x.Delete();
                    Thread.Sleep(500);
                    await Reload();
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
            await PerformOperationWithCheck(s =>
                {
                    if (s.Count > 1)
                    {
                        MessageBox.Show(@"Please only select 1 service to view in explorer", @"View In Explorer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    return true;
                },
                async x => { await x.OpenServiceInExplorer(); });
        }

        private async void AssemblyInfoClick(object sender, EventArgs e)
        {
            await PerformOperationWithCheck(s =>
            {
                if (s.Count > 1)
                {
                    MessageBox.Show(@"Please only select 1 service to view assembly info", @"Assembly Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            },
            async x =>
            {
                var value = await x.GetAssemblyInfo();
                MessageBox.Show($@"Service '{x.Name}' assembly info:{Environment.NewLine}{value}", @"Assembly Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                await PerformBackgroundOperation(x => x.Refresh(
                    ServiceViewModel.RefreshData.DisplayName,
                    ServiceViewModel.RefreshData.ServiceName,
                    ServiceViewModel.RefreshData.Description,
                    ServiceViewModel.RefreshData.Status,
                    ServiceViewModel.RefreshData.Startup,
                    ServiceViewModel.RefreshData.LogOnAs));

                PopulateFilteredDataview();
                SetTitle();
                return true;
            }
            catch (Exception e) when (ExceptionIsAccessDenied(e))
            {
                var prompt = new VistaPrompt
                {
                    Title = "Access denied",
                    Message = $"Enter administrator credentials for {machineHostname}"
                };

                if (prompt.ShowDialog() == CredentialManagement.DialogResult.OK)
                {
                    StartNewProcess(prompt);
                    return false;
                }

                Disconnect();
                MessageBox.Show($@"Unable to retrieve the services from {toolStripConnectToTextBox.Text}.{Environment.NewLine}Message: {e.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception e)
            {
                Disconnect();
                MessageBox.Show($@"Unable to retrieve the services from {toolStripConnectToTextBox.Text}.{Environment.NewLine}Message: {e.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void StartNewProcess(BaseCredentialsPrompt promptResult)
        {
            string username, domain;

            var splitCheck = promptResult.Username.Split('\\');
            if (splitCheck.Length > 1)
            {
                username = splitCheck[1];
                domain = splitCheck[0];
            }
            else
            {
                username = splitCheck[0];
                domain = null;
            }

            var commandName = $"{Process.GetCurrentProcess().MainModule.FileName} --machine={machineHostname}";
            RunAs.StartProcess(username, domain, promptResult.Password, RunAs.LogonFlags.NetworkCredentialsOnly, null, commandName, RunAs.CreationFlags.NewProcessGroup, null);

            Application.Exit();
        }

        private static bool ExceptionIsAccessDenied(Exception e)
        {
            var baseException = e.GetBaseException();
            if (baseException is Win32Exception nativeException)
            {
                if (nativeException.NativeErrorCode == 5) // ERROR_ACCESS_DENIED
                {
                    return true;
                }
            }
            return false;
        }

        private void PopulateFilteredDataview()
        {
            var sortColumn = dataGridView.SortedColumn;
            var sortOrder = ListSortDirection.Ascending;
            if (dataGridView.SortOrder == SortOrder.Descending) sortOrder = ListSortDirection.Descending;

            var searchTerm = toolStripFilterBox.Text;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var filteredServices = services
                    .Where(service =>
                        service.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        (service.Description ?? string.Empty).IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                dataGridView.DataSource = new SortableBindingList<ServiceViewModel>(filteredServices);
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

                backgroundRefreshSeconds = EnvHelper.IsLocalMachine(machineHostname) ? 1 : 30;

                refreshTimer.Enabled = true;
                refreshTimer.Interval = backgroundRefreshSeconds * 1000;

                SetConnectedStatusBar();

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
            if (IsActive && services.Any())
            {
                var titles = services.GroupBy(s => s.Status).Select(s => (string.IsNullOrWhiteSpace(s.Key) ? "Unknown" : s.Key) + ": " + s.Count());
                Text = $@"Service Bouncer - Total: {services.Count}, {string.Join(", ", titles)}";
            }
            else
            {
                Text = @"Service Bouncer";
            }
        }

        private void SetConnectedStatusBar()
        {
            if (IsActive)
            {
                var backgroundRefreshTimeText = backgroundRefreshSeconds == 1 ? "1 second" : $"{backgroundRefreshSeconds} seconds";
                toolStripStatusLabel.Text = $@"Connected to {machineHostname}. - Background refresh every {backgroundRefreshTimeText}.";
            }
            else
            {
                toolStripStatusLabel.Text = $@"Connected to {machineHostname}. - Background refresh disabled";
            }
        }

        private async Task PerformOperationWithCheck(Func<IReadOnlyCollection<ServiceViewModel>, bool> check, Func<ServiceViewModel, Task> actionToPerform)
        {
            var selectedServices = dataGridView.SelectedRows.OfType<DataGridViewRow>().Select(g => g.DataBoundItem).OfType<ServiceViewModel>().ToList();
            await PerformOperation(check, actionToPerform, selectedServices, true);
        }

        private async Task PerformBackgroundOperationWithCheck(Func<IReadOnlyCollection<ServiceViewModel>, bool> check, Func<ServiceViewModel, Task> actionToPerform)
        {
            await PerformOperation(check, actionToPerform, services.ToList(), false);
        }

        private async Task PerformOperation(Func<ServiceViewModel, Task> actionToPerform)
        {
            await PerformOperationWithCheck(i => true, actionToPerform);
        }

        private async Task PerformBackgroundOperation(Func<ServiceViewModel, Task> actionToPerform)
        {
            await PerformBackgroundOperationWithCheck(i => true, actionToPerform);
        }

        private async Task PerformOperation(Func<IReadOnlyCollection<ServiceViewModel>, bool> check, Func<ServiceViewModel, Task> actionToPerform, IReadOnlyCollection<ServiceViewModel> servicesToAction, bool disableToolstrip)
        {
            if (check(servicesToAction))
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
                            MessageBox.Show($@"An error occured interacting with service '{model.Name}'{Environment.NewLine}Message: {e.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
