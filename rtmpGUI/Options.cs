using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace rtmpGUI
{
    public partial class Options : Form
    {
        string vlcfile = "";
        public Options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (findVLC.ShowDialog() == DialogResult.OK)
            {
                txtVLCloc.Text = findVLC.FileName.ToString();
                vlcfile = "\"" + findVLC.FileName + "\"";    
            }
        }

        public void SaveSettings(string file, string item, string setting)
        {

            XmlTextWriter textWriter = new XmlTextWriter(file, null);

            textWriter.Formatting = Formatting.Indented;
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("rtmpGUI", "");

            textWriter.WriteStartElement(item, "");
            textWriter.WriteString(setting);
            textWriter.WriteEndElement();

            textWriter.WriteEndElement();
            textWriter.WriteEndDocument();
            textWriter.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveSettings(Application.StartupPath.ToString() + "\\config.xml", "vlc-loc", vlcfile);
            this.Hide();
        }
    }
}
