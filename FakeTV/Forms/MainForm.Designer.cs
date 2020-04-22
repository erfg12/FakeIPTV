namespace FakeTV
{
    partial class FakeTV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlexIP = new System.Windows.Forms.TextBox();
            this.PlexPort = new System.Windows.Forms.TextBox();
            this.PlexToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartServerBtn = new System.Windows.Forms.Button();
            this.VLCPathBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BrowseVLCExe = new System.Windows.Forms.Button();
            this.GetVLCDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HowToBtn = new System.Windows.Forms.Button();
            this.VisitPlex = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.StartingPortBox = new System.Windows.Forms.TextBox();
            this.HideVLC = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DeleteChanBtn = new System.Windows.Forms.Button();
            this.AddNewChanBtn = new System.Windows.Forms.Button();
            this.ChannelListView = new System.Windows.Forms.ListView();
            this.ChanName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Logo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Genre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NewOrOld = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Filters = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CheckChannelsDirWatcher = new System.IO.FileSystemWatcher();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckChannelsDirWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // PlexIP
            // 
            this.PlexIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlexIP.Location = new System.Drawing.Point(70, 17);
            this.PlexIP.Name = "PlexIP";
            this.PlexIP.Size = new System.Drawing.Size(299, 20);
            this.PlexIP.TabIndex = 0;
            this.PlexIP.Text = "127.0.0.1";
            // 
            // PlexPort
            // 
            this.PlexPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PlexPort.Location = new System.Drawing.Point(373, 17);
            this.PlexPort.Name = "PlexPort";
            this.PlexPort.Size = new System.Drawing.Size(65, 20);
            this.PlexPort.TabIndex = 1;
            this.PlexPort.Text = "32400";
            // 
            // PlexToken
            // 
            this.PlexToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlexToken.Location = new System.Drawing.Point(70, 44);
            this.PlexToken.Name = "PlexToken";
            this.PlexToken.Size = new System.Drawing.Size(368, 20);
            this.PlexToken.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Plex IP:Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Plex Token";
            // 
            // StartServerBtn
            // 
            this.StartServerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartServerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartServerBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.StartServerBtn.Location = new System.Drawing.Point(332, 382);
            this.StartServerBtn.Name = "StartServerBtn";
            this.StartServerBtn.Size = new System.Drawing.Size(190, 23);
            this.StartServerBtn.TabIndex = 5;
            this.StartServerBtn.Text = "START FAKE TV STREAMS";
            this.StartServerBtn.UseVisualStyleBackColor = true;
            this.StartServerBtn.Click += new System.EventHandler(this.StartServerBtn_Click);
            // 
            // VLCPathBox
            // 
            this.VLCPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VLCPathBox.Location = new System.Drawing.Point(70, 70);
            this.VLCPathBox.Name = "VLCPathBox";
            this.VLCPathBox.Size = new System.Drawing.Size(368, 20);
            this.VLCPathBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "VLC Exe";
            // 
            // BrowseVLCExe
            // 
            this.BrowseVLCExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseVLCExe.Location = new System.Drawing.Point(442, 69);
            this.BrowseVLCExe.Name = "BrowseVLCExe";
            this.BrowseVLCExe.Size = new System.Drawing.Size(67, 21);
            this.BrowseVLCExe.TabIndex = 8;
            this.BrowseVLCExe.Text = "Browse";
            this.BrowseVLCExe.UseVisualStyleBackColor = true;
            this.BrowseVLCExe.Click += new System.EventHandler(this.BrowseVLCExe_Click);
            // 
            // GetVLCDialog
            // 
            this.GetVLCDialog.DefaultExt = "exe";
            this.GetVLCDialog.Filter = "VLC exe File (*.exe) | *.exe";
            this.GetVLCDialog.InitialDirectory = "C:/";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.HowToBtn);
            this.groupBox1.Controls.Add(this.VisitPlex);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.StartingPortBox);
            this.groupBox1.Controls.Add(this.HideVLC);
            this.groupBox1.Controls.Add(this.BrowseVLCExe);
            this.groupBox1.Controls.Add(this.PlexIP);
            this.groupBox1.Controls.Add(this.PlexPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PlexToken);
            this.groupBox1.Controls.Add(this.VLCPathBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 127);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // HowToBtn
            // 
            this.HowToBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HowToBtn.Location = new System.Drawing.Point(442, 42);
            this.HowToBtn.Name = "HowToBtn";
            this.HowToBtn.Size = new System.Drawing.Size(67, 23);
            this.HowToBtn.TabIndex = 14;
            this.HowToBtn.Text = "How To";
            this.HowToBtn.UseVisualStyleBackColor = true;
            this.HowToBtn.Click += new System.EventHandler(this.HowToBtn_Click);
            // 
            // VisitPlex
            // 
            this.VisitPlex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VisitPlex.Location = new System.Drawing.Point(442, 16);
            this.VisitPlex.Name = "VisitPlex";
            this.VisitPlex.Size = new System.Drawing.Size(67, 23);
            this.VisitPlex.TabIndex = 13;
            this.VisitPlex.Text = "Visit Plex";
            this.VisitPlex.UseVisualStyleBackColor = true;
            this.VisitPlex.Click += new System.EventHandler(this.VisitPlex_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Stream Start Port";
            // 
            // StartingPortBox
            // 
            this.StartingPortBox.Location = new System.Drawing.Point(94, 98);
            this.StartingPortBox.Name = "StartingPortBox";
            this.StartingPortBox.Size = new System.Drawing.Size(57, 20);
            this.StartingPortBox.TabIndex = 11;
            this.StartingPortBox.Text = "8080";
            // 
            // HideVLC
            // 
            this.HideVLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HideVLC.AutoSize = true;
            this.HideVLC.Location = new System.Drawing.Point(438, 98);
            this.HideVLC.Name = "HideVLC";
            this.HideVLC.Size = new System.Drawing.Size(71, 17);
            this.HideVLC.TabIndex = 10;
            this.HideVLC.Text = "Hide VLC";
            this.HideVLC.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.DeleteChanBtn);
            this.groupBox2.Controls.Add(this.AddNewChanBtn);
            this.groupBox2.Controls.Add(this.ChannelListView);
            this.groupBox2.Location = new System.Drawing.Point(7, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 236);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channels";
            // 
            // DeleteChanBtn
            // 
            this.DeleteChanBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteChanBtn.ForeColor = System.Drawing.Color.Red;
            this.DeleteChanBtn.Location = new System.Drawing.Point(6, 207);
            this.DeleteChanBtn.Name = "DeleteChanBtn";
            this.DeleteChanBtn.Size = new System.Drawing.Size(104, 23);
            this.DeleteChanBtn.TabIndex = 2;
            this.DeleteChanBtn.Text = "Delete Channel";
            this.DeleteChanBtn.UseVisualStyleBackColor = true;
            this.DeleteChanBtn.Click += new System.EventHandler(this.DeleteChanBtn_Click);
            // 
            // AddNewChanBtn
            // 
            this.AddNewChanBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewChanBtn.Location = new System.Drawing.Point(405, 207);
            this.AddNewChanBtn.Name = "AddNewChanBtn";
            this.AddNewChanBtn.Size = new System.Drawing.Size(104, 23);
            this.AddNewChanBtn.TabIndex = 1;
            this.AddNewChanBtn.Text = "Add New Channel";
            this.AddNewChanBtn.UseVisualStyleBackColor = true;
            this.AddNewChanBtn.Click += new System.EventHandler(this.AddNewChanBtn_Click);
            // 
            // ChannelListView
            // 
            this.ChannelListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChannelListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChanName,
            this.Logo,
            this.Type,
            this.Genre,
            this.NewOrOld,
            this.Filters});
            this.ChannelListView.FullRowSelect = true;
            this.ChannelListView.GridLines = true;
            this.ChannelListView.HideSelection = false;
            this.ChannelListView.Location = new System.Drawing.Point(7, 20);
            this.ChannelListView.Name = "ChannelListView";
            this.ChannelListView.Size = new System.Drawing.Size(502, 181);
            this.ChannelListView.TabIndex = 0;
            this.ChannelListView.UseCompatibleStateImageBehavior = false;
            this.ChannelListView.View = System.Windows.Forms.View.Details;
            // 
            // ChanName
            // 
            this.ChanName.Text = "Name";
            this.ChanName.Width = 89;
            // 
            // Logo
            // 
            this.Logo.Text = "Logo";
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 67;
            // 
            // Genre
            // 
            this.Genre.Text = "Genre";
            this.Genre.Width = 66;
            // 
            // NewOrOld
            // 
            this.NewOrOld.Text = "New/Old";
            this.NewOrOld.Width = 63;
            // 
            // Filters
            // 
            this.Filters.Text = "Regex Title Filters";
            this.Filters.Width = 210;
            // 
            // CheckChannelsDirWatcher
            // 
            this.CheckChannelsDirWatcher.EnableRaisingEvents = true;
            this.CheckChannelsDirWatcher.Filter = "*.cfg*";
            this.CheckChannelsDirWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.CheckChannelsDirWatcher.Path = "channels";
            this.CheckChannelsDirWatcher.SynchronizingObject = this;
            this.CheckChannelsDirWatcher.Changed += new System.IO.FileSystemEventHandler(this.CheckChannelsDirWatcher_Changed);
            // 
            // FakeTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 417);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartServerBtn);
            this.MinimumSize = new System.Drawing.Size(550, 456);
            this.Name = "FakeTV";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FakeTV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FakeTV_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.FakeTV_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckChannelsDirWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox PlexIP;
        private System.Windows.Forms.TextBox PlexPort;
        private System.Windows.Forms.TextBox PlexToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartServerBtn;
        private System.Windows.Forms.TextBox VLCPathBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BrowseVLCExe;
        private System.Windows.Forms.OpenFileDialog GetVLCDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView ChannelListView;
        private System.Windows.Forms.ColumnHeader ChanName;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Genre;
        private System.Windows.Forms.ColumnHeader NewOrOld;
        private System.Windows.Forms.Button AddNewChanBtn;
        private System.Windows.Forms.Button DeleteChanBtn;
        private System.IO.FileSystemWatcher CheckChannelsDirWatcher;
        private System.Windows.Forms.ColumnHeader Filters;
        private System.Windows.Forms.CheckBox HideVLC;
        private System.Windows.Forms.ColumnHeader Logo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox StartingPortBox;
        private System.Windows.Forms.Button VisitPlex;
        private System.Windows.Forms.Button HowToBtn;
    }
}

