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
        Main frm = new Main();
        string vlcfile = string.Empty;
        string list = string.Empty;
        string updates = string.Empty;
        string altload = string.Empty;
        string suppress = string.Empty;
        string default_commands = string.Empty;

        private static Options _instance;
        public Options()
        {
            InitializeComponent();

            tabControl1.ImageList = imageList1;
            tabPage1.ImageIndex = 0;
            tabPage2.ImageIndex = 1;

            this.Font = SystemFonts.MessageBoxFont;
        }

        public static Options Instance()
        {
            if (_instance == null)
            {
                _instance = new Options();
            }
            return _instance;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (findVLC.ShowDialog() == DialogResult.OK)
            {
                txtVLCloc.Text = findVLC.FileName.ToString();
                txtVLCloc.Text = "\"" + txtVLCloc.Text + "\"";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (findChannels.ShowDialog() == DialogResult.OK)
            {
                txtLocList.Text = findChannels.FileName.ToString();
            }
        }


        public void SaveSettings()
        {
            using (var tw = new XmlTextWriter(Application.StartupPath.ToString() + "\\config.xml", null)) // By using the using statement (not directive!) we remove the need of tw.Close() afterwards.
            {
                tw.Formatting = Formatting.Indented;
                tw.WriteStartDocument();
                tw.WriteStartElement("rtmpGUI", string.Empty);

                tw.WriteStartElement("vlc-loc", "");
                tw.WriteString(txtVLCloc.Text);
                tw.WriteEndElement();


                tw.WriteStartElement("list", "");
                if (chkStartList.Checked == true)
                {
                    tw.WriteAttributeString("remote", "true");
                }
                else
                {
                    tw.WriteAttributeString("remote", "false");
                    tw.WriteString(txtLocList.Text);
                }
                
                tw.WriteEndElement();

                tw.WriteStartElement("updates", "");
                if (chkCheckUpdates.Checked == true)
                {
                    tw.WriteString("true");
                }
                else
                {
                    tw.WriteString("false");
                }
                tw.WriteEndElement();

                tw.WriteStartElement("altpage", "");
                if (chkWebPage.Checked == true)
                {
                    tw.WriteAttributeString("load", "true");
                }
                else
                {
                    tw.WriteAttributeString("load", "false");
                }
                tw.WriteString(txtWeb.Text);
                tw.WriteEndElement();

                tw.WriteStartElement("suppress", "");
                if (chkSuppress.Checked == true)
                {
                    tw.WriteString("true");
                }
                else
                {
                    tw.WriteString("false");
                }
                tw.WriteEndElement();

                tw.WriteStartElement("default_commands", "");
                if (chkCommands.Checked == true)
                {
                    tw.WriteString("true");
                }
                else
                {
                    tw.WriteString("false");
                }
                tw.WriteEndElement();

                tw.WriteStartElement("api", "");
                tw.WriteAttributeString("user", txtAPIuser.Text);
                tw.WriteAttributeString("key", txtAPIkey.Text);
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

                txtAPIuser.Text = xDoc.SelectSingleNode("/rtmpGUI/api/@user").Value;
                txtAPIkey.Text = xDoc.SelectSingleNode("/rtmpGUI/api/@key").Value;

                altload = xDoc.SelectSingleNode("/rtmpGUI/altpage/@load").Value;
                txtWeb.Text = xDoc.GetElementsByTagName("altpage")[0].InnerText;

                list = xDoc.SelectSingleNode("/rtmpGUI/list/@remote").Value;
                txtLocList.Text = xDoc.GetElementsByTagName("list")[0].InnerText;
                
                updates = xDoc.GetElementsByTagName("updates")[0].InnerText;
                suppress = xDoc.GetElementsByTagName("suppress")[0].InnerText;

                default_commands = xDoc.GetElementsByTagName("default_commands")[0].InnerText;


                if (list == "true")
                {
                    chkStartList.Checked = true;
                }
                else
                {
                    chkStartList.Checked = false;
                }

                if (updates == "true")
                {
                    chkCheckUpdates.Checked = true;
                }
                else
                {
                    chkCheckUpdates.Checked = false;
                }

                if (altload == "true")
                {
                    chkWebPage.Checked = true;
                }
                else
                {
                    chkWebPage.Checked = false;
                }

                if (suppress == "true")
                {
                    chkSuppress.Checked = true;
                }
                else
                {
                    chkSuppress.Checked = false;
                }

                if (default_commands == "true")
                {
                    chkCommands.Checked = true;
                }
                else
                {
                    chkCommands.Checked = false;
                }


            }
            catch (Exception ex)
            {
                chkStartList.Checked = true;
                chkCheckUpdates.Checked = true;
                chkWebPage.Checked = false;
                chkSuppress.Checked = true;
                chkCommands.Checked = false;
            }
        }

        private void Options_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void chkWebPage_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWebPage.Checked == true)
            {
                txtWeb.Enabled = true;
            }
            else
            {
                txtWeb.Enabled = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://apps.ohlulz.com/rtmpgui/users/");
        }

        private void chkStartList_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStartList.Checked == true)
            {
                txtLocList.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                txtLocList.Enabled = true;
                button4.Enabled = true;
            }

        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        

    }
}