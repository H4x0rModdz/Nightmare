using System.Diagnostics;

namespace Nightmare
{
    public class Cmd
    {
        public static void CmdResource(string filename, string argue)
        {
            ProcessStartInfo cmdProc = new ProcessStartInfo();
            cmdProc.FileName = filename;
            cmdProc.WindowStyle = ProcessWindowStyle.Hidden;
            cmdProc.Arguments = argue;
            Process.Start(cmdProc);
            return;
        }
    }
}