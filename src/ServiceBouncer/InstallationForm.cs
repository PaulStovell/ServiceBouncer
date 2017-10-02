using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceBouncer
{
    public partial class InstallationForm : Form
    {
        private bool m_installationInProgress;

        public InstallationForm()
        {
            InitializeComponent();
        }

        private void btnSelectService_Click(object sender, EventArgs e)
        {
            if (installSvcFileSelectionDialog.ShowDialog() == DialogResult.OK)
            {
                txtBxServiceExePath.Text = installSvcFileSelectionDialog.FileName;

                if (installSvcFileSelectionDialog.SafeFileName != null)
                {
                    var winSvcExeFileName = installSvcFileSelectionDialog.SafeFileName.Replace(".exe", "");
                    txtBxDisplayName.Text = winSvcExeFileName;
                    txtBxServiceName.Text = winSvcExeFileName;
                }
                else
                {
                    txtBxDisplayName.Text = installSvcFileSelectionDialog.FileName;
                    txtBxServiceName.Text = installSvcFileSelectionDialog.FileName;
                }

                txtBxDisplayName.Enabled = true;
                txtBxServiceName.Enabled = true;

                cmbBxOptionStart.SelectedItem = "Manual";

                btnInstall.Enabled = true;
                btnInstall.Text = "Install";
                btnInstall.Focus();

                lblProcessResult.Text = "";
            }
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            if (m_installationInProgress)
            {
                MessageBox.Show("One installation is in progress. Please wait until completion.", "One installation is in progress");
                return;
            }

            m_installationInProgress = true;

            Enabled = false;
            Refresh();
            lblProcessResult.Text = "Installing...";
            lblProcessResult.ForeColor = Color.Orange;
            lblProcessResult.Refresh();
            btnInstall.Text = "Installing...";
            btnInstall.Refresh();

            txtBxServiceExePath.Enabled = false;
            txtBxServiceExePath.Refresh();

            string startMode;
            switch (cmbBxOptionStart.SelectedItem)
            {
                case "Automatic":
                    startMode = "auto";
                    break;
                case "Manual":
                    startMode = "demand";
                    break;
                default:
                    startMode = "disabled";
                    break;
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = "sc.exe",
                Arguments = $"create \"{txtBxServiceName.Text}\" start={startMode} binPath=\"{txtBxServiceExePath.Text}\" DisplayName=\"{txtBxDisplayName.Text}\"",
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            try
            {
                await Task.Run(() =>
                {
                    using (var installationProcess = Process.Start(startInfo))
                    {
                        installationProcess.OutputDataReceived += InstallationProcess_OutputDataReceived;
                        installationProcess.BeginOutputReadLine();
                        installationProcess.WaitForExit();
                    }

                });
            }
            catch (Exception ex)
            {
                lblProcessResult.Invoke(new MethodInvoker(() =>
                {
                    lblProcessResult.ForeColor = Color.Red;
                    lblProcessResult.Text = "An error occurred during installation.";
                }));
                MessageBox.Show(ex.Message, "An error occurred during installation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            m_installationInProgress = false;
            Enabled = true;
            Refresh();
            btnInstall.Text = "Install";
        }

        private void InstallationProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            lblProcessResult.Invoke(new MethodInvoker(() =>
            {
                if (string.IsNullOrEmpty(e.Data))
                    return;

                lblProcessResult.Text += e.Data;
                lblProcessResult.ForeColor = lblProcessResult.Text.IndexOf("failed", StringComparison.OrdinalIgnoreCase) > -1 ? Color.Red : Color.Green;
                lblProcessResult.Refresh();
            }));
        }

        private void InstallationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_installationInProgress)
            {
                MessageBox.Show("One installation is in progress. Please wait until completion.", "One installation is in progress");
                e.Cancel = true;
            }
        }
    }
}
