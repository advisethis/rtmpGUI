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
        string list = string.Empty;
        public Options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (findVLC.ShowDialog() == DialogResult.OK)
            {
                txtVLCloc.Text = findVLC.FileName.ToString();
                vlcfile = "\"" + txtVLCloc.Text + "\"";
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Hide();
        }

        public void SaveSettings()
        {
            using (var tw = new XmlTextWriter(Application.StartupPath.ToString() + "\\config.xml", null)) // By using the using statement (not directive!) we remove the need of tw.Close() afterwards.
            {
                tw.Formatting = Formatting.Indented;
                tw.WriteStartDocument();
                tw.WriteStartElement("rtmpGUI", string.Empty);

                tw.WriteStartElement("vlc-loc", "");
                tw.WriteString(vlcfile);
                tw.WriteEndElement();


                tw.WriteStartElement("load-list", "");
                if (chkStartList.Checked == true)
                {
                tw.WriteString("remote");
                }
                else
                {
                tw.WriteString("local");
                } 
                tw.WriteEndElement();


                tw.WriteEndElement();
                tw.WriteEndDocument();
            }
        }

        private void LoadSettings()
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(Application.StartupPath.ToString() + "\\config.xml");
                txtVLCloc.Text = xDoc.GetElementsByTagName("vlc-loc")[0].InnerText;
                list = xDoc.GetElementsByTagName("load-list")[0].InnerText;

                if (list == "remote")
                {
                    chkStartList.Checked = true;
                }
                else
                {
                    chkStartList.Checked = false;
                }


            }
            catch (Exception ex)
            {
                chkStartList.Checked = true;
            }
        }

        private void Options_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
    }
}
