using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace HmAppBitChecker
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool GetBinaryType(string lpApplicationName, out BinaryType lpBinaryType);
        public enum BinaryType : uint
        {
            SCS_32BIT_BINARY = 0, // A 32-bit Windows-based application
            SCS_64BIT_BINARY = 6, // A 64-bit Windows-based application.
            SCS_DOS_BINARY = 1, // An MS-DOS – based application
            SCS_OS216_BINARY = 5, // A 16-bit OS/2-based application
            SCS_PIF_BINARY = 3, // A PIF file that executes an MS-DOS – based application
            SCS_POSIX_BINARY = 4, // A POSIX – based application
            SCS_WOW_BINARY = 2 // A 16-bit Windows-based application
        }
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                string target_path = args[0];

                if (File.Exists(target_path))
                {
                    BinaryType rettype;

                    GetBinaryType(target_path, out rettype);

                    if (rettype == BinaryType.SCS_32BIT_BINARY)
                    {
                        Console.WriteLine("x86");
                        return 32;
                    }
                    if (rettype == BinaryType.SCS_64BIT_BINARY)
                    {
                        Console.WriteLine("x64");
                        return 64;
                    }
                }
            }
            Console.WriteLine("0");
            return 0;
        }
    }
}
