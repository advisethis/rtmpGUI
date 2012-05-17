using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

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
        string default_commands = string.Empty;

        string localloadloc = string.Empty;
        string localsaveloc = string.Empty;

        string apiUser = string.Empty;
        string apiKey = string.Empty;

        public bool supcom = true;
        HttpWebRequest webconnect;

        private delegate void AddItemCallback(object o);
        delegate void MyDelegate(string[] array);

        private ListViewColumnSorter lvwColumnSorter;

        public Main()
        {
            InitializeComponent();
            this.Font = SystemFonts.MessageBoxFont;
            wbApp.IsWebBrowserContextMenuEnabled = false;

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
        }

        #region form_stuff

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();

            LoadAppSettings();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAppSettings();
        }

        #region file_menu

        private void optionsMenu_Click(object sender, EventArgs e)
        {
            Options form = Options.Instance();
            if (!form.Visible)
            {
                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }

        private void remoteXmlLoad_Click(object sender, EventArgs e)
        {
            ThreadStart update = new ThreadStart(RemoteXML);
            Thread remoteThread = new Thread(update);
            remoteThread.Priority = ThreadPriority.Normal;
            remoteThread.IsBackground = true;
            remoteThread.Start();
        }

        private void LocalXMLLoad_Click(object sender, EventArgs e)
        {
            ThreadStart update = new ThreadStart(LocalXml);
            Thread localThread = new Thread(update);
            localThread.Priority = ThreadPriority.Normal;
            localThread.IsBackground = true;
            localThread.Start();
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

        #endregion file_menu

        #region help_menu

        private void howToMenu_Click(object sender, EventArgs e)
        {
            if (howToMenu.Checked == true)
            {
                wbApp.Navigate("http://apps.ohlulz.com/rtmpgui/guide.php");
            }
            else
            {
                wbApp.Navigate(homepage);
            }
        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            using (Form About = new About())
            {
                About.ShowDialog();
            }
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://ohlulz.com/donate.php");
        }

        #endregion help_menu

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
                    ec.txtResolution.Text = lvi.SubItems[7].Text;
                    ec.txtBitrate.Text = lvi.SubItems[8].Text;
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
                    var saferesolution = HttpUtility.UrlEncode(lvi.SubItems[7].Text);
                    var safebitrate = HttpUtility.UrlEncode(lvi.SubItems[8].Text);
                    sysLabel.Text = connection("http://apps.ohlulz.com/rtmpgui/api.php?title=" + safetitle + "&swfUrl=" + safeswf + "&link=" + safertmp + "&pageUrl=" + safepage + "&playpath=" + safeplay + "&lang=" + safelang + "&advanced=" + safeadvanced + "&resolution=" + saferesolution + "&bitrate=" + safebitrate + "&apiUser=" + apiUser + "&apiKey=" + apiKey);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DebugLog(ex.ToString());
            }
        }

        #endregion context_menu

        #region listview

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                fontDialog.Font = SystemFonts.MessageBoxFont;
                fontDialog.ShowDialog();
                listView1.Font = fontDialog.Font;
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            RefreshSettings();
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                RunStream(lvi.SubItems[0].Text, lvi.SubItems[1].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text, lvi.SubItems[4].Text, lvi.SubItems[6].Text);
                sysLabel.Text = "Loading : " + lvi.SubItems[0].Text;
            }
            timer1.Enabled = true;
            timer1.Start();
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                RefreshSettings();
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    RunStream(lvi.SubItems[0].Text, lvi.SubItems[1].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text, lvi.SubItems[4].Text, lvi.SubItems[6].Text);
                    sysLabel.Text = "Loading : " + lvi.SubItems[0].Text;
                }
                timer1.Enabled = true;
                timer1.Start();
            }
        }

        #endregion listview

        private void wbApp_NewWindow(object sender, CancelEventArgs e)
        {
            wbApp.Navigate(wbApp.StatusText);
            e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 0;
            while (i <= 5)
            {
                if (i == 5)
                {
                    sysLabel.Text = "";
                    timer1.Stop();
                    timer1.Enabled = false;
                }
                i++;
            }
        }

        #endregion form_stuff

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
                    xDoc.LoadXml(connection("http://apps.ohlulz.com/rtmpgui/list.xml"));
                    //xDoc.LoadXml(connection("http://127.0.0.1/www/rtmpgui/list.php"));
                    this.Text = "rtmpGUI : Remote Channel List";

                    XmlNodeList nodes = xDoc.SelectNodes("/streams/stream");
                    int nc = nodes.Count;
                    tsslRight.Text = nc.ToString() + " streams loaded";
                    foreach (XmlNode xn in nodes)
                    {
                        ListViewItem lvi = listView1.Items.Add(xn["title"].InnerText);
                        lvi.SubItems.Add(xn["swfUrl"].InnerText);
                        lvi.SubItems.Add(xn["link"].InnerText);
                        lvi.SubItems.Add(xn["pageUrl"].InnerText);
                        lvi.SubItems.Add(xn["playpath"].InnerText);
                        lvi.SubItems.Add(xn["language"].InnerText);
                        lvi.SubItems.Add(xn["advanced"].InnerText);
                        //lvi.SubItems.Add(xn["info"].Attributes["resolution"].Value);
                        //lvi.SubItems.Add(xn["info"].Attributes["bitrate"].Value);
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    MessageBox.Show("An error occurred while trying to load the remote channel list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DebugLog(ex.ToString());
                }
            }
        }

        private void LocalXml()
        {
            if (listView1.InvokeRequired)
            {
                listView1.BeginInvoke(new MethodInvoker(() => LocalXml()));
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
                    this.Text = "rtmpGUI : " + localloadloc;

                    XmlNodeList nodes = xDoc.SelectNodes("/streams/stream");
                    int nc = nodes.Count;
                    tsslRight.Text = nc.ToString() + " streams loaded";
                    foreach (XmlNode xn in nodes)
                    {
                        ListViewItem lvi = listView1.Items.Add(xn["title"].InnerText);
                        lvi.SubItems.Add(xn["swfUrl"].InnerText);
                        lvi.SubItems.Add(xn["link"].InnerText);
                        lvi.SubItems.Add(xn["pageUrl"].InnerText);
                        lvi.SubItems.Add(xn["playpath"].InnerText);
                        lvi.SubItems.Add(xn["language"].InnerText);
                        lvi.SubItems.Add(xn["advanced"].InnerText);
                        //lvi.SubItems.Add(xn["info"].Attributes["resolution"].Value);
                        //lvi.SubItems.Add(xn["info"].Attributes["bitrate"].Value);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while trying to load " + localloadloc, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lvi.SubItems.Add(array[7]);
                lvi.SubItems.Add(array[8]);
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
                    lvi.SubItems[7].Text = array[7];
                    lvi.SubItems[8].Text = array[8];
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
                list = xDoc.SelectSingleNode("/rtmpGUI/list/@remote").Value;
                updates = xDoc.GetElementsByTagName("updates")[0].InnerText;
                altload = xDoc.SelectSingleNode("/rtmpGUI/altpage/@load").Value;
                altpage = xDoc.GetElementsByTagName("altpage")[0].InnerText;
                suppress = xDoc.GetElementsByTagName("suppress")[0].InnerText;
                default_commands = xDoc.GetElementsByTagName("default_commands")[0].InnerText;

                apiUser = xDoc.SelectSingleNode("/rtmpGUI/api/@user").Value;
                apiKey = xDoc.SelectSingleNode("/rtmpGUI/api/@key").Value;

                if (list == "true")
                {
                    ThreadStart update = new ThreadStart(RemoteXML);
                    Thread check = new Thread(update);
                    check.Start();
                }
                else
                {
                    localloadloc = xDoc.GetElementsByTagName("list")[0].InnerText;
                    ThreadStart update = new ThreadStart(LocalXml);
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

                if (default_commands == "true")
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
                suppress = xDoc.GetElementsByTagName("suppress")[0].InnerText;

                apiUser = xDoc.SelectSingleNode("/rtmpGUI/api/@user").Value;
                apiKey = xDoc.SelectSingleNode("/rtmpGUI/api/@key").Value;

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

        private void RunStream(string title, string swfUrl, string link, string pageUrl, string playpath, string advanced)
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
                    pr.StartInfo.Arguments = @"/C" + "rtmpdump --live -v -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " | " + vlcLoc + " --meta-title=\"" + title + "\" -";
                    txtCommands.Text = "rtmpdump" + " -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " | " + vlcLoc + " --meta-title=\"" + title + "\" -";
                }
                else
                {
                    pr.StartInfo.Arguments = @"/C" + "rtmpdump --live -v -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " -y " + playpath + " | " + vlcLoc + " --meta-title=\"" + title + "\" -";
                    txtCommands.Text = "rtmpdump" + " -r " + link + " -W " + swfUrl + " " + advanced + " -p " + pageUrl + " -y " + playpath + " | " + vlcLoc + " --meta-title=\"" + title + "\" -";
                }

                pr.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to play the channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("An error occurred while trying to record the channel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DebugLog(ex.ToString());
            }
        }

        public void SaveList(ListView list, string file)
        {
            try
            {
                using (var tw = new XmlTextWriter(file, null))
                {
                    tw.Formatting = Formatting.Indented;
                    tw.WriteStartDocument();
                    tw.WriteStartElement("streams");

                    for (int i = 0; i < list.Items.Count; i++)
                    {
                        tw.WriteStartElement("stream", string.Empty);

                        tw.WriteStartElement("title", string.Empty);
                        tw.WriteString(list.Items[i].SubItems[0].Text);
                        tw.WriteEndElement();

                        tw.WriteStartElement("info", string.Empty);
                        tw.WriteAttributeString("resolution", list.Items[i].SubItems[7].Text);
                        tw.WriteAttributeString("bitrate", list.Items[i].SubItems[8].Text);
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

                        tw.WriteEndElement();
                    }

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
                    timer1.Enabled = true;
                    timer1.Start();
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

        public void SaveAppSettings()
        {
            using (var tw = new XmlTextWriter(Application.StartupPath.ToString() + "\\app.config", null))
            {
                tw.Formatting = Formatting.Indented;
                tw.WriteStartDocument();
                tw.WriteStartElement("rtmpGUI", string.Empty);

                tw.WriteStartElement("WindowSize", "");
                tw.WriteAttributeString("Height", this.Size.Height.ToString());
                tw.WriteAttributeString("Width", this.Size.Width.ToString());
                tw.WriteEndElement();

                tw.WriteStartElement("WindowLocation", "");
                tw.WriteAttributeString("X", this.Location.X.ToString());
                tw.WriteAttributeString("Y", this.Location.Y.ToString());
                tw.WriteEndElement();

                tw.WriteStartElement("PanelWidth", "");
                tw.WriteString(splitContainer1.SplitterDistance.ToString());
                tw.WriteEndElement();

                tw.WriteEndElement();
                tw.WriteEndDocument();
            }
        }

        private void LoadAppSettings()
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                int LocationX;
                int LocationY;
                string PanelWidth;
                xDoc.Load(Application.StartupPath.ToString() + "\\app.config");

                this.Height = int.Parse(xDoc.SelectSingleNode("/rtmpGUI/WindowSize/@Height").Value);
                this.Width = int.Parse(xDoc.SelectSingleNode("/rtmpGUI/WindowSize/@Width").Value);

                LocationX = int.Parse(xDoc.SelectSingleNode("/rtmpGUI/WindowLocation/@X").Value);
                LocationY = int.Parse(xDoc.SelectSingleNode("/rtmpGUI/WindowLocation/@Y").Value);

                PanelWidth = xDoc.GetElementsByTagName("PanelWidth")[0].InnerText;

                this.Location = new Point(LocationX, LocationY);
                splitContainer1.SplitterDistance = int.Parse(PanelWidth);
            }
            catch (Exception ex)
            {
                this.Height = 383;
                this.Width = 590;

                this.Location = new Point(0, 0);
                splitContainer1.SplitterDistance = 180;
            }
        }

        #endregion functions
    }
}