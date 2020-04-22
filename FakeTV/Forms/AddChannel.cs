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
        public AddChannel()
        {
            InitializeComponent();
        }

        private void AddChannel_Load(object sender, EventArgs e)
        {
            
        }

        private void AddChannel_Shown(object sender, EventArgs e)
        {
            GenreBox.SelectedIndex = 0;
            TypeBox.SelectedIndex = 0;
            NewOldBox.SelectedIndex = 0;
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
