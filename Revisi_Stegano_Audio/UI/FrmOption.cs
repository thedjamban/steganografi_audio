using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using USBKeyLib;

namespace Revisi_Stegano_Audio.UI
{
    public partial class FrmOption : Form
    {
        private FrmEmbedding frmEmbedding;
        private FrmExtraction frmExtraction;

        //private USBUnlock usbUnlock;
        private bool _loading;

        public FrmOption()
        {
            InitializeComponent();
            //usbUnlock = new USBUnlock();
        }

        #region method=method

        private void exit()
        {
            Application.ExitThread();
        }

        private void enterFrmEmbedding()
        {
            if (frmEmbedding == null || frmEmbedding.IsDisposed)
                frmEmbedding = new FrmEmbedding();
            frmEmbedding.Show();
        }

        private void enterFrmExtraction()
        {
            if (frmExtraction == null || frmExtraction.IsDisposed)
                frmExtraction = new FrmExtraction();
            frmExtraction.Show();
        }

        #endregion

        private void btnEmbedding_Click(object sender, EventArgs e)
        {
            enterFrmEmbedding();
            Hide();
        }

        private void btnExtraction_Click(object sender, EventArgs e)
        {
            enterFrmExtraction();
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void FrmOption_Load(object sender, EventArgs e)
        {
            //USBLoad(1);
        }

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x0219)
        //    {
        //        if (!_loading)
        //        {
        //            USBLoad(2);
        //        }
        //    }
        //    base.WndProc(ref m);
        //}

        //private void USBLoad(int a)
        //{
        //    _loading = true;
        //    if (!usbUnlock.validateKey("12345678"))
        //    {
        //        this.Hide();
        //        if (a == 1)
        //            MessageBox.Show("TIDAK DITEMUKAN");
        //        else
        //            MessageBox.Show("REMOVED");
        //        this.Close();
        //    }
        //    _loading = false;
        //}
    }
}
