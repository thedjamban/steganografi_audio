using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Revisi_Stegano_Audio.Lib
{
    class DocCommonFunction
    {
        public static byte[] readDocumentBytes(string path)
        {
            return File.ReadAllBytes(@path);
        }

        public static string readDocumentString(string path)
        {
            return File.ReadAllText(@path);
        }

        public static void createDocumentBytes(string path, byte[] data)
        {
            File.WriteAllBytes(@path, data);
        }

        public static void createDocumentString(string path, string data)
        {
            File.WriteAllText(@path, data);
        }

        public static string byteToBinnary(byte data)
        {
            return Convert.ToString(data, 2).PadLeft(8, '0');
        }

        public static byte binnaryToByte(string binnary)
        {
            return Convert.ToByte(binnary, 2);
        }
    }
}
