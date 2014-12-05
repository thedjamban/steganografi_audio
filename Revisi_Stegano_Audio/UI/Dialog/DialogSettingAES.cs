using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Revisi_Stegano_Audio.UI.Dialog
{
    public partial class DialogSettingAES : Form
    {
        private string[] paddingModes = { 
                                                 PaddingMode.ANSIX923.ToString(),
                                                 PaddingMode.ISO10126.ToString(),
                                                 PaddingMode.PKCS7.ToString()
                                                 //PaddingMode.Zeros.ToString()
                                             };

        private string[] cipherModes = { 
                                               CipherMode.CBC.ToString(),
                                               CipherMode.ECB.ToString()
                                           };

        private string keySize;
        private string saltKey;
        private string padding;
        private string cipher;

        public DialogSettingAES(string keySize, string saltKey, string padding, string cipher)
        {
            InitializeComponent();
            this.keySize = keySize;
            this.saltKey = saltKey;
            this.padding = padding;
            this.cipher = cipher;
        }

        #region method-method

        private void loadForm()
        {
            cmbPaddingMode.Items.AddRange(paddingModes);
            cmbCipherMode.Items.AddRange(cipherModes);
            cmbPaddingMode.SelectedItem = padding;
            cmbCipherMode.SelectedItem = cipher;
            txtSalt.Text = saltKey;

            if (rd128.Name.Contains(keySize))
                rd128.Checked = true;

            else if (rd192.Name.Contains(keySize))
                rd192.Checked = true;

            else
                rd256.Checked = true;
        }

        private void close()
        {
            Close();
        }

        private void saveSetting()
        {
            if (rd128.Checked)
                keySize = rd128.Text.Trim();
            else if (rd192.Checked)
                keySize = rd192.Text.Trim();
            else
                keySize = rd256.Text.Trim();

            saltKey = txtSalt.Text;
            padding = cmbPaddingMode.Text;
            cipher = cmbCipherMode.Text;

            StreamWriter sw = new StreamWriter(@".\settings.setApp");
            sw.WriteLine("#keySize");
            sw.WriteLine(keySize);
            sw.WriteLine("#salt");
            sw.WriteLine(saltKey);
            sw.WriteLine("#paddingMode");
            sw.WriteLine(padding);
            sw.WriteLine("#cipherMode");
            sw.WriteLine(cipher);
            sw.Close();
        }

        private void apply()
        {
            if (!validation())
                return;
            DialogResult result = MessageBox.Show("Do you want to change cryptography settings?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            saveSetting();
            MessageBox.Show("Cryptography settings changed!\nPlease restart the program", "Setting");
            restart();
        }

        private void ok()
        {
            if (!validation())
                return;
            saveSetting();
            MessageBox.Show("Cryptography settings changed!\nPlease restart the program", "Setting");
            Application.Restart();
        }

        private void restart()
        {
            Application.Restart();
        }

        private bool validation()
        {
            if (txtSalt.Text.Length != 16)
            {
                MessageBox.Show("Salt key must equal to 16 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        private void DialogSettingAES_Load(object sender, EventArgs e)
        {
            loadForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            apply();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ok();
        }
    }
}
