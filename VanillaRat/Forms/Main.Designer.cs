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
            this.clientControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClientKill = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClientDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowClientConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRaisePerms = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetRunningApps = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenComputerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenFileBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGrabClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetHardwareUsage = new System.Windows.Forms.ToolStripMenuItem();
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
            this.clientExtrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnBuilder = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.GetDataLoop = new System.Windows.Forms.Timer(this.components);
            this.btnStopRD = new System.Windows.Forms.Button();
            this.btnStartRD = new System.Windows.Forms.Button();
            this.bwUpdateImage = new System.ComponentModel.BackgroundWorker();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbConnectedClients = new System.Windows.Forms.ListView();
            this.chConnectionId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pbDesktop = new System.Windows.Forms.PictureBox();
            this.ClientMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesktop)).BeginInit();
            this.SuspendLayout();
            // 
            // ClientMenu
            // 
            this.ClientMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientControlsToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.clientCommunicationToolStripMenuItem,
            this.clientExtrasToolStripMenuItem});
            this.ClientMenu.Name = "ClientMenu";
            this.ClientMenu.Size = new System.Drawing.Size(196, 92);
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
            this.clientControlsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
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
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
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
            // clientCommunicationToolStripMenuItem
            // 
            this.clientCommunicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenMessageBoxDialog});
            this.clientCommunicationToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Communication_48px;
            this.clientCommunicationToolStripMenuItem.Name = "clientCommunicationToolStripMenuItem";
            this.clientCommunicationToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
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
            // clientExtrasToolStripMenuItem
            // 
            this.clientExtrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenWebsite});
            this.clientExtrasToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Flash_On_48px;
            this.clientExtrasToolStripMenuItem.Name = "clientExtrasToolStripMenuItem";
            this.clientExtrasToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.clientExtrasToolStripMenuItem.Text = "Client Extras ";
            // 
            // btnOpenWebsite
            // 
            this.btnOpenWebsite.Image = global::VanillaRat.Properties.Resources.Website_48px;
            this.btnOpenWebsite.Name = "btnOpenWebsite";
            this.btnOpenWebsite.Size = new System.Drawing.Size(151, 22);
            this.btnOpenWebsite.Text = "Open Website ";
            this.btnOpenWebsite.Click += new System.EventHandler(this.btnOpenWebsite_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(71, 321);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(102, 23);
            this.btnStartServer.TabIndex = 1;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(179, 321);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(102, 23);
            this.btnStopServer.TabIndex = 2;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(395, 321);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(102, 23);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnBuilder
            // 
            this.btnBuilder.Location = new System.Drawing.Point(287, 321);
            this.btnBuilder.Name = "btnBuilder";
            this.btnBuilder.Size = new System.Drawing.Size(102, 23);
            this.btnBuilder.TabIndex = 4;
            this.btnBuilder.Text = "Builder";
            this.btnBuilder.UseVisualStyleBackColor = true;
            this.btnBuilder.Click += new System.EventHandler(this.btnBuilder_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 326);
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
            // btnStopRD
            // 
            this.btnStopRD.Location = new System.Drawing.Point(805, 321);
            this.btnStopRD.Name = "btnStopRD";
            this.btnStopRD.Size = new System.Drawing.Size(143, 23);
            this.btnStopRD.TabIndex = 8;
            this.btnStopRD.Text = "Stop Remote Desktop";
            this.btnStopRD.UseVisualStyleBackColor = true;
            this.btnStopRD.Click += new System.EventHandler(this.btnStopRD_Click);
            // 
            // btnStartRD
            // 
            this.btnStartRD.Location = new System.Drawing.Point(954, 321);
            this.btnStartRD.Name = "btnStartRD";
            this.btnStartRD.Size = new System.Drawing.Size(143, 23);
            this.btnStartRD.TabIndex = 9;
            this.btnStartRD.Text = "Start Remote Desktop";
            this.btnStartRD.UseVisualStyleBackColor = true;
            this.btnStartRD.Click += new System.EventHandler(this.btnStartRD_Click);
            // 
            // bwUpdateImage
            // 
            this.bwUpdateImage.WorkerSupportsCancellation = true;
            this.bwUpdateImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwUpdateImage_DoWork);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(503, 323);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(296, 20);
            this.txtStatus.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbConnectedClients);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 303);
            this.panel1.TabIndex = 7;
            // 
            // lbConnectedClients
            // 
            this.lbConnectedClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbConnectedClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chConnectionId,
            this.chIP,
            this.chTag});
            this.lbConnectedClients.ContextMenuStrip = this.ClientMenu;
            this.lbConnectedClients.FullRowSelect = true;
            this.lbConnectedClients.GridLines = true;
            this.lbConnectedClients.Location = new System.Drawing.Point(-1, -1);
            this.lbConnectedClients.MultiSelect = false;
            this.lbConnectedClients.Name = "lbConnectedClients";
            this.lbConnectedClients.Size = new System.Drawing.Size(485, 299);
            this.lbConnectedClients.TabIndex = 0;
            this.lbConnectedClients.UseCompatibleStateImageBehavior = false;
            this.lbConnectedClients.View = System.Windows.Forms.View.Details;
            this.lbConnectedClients.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            this.lbConnectedClients.SelectedIndexChanged += new System.EventHandler(this.lbConnectedClients_SelectedIndexChanged);
            // 
            // chConnectionId
            // 
            this.chConnectionId.Text = "ID";
            this.chConnectionId.Width = 98;
            // 
            // chIP
            // 
            this.chIP.Text = "IP Address";
            this.chIP.Width = 192;
            // 
            // chTag
            // 
            this.chTag.Text = "Client Tag";
            this.chTag.Width = 192;
            // 
            // pbDesktop
            // 
            this.pbDesktop.BackColor = System.Drawing.SystemColors.Window;
            this.pbDesktop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDesktop.Location = new System.Drawing.Point(503, 12);
            this.pbDesktop.Name = "pbDesktop";
            this.pbDesktop.Size = new System.Drawing.Size(594, 303);
            this.pbDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDesktop.TabIndex = 6;
            this.pbDesktop.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 350);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnStartRD);
            this.Controls.Add(this.btnStopRD);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbDesktop);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnBuilder);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnStartServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "Vanilla Rat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ClientMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDesktop)).EndInit();
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
        private System.Windows.Forms.PictureBox pbDesktop;
        private System.Windows.Forms.Button btnStopRD;
        private System.Windows.Forms.Button btnStartRD;
        private System.ComponentModel.BackgroundWorker bwUpdateImage;
        private System.Windows.Forms.TextBox txtStatus;
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
    }
}

