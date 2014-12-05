using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Revisi_Stegano_Audio.Lib;
using Revisi_Stegano_Audio.UI.Dialog;
using System.Diagnostics;
using System.Threading;

namespace Revisi_Stegano_Audio.UI
{
    public partial class FrmExtraction : Form
    {
        private DialogSettingAES frmSettingAES;

        private MediaPlayer mPlayer;
        private ReadSetting rs;
        private SteganoExtraction stega;

        private bool isImage;
        private bool isSuccess;
        private string plainText;
        private Thread thread;

        public FrmExtraction()
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
        }

        private void browsePathFolder(TextBox tb)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;

            tb.Text = folderBrowserDialog1.SelectedPath;
        }

        private void initMPlayer(string path)
        {
            if (string.IsNullOrEmpty(@path))
                return;
            mPlayer = new MediaPlayer();
        }

        private void playMedia(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            mPlayer.play(@path);
            btnPlaySteganoMP3.Enabled = false;
            btnPausedSteganoMP3.Enabled = true;
            btnStopSteganoMP3.Enabled = true;
        }

        private void pauseMedia()
        {
            mPlayer.pause();
            btnPlaySteganoMP3.Enabled = true;
            btnStopSteganoMP3.Enabled = true;
            btnPausedSteganoMP3.Enabled = false;
        }

        private void stopMedia()
        {
            mPlayer.stop();
            btnPausedSteganoMP3.Enabled = false;
            btnStopSteganoMP3.Enabled = false;
            btnPlaySteganoMP3.Enabled = true;
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

        private bool validation()
        {
            if (string.IsNullOrEmpty(txtSteganofile.Text))
            {
                MessageBox.Show("Steganofile path is not filled yet!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtDestinaion.Text))
            {
                MessageBox.Show("Destination path is not filled yet!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Please fill the password field with 6 characters minimal!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool decrypt(string cipherData)
        {
            plainText = string.Empty;
            plainText = CryptoAES.decrypt(
                cipherData,
                txtPassword.Text,
                rs.keySize(),
                rs.keySalt(),
                rs.padding(),
                rs.cipher());
            if (!string.IsNullOrEmpty(plainText))
                return true;
            return false;
        }

        private void extraction()
        {
            stega = new SteganoExtraction();
            stega.steganoFileMP3 = txtSteganofile.Text;

            if (stega.extractData())
            {
                if (!decrypt(Encoding.UTF8.GetString(stega.bytesMessage)))
                    return;
                if (isImage)
                {
                    byte[] blob = Convert.FromBase64String(plainText);
                    DocCommonFunction.createDocumentBytes(@txtDestinaion.Text + @"\Image Message.jpg", blob);
                }
                else
                    DocCommonFunction.createDocumentString(@txtDestinaion.Text + @"\Text Message.txt", plainText);

                MessageBox.Show("Extraction data success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSuccess = true;
            }
            else
            {
                MessageBox.Show("Extraction data failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isSuccess = false;
            }
        }

        private void reset()
        {
            txtSteganofile.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtDestinaion.Text = string.Empty;

            lblLoading.Text = "Loading: 0%";
            progressBar1.Value = 0;
        }

        private void openFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;
            Process.Start(@path);
        }

        private void enableComonents(bool bol)
        {
            fileToolStripMenuItem.Enabled = bol;
            settingToolStripMenuItem.Enabled = bol;
            txtSteganofile.Enabled = bol;
            txtMessage.Enabled = bol;
            txtDestinaion.Enabled = bol;
            txtPassword.Enabled = bol;
            cbIsImage.Enabled = bol;
            btnPlaySteganoMP3.Enabled = bol;
            btnOpenSteganofile.Enabled = bol;
            btnOpenMessage.Enabled = bol;
            btnBrowseDestination.Enabled = bol;
            btnExtraction.Enabled = bol;
            btnExit.Enabled = bol;
            btnRestart.Enabled = bol;
            ControlBox = bol;
        }

        #endregion

        private void btnOpenSteganofile_Click(object sender, EventArgs e)
        {
            browseFile(txtSteganofile);
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            browsePathFolder(txtDestinaion);
        }

        private void btnExtraction_Click(object sender, EventArgs e)
        {
            if (!validation())
                return;
            thread = new Thread(new ThreadStart(extraction));
            thread.IsBackground = true;
            thread.Start();
            timer1.Enabled = true;
        }

        private void btnOpenMessage_Click(object sender, EventArgs e)
        {
            openFile(txtMessage.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void cryptographySettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSetting();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void FrmExtraction_FormClosed(object sender, FormClosedEventArgs e)
        {
            exit();
        }

        private void btnPlaySteganoMP3_Click(object sender, EventArgs e)
        {
            playMedia(txtSteganofile.Text);
        }

        private void btnPausedSteganoMP3_Click(object sender, EventArgs e)
        {
            pauseMedia();
        }

        private void btnStopSteganoMP3_Click(object sender, EventArgs e)
        {
            stopMedia();
        }

        private void txtSteganofile_DoubleClick(object sender, EventArgs e)
        {
            browseFile(txtSteganofile);
        }

        private void txtDestinaion_DoubleClick(object sender, EventArgs e)
        {
            btnBrowseDestination_Click(sender, e);
        }

        private void txtMessage_DoubleClick(object sender, EventArgs e)
        {
            btnOpenMessage_Click(sender, e);
        }

        private void txtSteganofile_TextChanged(object sender, EventArgs e)
        {
            initMPlayer(txtSteganofile.Text);
        }

        private void cbIsImage_CheckedChanged(object sender, EventArgs e)
        {
            isImage = cbIsImage.Checked;
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (thread.IsAlive)
            {
                enableComonents(false);
                lblLoading.Text = "Loading: " + stega.persenLoading.ToString() + "%";
                progressBar1.Value = Convert.ToInt32(stega.persenLoading);
                i++;
            }
            else
            {
                timer1.Enabled = false;
                enableComonents(true);
                if (isSuccess)
                {
                    if (isImage)
                        txtMessage.Text = @txtDestinaion.Text + @"\Image Message.jpg";
                    else
                        txtMessage.Text = @txtDestinaion.Text + @"\Text Message.txt";
                }
                else
                    txtMessage.Text = string.Empty;
                reset();
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void aESAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSetting();
        }
    }
}
