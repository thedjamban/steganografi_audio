using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Revisi_Stegano_Audio.Lib
{
    class SteganoEmbedding
    {
        public string fileMedia { get; set; }
        public string data { get; set; }
        public byte[] stegofileMp3 { get; set; }
        public long counterLoading;
        public long persenLoading;
        public long totalLoading;

        private byte[] bytesMp3;
        private byte[] bytesData;

        public bool embeddingData()
        {
            bytesMp3 = bytesMedia(fileMedia);
            bytesData = bytesMessage(data);
            stegofileMp3 = embeddToMedia(bytesMp3, bytesData);
            if (stegofileMp3 == null)
                return false;
            return true;
        }

        private byte[] embeddToMedia(byte[] media, byte[] message)
        {
            try
            {
                string[] binnaryMedia = new string[media.Length];
                string[] binnaryMessage = new string[message.Length];
                string[] tempBinnaryMedia = new string[media.Length];
                char[] charBinnaryMessage = new char[8 * binnaryMessage.Length];
                byte[] steganoFile = new byte[media.Length];

                totalLoading = media.Length + message.Length + tempBinnaryMedia.Length + tempBinnaryMedia.Length;

                int i = 0;
                foreach (byte b in media)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;
                    binnaryMedia[i] = DocCommonFunction.byteToBinnary(b);
                    i++;
                }

                int j = 0;
                int k = 0;
                foreach (byte b in message)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;
                    binnaryMessage[j] = DocCommonFunction.byteToBinnary(b);
                    foreach (char c in binnaryMessage[j])
                    {
                        counterLoading++;
                        totalLoading++;
                        charBinnaryMessage[k] = c;
                        k++;
                    }
                    totalLoading--;
                    j++;
                }

                int indexStart = Pattern.patternPositionStart;
                int tempIndexStart = Pattern.patternPositionStart;
                int multipleBase = Pattern.patternBase;
                int n = 0;
                for (int m = 0; m < tempBinnaryMedia.Length; m++)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;

                    tempBinnaryMedia[m] = binnaryMedia[m];
                    if (m == indexStart - 5 || m == indexStart - 4 || m == indexStart - 3 || m == indexStart - 2 || m == indexStart - 1)
                        tempBinnaryMedia[m] = "10101011";
                    if (n == -1)
                        continue;
                    if (m >= indexStart && m <= tempBinnaryMedia.Length - indexStart)
                    {
                        if (m == indexStart)
                        {
                            tempBinnaryMedia[m] = binnaryMedia[m].Substring(0, 7);
                            tempBinnaryMedia[m] += charBinnaryMessage[n];
                            n++;
                            continue;
                        }
                        if (m == tempIndexStart + multipleBase)
                        {
                            if (n == charBinnaryMessage.Length - 1)
                            {
                                tempBinnaryMedia[m] = "10101011";
                                tempBinnaryMedia[m + 1] = "10101011";
                                tempBinnaryMedia[m + 2] = "10101011";
                                tempBinnaryMedia[m + 3] = "10101011";
                                tempBinnaryMedia[m + 4] = "10101011";
                                n = -1;
                                m += 6;
                                continue;
                            }
                            tempIndexStart += multipleBase;
                            tempBinnaryMedia[m] = binnaryMedia[m].Substring(0, 7);
                            tempBinnaryMedia[m] += charBinnaryMessage[n];
                            n++;
                        }
                        else
                            tempBinnaryMedia[m] = binnaryMedia[m];
                    }
                }

                int p = 0;
                foreach (string str in tempBinnaryMedia)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;
                    steganoFile[p] = DocCommonFunction.binnaryToByte(str);
                    p++;
                }

                return steganoFile;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private byte[] bytesMessage(string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        private byte[] bytesMedia(string fileMedia)
        {
            return DocCommonFunction.readDocumentBytes(@fileMedia);
        }
    }
}
