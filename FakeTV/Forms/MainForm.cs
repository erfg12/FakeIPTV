using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace FakeTV
{
    public partial class FakeTV : Form
    {
        public FakeTV()
        {
            fun.CreateDirs();
            InitializeComponent();
        }

        Functions fun = new Functions();
        string XMLTVData = "";
        Dictionary<string,string> XMLVideoData = new Dictionary<string,string>();

        private void BrowseVLCExe_Click(object sender, EventArgs e)
        {
            DialogResult result = GetVLCDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                VLCPathBox.Text = GetVLCDialog.FileName;
            }
        }

        private void StartServerBtn_Click(object sender, EventArgs e)
        {
            if (!fun.GrabPlexLibrary(PlexIP.Text, PlexPort.Text, PlexToken.Text))
            {
                MessageBox.Show("ERROR: No access to Plex's library!");
            }

            GenerateM3uChannels();

            if (StartServerBtn.Text.Equals("STOP FAKE TV STREAMS"))
            {
                fun.KillVLC();
                StartServerBtn.Text = "START FAKE TV STREAMS";
                StartServerBtn.ForeColor = Color.ForestGreen;
                //File.Delete("XMLTV.xml");
                //File.Delete("iptv.m3u");
                XMLTVData = "";
                XMLVideoData.Clear();
                return;
            }

            // create our IP TV extended m3u file, and start VLC streams
            List<string> iptv_lines = new List<string>();
            iptv_lines.Add("#EXTM3U");

            int StreamPort = Convert.ToInt32(StartingPortBox.Text);

            XMLTVData += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<tv generator-info-name=\"WebGrab+Plus/w MDB &amp; REX Postprocess -- version V2.1.9 -- Jan van Straaten\" generator-info-url=\"http://www.MarvelIPTV.com\">";
            foreach (ListViewItem item in ChannelListView.Items)
            {
                string ChanName = item.SubItems[0].Text;
                string ChanLogo = item.SubItems[1].Text;
                string ChanType = item.SubItems[2].Text;
                string ChanGenre = item.SubItems[3].Text;
                string ChanAge = item.SubItems[4].Text;
                string ChanFilters = item.SubItems[5].Text;

                // add to IP TV m3u
                iptv_lines.Add("#EXTINF:-1 tvg-id=\"\" tvg-name=\"" + ChanName + "\" tvg-language=\"English\" tvg-logo=\"" + ChanLogo + "\" tvg-country=\"US\" tvg-url=\"\" group-title=\"" + ChanGenre + "\"," + ChanName);
                iptv_lines.Add("http://127.0.0.1:" + StreamPort);

                // append to XMLTV file
                XMLTVData += "<channel id=\"" + ChanName + "\">" +
                    "<display-name>" + ChanName + @"</display-name>" +
                    "<icon src=\"" + ChanLogo + "\" />" +
                    "</channel>";
                
                // start up our VLC streams
                if (VLCPathBox.Text != "")
                {
                    Process vlc = new Process();
                    vlc.StartInfo.FileName = VLCPathBox.Text;
                    string vlcArgs = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    if (HideVLC.Checked)
                        vlcArgs += @"\playlists\" + ChanName + ".m3u --sout=#http{mux=ts,dst=:" + StreamPort + "/} :no-sout-all :sout-keep -I dummy";
                    else
                        vlcArgs += @"\playlists\" + ChanName + ".m3u --sout=#http{mux=ts,dst=:" + StreamPort + "/} :no-sout-all :sout-keep";
                    vlc.StartInfo.Arguments = vlcArgs;
                    vlc.Start();
                }
                StreamPort++;
            }
            File.WriteAllLines(@"iptv.m3u", iptv_lines);

            XmlDocument xdoc = new XmlDocument();
            string XMLInfo = XMLTVData;
            foreach(KeyValuePair<string, string> kvp in XMLVideoData) {
                XMLInfo += kvp.Value;
            }
            XMLInfo += "</tv>";
            //File.WriteAllText(@"debug.txt", XMLInfo); // DEBUG
            xdoc.LoadXml(XMLInfo);
            xdoc.Save("XMLTV.xml");

            StartServerBtn.Text = "STOP FAKE TV STREAMS";
            StartServerBtn.ForeColor = Color.Maroon;
        }

        private void FetchMediaBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void Form_Load(object sender, EventArgs e)
        {
            
        }

        private void AddNewChanBtn_Click(object sender, EventArgs e)
        {
            AddChannel AddChan = new AddChannel();
            AddChan.Show();
        }

        void UpdateChanListView()
        {
            ChannelListView.Items.Clear();
            DirectoryInfo d = new DirectoryInfo("channels");

            foreach (var file in d.GetFiles("*.cfg"))
            {
                string[] row = fun.ParseChanCFGFile(file);
                var listViewItem = new ListViewItem(row);
                ChannelListView.Items.Add(listViewItem);
            }
        }

        private void CheckChannelsDirWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine("CheckChannelsDirWatcher triggered!");
            UpdateChanListView();
        }

        public void GenerateM3uChannels()
        {
            foreach (ListViewItem item in ChannelListView.Items)
            {
                string ChanName = item.SubItems[0].Text;
                string ChanLogo = item.SubItems[1].Text;
                string ChanType = item.SubItems[2].Text;
                string ChanGenre = item.SubItems[3].Text;
                string ChanAge = item.SubItems[4].Text;
                string ChanFilters = item.SubItems[5].Text;

                // store XML nodes in these variables so we can shuffle them later
                List<string> VideoFiles = new List<string>();
                Dictionary<string, string> Titles = new Dictionary<string, string>();
                Dictionary<string, string> Summaries = new Dictionary<string, string>();
                Dictionary<string, int> Durations = new Dictionary<string, int>();

                DateTime dt = DateTime.Now;

                // parse our media XML files
                DirectoryInfo d = new DirectoryInfo("categories");

                foreach (var file in d.GetFiles("*.xml"))
                {
                    // get our direct media paths and append to playlist m3u
                    Debug.WriteLine("Parsing XML " + file.FullName);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(file.FullName);
                    XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/MediaContainer/Video");
                    foreach (XmlNode node in nodeList)
                    {
                        bool FoundGenre = false;
                        bool FoundType = false;
                        bool FilterFound = false;
                        foreach (XmlNode GNode in node.SelectNodes("Genre"))
                        {
                            if (GNode.Attributes["tag"].Value.Equals(ChanGenre) || ChanGenre.Equals("Any"))
                                FoundGenre = true;
                        }
                        if (node.Attributes["type"].Value.Equals(ChanType) || ChanType.Equals("Both"))
                            FoundType = true;

                        if (!ChanFilters.Equals(""))
                        {
                            Regex rx = new Regex(ChanFilters, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                            if (rx.Match(WebUtility.HtmlEncode(node.Attributes["title"].Value)).Success)
                                FilterFound = true;
                        }

                        if (FoundType && FoundGenre && (!ChanFilters.Equals("") && FilterFound))
                        {
                            string VideoPath = "";
                            if (node.Attributes["type"].Value.Equals("show") && ChanType.Equals("show"))
                            {
                                // parse through XML differently

                            }
                            else
                            {
                                VideoPath = node.SelectSingleNode("Media/Part").Attributes["file"].Value;
                            }
                            VideoFiles.Add(VideoPath);
                            Durations[VideoPath] = Convert.ToInt32(node.Attributes["duration"].Value);
                            Titles[VideoPath] = WebUtility.HtmlEncode(node.Attributes["title"].Value);
                            Summaries[VideoPath] = WebUtility.HtmlEncode(node.Attributes["title"].Value);
                        }
                    }
                }

                // shuffle the videos around to prevent videos with the same genre from playing all on the same channels
                foreach (string vf in fun.Shuffle(VideoFiles))
                {
                    TimeSpan ts = new TimeSpan(0, 0, Durations[vf] / 1000);
                    DateTime dt2 = dt;
                    dt2 += ts;

                    XMLVideoData[vf] = "<programme start=\"" + String.Format("{0:yyyyMMddHHmmss}", dt) + " -0400\" stop=\"" + String.Format("{0:yyyyMMddHHmmss}", dt2) + " -0400\" channel=\"" + ChanName + "\">" +
                        "<title lang=\"en\">" + Titles[vf] + "</title>" +
                        "<desc lang=\"en\">" + Summaries[vf] + "</desc>" +
                        "<category lang=\"en\">" + ChanName + "</category>" +
                        "</programme>";

                    dt += ts;
                }
                File.WriteAllLines(@"playlists/" + ChanName + ".m3u", XMLVideoData.Keys);
            }
        }

        private void GenerateM3UChansBtn_Click(object sender, EventArgs e)
        {
            // iterate through channel list view items, generate playlist m3u files
            
        }

        private void FakeTV_Shown(object sender, EventArgs e)
        {
            PlexIP.Text = Properties.Settings.Default.PlexIP;
            PlexPort.Text = Properties.Settings.Default.PlexPort;
            PlexToken.Text = Properties.Settings.Default.PlexToken;
            HideVLC.Checked = Properties.Settings.Default.HideVLC;
            StartingPortBox.Text = Properties.Settings.Default.StartPort;
            VLCPathBox.Text = Properties.Settings.Default.VLCexe;
            UpdateChanListView();
        }

        private void FakeTV_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.PlexIP = PlexIP.Text;
            Properties.Settings.Default.PlexPort = PlexPort.Text;
            Properties.Settings.Default.PlexToken = PlexToken.Text;
            Properties.Settings.Default.HideVLC = HideVLC.Checked;
            Properties.Settings.Default.StartPort = StartingPortBox.Text;
            Properties.Settings.Default.VLCexe = VLCPathBox.Text;
            Properties.Settings.Default.Save();
            fun.KillVLC();
        }

        private void VisitPlex_Click(object sender, EventArgs e)
        {
            Process.Start("http://" + PlexIP.Text + ":" + PlexPort.Text);
        }

        private void HowToBtn_Click(object sender, EventArgs e)
        {
            using (Form form = new Form())
            {
                var img = new Bitmap(Properties.Resources.guide);

                form.StartPosition = FormStartPosition.CenterScreen;
                form.Size = new Size(img.Size.Width + 15, img.Size.Height + 40);

                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                pb.Image = img;

                form.Controls.Add(pb);
                form.ShowDialog();
            }
        }

        private void DeleteChanBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"channels/" + ChannelListView.SelectedItems[0].SubItems[0].Text + ".cfg"))
            {
                File.Delete(@"channels/" + ChannelListView.SelectedItems[0].SubItems[0].Text + ".cfg");
            }
            UpdateChanListView();
        }
    }
}