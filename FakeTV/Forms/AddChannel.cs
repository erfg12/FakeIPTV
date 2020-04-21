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

        private void GetChanIconBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = ChanIconBrowse.ShowDialog();
            Directory.CreateDirectory("logos");
            if (result == DialogResult.OK)
            {
                ChanIconBox.ImageLocation = ChanIconBrowse.FileName;
                System.IO.File.Copy(ChanIconBrowse.FileName, "logos/" + ChanIconBrowse.FileName, true);
            }
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
            System.IO.Directory.CreateDirectory("channels");
            string[] lines = { ChanIconBrowse.FileName, TypeBox.Text, GenreBox.Text, NewOldBox.Text, FiltersBox.Text };
            System.IO.File.WriteAllLines(@"channels/" + ChanNameBox.Text + ".cfg", lines);
            Close();
        }
    }
}
