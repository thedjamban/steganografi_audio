using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Revisi_Stegano_Audio.UI;

namespace Revisi_Stegano_Audio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmOption());
        }
    }
}
