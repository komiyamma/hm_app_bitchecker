using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HmAppBitChecker
{
    internal class Program
    {
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                string target_path = args[0];

                if (File.Exists(target_path))
                {
                    FileStream fs = new FileStream(target_path, FileMode.Open, FileAccess.Read);

                    const int HEADER_BUF_SIZE = 1024;
                    byte[] buf = new byte[HEADER_BUF_SIZE]; // データ格納用配列

                    long remain = (long)fs.Length; // 読み込むべき残りのバイト数
                    int readSize = fs.Read(buf, 0, (int)Math.Min(1024, remain));

                    fs.Dispose();

                    // x86プログラムなら通常先頭1024バイトまでに以下の並びがある
                    byte[] byteArrX86 = { 0x50, 0x45, 0x00, 0x00, 0x4C, 0x01 };

                    // x64プログラムなら通常先頭1024バイトまでに以下の並びがある
                    byte[] byteArrX64 = { 0x50, 0x45, 0x00, 0x00, 0x64, 0x86 };

                    int hitCountX86 = 0;
                    int hitCountX64 = 0;
                    foreach (byte b in buf)
                    {
                        if (b == byteArrX86[hitCountX86])
                        {
                            hitCountX86++;
                        }
                        else
                        {
                            hitCountX86 = 0;
                        }

                        if (b == byteArrX64[hitCountX64])
                        {
                            hitCountX64++;
                        }
                        else
                        {
                            hitCountX64 = 0;
                        }

                        if (hitCountX86 == byteArrX86.Length)
                        {
                            break;
                        }
                        if (hitCountX64 == byteArrX64.Length)
                        {
                            break;
                        }
                    }

                    if (hitCountX86 == byteArrX86.Length)
                    {
                        Console.WriteLine("x86");
                        return 32;
                    }
                    if (hitCountX64 == byteArrX64.Length)
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
