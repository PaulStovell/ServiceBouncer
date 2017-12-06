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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.servicesDataGridView = new System.Windows.Forms.DataGridView();
            this.StatusIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.StartupType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStopItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRestartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSpacer1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStartupTypeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextStatupTypeAutomatic = new System.Windows.Forms.ToolStripMenuItem();
            this.contextStartupTypeManual = new System.Windows.Forms.ToolStripMenuItem();
            this.contextStartupTypeDisabled = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSpacer2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuRefreshItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSpacer3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuOpenLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuAssemblyInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripStartButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripPauseButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripStopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripRestartButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripInstallButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripStartupTypeButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStartupTypeAutomaticItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStartupTypeManualItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStartupTypeDisabledItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExplorerButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripInfoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripFilterIcon = new System.Windows.Forms.ToolStripLabel();
            this.toolStripFilterBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripConnectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripConnectToTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGridView)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.statusStrip1);
            this.toolStripContainer.ContentPanel.Controls.Add(this.servicesDataGridView);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1184, 329);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1184, 361);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer.TopToolStripPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolStripContainer.TopToolStripPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 307);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // servicesDataGridView
            // 
            this.servicesDataGridView.AllowUserToAddRows = false;
            this.servicesDataGridView.AllowUserToDeleteRows = false;
            this.servicesDataGridView.AllowUserToResizeRows = false;
            this.servicesDataGridView.AutoGenerateColumns = false;
            this.servicesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.servicesDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.servicesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.servicesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.servicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.servicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StatusIcon,
            this.nameDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.StartupType});
            this.servicesDataGridView.ContextMenuStrip = this.contextMenu;
            this.servicesDataGridView.DataSource = this.serviceViewModelBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.servicesDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.servicesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servicesDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.servicesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.servicesDataGridView.Margin = new System.Windows.Forms.Padding(7);
            this.servicesDataGridView.Name = "servicesDataGridView";
            this.servicesDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.servicesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.servicesDataGridView.RowHeadersVisible = false;
            this.servicesDataGridView.RowTemplate.Height = 25;
            this.servicesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.servicesDataGridView.Size = new System.Drawing.Size(1184, 329);
            this.servicesDataGridView.TabIndex = 0;
            // 
            // StatusIcon
            // 
            this.StatusIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StatusIcon.DataPropertyName = "StatusIcon";
            this.StatusIcon.FillWeight = 30.45685F;
            this.StatusIcon.Frozen = true;
            this.StatusIcon.HeaderText = "";
            this.StatusIcon.Name = "StatusIcon";
            this.StatusIcon.ReadOnly = true;
            this.StatusIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StatusIcon.Width = 7;
            // 
            // StartupType
            // 
            this.StartupType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StartupType.DataPropertyName = "StartupType";
            this.StartupType.FillWeight = 113.9086F;
            this.StartupType.HeaderText = "Startup Type";
            this.StartupType.Name = "StartupType";
            this.StartupType.ReadOnly = true;
            this.StartupType.Width = 102;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuStartItem,
            this.contextMenuStopItem,
            this.contextMenuRestartItem,
            this.contextMenuSpacer1,
            this.contextMenuDeleteItem,
            this.contextMenuStartupTypeItem,
            this.contextMenuSpacer2,
            this.contextMenuRefreshItem,
            this.contextMenuSpacer3,
            this.contextMenuOpenLocation,
            this.contextMenuAssemblyInfo});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(180, 198);
            // 
            // contextMenuStartItem
            // 
            this.contextMenuStartItem.Name = "contextMenuStartItem";
            this.contextMenuStartItem.Size = new System.Drawing.Size(179, 22);
            this.contextMenuStartItem.Text = "Start";
            this.contextMenuStartItem.Click += new System.EventHandler(this.StartClicked);
            // 
            // contextMenuStopItem
            // 
            this.contextMenuStopItem.Name = "contextMenuStopItem";
            this.contextMenuStopItem.Size = new System.Drawing.Size(179, 22);
            this.contextMenuStopItem.Text = "Stop";
            this.contextMenuStopItem.Click += new System.EventHandler(this.StopClicked);
            // 
            // contextMenuRestartItem
            // 
            this.contextMenuRestartItem.Name = "contextMenuRestartItem";
            this.contextMenuRestartItem.Size = new System.Drawing.Size(179, 22);
            this.contextMenuRestartItem.Text = "Restart";
            this.contextMenuRestartItem.Click += new System.EventHandler(this.RestartClicked);
            // 
            // contextMenuSpacer1
            // 
            this.contextMenuSpacer1.Name = "contextMenuSpacer1";
            this.contextMenuSpacer1.Size = new System.Drawing.Size(176, 6);
            // 
            // contextMenuDeleteItem
            // 
            this.contextMenuDeleteItem.Name = "contextMenuDeleteItem";
            this.contextMenuDeleteItem.Size = new System.Drawing.Size(179, 22);
            this.contextMenuDeleteItem.Text = "Delete";
            this.contextMenuDeleteItem.Click += new System.EventHandler(this.DeleteClicked);
            // 
            // contextMenuStartupTypeItem
            // 
            this.contextMenuStartupTypeItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextStatupTypeAutomatic,
            this.contextStartupTypeManual,
            this.contextStartupTypeDisabled});
            this.contextMenuStartupTypeItem.Name = "contextMenuStartupTypeItem";
            this.contextMenuStartupTypeItem.Size = new System.Drawing.Size(179, 22);
            this.contextMenuStartupTypeItem.Text = "Startup Type";
            // 
            // contextStatupTypeAutomatic
            // 
            this.contextStatupTypeAutomatic.Name = "contextStatupTypeAutomatic";
            this.contextStatupTypeAutomatic.Size = new System.Drawing.Size(130, 22);
            this.contextStatupTypeAutomatic.Text = "Automatic";
            this.contextStatupTypeAutomatic.Click += new System.EventHandler(this.StartupAutomaticClicked);
            // 
            // contextStartupTypeManual
            // 
            this.contextStartupTypeManual.Name = "contextStartupTypeManual";
            this.contextStartupTypeManual.Size = new System.Drawing.Size(130, 22);
            this.contextStartupTypeManual.Text = "Manual";
            this.contextStartupTypeManual.Click += new System.EventHandler(this.StartupManualClicked);
            // 
            // contextStartupTypeDisabled
            // 
            this.contextStartupTypeDisabled.Name = "contextStartupTypeDisabled";
            this.contextStartupTypeDisabled.Size = new System.Drawing.Size(130, 22);
            this.contextStartupTypeDisabled.Text = "Disabled";
            this.contextStartupTypeDisabled.Click += new System.EventHandler(this.StartupDisabledClick);
            // 
            // contextMenuSpacer2
            // 
            this.contextMenuSpacer2.Name = "contextMenuSpacer2";
            this.contextMenuSpacer2.Size = new System.Drawing.Size(176, 6);
            // 
            // contextMenuRefreshItem
            // 
            this.contextMenuRefreshItem.Name = "contextMenuRefreshItem";
            this.contextMenuRefreshItem.Size = new System.Drawing.Size(179, 22);
            this.contextMenuRefreshItem.Text = "Refresh";
            this.contextMenuRefreshItem.Click += new System.EventHandler(this.RefreshClicked);
            // 
            // contextMenuSpacer3
            // 
            this.contextMenuSpacer3.Name = "contextMenuSpacer3";
            this.contextMenuSpacer3.Size = new System.Drawing.Size(176, 6);
            // 
            // contextMenuOpenLocation
            // 
            this.contextMenuOpenLocation.Name = "contextMenuOpenLocation";
            this.contextMenuOpenLocation.Size = new System.Drawing.Size(179, 22);
            this.contextMenuOpenLocation.Text = "Open Service Folder";
            this.contextMenuOpenLocation.Click += new System.EventHandler(this.OpenServiceLocationClick);
            // 
            // contextMenuAssemblyInfo
            // 
            this.contextMenuAssemblyInfo.Name = "contextMenuAssemblyInfo";
            this.contextMenuAssemblyInfo.Size = new System.Drawing.Size(179, 22);
            this.contextMenuAssemblyInfo.Text = "Assembly Info";
            this.contextMenuAssemblyInfo.Click += new System.EventHandler(this.AssemblyInfoClick);
            // 
            // toolStrip
            // 
            this.toolStrip.AllowMerge = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripConnectButton,
            this.toolStripConnectToTextBox,
            this.toolStripSeparator3,
            this.toolStripStartButton,
            this.toolStripPauseButton,
            this.toolStripStopButton,
            this.toolStripRestartButton,
            this.toolStripSeparator1,
            this.toolStripDeleteButton,
            this.toolStripInstallButton,
            this.toolStripStartupTypeButton,
            this.toolStripExplorerButton,
            this.toolStripInfoButton,
            this.toolStripSeparator2,
            this.toolStripRefreshButton,
            this.toolStripFilterIcon,
            this.toolStripFilterBox});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(1184, 32);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripStartButton
            // 
            this.toolStripStartButton.Image = global::ServiceBouncer.Properties.Resources.Start;
            this.toolStripStartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStartButton.Margin = new System.Windows.Forms.Padding(7, 1, 0, 2);
            this.toolStripStartButton.Name = "toolStripStartButton";
            this.toolStripStartButton.Size = new System.Drawing.Size(60, 29);
            this.toolStripStartButton.Text = "Start";
            this.toolStripStartButton.Click += new System.EventHandler(this.StartClicked);
            // 
            // toolStripPauseButton
            // 
            this.toolStripPauseButton.Image = global::ServiceBouncer.Properties.Resources.Pause;
            this.toolStripPauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPauseButton.Margin = new System.Windows.Forms.Padding(7, 1, 0, 2);
            this.toolStripPauseButton.Name = "toolStripPauseButton";
            this.toolStripPauseButton.Size = new System.Drawing.Size(67, 29);
            this.toolStripPauseButton.Text = "Pause";
            this.toolStripPauseButton.Click += new System.EventHandler(this.PauseClicked);
            // 
            // toolStripStopButton
            // 
            this.toolStripStopButton.Image = global::ServiceBouncer.Properties.Resources.Stop;
            this.toolStripStopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStopButton.Name = "toolStripStopButton";
            this.toolStripStopButton.Size = new System.Drawing.Size(60, 29);
            this.toolStripStopButton.Text = "Stop";
            this.toolStripStopButton.Click += new System.EventHandler(this.StopClicked);
            // 
            // toolStripRestartButton
            // 
            this.toolStripRestartButton.Image = global::ServiceBouncer.Properties.Resources.Restart;
            this.toolStripRestartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRestartButton.Name = "toolStripRestartButton";
            this.toolStripRestartButton.Size = new System.Drawing.Size(72, 29);
            this.toolStripRestartButton.Text = "Restart";
            this.toolStripRestartButton.ToolTipText = "Stop, wait, then start";
            this.toolStripRestartButton.Click += new System.EventHandler(this.RestartClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripDeleteButton
            // 
            this.toolStripDeleteButton.Image = global::ServiceBouncer.Properties.Resources.Delete;
            this.toolStripDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDeleteButton.Name = "toolStripDeleteButton";
            this.toolStripDeleteButton.Size = new System.Drawing.Size(69, 29);
            this.toolStripDeleteButton.Text = "Delete";
            this.toolStripDeleteButton.Click += new System.EventHandler(this.DeleteClicked);
            // 
            // toolStripInstallButton
            // 
            this.toolStripInstallButton.Image = global::ServiceBouncer.Properties.Resources.Install;
            this.toolStripInstallButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripInstallButton.Name = "toolStripInstallButton";
            this.toolStripInstallButton.Size = new System.Drawing.Size(67, 29);
            this.toolStripInstallButton.Text = "Install";
            this.toolStripInstallButton.Click += new System.EventHandler(this.InstallClicked);
            // 
            // toolStripStartupTypeButton
            // 
            this.toolStripStartupTypeButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStartupTypeAutomaticItem,
            this.toolStripStartupTypeManualItem,
            this.toolStripStartupTypeDisabledItem});
            this.toolStripStartupTypeButton.Image = global::ServiceBouncer.Properties.Resources.Startup;
            this.toolStripStartupTypeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStartupTypeButton.Name = "toolStripStartupTypeButton";
            this.toolStripStartupTypeButton.Size = new System.Drawing.Size(83, 29);
            this.toolStripStartupTypeButton.Text = "Startup";
            // 
            // toolStripStartupTypeAutomaticItem
            // 
            this.toolStripStartupTypeAutomaticItem.Name = "toolStripStartupTypeAutomaticItem";
            this.toolStripStartupTypeAutomaticItem.Size = new System.Drawing.Size(130, 22);
            this.toolStripStartupTypeAutomaticItem.Text = "Automatic";
            this.toolStripStartupTypeAutomaticItem.Click += new System.EventHandler(this.StartupAutomaticClicked);
            // 
            // toolStripStartupTypeManualItem
            // 
            this.toolStripStartupTypeManualItem.Name = "toolStripStartupTypeManualItem";
            this.toolStripStartupTypeManualItem.Size = new System.Drawing.Size(130, 22);
            this.toolStripStartupTypeManualItem.Text = "Manual";
            this.toolStripStartupTypeManualItem.Click += new System.EventHandler(this.StartupManualClicked);
            // 
            // toolStripStartupTypeDisabledItem
            // 
            this.toolStripStartupTypeDisabledItem.Name = "toolStripStartupTypeDisabledItem";
            this.toolStripStartupTypeDisabledItem.Size = new System.Drawing.Size(130, 22);
            this.toolStripStartupTypeDisabledItem.Text = "Disabled";
            this.toolStripStartupTypeDisabledItem.Click += new System.EventHandler(this.StartupDisabledClick);
            // 
            // toolStripExplorerButton
            // 
            this.toolStripExplorerButton.Image = global::ServiceBouncer.Properties.Resources.Browse;
            this.toolStripExplorerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExplorerButton.Name = "toolStripExplorerButton";
            this.toolStripExplorerButton.Size = new System.Drawing.Size(74, 29);
            this.toolStripExplorerButton.Text = "Browse";
            this.toolStripExplorerButton.Click += new System.EventHandler(this.OpenServiceLocationClick);
            // 
            // toolStripInfoButton
            // 
            this.toolStripInfoButton.Image = global::ServiceBouncer.Properties.Resources.Info;
            this.toolStripInfoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripInfoButton.Name = "toolStripInfoButton";
            this.toolStripInfoButton.Size = new System.Drawing.Size(57, 29);
            this.toolStripInfoButton.Text = "Info";
            this.toolStripInfoButton.Click += new System.EventHandler(this.AssemblyInfoClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripRefreshButton
            // 
            this.toolStripRefreshButton.Image = global::ServiceBouncer.Properties.Resources.Refresh;
            this.toolStripRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefreshButton.Name = "toolStripRefreshButton";
            this.toolStripRefreshButton.Size = new System.Drawing.Size(75, 29);
            this.toolStripRefreshButton.Text = "Refresh";
            this.toolStripRefreshButton.Click += new System.EventHandler(this.RefreshClicked);
            // 
            // toolStripFilterIcon
            // 
            this.toolStripFilterIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripFilterIcon.Image = global::ServiceBouncer.Properties.Resources.Filter;
            this.toolStripFilterIcon.Name = "toolStripFilterIcon";
            this.toolStripFilterIcon.Size = new System.Drawing.Size(25, 25);
            // 
            // toolStripFilterBox
            // 
            this.toolStripFilterBox.Margin = new System.Windows.Forms.Padding(1, 3, 10, 0);
            this.toolStripFilterBox.Name = "toolStripFilterBox";
            this.toolStripFilterBox.Size = new System.Drawing.Size(150, 23);
            this.toolStripFilterBox.ToolTipText = "Type a name here to filter";
            this.toolStripFilterBox.TextChanged += new System.EventHandler(this.FilterBoxTextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1, 0);
            this.toolStrip1.TabIndex = 1;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 750;
            this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimerTicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripConnectButton
            // 
            this.toolStripConnectButton.AutoSize = false;
            this.toolStripConnectButton.Image = global::ServiceBouncer.Properties.Resources.Disconnected;
            this.toolStripConnectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConnectButton.Name = "toolStripConnectButton";
            this.toolStripConnectButton.Size = new System.Drawing.Size(100, 29);
            this.toolStripConnectButton.Tag = "Disconnected";
            this.toolStripConnectButton.Text = "Connect";
            this.toolStripConnectButton.ToolTipText = "Connect";
            this.toolStripConnectButton.Click += new System.EventHandler(this.ConnectButtonClick);
            // 
            // toolStripConnectToTextBox
            // 
            this.toolStripConnectToTextBox.Margin = new System.Windows.Forms.Padding(1, 3, 10, 0);
            this.toolStripConnectToTextBox.MaxLength = 120;
            this.toolStripConnectToTextBox.Name = "toolStripConnectToTextBox";
            this.toolStripConnectToTextBox.Size = new System.Drawing.Size(100, 23);
            this.toolStripConnectToTextBox.Text = "localhost";
            this.toolStripConnectToTextBox.ToolTipText = "Hostname of the machine to connect to";
            this.toolStripConnectToTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectTextBoxKeyDown);
            this.toolStripConnectToTextBox.TextChanged += new System.EventHandler(this.ConnectTextBoxChanged);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nameDataGridViewTextBoxColumn.FillWeight = 341.7259F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Display name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.FillWeight = 113.9086F;
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 68;
            // 
            // serviceViewModelBindingSource
            // 
            this.serviceViewModelBindingSource.DataSource = typeof(ServiceBouncer.ServiceViewModel);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 361);
            this.Controls.Add(this.toolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(920, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Bouncer";
            this.Activated += new System.EventHandler(this.FormActivated);
            this.Deactivate += new System.EventHandler(this.FormDeactivated);
            this.Load += new System.EventHandler(this.FormLoaded);
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.ContentPanel.PerformLayout();
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGridView)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStripButton toolStripStartButton;
        private System.Windows.Forms.ToolStripButton toolStripStopButton;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.DataGridView servicesDataGridView;
        private System.Windows.Forms.BindingSource serviceViewModelBindingSource;
        private System.Windows.Forms.ToolStripButton toolStripRestartButton;
        private System.Windows.Forms.ToolStripTextBox toolStripFilterBox;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripStartupTypeAutomaticItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripStartupTypeManualItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripStartupTypeDisabledItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripFilterIcon;
        private System.Windows.Forms.ToolStripButton toolStripPauseButton;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStartupTypeItem;
        private System.Windows.Forms.ToolStripMenuItem contextStatupTypeAutomatic;
        private System.Windows.Forms.ToolStripMenuItem contextStartupTypeManual;
        private System.Windows.Forms.ToolStripMenuItem contextStartupTypeDisabled;
        private System.Windows.Forms.DataGridViewImageColumn StatusIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartupType;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator contextMenuSpacer3;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOpenLocation;
        private System.Windows.Forms.ToolStripMenuItem contextMenuAssemblyInfo;
        private System.Windows.Forms.ToolStripButton toolStripExplorerButton;
        private System.Windows.Forms.ToolStripButton toolStripInfoButton;
        private System.Windows.Forms.ToolStripButton toolStripInstallButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton toolStripConnectButton;
        private System.Windows.Forms.ToolStripTextBox toolStripConnectToTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

