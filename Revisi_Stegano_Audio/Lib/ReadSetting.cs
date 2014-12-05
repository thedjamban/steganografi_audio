using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Revisi_Stegano_Audio.Lib
{
    class ReadSetting
    {
        private string keysize;
        private string salt;
        private string paddingMode;
        private string cipherMode;

        private const PaddingMode paddingPKCS = PaddingMode.PKCS7;
        private const PaddingMode paddingAnsi = PaddingMode.ANSIX923;
        private const PaddingMode paddingIso = PaddingMode.ISO10126;

        private const CipherMode cipherCBC = CipherMode.CBC;
        private const CipherMode cipherECB = CipherMode.ECB;

        public ReadSetting()
        {
            string[] arrLine = File.ReadAllLines(@".\settings.setApp");
            keysize = arrLine[1];
            salt = arrLine[3];
            paddingMode = arrLine[5];
            cipherMode = arrLine[7];
        }

        public int keySize()
        {
            return Convert.ToInt32(keysize);
        }

        public string keySalt()
        {
            return salt;
        }

        public PaddingMode padding()
        {
            if (paddingMode == paddingPKCS.ToString())
                return paddingPKCS;
            else if (paddingMode == paddingAnsi.ToString())
                return paddingAnsi;
            else
                return paddingIso;
        }

        public CipherMode cipher()
        {
            if (cipherMode == cipherCBC.ToString())
                return cipherCBC;
            else
                return cipherECB;
        }
    }
}
