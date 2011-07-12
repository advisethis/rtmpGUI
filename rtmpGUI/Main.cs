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
using System.Net;
using System.Web;
using System.Threading;
using System.Diagnostics;


namespace rtmpGUI
{
    public partial class Main : Form
    {
        string vlcLoc = "";
        string list = "";
        HttpWebRequest webconnect;
        private delegate void AddItemCallback(object o);
        delegate void MyDelegate(string[] array);

        public Main()
        {
            InitializeComponent();

        }
        #region form_stuff
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        #region file_menu
        private void optionsMenu_Click(object sender, EventArgs e)
        {
            Form Options = new Options();
            Options.Show();
        }

        private void remoteXmlLoad_Click(object sender, EventArgs e)
        {
            ThreadStart update = new ThreadStart(RemoteXML);
            Thread check = new Thread(update);
            check.Priority = ThreadPriority.Normal;
            check.Start();
        }

        private void LocalXMLLoad_Click(object sender, EventArgs e)
        {
            ThreadStart update = new ThreadStart(LocalXML);
            Thread check = new Thread(update);
            check.Priority = ThreadPriority.Normal;
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

        private void saveChannels_Click(object sender, EventArgs e)
        {
            SaveList(listView1, Application.StartupPath.ToString() + "\\channels.xml");
        }


        private void submitChannel_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    var safeswf = HttpUtility.UrlEncode(lvi.SubItems[1].Text);
                    var safertmp = HttpUtility.UrlEncode(lvi.SubItems[2].Text);
                    var safepage = HttpUtility.UrlEncode(lvi.SubItems[3].Text);
                    sysLabel.Text = connection("http://apps.ohlulz.com/rtmpplayer/api.php?title=" + lvi.SubItems[0].Text + "&swfUrl=" + safeswf + "&link=" + safertmp + "&pageUrl=" + safepage + "&playpath=" + lvi.SubItems[4]);
                     //connection("http://127.0.0.1/rtmpplayer/api.php?title=" + lvi.SubItems[0].Text + "&swfUrl=" + safeswf + "&link=" + safertmp + "&pageUrl=" + safepage + "&playpath=" + lvi.SubItems[4].Text);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DebugLog(ex.ToString());
            }
        }
        #endregion

        #region listview
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                LoadSettings();
                RunStream(lvi.SubItems[1].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text, lvi.SubItems[4].Text);
                sysLabel.Text = "Loading : " + lvi.SubItems[0].Text;
            }
        }
        #endregion


        private void wbApp_NewWindow(object sender, CancelEventArgs e)
        {

            wbApp.Navigate(wbApp.StatusText);
            e.Cancel = true;

        }
        #endregion

        #region functions
        private void RemoteXML()
        {

            if (listView1.InvokeRequired)
            {
                listView1.BeginInvoke(new MethodInvoker(() => RemoteXML()));
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

        private void LocalXML()
        {

            if (listView1.InvokeRequired)
            {
                listView1.BeginInvoke(new MethodInvoker(() => LocalXML()));
            }
            else
            {
                XmlDocument xDoc = new XmlDocument();
                listView1.Items.Clear();
                try
                {
                    xDoc.Load(Application.StartupPath.ToString() + "\\channels.xml");
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
            SaveList(listView1, Application.StartupPath.ToString() + "\\channels.xml");
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
            SaveList(listView1, Application.StartupPath.ToString() + "\\channels.xml");
        }


        private void LoadSettings()
        {
            XmlDocument xDoc = new XmlDocument();
            Options f2 = new Options();
            try
            {
                xDoc.Load(Application.StartupPath.ToString() + "\\config.xml");
                vlcLoc = xDoc.GetElementsByTagName("vlc-loc")[0].InnerText;
                list = xDoc.GetElementsByTagName("load-list")[0].InnerText;

                if (list == "remote")
                {
                    ThreadStart update = new ThreadStart(RemoteXML);
                    Thread check = new Thread(update);
                    check.Start();
                }
                else
                {
                    ThreadStart update = new ThreadStart(LocalXML);
                    Thread check = new Thread(update);
                    check.Start();
                }
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

        public void SaveList(ListView list, string file)
        {
            try
            {
                using (var tw = new XmlTextWriter(file, null)) // By using the using statement (not directive!) we remove the need of tw.Close() afterwards.
                {
                    tw.Formatting = Formatting.Indented;
                    tw.WriteStartDocument();
                    tw.WriteStartElement("streams");


                    for (int i = 0; i < list.Items.Count; i++)
                    {
                        // Start a new element.
                        tw.WriteStartElement("stream", string.Empty);

                        tw.WriteStartElement("title", string.Empty);
                        tw.WriteString(list.Items[i].SubItems[0].Text);
                        tw.WriteEndElement();

                        tw.WriteStartElement("swfUrl", string.Empty);
                        tw.WriteString(list.Items[i].SubItems[1].Text);
                        tw.WriteEndElement();

                        tw.WriteStartElement("link", string.Empty);
                        tw.WriteString(list.Items[i].SubItems[2].Text);
                        tw.WriteEndElement();

                        tw.WriteStartElement("pageUrl", string.Empty);
                        tw.WriteString(list.Items[i].SubItems[3].Text);
                        tw.WriteEndElement();

                        tw.WriteStartElement("playpath", string.Empty);
                        tw.WriteString(list.Items[i].SubItems[4].Text);
                        tw.WriteEndElement();

                        // And close it off.
                        tw.WriteEndElement();
                    }

                    // I'd relocate these statements out of the foreach loop, seeing we already close each element
                    // properly, and we don't want to close the entire file off until after we've written all elements, right?
                    tw.WriteEndElement();
                    tw.WriteEndDocument();
                }
            }
            catch (Exception ex)
            {
                DebugLog(ex.Message);
            }
        }


        public string connection(string url)
        {
            webconnect = (HttpWebRequest)HttpWebRequest.Create(url);

            webconnect.UserAgent = "rtmpGUI";

            WebResponse Response = webconnect.GetResponse();
            Stream WebStream = Response.GetResponseStream();
            StreamReader Reader = new StreamReader(WebStream);
            string PageContent = Reader.ReadToEnd();

            Reader.Close();
            WebStream.Close();
            Response.Close();

            return PageContent;
        }

        public void DebugLog(string item)
        {
            StreamWriter log;

            if (!File.Exists("logfile.txt"))
            {
                log = new StreamWriter("logfile.txt");
            }
            else
            {
                log = File.AppendText("logfile.txt");
            }

            // Write to the file:
            log.WriteLine(DateTime.Now);
            log.WriteLine(item);
            log.WriteLine();

            // Close the stream:
            log.Close();

        }


        #endregion


    }
}
