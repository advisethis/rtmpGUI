using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rtmpGUI
{
    public partial class AddChannel : Form
    {
        Main fmain;

        public AddChannel(Main _main)
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            fmain = _main;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            string[] array = new string[9] { txtTitle.Text, txtswfUrl.Text, txtLink.Text, txtPageUrl.Text, txtPlaypath.Text, txtLanguage.Text, txtAdvanced.Text, txtResolution.Text, txtBitrate.Text };
            fmain.AddChanel(array);
            this.Hide();
        }

        private void txtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOkay_Click(null, null);
            }
        }
    }
}