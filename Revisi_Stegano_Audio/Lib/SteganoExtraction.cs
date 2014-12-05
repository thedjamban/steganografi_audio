using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Revisi_Stegano_Audio.Lib
{
    class SteganoExtraction
    {
        public string steganoFileMP3 { get; set; }
        public byte[] bytesMessage { get; set; }
        public long counterLoading;
        public long persenLoading;
        public long totalLoading;

        private byte[] bytesSteganoMP3;

        public bool extractData()
        {
            bytesSteganoMP3 = bytesStegano(steganoFileMP3);
            bytesMessage = extractFromMedia(bytesSteganoMP3);
            if (bytesMessage == null)
                return false;
            return true;
        }

        private byte[] extractFromMedia(byte[] steganoMP3)
        {
            try
            {
                int beginIndexMessage = 0;
                int lastIndexMessage = 0;
                int messageLengthBlock = 0;

                if ((beginIndexMessage = getIndexBegin(steganoMP3)) == 0)
                    return null;
                if ((lastIndexMessage = getIndexLast(steganoMP3)) == 0)
                    return null;

                for (int w = beginIndexMessage; w <= lastIndexMessage; w += Pattern.patternBase)
                {
                    messageLengthBlock++;
                }

                string[] binnaryStegano = new string[steganoMP3.Length];
                string[] binnaryMessage = new string[messageLengthBlock];
                char[] charMessage = new char[messageLengthBlock];
                byte[] tempSteganoMP3 = new byte[messageLengthBlock];

                totalLoading = messageLengthBlock + binnaryMessage.Length + charMessage.Length;

                int indexPattern = beginIndexMessage;
                for (int i = 0; i < messageLengthBlock; i++)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;

                    binnaryMessage[i] = DocCommonFunction.byteToBinnary(steganoMP3[indexPattern]);
                    indexPattern += Pattern.patternBase;
                }

                int j = 0;
                foreach (string b in binnaryMessage)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;

                    charMessage[j] = b[7];
                    j++;
                }

                int n = 0;
                int m = 0;
                string tempBinnaryMessage = string.Empty;
                byte[] message = new byte[charMessage.Length / 8];

                foreach (char c in charMessage)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;

                    tempBinnaryMessage += c;
                    if (n == 7)
                    {
                        message[m] = DocCommonFunction.binnaryToByte(tempBinnaryMessage);
                        n = 0;
                        m++;
                        tempBinnaryMessage = string.Empty;
                        continue;
                    }
                    n++;
                }
                return message;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private byte[] bytesStegano(string fileMedia)
        {
            return DocCommonFunction.readDocumentBytes(fileMedia);
        }

        private int getIndexBegin(byte[] steganoMP3)
        {
            int begin = 0;
            for (int g = 0; g < steganoMP3.Length; g++)
            {
                if (g == steganoMP3.Length - 1)
                    break;
                if (steganoMP3[g + 1] == 171 && steganoMP3[g + 2] == 171 && steganoMP3[g + 3] == 171 && steganoMP3[g + 4] == 171 && steganoMP3[g + 5] == 171)
                {
                    begin = g + 6;
                    break;
                }
            }
            return begin;
        }

        private int getIndexLast(byte[] steganoMP3)
        {
            int last = 0;
            for (int g = steganoMP3.Length - 1; g >= 0; g--)
            {
                if (g < 0)
                    break;
                if (steganoMP3[g - 1] == 171 && steganoMP3[g - 2] == 171 && steganoMP3[g - 3] == 171 && steganoMP3[g - 4] == 171 && steganoMP3[g - 5] == 171)
                {
                    last = g - 5;
                    break;
                }
            }
            return last;
        }
    }
}
