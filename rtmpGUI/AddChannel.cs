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
            fmain = _main;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] array = new string[5] { txtTitle.Text, txtswfUrl.Text, txtLink.Text, txtPageUrl.Text, txtPlaypath.Text };
            fmain.AddChanel(array);
            this.Hide();
        }
    }
}
