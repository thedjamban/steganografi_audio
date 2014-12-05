using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Revisi_Stegano_Audio.Lib
{
    class TempSteganoExtraction
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
                int begin = 0;
                int last = 0;
                int pattern = 0;

                if ((begin = posBegin(steganoMP3)) == 0)
                    return null;

                if ((last = posLast(steganoMP3)) == 0)
                    return null;

                for (int w = begin; w <= last; w += Pattern.patternBase)
                {
                    pattern++;
                }

                string[] binnaryStegano = new string[steganoMP3.Length];
                //string[] binnaryMessage = new string[last - begin];
                string[] binnaryMessage = new string[pattern];
                char[] charMessage = new char[binnaryMessage.Length];
                totalLoading = pattern + binnaryMessage.Length;

                byte[] tempSteganoMP3 = new byte[pattern];

                int d = 0;
                for (int g = 0; g < steganoMP3.Length; g++)
                {
                    if (g >= Pattern.patternPositionStart)
                    {
                        if (d == pattern)
                            break;
                        if (g % Pattern.patternBase == 0)
                        {
                            tempSteganoMP3[d] = steganoMP3[g];
                            d++;
                        }
                    }
                }

                //int pos = begin;
                int indexPattern = begin;
                for (int i = 0; i < pattern; i++)
                {
                    //if (indexPattern == begin || indexPattern % Pattern.patternBase == 0)
                    //{
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;
                    binnaryMessage[i] = DocCommonFunction.byteToBinnary(steganoMP3[indexPattern]);
                    //binnaryMessage[i] = DocCommonFunction.byteToBinnary(tempSteganoMP3[i]);
                    indexPattern += Pattern.patternBase;
                    //}
                    //pos++;
                }

                int j = 0;
                foreach (string b in binnaryMessage)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;
                    charMessage[j] = b[7];
                    j++;
                }

                int k = 0;
                int m = 0;
                string tempBinnaryMessage = null;
                byte[] message = new byte[charMessage.Length / 8];
                totalLoading += charMessage.Length;

                foreach (char c in charMessage)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;
                    tempBinnaryMessage += c;
                    if (k == 7)
                    {
                        message[m] = DocCommonFunction.binnaryToByte(tempBinnaryMessage);
                        k = 0;
                        tempBinnaryMessage = null;
                        m++;
                        continue;
                    }
                    k++;
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

        private int posBegin(byte[] steganoMP3)
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

        private int posLast(byte[] steganoMP3)
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
