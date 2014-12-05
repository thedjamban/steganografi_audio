using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace Revisi_Stegano_Audio.Lib
{
    class CryptoAES
    {
        public static string decrypt(string cipherText, string password, int keySize, string salt, PaddingMode padding, CipherMode cipher)
        {
            try
            {
                var keys = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt));
                var alg = new RijndaelManaged { KeySize = keySize, BlockSize = 128, Padding = padding, Mode = cipher };
                alg.Key = keys.GetBytes(alg.KeySize / 8);
                alg.IV = keys.GetBytes(alg.BlockSize / 8);

                byte[] cipherData = Convert.FromBase64String(cipherText);
                ICryptoTransform decryptor = alg.CreateDecryptor(alg.Key, alg.IV);
                MemoryStream ms = new MemoryStream(cipherData);
                CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs, Encoding.UTF8);

                string base64 = sr.ReadToEnd();

                ms.Close();
                cs.Close();
                return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Decrypted Failed!\n" + ex.Message, "Warning");
                return null;
            }
        }

        public static string encrypt(string plainText, string password, int keySize, string salt, PaddingMode padding, CipherMode cipher)
        {
            try
            {
                var keys = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt));
                var alg = new RijndaelManaged { KeySize = keySize, BlockSize = 128, Padding = padding, Mode = cipher };
                alg.Key = keys.GetBytes(alg.KeySize / 8);
                alg.IV = keys.GetBytes(alg.BlockSize / 8);

                ICryptoTransform encryptor = alg.CreateEncryptor(alg.Key, alg.IV);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);

                byte[] plainBytes = Encoding.UTF8.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText)));

                cs.Write(plainBytes, 0, plainBytes.Length);
                cs.FlushFinalBlock();
                byte[] cipherBytes = ms.ToArray();

                ms.Close();
                cs.Close();
                return Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encrypted Failed!\n" + ex.Message, "Warning");
                return null;
            }
        }
    }
}
