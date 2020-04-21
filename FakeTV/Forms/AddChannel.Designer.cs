namespace FakeTV
{
    partial class AddChannel
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
            this.ChanNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChanIconBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GetChanIconBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.GenreBox = new System.Windows.Forms.ComboBox();
            this.NewOldBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SaveAndClose = new System.Windows.Forms.Button();
            this.ChanIconBrowse = new System.Windows.Forms.OpenFileDialog();
            this.FiltersBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChanIconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChanNameBox
            // 
            this.ChanNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChanNameBox.Location = new System.Drawing.Point(96, 27);
            this.ChanNameBox.Name = "ChanNameBox";
            this.ChanNameBox.Size = new System.Drawing.Size(154, 20);
            this.ChanNameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Channel Name";
            // 
            // ChanIconBox
            // 
            this.ChanIconBox.Location = new System.Drawing.Point(18, 27);
            this.ChanIconBox.Name = "ChanIconBox";
            this.ChanIconBox.Size = new System.Drawing.Size(65, 65);
            this.ChanIconBox.TabIndex = 2;
            this.ChanIconBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Channel Logo";
            // 
            // GetChanIconBtn
            // 
            this.GetChanIconBtn.Location = new System.Drawing.Point(18, 98);
            this.GetChanIconBtn.Name = "GetChanIconBtn";
            this.GetChanIconBtn.Size = new System.Drawing.Size(65, 27);
            this.GetChanIconBtn.TabIndex = 4;
            this.GetChanIconBtn.Text = "Browse";
            this.GetChanIconBtn.UseVisualStyleBackColor = true;
            this.GetChanIconBtn.Click += new System.EventHandler(this.GetChanIconBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Genre";
            // 
            // GenreBox
            // 
            this.GenreBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenreBox.FormattingEnabled = true;
            this.GenreBox.Items.AddRange(new object[] {
            "Any",
            "Action",
            "Comedy",
            "Drama"});
            this.GenreBox.Location = new System.Drawing.Point(96, 64);
            this.GenreBox.Name = "GenreBox";
            this.GenreBox.Size = new System.Drawing.Size(154, 21);
            this.GenreBox.TabIndex = 7;
            // 
            // NewOldBox
            // 
            this.NewOldBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NewOldBox.FormattingEnabled = true;
            this.NewOldBox.Items.AddRange(new object[] {
            "New",
            "Old",
            "Both"});
            this.NewOldBox.Location = new System.Drawing.Point(176, 104);
            this.NewOldBox.Name = "NewOldBox";
            this.NewOldBox.Size = new System.Drawing.Size(74, 21);
            this.NewOldBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "New / Old";
            // 
            // TypeBox
            // 
            this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Items.AddRange(new object[] {
            "Both",
            "TVShows",
            "Movies"});
            this.TypeBox.Location = new System.Drawing.Point(96, 104);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(74, 21);
            this.TypeBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Type";
            // 
            // SaveAndClose
            // 
            this.SaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveAndClose.Location = new System.Drawing.Point(157, 174);
            this.SaveAndClose.Name = "SaveAndClose";
            this.SaveAndClose.Size = new System.Drawing.Size(93, 29);
            this.SaveAndClose.TabIndex = 12;
            this.SaveAndClose.Text = "Save And Close";
            this.SaveAndClose.UseVisualStyleBackColor = true;
            this.SaveAndClose.Click += new System.EventHandler(this.SaveAndClose_Click);
            // 
            // FiltersBox
            // 
            this.FiltersBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FiltersBox.Location = new System.Drawing.Point(18, 145);
            this.FiltersBox.Name = "FiltersBox";
            this.FiltersBox.Size = new System.Drawing.Size(232, 20);
            this.FiltersBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Filters";
            // 
            // AddChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 215);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FiltersBox);
            this.Controls.Add(this.SaveAndClose);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NewOldBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GenreBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GetChanIconBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChanIconBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChanNameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(279, 254);
            this.Name = "AddChannel";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Channel";
            this.Load += new System.EventHandler(this.AddChannel_Load);
            this.Shown += new System.EventHandler(this.AddChannel_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ChanIconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChanNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ChanIconBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetChanIconBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox GenreBox;
        private System.Windows.Forms.ComboBox NewOldBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SaveAndClose;
        private System.Windows.Forms.OpenFileDialog ChanIconBrowse;
        private System.Windows.Forms.TextBox FiltersBox;
        private System.Windows.Forms.Label label6;
    }
}