using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
//using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace rtmpGUI
{
    public class ListFunctions
    {
        public void SaveList(ListView listView, string file)
        {
            try
            {
                using (var tw = new XmlTextWriter(file, null)) // By using the using statement (not directive!) we remove the need of tw.Close() afterwards.
                {
                    tw.Formatting = Formatting.Intended;
                    tw.WriteStartDocument();
                    tw.WriteStartElement("streams", string.Empty);

                    foreach (var listItem in list.SelectedItems)
                    {
                        // Start a new element.
                        tw.WriteStartElement("stream", string.Empty);

                        tw.WriteString("title", listItem.SubItems[0].Text);
                        tw.WriteString("swfUrl", listItem.SubItems[1].Text);
                        tw.WriteString("link", listItem.SubItems[2].Text);
                        tw.WriteString("pageUrl", listItem.SubItems[3].Text);
                        tw.WriteString("playpath", listItem.SubItems[4].Text);

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

        private void DebugLog(string item)
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
    }
}
