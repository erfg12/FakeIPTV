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
            InitializeComponent();
        }

        Functions fun = new Functions();

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

            foreach (ListViewItem item in ChannelListView.Items)
            {
                string ChanName = item.SubItems[0].Text;
                string ChanLogo = item.SubItems[1].Text;
                string ChanType = item.SubItems[2].Text;
                string ChanGenre = item.SubItems[3].Text;
                string ChanAge = item.SubItems[4].Text;
                string ChanFilters = item.SubItems[5].Text;

                iptv_lines.Add("#EXTINF:-1 tvg-id=\"\" tvg-name=\"" + ChanName + "\" tvg-language=\"English\" tvg-logo=\"" + ChanLogo + "\" tvg-country=\"US\" tvg-url=\"\" group-title=\"" + ChanGenre + "\"");
                iptv_lines.Add("http://127.0.0.1:" + StreamPort);
                
                if (VLCPathBox.Text != "")
                {
                    Process vlc = new Process();
                    vlc.StartInfo.FileName = VLCPathBox.Text;
                    if (HideVLC.Checked)
                        vlc.StartInfo.Arguments = @"playlists/" + ChanName + ".m3u --sout =#http{mux=ts,dst=:" + StreamPort + "/} :no-sout-all :sout-keep -I dummy";
                    else
                        vlc.StartInfo.Arguments = @"playlists/" + ChanName + ".m3u --sout =#http{mux=ts,dst=:" + StreamPort + "/} :no-sout-all :sout-keep";
                    vlc.Start();
                }
                StreamPort++;
            }
            File.WriteAllLines(@"iptv.m3u", iptv_lines);

            // create XMLTV file
            // TODO

            StartServerBtn.Text = "STOP FAKE TV STREAMS";
            StartServerBtn.ForeColor = Color.Maroon;
        }

        private void FetchMediaBtn_Click(object sender, EventArgs e)
        {
            if (!fun.GrabPlexLibrary(PlexIP.Text, PlexPort.Text, PlexToken.Text))
            {
                MessageBox.Show("ERROR: No access to Plex's library!");
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            fun.CreateDirs();
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

        private void GenerateM3UChansBtn_Click(object sender, EventArgs e)
        {
            // iterate through channel list view items, generate playlist m3u files
            foreach (ListViewItem item in ChannelListView.Items)
            {
                string ChanName = item.SubItems[0].Text;
                string ChanLogo = item.SubItems[1].Text;
                string ChanType = item.SubItems[2].Text;
                string ChanGenre = item.SubItems[3].Text;
                string ChanAge = item.SubItems[4].Text;
                string ChanFilters = item.SubItems[5].Text;

                // TODO: Apply filters
                /*if (!item.SubItems[1].Text.Equals("Any")) // Type
                {
                }*/

                // parse our media XML files
                DirectoryInfo d = new DirectoryInfo("categories");

                foreach (var file in d.GetFiles("*.xml"))
                {
                    // get our direct media paths and append to playlist m3u
                    Debug.WriteLine("Parsing XML " + file.FullName);
                    XDocument coordinates = XDocument.Load(file.FullName);
                    var items = coordinates.Descendants("Part")
                       .Select(node => (string)node.Attribute("file").Value.ToString())
                       .ToList();
                    File.WriteAllLines(@"playlists/" + ChanName + ".m3u", items);
                }
            }
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
    }
}
