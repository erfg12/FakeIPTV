using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeTV
{
    public partial class AddChannel : Form
    {
        string cfgPath = "";
        public AddChannel(string ConfigPath = "")
        {
            InitializeComponent();
            cfgPath = ConfigPath;
        }

        private void AddChannel_Load(object sender, EventArgs e)
        {

        }

        private void AddChannel_Shown(object sender, EventArgs e)
        {
            if (cfgPath.Equals(""))
            {
                GenreBox.SelectedIndex = 0;
                TypeBox.SelectedIndex = 0;
                NewOldBox.SelectedIndex = 0;
            } 
            else
            {
                this.Name = "Edit Existing Channel";
                string[] vars = File.ReadAllLines(cfgPath);
                ChanLogoBox.Text = vars[0];
                TypeBox.Text = vars[1];
                GenreBox.Text = vars[2];
                NewOldBox.Text = vars[3];
                FiltersBox.Text = vars[4];
                ChanNameBox.Text = Path.GetFileNameWithoutExtension(cfgPath);
            }
        }

        private void SaveAndClose_Click(object sender, EventArgs e)
        {
            if (ChanLogoBox.Text == "" || ChanNameBox.Text == "")
            {
                MessageBox.Show("ERROR: Channel Logo and Name are required.");
                return;
            }
            Directory.CreateDirectory("channels");
            string exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string[] lines = { ChanLogoBox.Text, TypeBox.Text, GenreBox.Text, NewOldBox.Text, FiltersBox.Text };
            File.WriteAllLines(@"channels/" + ChanNameBox.Text + ".cfg", lines);
            Close();
        }
    }
}
