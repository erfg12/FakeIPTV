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
        string XMLTVShowData = "";

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
                return;
            }

            // create our IP TV extended m3u file, and start VLC streams
            List<string> iptv_lines = new List<string>();
            iptv_lines.Add("#EXTM3U");

            int StreamPort = Convert.ToInt32(StartingPortBox.Text);

            XMLTVData += "<tv source-info-url=\"http://www.schedulesdirect.org/\" source-info-name=\"Schedules Direct\" generator-info-name=\"XMLTV/$Id: tv_grab_na_dd.in,v 1.70 2008/03/03 15:21:41 rmeden Exp $\" generator-info-url=\"http://www.xmltv.org/\">";
            foreach (ListViewItem item in ChannelListView.Items)
            {
                string ChanName = item.SubItems[0].Text;
                string ChanLogo = item.SubItems[1].Text;
                string ChanType = item.SubItems[2].Text;
                string ChanGenre = item.SubItems[3].Text;
                string ChanAge = item.SubItems[4].Text;
                string ChanFilters = item.SubItems[5].Text;

                // add to IP TV m3u
                iptv_lines.Add("#EXTINF:-1 tvg-id=\"\" tvg-name=\"" + ChanName + "\" tvg-language=\"English\" tvg-logo=\"" + ChanLogo + "\" tvg-country=\"US\" tvg-url=\"\" group-title=\"" + ChanGenre + "\"");
                iptv_lines.Add("http://127.0.0.1:" + StreamPort);

                // append to XMLTV file
                XMLTVData += "<channel id=\"" + item.Index.ToString() + "\">" +
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
            string XMLInfo = XMLTVData + XMLTVShowData + "</tv>";
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
                    List<string> VideoFiles = new List<string>();
                    foreach (XmlNode node in nodeList)
                    {
                        bool FoundGenre = false;
                        bool FoundType = false;
                        foreach (XmlNode GNode in node.SelectNodes("Genre"))
                        {
                            if (GNode.Attributes["tag"].Value.Equals(ChanGenre) || ChanGenre.Equals("Any"))
                                FoundGenre = true;
                        }
                        if (node.Attributes["type"].Value.Equals(ChanType) || ChanType.Equals("Both"))
                            FoundType = true;

                        if (FoundType && FoundGenre)
                            VideoFiles.Add(node.SelectSingleNode("Media/Part").Attributes["file"].Value);

                        TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(node.Attributes["duration"].Value) / 1000);
                        DateTime dt2 = DateTime.Now;
                        dt2 += ts;

                        XMLTVShowData += "<programme start=\"" + String.Format("{0:yyyyMMddHHmmss}", dt) + " -0500\" stop=\"" + String.Format("{0:yyyyMMddHHmmss}", dt2) + " -0500\" channel=\"" + item.Index.ToString() + "\">" +
                            "<title lang=\"en\">" + WebUtility.HtmlEncode(node.Attributes["title"].Value) + "</title>" +
                            "<desc lang=\"en\">" + WebUtility.HtmlEncode(node.Attributes["summary"].Value) + "</desc>" +
                            "<date>" + String.Format("{0:yyyyMMdd}", dt) + "</date>" +
                            "<category lang=\"en\">" + ChanName + "</category>" +
                            "<audio>" +
                            "<stereo>stereo</stereo>" +
                            "</audio>" +
                            "<previously-shown start = \"\" />" +
                            "<subtitles type = \"teletext\" />" +
                            "</programme>";

                        dt += ts;
                    }
                    File.WriteAllLines(@"playlists/" + ChanName + ".m3u", VideoFiles);
                }
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
