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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridStatusIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridStatupType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridLogOnAs = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.serviceViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripConnectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripConnectToTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
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
            this.appTerminationTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceViewModelBindingSource)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.dataGridView);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1008, 307);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1008, 361);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
            this.toolStripContainer.TopToolStripPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolStripContainer.TopToolStripPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridStatusIcon,
            this.dataGridName,
            this.dataGridDescription,
            this.dataGridStatus,
            this.dataGridStatupType,
            this.dataGridLogOnAs});
            this.dataGridView.ContextMenuStrip = this.contextMenu;
            this.dataGridView.DataSource = this.serviceViewModelBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(7);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1008, 307);
            this.dataGridView.TabIndex = 0;
            // 
            // dataGridStatusIcon
            // 
            this.dataGridStatusIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridStatusIcon.DataPropertyName = "StatusIcon";
            this.dataGridStatusIcon.FillWeight = 50.76142F;
            this.dataGridStatusIcon.HeaderText = "";
            this.dataGridStatusIcon.MinimumWidth = 30;
            this.dataGridStatusIcon.Name = "dataGridStatusIcon";
            this.dataGridStatusIcon.ReadOnly = true;
            this.dataGridStatusIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridStatusIcon.Width = 30;
            // 
            // dataGridName
            // 
            this.dataGridName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridName.DataPropertyName = "Name";
            this.dataGridName.FillWeight = 70.05687F;
            this.dataGridName.HeaderText = "Display Name";
            this.dataGridName.Name = "dataGridName";
            this.dataGridName.ReadOnly = true;
            // 
            // dataGridDescription
            // 
            this.dataGridDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridDescription.DataPropertyName = "Description";
            this.dataGridName.FillWeight = 40.125F;
            this.dataGridDescription.HeaderText = "Description";
            this.dataGridDescription.Name = "dataGridDescription";
            this.dataGridDescription.ReadOnly = true;
            // 
            // dataGridStatus
            // 
            this.dataGridStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridStatus.DataPropertyName = "Status";
            this.dataGridStatus.FillWeight = 70.05687F;
            this.dataGridStatus.HeaderText = "Status";
            this.dataGridStatus.Name = "dataGridStatus";
            this.dataGridStatus.ReadOnly = true;
            this.dataGridStatus.Width = 68;
            // 
            // dataGridStatupType
            // 
            this.dataGridStatupType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridStatupType.DataPropertyName = "StartupType";
            this.dataGridStatupType.FillWeight = 209.125F;
            this.dataGridStatupType.HeaderText = "Startup Type";
            this.dataGridStatupType.Name = "dataGridStatupType";
            this.dataGridStatupType.ReadOnly = true;
            this.dataGridStatupType.Width = 101;
            // 
            // dataGridLogOnAs
            // 
            this.dataGridLogOnAs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridLogOnAs.DataPropertyName = "LogOnAs";
            this.dataGridLogOnAs.FillWeight = 209.125F;
            this.dataGridLogOnAs.HeaderText = "Log On As";
            this.dataGridLogOnAs.Name = "dataGridLogOnAs";
            this.dataGridLogOnAs.ReadOnly = true;
            this.dataGridLogOnAs.Width = 101;
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
            this.contextMenuStartItem.Image = global::ServiceBouncer.Properties.Resources.Start;
            this.contextMenuStartItem.Name = "contextMenuStartItem";
            this.contextMenuStartItem.Size = new System.Drawing.Size(179, 22);
            this.contextMenuStartItem.Text = "Start";
            this.contextMenuStartItem.Click += new System.EventHandler(this.StartClicked);
            // 
            // contextMenuStopItem
            // 
            this.contextMenuStopItem.Image = global::ServiceBouncer.Properties.Resources.Stop;
            this.contextMenuStopItem.Name = "contextMenuStopItem";
            this.contextMenuStopItem.Size = new System.Drawing.Size(179, 22);
            this.contextMenuStopItem.Text = "Stop";
            this.contextMenuStopItem.Click += new System.EventHandler(this.StopClicked);
            // 
            // contextMenuRestartItem
            // 
            this.contextMenuRestartItem.Image = global::ServiceBouncer.Properties.Resources.Restart;
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
            this.contextMenuDeleteItem.Image = global::ServiceBouncer.Properties.Resources.Delete;
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
            this.contextMenuStartupTypeItem.Image = global::ServiceBouncer.Properties.Resources.Startup;
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
            this.contextMenuRefreshItem.Image = global::ServiceBouncer.Properties.Resources.Refresh;
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
            this.contextMenuOpenLocation.Image = global::ServiceBouncer.Properties.Resources.Browse;
            this.contextMenuOpenLocation.Name = "contextMenuOpenLocation";
            this.contextMenuOpenLocation.Size = new System.Drawing.Size(179, 22);
            this.contextMenuOpenLocation.Text = "Open Service Folder";
            this.contextMenuOpenLocation.Click += new System.EventHandler(this.OpenServiceLocationClick);
            // 
            // contextMenuAssemblyInfo
            // 
            this.contextMenuAssemblyInfo.Image = global::ServiceBouncer.Properties.Resources.Info;
            this.contextMenuAssemblyInfo.Name = "contextMenuAssemblyInfo";
            this.contextMenuAssemblyInfo.Size = new System.Drawing.Size(179, 22);
            this.contextMenuAssemblyInfo.Text = "Assembly Info";
            this.contextMenuAssemblyInfo.Click += new System.EventHandler(this.AssemblyInfoClick);
            // 
            // serviceViewModelBindingSource
            // 
            this.serviceViewModelBindingSource.DataSource = typeof(ServiceBouncer.ServiceViewModel);
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
            this.toolStrip.Size = new System.Drawing.Size(1008, 32);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripConnectButton
            // 
            this.toolStripConnectButton.Image = global::ServiceBouncer.Properties.Resources.Connect;
            this.toolStripConnectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConnectButton.Name = "toolStripConnectButton";
            this.toolStripConnectButton.Size = new System.Drawing.Size(95, 29);
            this.toolStripConnectButton.Tag = "Connected";
            this.toolStripConnectButton.Text = "Disconnect";
            this.toolStripConnectButton.ToolTipText = "Disconnect";
            this.toolStripConnectButton.Click += new System.EventHandler(this.ConnectButtonClick);
            // 
            // toolStripConnectToTextBox
            // 
            this.toolStripConnectToTextBox.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.toolStripConnectToTextBox.MaxLength = 120;
            this.toolStripConnectToTextBox.Name = "toolStripConnectToTextBox";
            this.toolStripConnectToTextBox.Size = new System.Drawing.Size(500, 23);
            this.toolStripConnectToTextBox.Text = "localhost";
            this.toolStripConnectToTextBox.ToolTipText = "Hostname of the machine to connect to";
            this.toolStripConnectToTextBox.Visible = false;
            this.toolStripConnectToTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectTextBoxKeyDown);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripStartButton
            // 
            this.toolStripStartButton.Image = global::ServiceBouncer.Properties.Resources.Start;
            this.toolStripStartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStartButton.Name = "toolStripStartButton";
            this.toolStripStartButton.Size = new System.Drawing.Size(60, 29);
            this.toolStripStartButton.Text = "Start";
            this.toolStripStartButton.Click += new System.EventHandler(this.StartClicked);
            // 
            // toolStripPauseButton
            // 
            this.toolStripPauseButton.Image = global::ServiceBouncer.Properties.Resources.Pause;
            this.toolStripPauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
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
            this.toolStripFilterBox.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.toolStripFilterBox.Name = "toolStripFilterBox";
            this.toolStripFilterBox.Size = new System.Drawing.Size(150, 23);
            this.toolStripFilterBox.ToolTipText = "Type a name here to filter";
            this.toolStripFilterBox.TextChanged += new System.EventHandler(this.FilterBoxTextChanged);
            // 
            // appTerminationTimer
            // 
            this.appTerminationTimer.Enabled = true;
            this.appTerminationTimer.Interval = 60000;
            this.appTerminationTimer.Tick += new System.EventHandler(this.AppTerminationTimerTick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 361);
            this.Controls.Add(this.toolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Bouncer";
            this.Activated += new System.EventHandler(this.FormActivated);
            this.Deactivate += new System.EventHandler(this.FormDeactivated);
            this.Load += new System.EventHandler(this.FormLoaded);
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serviceViewModelBindingSource)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStripButton toolStripStartButton;
        private System.Windows.Forms.ToolStripButton toolStripStopButton;
        private System.Windows.Forms.DataGridView dataGridView;
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
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator contextMenuSpacer3;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOpenLocation;
        private System.Windows.Forms.ToolStripMenuItem contextMenuAssemblyInfo;
        private System.Windows.Forms.ToolStripButton toolStripExplorerButton;
        private System.Windows.Forms.ToolStripButton toolStripInfoButton;
        private System.Windows.Forms.ToolStripButton toolStripInstallButton;
        private System.Windows.Forms.ToolStripButton toolStripConnectButton;
        private System.Windows.Forms.ToolStripTextBox toolStripConnectToTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridStatusIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridStatupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridLogOnAs;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Timer appTerminationTimer;
    }
}

