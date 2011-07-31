using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.IO;
using System.Web;
using Microsoft.Win32;
using System.Threading;


namespace rtmpGUI
{
    public partial class Main : Form
    {
        string vlcLoc = string.Empty;
        string list = string.Empty;
        string updates = string.Empty;
        string altpage = string.Empty;
        string altload = string.Empty;
        string homepage = string.Empty;
        string suppress = string.Empty;

        string localloadloc = string.Empty;
        string localsaveloc = string.Empty;

        string apiUser = string.Empty;
        string apiKey = string.Empty;

        public bool supcom = true;
        HttpWebRequest webconnect;

        private delegate void AddItemCallback(object o);
        delegate void MyDelegate(string[] array);

        public Main()
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
        }
        #region form_stuff
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void DonateLabel_Click(object sender, EventArgs e)
        {
            Process.Start("http://ohlulz.com/donate.php");
        }

        #region file_menu
        private void optionsMenu_Click(object sender, EventArgs e)
        {
            using (Form Options = new Options())
            {
                Options.ShowDialog(this);
            }
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

        private void webpageRefresh_Click(object sender, EventArgs e)
        {
            wbApp.Refresh();
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

        private void checkUpdatesMenu_Click(object sender, EventArgs e)
        {
            CheckUpdates();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region help_menu
        private void howToMenu_Click(object sender, EventArgs e)
        {
            if (howToMenu.Checked == true)
            {
                wbApp.Navigate("http://apps.ohlulz.com/rtmpplayer/guide.php");
            }
            else
            {
                wbApp.Navigate(homepage);
            }


        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            using (Form AboutBox1 = new AboutBox1())
            {
                AboutBox1.ShowDialog();
            }
        }
        #endregion


        #region context_menu
        private void addChannel_Click(object sender, EventArgs e)
        {
            using (Form Channel = new AddChannel(this))
            {
                Channel.ShowDialog(this);
            }
        }

        private void recordChannel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                RecordStream(lvi.SubItems[0].Text, lvi.SubItems[1].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text, lvi.SubItems[4].Text, lvi.SubItems[6].Text);
            }

        }

        private void editChannel_Click(object sender, EventArgs e)
        {

            using (EditChannel ec = new EditChannel(this))
            {
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    ec.txtTitle.Text = lvi.SubItems[0].Text;
                    ec.txtswfUrl.Text = lvi.SubItems[1].Text;
                    ec.txtLink.Text = lvi.SubItems[2].Text;
                    ec.txtPageUrl.Text = lvi.SubItems[3].Text;
                    ec.txtPlaypath.Text = lvi.SubItems[4].Text;
                    ec.txtLanguage.Text = lvi.SubItems[5].Text;
                    ec.txtAdvanced.Text = lvi.SubItems[6].Text;
                }

                ec.ShowDialog(this);
            }
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

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                localsaveloc = saveDialog.FileName.ToString();
                SaveList(listView1, localsaveloc);
            }
        }


        private void submitChannel_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    var safetitle = HttpUtility.UrlEncode(lvi.SubItems[0].Text);
                    var safeswf = HttpUtility.UrlEncode(lvi.SubItems[1].Text);
                    var safertmp = HttpUtility.UrlEncode(lvi.SubItems[2].Text);
                    var safepage = HttpUtility.UrlEncode(lvi.SubItems[3].Text);
                    var safeplay = HttpUtility.UrlEncode(lvi.SubItems[4].Text);
                    var safelang = HttpUtility.UrlEncode(lvi.SubItems[5].Text);
                    var safeadvanced = HttpUtility.UrlEncode(lvi.SubItems[6].Text);
                    sysLabel.Text = connection("http://apps.ohlulz.com/rtmpgui/api.php?title=" + safetitle + "&swfUrl=" + safeswf + "&link=" + safertmp + "&pageUrl=" + safepage + "&playpath=" + safeplay + "&lang=" + safelang + "&advanced=" + safeadvanced + "&apiUser=" + apiUser + "&apiKey=" + apiKey);
                    //txtCommands.Text = "http://apps.ohlulz.com/rtmpgui/api.php?title=" + safetitle + "&swfUrl=" + safeswf + "&link=" + safertmp + "&pageUrl=" + safepage + "&playpath=" + safeplay + "&lang=" + safelang + "&advanced=" + safeadvanced + "&apiUser=" + apiUser + "&apiKey=" + apiKey;
                    //sysLabel.Text = connection("http://127.0.0.1/rtmpplayer/api.php?title=" + safetitle + "&swfUrl=" + safeswf + "&link=" + safertmp + "&pageUrl=" + safepage + "&playpath=" + safeplay + "&lang=" + safelang + "&advanced=" + safeadvanced + "&apiUser=" + apiUser + "&apiKey=" + apiKey);
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
            RefreshSettings();
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                RunStream(lvi.SubItems[1].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text, lvi.SubItems[4].Text, lvi.SubItems[6].Text);
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
                    xDoc.Load("http://apps.ohlulz.com/rtmpgui/list.xml");
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
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("language")[i].InnerText);
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("advanced")[i].InnerText);
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while trying to load the remote channel list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (localloadloc == string.Empty)
                {
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        localloadloc = openDialog.FileName.ToString();
                    }
                }
                XmlDocument xDoc = new XmlDocument();
                listView1.Items.Clear();
                try
                {
                    xDoc.Load(localloadloc);
                    int c = xDoc.GetElementsByTagName("stream").Count;
                    int i = 0;

                    while (i < c)
                    {
                        ListViewItem lvi = listView1.Items.Add(xDoc.GetElementsByTagName("title")[i].InnerText);
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("swfUrl")[i].InnerText);
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("link")[i].InnerText);
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("pageUrl")[i].InnerText);
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("playpath")[i].InnerText);
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("language")[i].InnerText);
                        lvi.SubItems.Add(xDoc.GetElementsByTagName("advanced")[i].InnerText);
                        
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while trying to load the local channel list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lvi.SubItems.Add(array[5]);
                lvi.SubItems.Add(array[6]);
                this.listView1.Items.Add(lvi);
            }

            if (localsaveloc == string.Empty)
            {
                saveChannels_Click(null, null);
            }
            else
            {
                SaveList(listView1, localsaveloc);
            }

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
                    lvi.SubItems[5].Text = array[5];
                    lvi.SubItems[6].Text = array[6];
                }
            }
            if (localsaveloc == string.Empty)
            {
                saveChannels_Click(null, null);
            }
            else
            {
                SaveList(listView1, localsaveloc);
            }
        }

        public void LoadSettings()
        {
            XmlDocument xDoc = new XmlDocument();
            Options f2 = new Options();
            try
            {
                xDoc.Load(Application.StartupPath.ToString() + "\\config.xml");
                vlcLoc = xDoc.GetElementsByTagName("vlc-loc")[0].InnerText;
                list = xDoc.GetElementsByTagName("load-list")[0].InnerText;
                updates = xDoc.GetElementsByTagName("updates")[0].InnerText;
                altload = xDoc.SelectSingleNode("/rtmpGUI/altpage/@load").Value;
                altpage = xDoc.GetElementsByTagName("altpage")[0].InnerText;
                suppress = xDoc.GetElementsByTagName("suppress")[0].InnerText;

                apiUser = xDoc.SelectSingleNode("/rtmpGUI/api/@user").Value;
                apiKey = xDoc.SelectSingleNode("/rtmpGUI/api/@key").Value;

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

                if (updates == "true")
                {
                    CheckUpdates();
                }
                else
                {
                    //Do jack
                }

                if (altload == "true")
                {
                    homepage = altpage;
                }
                else
                {
                    homepage = "http://tvlistings.tvguide.com/ListingsWeb/listings/ScrollingGridIFrame.aspx";
                }
                wbApp.Navigate(homepage);

                if (suppress == "true")
                {
                    supcom = true;
                }
                else
                {
                    supcom = false;
                }

            }
            catch (Exception ex)
            {
                f2.Show();
                MessageBox.Show("There was an error with the config file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DebugLog(ex.ToString());
            }
        }

        public void RefreshSettings()
        {
            XmlDocument xDoc = new XmlDocument();
            Options f2 = new Options();
            try
            {
                xDoc.Load(Application.StartupPath.ToString() + "\\config.xml");
                vlcLoc = xDoc.GetElementsByTagName("vlc-loc")[0].InnerText;
                altload = xDoc.SelectSingleNode("/rtmpGUI/altpage/@load").Value;
                altpage = xDoc.GetElementsByTagName("altpage")[0].InnerText;
                suppress = xDoc.GetElementsByTagName("suppress")[0].InnerText;

                apiUser = xDoc.SelectSingleNode("/rtmpGUI/api/@user").Value;
                apiKey = xDoc.SelectSingleNode("/rtmpGUI/api/@key").Value;

                if (altload == "true")
                {
                    homepage = altpage;
                }
                else
                {
                    homepage = "http://tvlistings.tvguide.com/ListingsWeb/listings/ScrollingGridIFrame.aspx";
                }
                wbApp.Navigate(homepage);

                if (suppress == "true")
                {
                    supcom = true;
                }
                else
                {
                    supcom = false;
                }

            }
            catch (Exception ex)
            {
                f2.Show();
                MessageBox.Show("There was an error with the config file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DebugLog(ex.ToString());
            }

        }

        private void RunStream(string swfUrl, string link, string pageUrl, string playpath, string advanced)
        {
            try
            {
                Process pr = new Process();
                pr.StartInfo.FileName = "cmd.exe";

                if (supcom == true)
                {
                    pr.StartInfo.CreateNoWindow = true;
                    pr.StartInfo.UseShellExecute = false;
                }


                if (playpath.Length == 0)
                {
                    pr.StartInfo.Arguments = @"/C " + "rtmpdump.exe --live -v -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " | " + vlcLoc + " -";
                    txtCommands.Text = "rtmpdump" + " -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " | " + vlcLoc + " -";
                }
                else
                {
                    pr.StartInfo.Arguments = @"/C " + "rtmpdump.exe --live -v -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " -y " + playpath + " | " + vlcLoc + " -";
                    txtCommands.Text = "rtmpdump" + " -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " -y " + playpath + " | " + vlcLoc + " -";
                }

                pr.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to play the channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DebugLog(ex.ToString());
            }
        }

        private void RecordStream(string title, string swfUrl, string link, string pageUrl, string playpath, string advanced)
        {
            try
            {
                sysLabel.Text = "Recording: " + title;
                Process pr = new Process();
                string format = "ddMMyy.HHmm";
                pr.StartInfo.FileName = "cmd.exe";
                if (playpath.Length == 0)
                {
                    pr.StartInfo.Arguments = @"/C " + "rtmpdump.exe --live -v -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " -o " + title + "-" + DateTime.Now.ToString(format) + ".flv";
                    txtCommands.Text = "rtmpdump" + " -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " -o " + title + "-" + DateTime.Now.ToString(format) + ".flv";
                }
                else
                {
                    pr.StartInfo.Arguments = @"/C " + "rtmpdump.exe --live -v -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " -y " + playpath + " -o " + title + "-" + DateTime.Now.ToString(format) + ".flv";
                    txtCommands.Text = "rtmpdump" + " -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " -y " + playpath + " -o " + title + "-" + DateTime.Now.ToString(format) + ".flv";
                }
                pr.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to record the channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        tw.WriteStartElement("language", string.Empty);
                        tw.WriteString(list.Items[i].SubItems[5].Text);
                        tw.WriteEndElement();

                        tw.WriteStartElement("advanced", string.Empty);
                        tw.WriteString(list.Items[i].SubItems[6].Text);
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

            webconnect.UserAgent = "rtmpGUI/" + Assembly.GetExecutingAssembly().GetName().Version;

            WebResponse Response = webconnect.GetResponse();
            Stream WebStream = Response.GetResponseStream();
            StreamReader Reader = new StreamReader(WebStream);
            string PageContent = Reader.ReadToEnd();

            Reader.Close();
            WebStream.Close();
            Response.Close();

            return PageContent;
        }



        public void CheckUpdates()
        {
            try
            {
                string data = connection("http://apps.ohlulz.com/rtmpgui/version.txt");

                var downloadedVersion = new Version(data.Substring("version=".Length));

                if (Assembly.GetExecutingAssembly().GetName().Version >= downloadedVersion)
                {

                    sysLabel.Text = "Update Status : There are no updates at this time.";
                }
                else
                {
                    sysLabel.Text = "Update Status : A new version of rtmpGUI is available.";
                    UpdateProgram("http://ohlulz.com/download.php?f=rtmpGUI.exe");
                }
            }
            catch (Exception ex)
            {
                sysLabel.Text = "Update Status : Update check failed.";
                DebugLog(ex.ToString());
            }
        }

        public void UpdateProgram(string fileuri)
        {
            try
            {
                tsPBar.Visible = true;
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                Uri uri = new Uri(fileuri);
                string filename = Path.GetFileName(uri.LocalPath);
                webClient.DownloadFileAsync(new Uri(fileuri), Application.StartupPath.ToString() + "\\temp.exe");
            }
            catch
            {
                MessageBox.Show("Download failed, please update manually.\n\nYour download manager should pop up once you hit OK.");
                System.Diagnostics.Process.Start("http://ohlulz.com/download.php?f=rtmpGUI.exe");
                Environment.Exit(0);
            }

        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            tsPBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            tsPBar.Visible = false;
            File.WriteAllText("autoupdate.bat", "@echo off\r\nrem THIS FILE WILL BE DELETED DO NOT EDIT IT\r\ntitle rtmpGUI AutoUpdater\r\necho Waiting for rtmpGUI to close...\r\n@ping 127.0.0.1 -n 2 -w 1000 > nul\r\n@ping 127.0.0.1 -n %1% -w 1000> nul\r\necho Updating rtmpGUI.exe...\r\ndel rtmpGUI.exe\r\nren temp.exe rtmpGUI.exe\r\necho Starting new version of rtmpGUI...\r\nstart rtmpGUI.exe\r\nping -n 1 127.0.0.1 >NUL\r\ndel autoupdate.bat\r\nexit");
            Process.Start("autoupdate.bat");
            this.Close();
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