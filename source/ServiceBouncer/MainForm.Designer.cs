namespace ServiceBouncer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.servicesDataGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartupType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStopItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRestartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSpacer1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSpacer2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuRefreshItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripStartButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripRestartButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripStopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripStartupTypeButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.startupTypeAutomaticItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupTypeManualItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupTypeDisabledItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGridView)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceViewModelBindingSource)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.servicesDataGridView);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(766, 288);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(766, 311);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
            this.toolStripContainer.TopToolStripPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolStripContainer.TopToolStripPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            // 
            // servicesDataGridView
            // 
            this.servicesDataGridView.AllowUserToAddRows = false;
            this.servicesDataGridView.AllowUserToDeleteRows = false;
            this.servicesDataGridView.AllowUserToOrderColumns = true;
            this.servicesDataGridView.AllowUserToResizeRows = false;
            this.servicesDataGridView.AutoGenerateColumns = false;
            this.servicesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.servicesDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.servicesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.servicesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.servicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.servicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.StatusIcon,
            this.statusDataGridViewTextBoxColumn,
            this.StartupType});
            this.servicesDataGridView.ContextMenuStrip = this.contextMenu;
            this.servicesDataGridView.DataSource = this.serviceViewModelBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.servicesDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.servicesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servicesDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.servicesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.servicesDataGridView.Margin = new System.Windows.Forms.Padding(7);
            this.servicesDataGridView.Name = "servicesDataGridView";
            this.servicesDataGridView.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.servicesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.servicesDataGridView.RowHeadersVisible = false;
            this.servicesDataGridView.RowTemplate.Height = 25;
            this.servicesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.servicesDataGridView.Size = new System.Drawing.Size(766, 288);
            this.servicesDataGridView.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.nameDataGridViewTextBoxColumn.FillWeight = 341.7259F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Display name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StatusIcon
            // 
            this.StatusIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StatusIcon.DataPropertyName = "StatusIcon";
            this.StatusIcon.FillWeight = 30.45685F;
            this.StatusIcon.HeaderText = "";
            this.StatusIcon.Name = "StatusIcon";
            this.StatusIcon.ReadOnly = true;
            this.StatusIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StatusIcon.Width = 7;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.FillWeight = 113.9086F;
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StartupType
            // 
            this.StartupType.DataPropertyName = "StartupType";
            this.StartupType.FillWeight = 113.9086F;
            this.StartupType.HeaderText = "Startup Type";
            this.StartupType.Name = "StartupType";
            this.StartupType.ReadOnly = true;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuStartItem,
            this.contextMenuStopItem,
            this.contextMenuRestartItem,
            this.contextMenuSpacer1,
            this.contextMenuDeleteItem,
            this.contextMenuSpacer2,
            this.contextMenuRefreshItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(114, 126);
            // 
            // contextMenuStartItem
            // 
            this.contextMenuStartItem.Name = "contextMenuStartItem";
            this.contextMenuStartItem.Size = new System.Drawing.Size(113, 22);
            this.contextMenuStartItem.Text = "Start";
            this.contextMenuStartItem.Click += new System.EventHandler(this.StartClicked);
            // 
            // contextMenuStopItem
            // 
            this.contextMenuStopItem.Name = "contextMenuStopItem";
            this.contextMenuStopItem.Size = new System.Drawing.Size(113, 22);
            this.contextMenuStopItem.Text = "Stop";
            this.contextMenuStopItem.Click += new System.EventHandler(this.StopClicked);
            // 
            // contextMenuRestartItem
            // 
            this.contextMenuRestartItem.Name = "contextMenuRestartItem";
            this.contextMenuRestartItem.Size = new System.Drawing.Size(113, 22);
            this.contextMenuRestartItem.Text = "Restart";
            this.contextMenuRestartItem.Click += new System.EventHandler(this.RestartClicked);
            // 
            // contextMenuSpacer1
            // 
            this.contextMenuSpacer1.Name = "contextMenuSpacer1";
            this.contextMenuSpacer1.Size = new System.Drawing.Size(110, 6);
            // 
            // contextMenuDeleteItem
            // 
            this.contextMenuDeleteItem.Name = "contextMenuDeleteItem";
            this.contextMenuDeleteItem.Size = new System.Drawing.Size(113, 22);
            this.contextMenuDeleteItem.Text = "Delete";
            this.contextMenuDeleteItem.Click += new System.EventHandler(this.DeleteClicked);
            // 
            // contextMenuSpacer2
            // 
            this.contextMenuSpacer2.Name = "contextMenuSpacer2";
            this.contextMenuSpacer2.Size = new System.Drawing.Size(110, 6);
            // 
            // contextMenuRefreshItem
            // 
            this.contextMenuRefreshItem.Name = "contextMenuRefreshItem";
            this.contextMenuRefreshItem.Size = new System.Drawing.Size(113, 22);
            this.contextMenuRefreshItem.Text = "Refresh";
            this.contextMenuRefreshItem.Click += new System.EventHandler(this.RefreshClicked);
            // 
            // serviceViewModelBindingSource
            // 
            this.serviceViewModelBindingSource.DataSource = typeof(ServiceBouncer.ServiceViewModel);
            // 
            // toolStrip
            // 
            this.toolStrip.AllowMerge = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStartButton,
            this.toolStripRestartButton,
            this.toolStripStopButton,
            this.toolStripDeleteButton,
            this.toolStripStartupTypeButton,
            this.filterBox,
            this.toolStripRefreshButton});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(510, 23);
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripStartButton
            // 
            this.toolStripStartButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStartButton.Image")));
            this.toolStripStartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStartButton.Margin = new System.Windows.Forms.Padding(7, 1, 0, 2);
            this.toolStripStartButton.Name = "toolStripStartButton";
            this.toolStripStartButton.Size = new System.Drawing.Size(51, 20);
            this.toolStripStartButton.Text = "Start";
            this.toolStripStartButton.Click += new System.EventHandler(this.StartClicked);
            // 
            // toolStripRestartButton
            // 
            this.toolStripRestartButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRestartButton.Image")));
            this.toolStripRestartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRestartButton.Name = "toolStripRestartButton";
            this.toolStripRestartButton.Size = new System.Drawing.Size(63, 20);
            this.toolStripRestartButton.Text = "Restart";
            this.toolStripRestartButton.ToolTipText = "Stop, wait, then start";
            this.toolStripRestartButton.Click += new System.EventHandler(this.RestartClicked);
            // 
            // toolStripStopButton
            // 
            this.toolStripStopButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStopButton.Image")));
            this.toolStripStopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStopButton.Name = "toolStripStopButton";
            this.toolStripStopButton.Size = new System.Drawing.Size(51, 20);
            this.toolStripStopButton.Text = "Stop";
            this.toolStripStopButton.Click += new System.EventHandler(this.StopClicked);
            // 
            // toolStripDeleteButton
            // 
            this.toolStripDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeleteButton.Image")));
            this.toolStripDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDeleteButton.Name = "toolStripDeleteButton";
            this.toolStripDeleteButton.Size = new System.Drawing.Size(60, 20);
            this.toolStripDeleteButton.Text = "Delete";
            this.toolStripDeleteButton.Click += new System.EventHandler(this.DeleteClicked);
            // 
            // toolStripStartupTypeButton
            // 
            this.toolStripStartupTypeButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startupTypeAutomaticItem,
            this.startupTypeManualItem,
            this.startupTypeDisabledItem});
            this.toolStripStartupTypeButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStartupTypeButton.Image")));
            this.toolStripStartupTypeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStartupTypeButton.Name = "toolStripStartupTypeButton";
            this.toolStripStartupTypeButton.Size = new System.Drawing.Size(102, 20);
            this.toolStripStartupTypeButton.Text = "Startup Type";
            // 
            // startupTypeAutomaticItem
            // 
            this.startupTypeAutomaticItem.Name = "startupTypeAutomaticItem";
            this.startupTypeAutomaticItem.Size = new System.Drawing.Size(130, 22);
            this.startupTypeAutomaticItem.Text = "Automatic";
            this.startupTypeAutomaticItem.Click += new System.EventHandler(this.StartupAutomaticClicked);
            // 
            // startupTypeManualItem
            // 
            this.startupTypeManualItem.Name = "startupTypeManualItem";
            this.startupTypeManualItem.Size = new System.Drawing.Size(130, 22);
            this.startupTypeManualItem.Text = "Manual";
            this.startupTypeManualItem.Click += new System.EventHandler(this.StartupManualClicked);
            // 
            // startupTypeDisabledItem
            // 
            this.startupTypeDisabledItem.Name = "startupTypeDisabledItem";
            this.startupTypeDisabledItem.Size = new System.Drawing.Size(130, 22);
            this.startupTypeDisabledItem.Text = "Disabled";
            this.startupTypeDisabledItem.Click += new System.EventHandler(this.StartupDisabledClick);
            // 
            // filterBox
            // 
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(150, 23);
            this.filterBox.ToolTipText = "Type a name here to filter";
            this.filterBox.TextChanged += new System.EventHandler(this.FilterBoxTextChanged);
            // 
            // toolStripRefreshButton
            // 
            this.toolStripRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRefreshButton.Image")));
            this.toolStripRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefreshButton.Name = "toolStripRefreshButton";
            this.toolStripRefreshButton.Size = new System.Drawing.Size(23, 20);
            this.toolStripRefreshButton.Text = "Refresh";
            this.toolStripRefreshButton.Click += new System.EventHandler(this.RefreshClicked);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimerTicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 311);
            this.Controls.Add(this.toolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Bouncer";
            this.Activated += new System.EventHandler(this.FormActivated);
            this.Deactivate += new System.EventHandler(this.FormDeactivated);
            this.Load += new System.EventHandler(this.FormLoaded);
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGridView)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serviceViewModelBindingSource)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripStartButton;
        private System.Windows.Forms.ToolStripButton toolStripStopButton;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.DataGridView servicesDataGridView;
        private System.Windows.Forms.BindingSource serviceViewModelBindingSource;
        private System.Windows.Forms.ToolStripButton toolStripRestartButton;
        private System.Windows.Forms.ToolStripTextBox filterBox;
        private System.Windows.Forms.ToolStripButton toolStripRefreshButton;
        private System.Windows.Forms.ToolStripButton toolStripDeleteButton;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStartItem;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStopItem;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRestartItem;
        private System.Windows.Forms.ToolStripSeparator contextMenuSpacer2;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRefreshItem;
        private System.Windows.Forms.ToolStripSeparator contextMenuSpacer1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuDeleteItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripStartupTypeButton;
        private System.Windows.Forms.ToolStripMenuItem startupTypeAutomaticItem;
        private System.Windows.Forms.ToolStripMenuItem startupTypeManualItem;
        private System.Windows.Forms.ToolStripMenuItem startupTypeDisabledItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn StatusIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartupType;
    }
}

