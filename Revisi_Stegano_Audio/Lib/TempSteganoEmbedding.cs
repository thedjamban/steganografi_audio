using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Revisi_Stegano_Audio.Lib
{
    class TempSteganoEmbedding
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
                byte[] stegoFile = new byte[media.Length];

                totalLoading = media.Length + message.Length /*+ binnaryMessage.Length*/ +
                    tempBinnaryMedia.Length + tempBinnaryMedia.Length;

                int i = 0;
                foreach (byte b in media)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;
                    binnaryMedia[i] = DocCommonFunction.byteToBinnary(b);
                    i++;
                }

                int j = 0;
                int counter = 0;
                foreach (byte b in message)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;
                    binnaryMessage[j] = DocCommonFunction.byteToBinnary(b);
                    foreach (char c in binnaryMessage[j])
                    {
                        counterLoading++;
                        charBinnaryMessage[counter] = c;
                        counter++;
                    }
                    j++;
                }

                int n = 0;
                int pos = Pattern.patternPositionStart;
                int tempPos = Pattern.patternPositionStart;
                int posRelatif = Pattern.patternBase;
                int maxCek1 = 0;
                int maxCek2 = 0;
                List<int> listArr = new List<int>();
                for (int m = 0; m < tempBinnaryMedia.Length; m++)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;

                    //if (m >= tempBinnaryMedia.Length)
                    //    break;
                    //if (binnaryMedia[m] == "11111111" && binnaryMedia[m + 1] == "11111010")
                    //{
                    //    tempBinnaryMedia[m] = binnaryMedia[m];
                    //    tempBinnaryMedia[m + 1] = binnaryMedia[m];
                    //    tempBinnaryMedia[m + 2] = binnaryMedia[m];
                    //    tempBinnaryMedia[m + 3] = binnaryMedia[m];
                    //    m += 4;
                    //    frameCek++;
                    //    continue;
                    //}

                    //if (m >= tempBinnaryMedia.Length)
                    //    break;
                    tempBinnaryMedia[m] = binnaryMedia[m];

                    if (m == pos - 5 || m == pos - 4 || m == pos - 3 || m == pos - 2 || m == pos - 1)
                        tempBinnaryMedia[m] = "10101011";

                    //int max = 0;
                    //if (m >= pos + charBinnaryMessage.Length)
                    //{
                    //if (m >= pos + max)
                    //{
                    //    if (m == pos + charBinnaryMessage.Length + 1 || m == pos + charBinnaryMessage.Length + 2 ||
                    //        m == pos + charBinnaryMessage.Length + 3 || m == pos + charBinnaryMessage.Length + 4 ||
                    //        m == pos + charBinnaryMessage.Length + 5)
                    //        tempBinnaryMedia[m] = "10101011";
                    //    continue;
                    //}

                    if (n == -1)
                        continue;

                    if (m >= pos && m <= tempBinnaryMedia.Length - pos)
                    {
                        if (m == pos)
                        {
                            tempBinnaryMedia[m] = binnaryMedia[m].Substring(0, 7);
                            tempBinnaryMedia[m] += charBinnaryMessage[n];
                            n++;
                            listArr.Add(m);
                            maxCek2 = m;
                            continue;
                        }
                        //if (((tempPos+posRelatif)-pos)  % posRelatif == 0)
                        //{
                        if (m == tempPos + posRelatif)
                        {
                            if (n == charBinnaryMessage.Length - 1)
                            {
                                //max = n;
                                tempBinnaryMedia[m] = "10101011";
                                tempBinnaryMedia[m + 1] = "10101011";
                                tempBinnaryMedia[m + 2] = "10101011";
                                tempBinnaryMedia[m + 3] = "10101011";
                                tempBinnaryMedia[m + 4] = "10101011";
                                n = -1;
                                maxCek1 = m;
                                m += 6;
                                continue;
                            }
                            tempPos += posRelatif;
                            tempBinnaryMedia[m] = binnaryMedia[m].Substring(0, 7);
                            tempBinnaryMedia[m] += charBinnaryMessage[n];
                            n++;
                            listArr.Add(m);
                            maxCek2 = m;
                        }
                        else
                            tempBinnaryMedia[m] = binnaryMedia[m];
                        //posRelatif++;
                        //pos += posRelatif;
                    }
                }

                int k = 0;
                foreach (string str in tempBinnaryMedia)
                {
                    counterLoading++;
                    persenLoading = (counterLoading * 100) / totalLoading;
                    stegoFile[k] = DocCommonFunction.binnaryToByte(str);
                    k++;
                }

                //int[] sample = new int[2];
                //for (int g = 0; g < stegoFile.Length; g++)
                //{
                //    if (stegoFile[(g + pos) - 1] == 171)
                //    {
                //        sample[0] = (g + pos) - 1;
                //        g += 5;
                //    }
                //    if (stegoFile[maxCek1 + 1] == 171)
                //    {
                //        sample[1] = maxCek1 + 1;
                //        break;
                //    }
                //}

                return stegoFile;
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
