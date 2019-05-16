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
            this.lblCurrentID = new System.Windows.Forms.ToolStripMenuItem();
            this.clientControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClientKill = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClientDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRaisePerms = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateClient = new System.Windows.Forms.ToolStripMenuItem();
            this.clientComputerControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLockComputer = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetRunningApps = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenComputerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFileBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGrabClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetHardwareUsage = new System.Windows.Forms.ToolStripMenuItem();
            this.clientCommunicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtHeader = new System.Windows.Forms.ToolStripTextBox();
            this.messageToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMessage = new System.Windows.Forms.ToolStripTextBox();
            this.buttonsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cbButtons = new System.Windows.Forms.ToolStripComboBox();
            this.iconToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cbIcons = new System.Windows.Forms.ToolStripComboBox();
            this.btnPreviewMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSendMessageBox = new System.Windows.Forms.ToolStripMenuItem();
            this.sendTextToSpeechToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.messageToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTTSText = new System.Windows.Forms.ToolStripTextBox();
            this.btnSendTTS = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenChat = new System.Windows.Forms.ToolStripMenuItem();
            this.clientExtrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartKL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartRD = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoteShell = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenAudioRecorder = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWebsiteOpener = new System.Windows.Forms.ToolStripMenuItem();
            this.btnToggleAntiProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenMessageBoxDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.headerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendTextToSpeechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnBuilder = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.GetDataLoop = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbConnectedClients = new System.Windows.Forms.ListView();
            this.chConnectionId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAntiVirus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOperatingSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SidebarPanel = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.bwUpdateImage = new System.ComponentModel.BackgroundWorker();
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
            this.clientComputerControlsToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.clientCommunicationToolStripMenuItem,
            this.clientExtrasToolStripMenuItem});
            this.ClientMenu.Name = "ClientMenu";
            this.ClientMenu.Size = new System.Drawing.Size(211, 136);
            // 
            // lblCurrentID
            // 
            this.lblCurrentID.Image = global::VanillaRat.Properties.Resources.Person_48px;
            this.lblCurrentID.Name = "lblCurrentID";
            this.lblCurrentID.Size = new System.Drawing.Size(210, 22);
            this.lblCurrentID.Text = "Client ID: None Selected";
            // 
            // clientControlsToolStripMenuItem
            // 
            this.clientControlsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClientKill,
            this.btnClientDisconnect,
            this.btnRaisePerms,
            this.btnUpdateClient});
            this.clientControlsToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Services_48px;
            this.clientControlsToolStripMenuItem.Name = "clientControlsToolStripMenuItem";
            this.clientControlsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
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
            // btnRaisePerms
            // 
            this.btnRaisePerms.Image = global::VanillaRat.Properties.Resources.Double_Up_48px;
            this.btnRaisePerms.Name = "btnRaisePerms";
            this.btnRaisePerms.Size = new System.Drawing.Size(262, 22);
            this.btnRaisePerms.Text = "Raise Permission Level (Will Restart)";
            this.btnRaisePerms.Click += new System.EventHandler(this.btnRaisePerms_Click);
            // 
            // btnUpdateClient
            // 
            this.btnUpdateClient.Image = global::VanillaRat.Properties.Resources.Restart_48px;
            this.btnUpdateClient.Name = "btnUpdateClient";
            this.btnUpdateClient.Size = new System.Drawing.Size(262, 22);
            this.btnUpdateClient.Text = "Update Client";
            this.btnUpdateClient.Click += new System.EventHandler(this.btnUpdateClient_Click);
            // 
            // clientComputerControlsToolStripMenuItem
            // 
            this.clientComputerControlsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLockComputer});
            this.clientComputerControlsToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Administrative_Tools_48px;
            this.clientComputerControlsToolStripMenuItem.Name = "clientComputerControlsToolStripMenuItem";
            this.clientComputerControlsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.clientComputerControlsToolStripMenuItem.Text = "Client Computer Controls";
            // 
            // btnLockComputer
            // 
            this.btnLockComputer.Image = global::VanillaRat.Properties.Resources.Lock_Landscape_48px;
            this.btnLockComputer.Name = "btnLockComputer";
            this.btnLockComputer.Size = new System.Drawing.Size(174, 22);
            this.btnLockComputer.Text = "Start Screen Locker";
            this.btnLockComputer.Click += new System.EventHandler(this.btnLockComputer_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGetRunningApps,
            this.btnOpenComputerInfo,
            this.btnFileBrowser,
            this.btnGrabClipboard,
            this.btnGetHardwareUsage});
            this.clientToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Info_48px;
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
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
            this.btnOpenComputerInfo.Image = global::VanillaRat.Properties.Resources.Monitor_48px;
            this.btnOpenComputerInfo.Name = "btnOpenComputerInfo";
            this.btnOpenComputerInfo.Size = new System.Drawing.Size(209, 22);
            this.btnOpenComputerInfo.Text = "Get Computer Info";
            this.btnOpenComputerInfo.Click += new System.EventHandler(this.btnOpenComputerInfo_Click);
            // 
            // btnFileBrowser
            // 
            this.btnFileBrowser.Image = global::VanillaRat.Properties.Resources.Opened_Folder_48px;
            this.btnFileBrowser.Name = "btnFileBrowser";
            this.btnFileBrowser.Size = new System.Drawing.Size(209, 22);
            this.btnFileBrowser.Text = "Open File Browser";
            this.btnFileBrowser.Click += new System.EventHandler(this.btnOpenFileBrowser_Click);
            // 
            // btnGrabClipboard
            // 
            this.btnGrabClipboard.Image = global::VanillaRat.Properties.Resources.Document_48px;
            this.btnGrabClipboard.Name = "btnGrabClipboard";
            this.btnGrabClipboard.Size = new System.Drawing.Size(209, 22);
            this.btnGrabClipboard.Text = "Get Clipboard Text";
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
            this.sendMessageToolStripMenuItem,
            this.sendTextToSpeechToolStripMenuItem1,
            this.btnOpenChat});
            this.clientCommunicationToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Communication_48px;
            this.clientCommunicationToolStripMenuItem.Name = "clientCommunicationToolStripMenuItem";
            this.clientCommunicationToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.clientCommunicationToolStripMenuItem.Text = "Client Communication";
            // 
            // sendMessageToolStripMenuItem
            // 
            this.sendMessageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.headerToolStripMenuItem1,
            this.messageToolStripMenuItem2,
            this.buttonsToolStripMenuItem1,
            this.iconToolStripMenuItem1,
            this.btnPreviewMessage,
            this.btnSendMessageBox});
            this.sendMessageToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Paper_Plane_48px;
            this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
            this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.sendMessageToolStripMenuItem.Text = "Send Message Box";
            // 
            // headerToolStripMenuItem1
            // 
            this.headerToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtHeader});
            this.headerToolStripMenuItem1.Name = "headerToolStripMenuItem1";
            this.headerToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.headerToolStripMenuItem1.Text = "Header";
            // 
            // txtHeader
            // 
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(100, 23);
            // 
            // messageToolStripMenuItem2
            // 
            this.messageToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtMessage});
            this.messageToolStripMenuItem2.Name = "messageToolStripMenuItem2";
            this.messageToolStripMenuItem2.Size = new System.Drawing.Size(123, 22);
            this.messageToolStripMenuItem2.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(100, 23);
            // 
            // buttonsToolStripMenuItem1
            // 
            this.buttonsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbButtons});
            this.buttonsToolStripMenuItem1.Name = "buttonsToolStripMenuItem1";
            this.buttonsToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.buttonsToolStripMenuItem1.Text = "Button(s)";
            // 
            // cbButtons
            // 
            this.cbButtons.Items.AddRange(new object[] {
            "Abort Retry Ignore ",
            "OK",
            "OK Cancel",
            "Retry Cancel",
            "Yes No",
            "Yes No Cancel"});
            this.cbButtons.Name = "cbButtons";
            this.cbButtons.Size = new System.Drawing.Size(121, 23);
            // 
            // iconToolStripMenuItem1
            // 
            this.iconToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbIcons});
            this.iconToolStripMenuItem1.Name = "iconToolStripMenuItem1";
            this.iconToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.iconToolStripMenuItem1.Text = "Icon";
            // 
            // cbIcons
            // 
            this.cbIcons.Items.AddRange(new object[] {
            "Asterisk",
            "Error",
            "Exclamation",
            "Hand",
            "Information ",
            "None",
            "Question",
            "Stop",
            "Warning"});
            this.cbIcons.Name = "cbIcons";
            this.cbIcons.Size = new System.Drawing.Size(121, 23);
            // 
            // btnPreviewMessage
            // 
            this.btnPreviewMessage.Name = "btnPreviewMessage";
            this.btnPreviewMessage.Size = new System.Drawing.Size(123, 22);
            this.btnPreviewMessage.Text = "Preview";
            this.btnPreviewMessage.Click += new System.EventHandler(this.btnPreviewMessage_Click);
            // 
            // btnSendMessageBox
            // 
            this.btnSendMessageBox.Name = "btnSendMessageBox";
            this.btnSendMessageBox.Size = new System.Drawing.Size(123, 22);
            this.btnSendMessageBox.Text = "Send";
            this.btnSendMessageBox.Click += new System.EventHandler(this.btnSendMessageBox_Click);
            // 
            // sendTextToSpeechToolStripMenuItem1
            // 
            this.sendTextToSpeechToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripMenuItem3,
            this.btnSendTTS});
            this.sendTextToSpeechToolStripMenuItem1.Image = global::VanillaRat.Properties.Resources.Paper_Plane_48px;
            this.sendTextToSpeechToolStripMenuItem1.Name = "sendTextToSpeechToolStripMenuItem1";
            this.sendTextToSpeechToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.sendTextToSpeechToolStripMenuItem1.Text = "Send Text To Speech";
            // 
            // messageToolStripMenuItem3
            // 
            this.messageToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtTTSText});
            this.messageToolStripMenuItem3.Name = "messageToolStripMenuItem3";
            this.messageToolStripMenuItem3.Size = new System.Drawing.Size(120, 22);
            this.messageToolStripMenuItem3.Text = "Message";
            // 
            // txtTTSText
            // 
            this.txtTTSText.Name = "txtTTSText";
            this.txtTTSText.Size = new System.Drawing.Size(100, 23);
            // 
            // btnSendTTS
            // 
            this.btnSendTTS.Name = "btnSendTTS";
            this.btnSendTTS.Size = new System.Drawing.Size(120, 22);
            this.btnSendTTS.Text = "Send";
            this.btnSendTTS.Click += new System.EventHandler(this.btnSendTTS_Click);
            // 
            // btnOpenChat
            // 
            this.btnOpenChat.Image = global::VanillaRat.Properties.Resources.Chat_48px;
            this.btnOpenChat.Name = "btnOpenChat";
            this.btnOpenChat.Size = new System.Drawing.Size(181, 22);
            this.btnOpenChat.Text = "Open Chat";
            this.btnOpenChat.Click += new System.EventHandler(this.btnOpenChat_Click);
            // 
            // clientExtrasToolStripMenuItem
            // 
            this.clientExtrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartKL,
            this.btnStartRD,
            this.btnRemoteShell,
            this.btnOpenAudioRecorder,
            this.btnWebsiteOpener,
            this.btnToggleAntiProcess});
            this.clientExtrasToolStripMenuItem.Image = global::VanillaRat.Properties.Resources.Flash_On_48px;
            this.clientExtrasToolStripMenuItem.Name = "clientExtrasToolStripMenuItem";
            this.clientExtrasToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.clientExtrasToolStripMenuItem.Text = "Client Extras ";
            // 
            // btnStartKL
            // 
            this.btnStartKL.Image = global::VanillaRat.Properties.Resources.Compose_48px;
            this.btnStartKL.Name = "btnStartKL";
            this.btnStartKL.Size = new System.Drawing.Size(187, 22);
            this.btnStartKL.Text = "Live Keylogger";
            this.btnStartKL.Click += new System.EventHandler(this.btnStartKL_Click);
            // 
            // btnStartRD
            // 
            this.btnStartRD.Image = global::VanillaRat.Properties.Resources.Laptop_48px;
            this.btnStartRD.Name = "btnStartRD";
            this.btnStartRD.Size = new System.Drawing.Size(187, 22);
            this.btnStartRD.Text = "Remote Desktop";
            this.btnStartRD.Click += new System.EventHandler(this.btnStartRD_Click);
            // 
            // btnRemoteShell
            // 
            this.btnRemoteShell.Image = global::VanillaRat.Properties.Resources.Console_48px;
            this.btnRemoteShell.Name = "btnRemoteShell";
            this.btnRemoteShell.Size = new System.Drawing.Size(187, 22);
            this.btnRemoteShell.Text = "Remote Shell";
            this.btnRemoteShell.Click += new System.EventHandler(this.btnRemoteShell_Click);
            // 
            // btnOpenAudioRecorder
            // 
            this.btnOpenAudioRecorder.Image = global::VanillaRat.Properties.Resources.Headphones_48px;
            this.btnOpenAudioRecorder.Name = "btnOpenAudioRecorder";
            this.btnOpenAudioRecorder.Size = new System.Drawing.Size(187, 22);
            this.btnOpenAudioRecorder.Text = "Audio Recorder (Mic)";
            this.btnOpenAudioRecorder.Click += new System.EventHandler(this.btnOpenAudioRecorder_Click);
            // 
            // btnWebsiteOpener
            // 
            this.btnWebsiteOpener.Image = global::VanillaRat.Properties.Resources.Website_48px;
            this.btnWebsiteOpener.Name = "btnWebsiteOpener";
            this.btnWebsiteOpener.Size = new System.Drawing.Size(187, 22);
            this.btnWebsiteOpener.Text = "Open Website";
            this.btnWebsiteOpener.Click += new System.EventHandler(this.btnWebsiteOpener_Click);
            // 
            // btnToggleAntiProcess
            // 
            this.btnToggleAntiProcess.Image = global::VanillaRat.Properties.Resources.Close_Window_48px;
            this.btnToggleAntiProcess.Name = "btnToggleAntiProcess";
            this.btnToggleAntiProcess.Size = new System.Drawing.Size(187, 22);
            this.btnToggleAntiProcess.Text = "Toggle Anti-Process";
            this.btnToggleAntiProcess.Click += new System.EventHandler(this.btnToggleAntiProcess_Click);
            // 
            // btnOpenMessageBoxDialog
            // 
            this.btnOpenMessageBoxDialog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.headerToolStripMenuItem,
            this.messageToolStripMenuItem,
            this.buttonsToolStripMenuItem,
            this.iconToolStripMenuItem});
            this.btnOpenMessageBoxDialog.Name = "btnOpenMessageBoxDialog";
            this.btnOpenMessageBoxDialog.Size = new System.Drawing.Size(181, 22);
            this.btnOpenMessageBoxDialog.Text = "Send Message Box";
            // 
            // headerToolStripMenuItem
            // 
            this.headerToolStripMenuItem.Name = "headerToolStripMenuItem";
            this.headerToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.headerToolStripMenuItem.Text = "Header";
            // 
            // messageToolStripMenuItem
            // 
            this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
            this.messageToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.messageToolStripMenuItem.Text = "Message ";
            // 
            // buttonsToolStripMenuItem
            // 
            this.buttonsToolStripMenuItem.Name = "buttonsToolStripMenuItem";
            this.buttonsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.buttonsToolStripMenuItem.Text = "Buttons";
            // 
            // iconToolStripMenuItem
            // 
            this.iconToolStripMenuItem.Name = "iconToolStripMenuItem";
            this.iconToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.iconToolStripMenuItem.Text = "Icon";
            // 
            // sendTextToSpeechToolStripMenuItem
            // 
            this.sendTextToSpeechToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripMenuItem1});
            this.sendTextToSpeechToolStripMenuItem.Name = "sendTextToSpeechToolStripMenuItem";
            this.sendTextToSpeechToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.sendTextToSpeechToolStripMenuItem.Text = "Send Text To Speech";
            // 
            // messageToolStripMenuItem1
            // 
            this.messageToolStripMenuItem1.Name = "messageToolStripMenuItem1";
            this.messageToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.messageToolStripMenuItem1.Text = "Message";
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
            this.lbConnectedClients.Location = new System.Drawing.Point(6, 0);
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
            this.lblVersion.Size = new System.Drawing.Size(40, 16);
            this.lblVersion.TabIndex = 9;
            this.lblVersion.Text = "v1.6.1";
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_Click);
            // 
            // bwUpdateImage
            // 
            this.bwUpdateImage.WorkerSupportsCancellation = true;
            this.bwUpdateImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwUpdateImage_DoWork);
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
        private System.Windows.Forms.ToolStripMenuItem clientCommunicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnOpenMessageBoxDialog;
        private System.Windows.Forms.ToolStripMenuItem headerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientExtrasToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lbConnectedClients;
        private System.Windows.Forms.ColumnHeader chConnectionId;
        private System.Windows.Forms.ColumnHeader chIP;
        private System.Windows.Forms.ColumnHeader chTag;
        private System.Windows.Forms.Panel SidebarPanel;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripMenuItem btnAudioRecorder;
        private System.Windows.Forms.ColumnHeader chAntiVirus;
        private System.Windows.Forms.ColumnHeader chOperatingSystem;
        private System.Windows.Forms.ToolStripMenuItem lblCurrentID;
        private System.ComponentModel.BackgroundWorker bwUpdateImage;
        private System.Windows.Forms.ToolStripMenuItem sendTextToSpeechToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientComputerControlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnGetRunningApps;
        private System.Windows.Forms.ToolStripMenuItem btnOpenComputerInfo;
        private System.Windows.Forms.ToolStripMenuItem btnFileBrowser;
        private System.Windows.Forms.ToolStripMenuItem btnGrabClipboard;
        private System.Windows.Forms.ToolStripMenuItem btnGetHardwareUsage;
        private System.Windows.Forms.ToolStripMenuItem sendMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendTextToSpeechToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnOpenChat;
        private System.Windows.Forms.ToolStripMenuItem btnStartKL;
        private System.Windows.Forms.ToolStripMenuItem btnStartRD;
        private System.Windows.Forms.ToolStripMenuItem btnOpenAudioRecorder;
        private System.Windows.Forms.ToolStripMenuItem btnRemoteShell;
        private System.Windows.Forms.ToolStripMenuItem btnWebsiteOpener;
        private System.Windows.Forms.ToolStripMenuItem btnToggleAntiProcess;
        private System.Windows.Forms.ToolStripMenuItem btnRaisePerms;
        private System.Windows.Forms.ToolStripMenuItem btnUpdateClient;
        private System.Windows.Forms.ToolStripMenuItem btnLockComputer;
        private System.Windows.Forms.ToolStripMenuItem headerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox txtHeader;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem buttonsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iconToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnPreviewMessage;
        private System.Windows.Forms.ToolStripMenuItem btnSendMessageBox;
        private System.Windows.Forms.ToolStripTextBox txtMessage;
        private System.Windows.Forms.ToolStripComboBox cbButtons;
        private System.Windows.Forms.ToolStripComboBox cbIcons;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem3;
        private System.Windows.Forms.ToolStripTextBox txtTTSText;
        private System.Windows.Forms.ToolStripMenuItem btnSendTTS;
    }
}

