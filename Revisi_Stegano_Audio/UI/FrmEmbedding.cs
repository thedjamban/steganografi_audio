using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Revisi_Stegano_Audio.Lib;
using Revisi_Stegano_Audio.UI.Dialog;
using System.Diagnostics;
using System.Threading;

namespace Revisi_Stegano_Audio.UI
{
    public partial class FrmEmbedding : Form
    {
        private DialogSettingAES frmSettingAES;

        private MediaPlayer mPlayer;
        private ReadSetting rs;
        private SteganoEmbedding stega;
        private FileSizeValidation fileValidation;

        private bool isImage;
        private bool isSuccess;
        private long messageSize;
        private long mediaSize;
        private Thread thread;

        private string cipherData;

        public FrmEmbedding()
        {
            InitializeComponent();
            rs = new ReadSetting();
        }

        #region method-method

        private void exit()
        {
            Application.ExitThread();
        }

        private void restart()
        {
            Application.Restart();
        }

        private void browseFile(TextBox tb)
        {
            openFileDialog1.FileName = string.Empty;
            if (tb == txtMessage)
                openFileDialog1.Filter = "Text File (*.txt)|*.txt|Image File (*.jpg, *.jpeg)|*.jpg;*.jpeg";
            else
                openFileDialog1.Filter = "MP3 File (*.mp3)|*.mp3";

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            tb.Text = openFileDialog1.FileName;
            if (tb.Name == "txtMessage")
            {
                if (openFileDialog1.FilterIndex != 1)
                    isImage = true;
                else
                    isImage = false;
            }
        }

        private void browsePathFolder(TextBox tb)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;

            tb.Text = folderBrowserDialog1.SelectedPath;
        }

        private void infoFile(TextBox tb, Label lbl)
        {
            if (string.IsNullOrEmpty(tb.Text))
                return;
            FileInfo info = new FileInfo(tb.Text);
            lbl.Text = string.Format(info.Length.ToString() + " {0}", "Bytes");

            if (tb.Name == "txtMessage")
                messageSize = info.Length;
            else
                mediaSize = info.Length;

            if (string.IsNullOrEmpty(lblMessageInf.Text) || string.IsNullOrEmpty(lblMediaInf.Text))
                return;

            fileValidation = new FileSizeValidation(messageSize, mediaSize);
            lblStatus.Text = fileValidation.messageValid();
            if (lblStatus.Text.Contains("embedded"))
            {
                lblStatus.ForeColor = Color.Green;
                lblSpaceInf.Text = string.Format(fileValidation.spaceEmpty() + " {0}", "Bytes");
                lblRequirement.Text = string.Format(fileValidation.requirement() + "{0}", "Bytes");
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblRequirement.Text = string.Format(fileValidation.requirement() + "{0}", "Bytes");
                lblSpaceInf.Text = string.Empty;
            }
        }

        private void playMedia(string path, string type)
        {
            if (string.IsNullOrEmpty(path))
                return;
            mPlayer.play(@path);
            if (type == "mp3")
            {
                btnPlayMp3.Enabled = false;
                btnPausedMP3.Enabled = true;
                btnStopMP3.Enabled = true;
            }
            else
            {
                btnPlayStegano.Enabled = false;
                btnPausedStegano.Enabled = true;
                btnStopStegano.Enabled = true;
            }
        }

        private void pauseMedia(string type)
        {
            mPlayer.pause();
            if (type == "mp3")
            {
                btnPlayMp3.Enabled = true;
                btnStopMP3.Enabled = true;
                btnPausedMP3.Enabled = false;
            }
            else
            {
                btnPlayStegano.Enabled = true;
                btnStopStegano.Enabled = true;
                btnPausedStegano.Enabled = false;
            }
        }

        private void stopMedia(string type)
        {
            mPlayer.stop();
            if (type == "mp3")
            {
                btnPausedMP3.Enabled = false;
                btnStopMP3.Enabled = false;
                btnPlayMp3.Enabled = true;
            }
            else
            {
                btnPausedStegano.Enabled = false;
                btnStopStegano.Enabled = false;
                btnPlayStegano.Enabled = true;
            }
        }

