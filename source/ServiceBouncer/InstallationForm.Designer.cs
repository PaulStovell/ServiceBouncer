namespace ServiceBouncer
{
    partial class InstallationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallationForm));
            this.installSvcFileSelectionDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtBxServiceExePath = new System.Windows.Forms.TextBox();
            this.btnSelectService = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxServiceName = new System.Windows.Forms.TextBox();
            this.cmbBxOptionStart = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBxDisplayName = new System.Windows.Forms.TextBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.lblProcessResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // installSvcFileSelectionDialog
            // 
            this.installSvcFileSelectionDialog.Filter = "Windows Service Files|*.exe";
            // 
            // txtBxServiceExePath
            // 
            this.txtBxServiceExePath.Location = new System.Drawing.Point(12, 21);
            this.txtBxServiceExePath.Name = "txtBxServiceExePath";
            this.txtBxServiceExePath.ReadOnly = true;
            this.txtBxServiceExePath.Size = new System.Drawing.Size(431, 23);
            this.txtBxServiceExePath.TabIndex = 0;
            // 
            // btnSelectService
            // 
            this.btnSelectService.Location = new System.Drawing.Point(449, 21);
            this.btnSelectService.Name = "btnSelectService";
            this.btnSelectService.Size = new System.Drawing.Size(61, 23);
            this.btnSelectService.TabIndex = 0;
            this.btnSelectService.Text = "...";
            this.btnSelectService.UseVisualStyleBackColor = true;
            this.btnSelectService.Click += new System.EventHandler(this.btnSelectService_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "BinPath";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "ServiceName";
            // 
            // txtBxServiceName
            // 
            this.txtBxServiceName.Location = new System.Drawing.Point(12, 65);
            this.txtBxServiceName.Name = "txtBxServiceName";
            this.txtBxServiceName.Size = new System.Drawing.Size(183, 23);
            this.txtBxServiceName.TabIndex = 1;
            // 
            // cmbBxOptionStart
            // 
            this.cmbBxOptionStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxOptionStart.FormattingEnabled = true;
            this.cmbBxOptionStart.Items.AddRange(new object[] {
            "auto",
            "demand",
            "disabled"});
            this.cmbBxOptionStart.Location = new System.Drawing.Point(390, 65);
            this.cmbBxOptionStart.Name = "cmbBxOptionStart";
            this.cmbBxOptionStart.Size = new System.Drawing.Size(120, 23);
            this.cmbBxOptionStart.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start Option";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "DisplayName";
            // 
            // txtBxDisplayName
            // 
            this.txtBxDisplayName.Location = new System.Drawing.Point(201, 65);
            this.txtBxDisplayName.Name = "txtBxDisplayName";
            this.txtBxDisplayName.Size = new System.Drawing.Size(183, 23);
            this.txtBxDisplayName.TabIndex = 2;
            // 
            // btnInstall
            // 
            this.btnInstall.Enabled = false;
            this.btnInstall.Location = new System.Drawing.Point(390, 103);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(120, 23);
            this.btnInstall.TabIndex = 4;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // lblProcessResult
            // 
            this.lblProcessResult.AutoSize = true;
            this.lblProcessResult.Location = new System.Drawing.Point(12, 111);
            this.lblProcessResult.Name = "lblProcessResult";
            this.lblProcessResult.Size = new System.Drawing.Size(0, 15);
            this.lblProcessResult.TabIndex = 10;
            // 
            // InstallationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 134);
            this.Controls.Add(this.lblProcessResult);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBxDisplayName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBxOptionStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxServiceName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectService);
            this.Controls.Add(this.txtBxServiceExePath);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Windows Service Installation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog installSvcFileSelectionDialog;
        private System.Windows.Forms.TextBox txtBxServiceExePath;
        private System.Windows.Forms.Button btnSelectService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxServiceName;
        private System.Windows.Forms.ComboBox cmbBxOptionStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBxDisplayName;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label lblProcessResult;
    }
}