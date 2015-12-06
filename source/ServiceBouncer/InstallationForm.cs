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
        private HashSet<string> m_installedServiceHashSets = new HashSet<string>();
        private ReadOnlyCollection<string> m_installedServicesCollection;
        public ReadOnlyCollection<string> InstalledServices
        {
            get
            {
                if (this.m_installedServicesCollection != null && this.m_installedServicesCollection.Count == this.m_installedServiceHashSets.Count)
                    return this.m_installedServicesCollection;

                this.m_installedServicesCollection = new ReadOnlyCollection<string>(m_installedServiceHashSets.ToList());
                return this.m_installedServicesCollection;
            }
        }

        public InstallationForm()
        {
            InitializeComponent();
            this.cmbBxOptionStart.SelectedItem = "demand";
        }

        private void btnSelectService_Click(object sender, EventArgs e)
        {
            if (this.installSvcFileSelectionDialog.ShowDialog() == DialogResult.OK)
            {
                string winSvcExeFileName = this.installSvcFileSelectionDialog.SafeFileName.Replace(".exe", "");
                this.txtBxDisplayName.Text = winSvcExeFileName;
                this.txtBxServiceName.Text = winSvcExeFileName;
                this.txtBxServiceExePath.Text = this.installSvcFileSelectionDialog.FileName;
                this.txtBxServiceName.Focus();
                this.txtBxServiceName.SelectAll();

                this.btnInstall.Enabled = true;
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            this.lblProcessResult.ForeColor = Color.Orange;
            this.lblProcessResult.Text = "Installing...";
            this.lblProcessResult.Refresh();

            StringBuilder installCmdBuilder = new StringBuilder();
            installCmdBuilder.Append("create");
            installCmdBuilder.AppendFormat("  \"{0}\"", this.txtBxServiceName.Text);
            installCmdBuilder.AppendFormat("  start=  {0}", this.cmbBxOptionStart.SelectedItem);
            installCmdBuilder.AppendFormat("  binPath=  \"{0}\"", this.txtBxServiceExePath.Text);
            installCmdBuilder.AppendFormat("  DisplayName=  \"{0}\"", this.txtBxDisplayName.Text);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "sc.exe";
            startInfo.Arguments = installCmdBuilder.ToString();
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;

            new Thread(() => {
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
                    this.lblProcessResult.Invoke(new MethodInvoker(() => {
                        this.lblProcessResult.ForeColor = Color.Red;
                        this.lblProcessResult.Text = "An error occurred during installation.";
                    }));
                    MessageBox.Show(ex.Message, "An error occurred during installation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }).Start();
        }

        private void InstallationProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.lblProcessResult.Invoke(new MethodInvoker(() => {
                if (string.IsNullOrEmpty(e.Data))
                    return;

                if (this.lblProcessResult.Text == "Installing...")
                    this.lblProcessResult.Text = "";

                string output = e.Data;
                this.lblProcessResult.Text += output;

                if (lblProcessResult.Text.IndexOf("failed", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    this.lblProcessResult.ForeColor = Color.Red;
                }
                else
                {
                    this.lblProcessResult.ForeColor = Color.Green;
                    this.m_installedServiceHashSets.Add(txtBxDisplayName.Text);
                }

                this.lblProcessResult.Refresh();
            }));
        }
    }
}
