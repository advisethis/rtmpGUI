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
    public partial class EditChannel : Form
    {
        Main fmain;

        public EditChannel(Main _main)
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            fmain = _main;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] array = new string[9] { txtTitle.Text, txtswfUrl.Text, txtLink.Text, txtPageUrl.Text, txtPlaypath.Text, txtLanguage.Text, txtAdvanced.Text, txtResolution.Text, txtBitrate.Text };
            fmain.EditChanel(array);
            this.Hide();
        }
    }
}