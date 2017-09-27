using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServiceBouncer
{
    public partial class InstallationForm : Form
    {
        private HashSet<string> installedServiceHashSets = new HashSet<string>();
        private ReadOnlyCollection<string> installedServicesCollection;
        public ReadOnlyCollection<string> InstalledServices
        {
            get
            {
                if (installedServicesCollection != null && installedServicesCollection.Count == installedServiceHashSets.Count)
                    return installedServicesCollection;

                installedServicesCollection = new ReadOnlyCollection<string>(installedServiceHashSets.ToList());
                return installedServicesCollection;
            }
        }

        public InstallationForm()
        {
            InitializeComponent();
            cmbBxOptionStart.SelectedItem = "demand";
        }

        private void btnSelectService_Click(object sender, EventArgs e)
        {
            if (installSvcFileSelectionDialog.ShowDialog() == DialogResult.OK)
            {
                string winSvcExeFileName = installSvcFileSelectionDialog.SafeFileName.Replace(".exe", "");
                txtBxDisplayName.Text = winSvcExeFileName;
                txtBxServiceName.Text = winSvcExeFileName;
                txtBxServiceExePath.Text = installSvcFileSelectionDialog.FileName;
                txtBxServiceName.Focus();
                txtBxServiceName.SelectAll();

                btnInstall.Enabled = true;
                btnInstall.Text = "Install";
                lblProcessResult.Text = "";
            }
        }
        private bool m_installationInProgress = false;

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (m_installationInProgress)
            {
                MessageBox.Show("One installation is in progress. Please wait until completion.", "One installation is in progress");
                return;
            }

            m_installationInProgress = true;

            SetUIForInstallationPhase();
            lblProcessResult.Text = "Installing...";
            lblProcessResult.ForeColor = Color.Orange;
            lblProcessResult.Refresh();
            btnInstall.Text = "Installing...";
            btnInstall.Refresh();

            StringBuilder installCmdBuilder = new StringBuilder();
            installCmdBuilder.Append("create");
            installCmdBuilder.AppendFormat("  \"{0}\"", txtBxServiceName.Text);
            installCmdBuilder.AppendFormat("  start=  {0}", cmbBxOptionStart.SelectedItem);
            installCmdBuilder.AppendFormat("  binPath=  \"{0}\"", txtBxServiceExePath.Text);
            installCmdBuilder.AppendFormat("  DisplayName=  \"{0}\"", txtBxDisplayName.Text);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "sc.exe";
            startInfo.Arguments = installCmdBuilder.ToString();
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;

            new Thread(() =>
            {
                try
                {
                    using (Process installationProcess = Process.Start(startInfo))
                    {
                        installationProcess.OutputDataReceived += InstallationProcess_OutputDataReceived;
                        installationProcess.BeginOutputReadLine();
                        installationProcess.WaitForExit();
                    }
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
                finally
                {
                    m_installationInProgress = false;
                    SetUIForInstallationPhase();
                    btnInstall.Invoke(new MethodInvoker(() => { btnInstall.Text = "Install"; }));
                }
            }).Start();
        }

        private void SetUIForInstallationPhase()
        {
            Invoke(new MethodInvoker(() =>
            {
                Enabled = !m_installationInProgress;
                Refresh();
            }));

            txtBxServiceExePath.Invoke(new MethodInvoker(() =>
            {
                txtBxServiceExePath.Enabled = false; //everytime must be false.
                txtBxServiceExePath.Refresh();
            }));
        }

        private void InstallationProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            lblProcessResult.Invoke(new MethodInvoker(() =>
            {
                if (string.IsNullOrEmpty(e.Data))
                    return;

                if (lblProcessResult.Text == "Installing...")
                    lblProcessResult.Text = "";

                string output = e.Data;
                lblProcessResult.Text += output;

                if (lblProcessResult.Text.IndexOf("failed", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    lblProcessResult.ForeColor = Color.Red;
                }
                else
                {
                    lblProcessResult.ForeColor = Color.Green;
                    installedServiceHashSets.Add(txtBxDisplayName.Text);
                }

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