        private bool validation()
        {
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                MessageBox.Show("Message path is not filled yet!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtDestination.Text))
            {
                MessageBox.Show("Destination path is not filled yet!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtMedia.Text))
            {
                MessageBox.Show("Media MP3 path is not filled yet!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Please fill the password field with 6 characters minimal!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(lblSpaceInf.Text))
            {
                MessageBox.Show(lblStatus.Text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool encrypt()
        {
            cipherData = string.Empty;
            if (isImage == true)
                cipherData = CryptoAES.encrypt(
                       Convert.ToBase64String(DocCommonFunction.readDocumentBytes(txtMessage.Text)),
                       txtPassword.Text,
                       rs.keySize(),
                       rs.keySalt(),
                       rs.padding(),
                       rs.cipher());
            else
                cipherData = CryptoAES.encrypt(
                    DocCommonFunction.readDocumentString(txtMessage.Text),
                       txtPassword.Text,
                       rs.keySize(),
                       rs.keySalt(),
                       rs.padding(),
                       rs.cipher());

            if (string.IsNullOrEmpty(cipherData))
                return false;
            return true;
        }

        private void embedding()
        {
            stega = new SteganoEmbedding();
            stega.fileMedia = txtMedia.Text;
            stega.data = cipherData;
            if (stega.embeddingData())
            {
                DocCommonFunction.createDocumentBytes(@txtDestination.Text + @"\SteganoFile.mp3", stega.stegofileMp3);
                DocCommonFunction.createDocumentString(@txtDestination.Text + @"\Cipher.txt", cipherData);
                MessageBox.Show("Embedding data success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSuccess = true;
            }
            else
            {
                MessageBox.Show("Embedding data failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isSuccess = false;
            }
        }

        private void openSetting()
        {
            if (frmSettingAES == null || frmSettingAES.IsDisposed)
                frmSettingAES = new DialogSettingAES(
                    rs.keySize().ToString(),
                    rs.keySalt(),
                    rs.padding().ToString(),
                    rs.cipher().ToString());
            frmSettingAES.ShowDialog(this);
        }

        private void openFile(string path)
        {
            if(string.IsNullOrEmpty(path))
                return;
            Process.Start(@path);
        }

        private void reset()
        {
            txtMessage.Text = string.Empty;
            txtMedia.Text = string.Empty;
            txtDestination.Text = string.Empty;
            txtPassword.Text = string.Empty;

            lblMessageInf.Text = string.Empty;
            lblMediaInf.Text = string.Empty;
            lblSpaceInf.Text = string.Empty;
            lblStatus.Text = string.Empty;
            lblRequirement.Text = string.Empty;

            lblLoading.Text = "Loading: 0%";
            progressBar2.Value = 0;
        }

        private void initMPlayer(string path)
        {
            if (string.IsNullOrEmpty(@path))
                return;
            mPlayer = new MediaPlayer();
        }

        private void enableComponents(bool bol)
        {
            fileToolStripMenuItem.Enabled = bol;
            settingToolStripMenuItem.Enabled = bol;
            txtMessage.Enabled = bol;
            txtDestination.Enabled = bol;
            txtMedia.Enabled = bol;
            txtPassword.Enabled = bol;
            txtStegofilePath.Enabled = bol;
            btnOpenMessage.Enabled = bol;
            btnBrowseDestination.Enabled = bol;
            btnOpenMedia.Enabled = bol;
            btnPlayMp3.Enabled = bol;
            btnPlayStegano.Enabled = bol;
            btnOpenFile.Enabled = bol;
            btnEmbedding.Enabled = bol;
            btnRestart.Enabled = bol;
            btnExit.Enabled = bol;
            ControlBox = bol;
        }

        #endregion

        private void FrmEmbedding_FormClosed(object sender, FormClosedEventArgs e)
        {
            exit();
        }

        private void btnOpenMessage_Click(object sender, EventArgs e)
        {
            browseFile(txtMessage);
            infoFile(txtMessage, lblMessageInf);
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            browsePathFolder(txtDestination);
        }

        private void btnOpenMedia_Click(object sender, EventArgs e)
        {
            browseFile(txtMedia);
            infoFile(txtMedia, lblMediaInf);
        }

        private void btnPlayMP3_Click(object sender, EventArgs e)
        {
            playMedia(txtMedia.Text, "mp3");
        }

        private void btnPausedMP3_Click(object sender, EventArgs e)
        {
            pauseMedia("mp3");
        }

        private void btnStopMP3_Click(object sender, EventArgs e)
        {
            stopMedia("mp3");
        }

        private void btnEmbedding_Click(object sender, EventArgs e)
        {
            if (!validation())
                return;
            if (!encrypt())
                return;

            thread = new Thread(new ThreadStart(embedding));
            thread.IsBackground = true;
            thread.Start();
            timer1.Enabled = true;
        }

        private void AESAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSetting();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFile(txtStegofilePath.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void btnPlayStegano_Click(object sender, EventArgs e)
        {
            playMedia(txtStegofilePath.Text, "stegano");
        }

        private void btnPausedStegano_Click(object sender, EventArgs e)
        {
            pauseMedia("stegano");
        }

        private void btnStopStegano_Click(object sender, EventArgs e)
        {
            stopMedia("stegano");
        }

        private void txtMedia_TextChanged(object sender, EventArgs e)
        {
            initMPlayer(txtMedia.Text);
        }

        private void txtStegofilePath_TextChanged(object sender, EventArgs e)
        {
            initMPlayer(txtStegofilePath.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void txtMessage_DoubleClick(object sender, EventArgs e)
        {
            btnOpenMessage_Click(sender, e);
        }

        private void txtDestination_DoubleClick(object sender, EventArgs e)
        {
            btnBrowseDestination_Click(sender, e);
        }

        private void txtMedia_DoubleClick(object sender, EventArgs e)
        {
            btnOpenMedia_Click(sender, e);
        }

        private void txtStegofilePath_DoubleClick(object sender, EventArgs e)
        {
            btnOpenFile_Click(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (thread.IsAlive)
            {
                enableComponents(false);
                lblLoading.Text = "Loading: " + stega.persenLoading.ToString() + "%";
                progressBar2.Value = Convert.ToInt32(stega.persenLoading);
            }
            else
            {
                timer1.Enabled = false;
                enableComponents(true);
                if (isSuccess)
                    txtStegofilePath.Text = @txtDestination.Text + @"\SteganoFile.mp3";
                else
                    txtStegofilePath.Text = string.Empty;
                reset();
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void aESAlgorithmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openSetting();
        }
    }
}
