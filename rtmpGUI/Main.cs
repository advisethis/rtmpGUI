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
using System.Threading;
using System.Diagnostics;


namespace rtmpGUI
{
    public partial class Main : Form
    {
        string vlcLoc = "";
        private delegate void AddItemCallback(object o);
        delegate void MyDelegate(string[] array);

        public Main()
        {
            InitializeComponent(); 
            
        }
        #region form_stuff
        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadStart update = new ThreadStart(RefreshXML);
            Thread check = new Thread(update);
            check.Start();
            RefreshXML();
            LoadSettings();
        }

        #region file_menu
        private void optionsMenu_Click(object sender, EventArgs e)
        {
            Form Options = new Options();
            Options.Show();
        }

        private void refreshxmlMenu_Click(object sender, EventArgs e)
        {
            ThreadStart update = new ThreadStart(RefreshXML);
            Thread check = new Thread(update);
            check.Start();
        }

        private void showCommands_Click(object sender, EventArgs e)
        {
            if (showCommands.Checked == true)
            {
                txtCommands.BringToFront();
                wbApp.SendToBack();
            }
            else
            {
                wbApp.BringToFront();
                txtCommands.SendToBack();
            }
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region help_menu
        private void howToMenu_Click(object sender, EventArgs e)
        {
            wbApp.Navigate("http://apps.ohlulz.com/rtmpplayer/guide.php");
        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            Form AboutBox1 = new AboutBox1();
            AboutBox1.Show();
        }
        #endregion


        #region context_menu
        private void addChannel_Click(object sender, EventArgs e)
        {
            Form Channel = new AddChannel(this);
            Channel.Show(this);
        }

        private void recordChannel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                RecordStream(lvi.SubItems[0].Text, lvi.SubItems[1].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text, lvi.SubItems[4].Text);
            }

        }

        private void editChannel_Click(object sender, EventArgs e)
        {

            EditChannel ec = new EditChannel(this);

            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                ec.txtTitle.Text = lvi.SubItems[0].Text;
                ec.txtswfUrl.Text = lvi.SubItems[1].Text;
                ec.txtLink.Text = lvi.SubItems[2].Text;
                ec.txtPageUrl.Text = lvi.SubItems[3].Text;
                ec.txtPlaypath.Text = lvi.SubItems[4].Text;
            }

            ec.Show(this);



        }

        private void deleteChannel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                listView1.Items.Remove(lvi);
            }
        }
        #endregion


        #region listview
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                sysLabel.Text = lvi.SubItems[0].Text;
            }
        }

        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                LoadSettings();
                RunStream(lvi.SubItems[1].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text, lvi.SubItems[4].Text);
            }
        }
        #endregion
        #endregion

        #region functions
        private void RefreshXML()
        {

            if (listView1.InvokeRequired)
            {
                listView1.BeginInvoke(new MethodInvoker(() => RefreshXML()));
            }
            else
            {
                XmlDocument xDoc = new XmlDocument();
                listView1.Items.Clear();
                try
                {
                    xDoc.Load("http://apps.ohlulz.com/rtmpplayer/list.xml");
                    //xDoc.Load("http://127.0.0.1/rtmpplayer/list.xml");
                    int c = xDoc.GetElementsByTagName("stream").Count;
                    int i = 0;

                    while (i < c)
                    {
                        ListViewItem lvi = listView1.Items.Add(xDoc.GetElementsByTagName("title")[i].InnerText);
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("swfUrl")[i].InnerText);
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("link")[i].InnerText);
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("pageUrl")[i].InnerText);
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("playpath")[i].InnerText);

                        i++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DebugLog(ex.ToString());
                }

            }
        }

        public void AddChanel(string[] array)
        {
            if (this.listView1.InvokeRequired)
            {
                this.listView1.Invoke(new MyDelegate(AddChanel), new object[] { array });
            }
            else
            {
                ListViewItem lvi = new ListViewItem(array[0]);
                lvi.SubItems.Add(array[1]);
                lvi.SubItems.Add(array[2]);
                lvi.SubItems.Add(array[3]);
                lvi.SubItems.Add(array[4]);
                this.listView1.Items.Add(lvi);
            }
            ListFunctions.SaveList(listView1, Application.StartupPath.ToString() + "\\channels.xml");
        }

        public void EditChanel(string[] array)
        {
            if (this.listView1.InvokeRequired)
            {
                this.listView1.Invoke(new MyDelegate(EditChanel), new object[] { array });
            }
            else
            {

                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    lvi.SubItems[0].Text = array[0];
                    lvi.SubItems[1].Text = array[1];
                    lvi.SubItems[2].Text = array[2];
                    lvi.SubItems[3].Text = array[3];
                    lvi.SubItems[4].Text = array[4];
                }
            }
            ListFunctions.SaveList(listView1, Application.StartupPath.ToString() + "\\channels.xml");
        }


        private void LoadSettings()
        {
            Options f2 = new Options();
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(Application.StartupPath.ToString() + "\\config.xml");
                vlcLoc = xDoc.GetElementsByTagName("vlc-loc")[0].InnerText;
                f2.txtVLCloc.Text = vlcLoc.ToString();
            }
            catch (Exception ex)
            {
                f2.Show();
                MessageBox.Show("config file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DebugLog(ex.ToString());
            }
        }

        private void RunStream(string swfUrl, string link, string pageUrl, string playpath)
        {
            try
            {
                Process pr = new Process();
                pr.StartInfo.FileName = "cmd.exe";
                pr.StartInfo.Arguments = @"/C " + "rtmpdump.exe -v -r " + link + " -W " + swfUrl + " -p " + pageUrl + " | " + vlcLoc + " -";
                txtCommands.Text = "rtmpdump" + " -r " + link + " -W " + swfUrl + " -p " + pageUrl + " | " + vlcLoc + " -";
                pr.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DebugLog(ex.ToString());
            }
        }

        private void RecordStream(string title, string swfUrl, string link, string pageUrl, string playpath)
        {
            try
            {
                Process pr = new Process();
                string format = "ddMMyy.HHmm";
                pr.StartInfo.FileName = "cmd.exe";
                pr.StartInfo.Arguments = @"/C " + "rtmpdump.exe -v -r " + link + " -W " + swfUrl + " -p " + pageUrl + " -o " + title + "-" + DateTime.Now.ToString(format) + ".flv";
                txtCommands.Text = "rtmpdump" + " -r " + link + " -W " + swfUrl + " -p " + pageUrl + " -o " + title + "-" + DateTime.Now.ToString(format) + ".flv";
                pr.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DebugLog(ex.ToString());
            }
        }

        


        #endregion
    }
}
