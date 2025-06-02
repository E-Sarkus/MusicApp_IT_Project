namespace MusicApp_IT_Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            flowLayoutPanel1 = new FlowLayoutPanel();
            lovedLabel = new Label();
            label1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            playlistSelectedLabel = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            uploadedMusicLabel = new Label();
            panel1 = new Panel();
            materialSlider1 = new MaterialSkin.Controls.MaterialSlider();
            materialFloatingActionButton3 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialFloatingActionButton2 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialFloatingActionButton1 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            artistPlaying = new Label();
            pictureBox1 = new PictureBox();
            musicPlaying = new Label();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(35, 35, 36);
            flowLayoutPanel1.Controls.Add(lovedLabel);
            flowLayoutPanel1.Location = new Point(12, 25);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(346, 991);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // lovedLabel
            // 
            lovedLabel.AutoSize = true;
            lovedLabel.BackColor = Color.Transparent;
            lovedLabel.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lovedLabel.ForeColor = Color.White;
            lovedLabel.Location = new Point(3, 0);
            lovedLabel.Name = "lovedLabel";
            lovedLabel.Size = new Size(123, 49);
            lovedLabel.TabIndex = 0;
            lovedLabel.Text = "Loved";
            lovedLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(364, 25);
            label1.Name = "label1";
            label1.Size = new Size(162, 49);
            label1.TabIndex = 1;
            label1.Text = "Playlists";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Location = new Point(376, 72);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1516, 213);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.FromArgb(35, 35, 36);
            flowLayoutPanel3.Controls.Add(playlistSelectedLabel);
            flowLayoutPanel3.Location = new Point(376, 315);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(1516, 213);
            flowLayoutPanel3.TabIndex = 3;
            // 
            // playlistSelectedLabel
            // 
            playlistSelectedLabel.AutoSize = true;
            playlistSelectedLabel.BackColor = Color.Transparent;
            playlistSelectedLabel.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playlistSelectedLabel.ForeColor = Color.White;
            playlistSelectedLabel.Location = new Point(3, 0);
            playlistSelectedLabel.Name = "playlistSelectedLabel";
            playlistSelectedLabel.Size = new Size(354, 49);
            playlistSelectedLabel.TabIndex = 6;
            playlistSelectedLabel.Text = "No Playlist Selected";
            playlistSelectedLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.BackColor = Color.FromArgb(35, 35, 36);
            flowLayoutPanel4.Controls.Add(uploadedMusicLabel);
            flowLayoutPanel4.Location = new Point(376, 559);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(1516, 213);
            flowLayoutPanel4.TabIndex = 4;
            // 
            // uploadedMusicLabel
            // 
            uploadedMusicLabel.AutoSize = true;
            uploadedMusicLabel.BackColor = Color.Transparent;
            uploadedMusicLabel.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uploadedMusicLabel.ForeColor = Color.White;
            uploadedMusicLabel.Location = new Point(3, 0);
            uploadedMusicLabel.Name = "uploadedMusicLabel";
            uploadedMusicLabel.Size = new Size(292, 49);
            uploadedMusicLabel.TabIndex = 5;
            uploadedMusicLabel.Text = "Uploaded Music";
            uploadedMusicLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom;
            panel1.BackColor = Color.FromArgb(35, 35, 36);
            panel1.Controls.Add(materialSlider1);
            panel1.Controls.Add(materialFloatingActionButton3);
            panel1.Controls.Add(materialFloatingActionButton2);
            panel1.Controls.Add(materialFloatingActionButton1);
            panel1.Controls.Add(artistPlaying);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(musicPlaying);
            panel1.Location = new Point(505, 921);
            panel1.Name = "panel1";
            panel1.Size = new Size(1121, 118);
            panel1.TabIndex = 5;
            // 
            // materialSlider1
            // 
            materialSlider1.Depth = 0;
            materialSlider1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialSlider1.Location = new Point(753, 36);
            materialSlider1.MouseState = MaterialSkin.MouseState.HOVER;
            materialSlider1.Name = "materialSlider1";
            materialSlider1.ShowText = false;
            materialSlider1.ShowValue = false;
            materialSlider1.Size = new Size(352, 40);
            materialSlider1.TabIndex = 11;
            materialSlider1.Text = "";
            materialSlider1.UseAccentColor = true;
            // 
            // materialFloatingActionButton3
            // 
            materialFloatingActionButton3.Depth = 0;
            materialFloatingActionButton3.Icon = (Image)resources.GetObject("materialFloatingActionButton3.Icon");
            materialFloatingActionButton3.Image = (Image)resources.GetObject("materialFloatingActionButton3.Image");
            materialFloatingActionButton3.Location = new Point(593, 29);
            materialFloatingActionButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton3.Name = "materialFloatingActionButton3";
            materialFloatingActionButton3.Size = new Size(56, 56);
            materialFloatingActionButton3.TabIndex = 10;
            materialFloatingActionButton3.Text = "materialFloatingActionButton3";
            materialFloatingActionButton3.TextImageRelation = TextImageRelation.ImageAboveText;
            materialFloatingActionButton3.UseVisualStyleBackColor = true;
            // 
            // materialFloatingActionButton2
            // 
            materialFloatingActionButton2.Depth = 0;
            materialFloatingActionButton2.Icon = (Image)resources.GetObject("materialFloatingActionButton2.Icon");
            materialFloatingActionButton2.Image = (Image)resources.GetObject("materialFloatingActionButton2.Image");
            materialFloatingActionButton2.Location = new Point(469, 29);
            materialFloatingActionButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton2.Name = "materialFloatingActionButton2";
            materialFloatingActionButton2.Size = new Size(56, 56);
            materialFloatingActionButton2.TabIndex = 9;
            materialFloatingActionButton2.Text = "materialFloatingActionButton2";
            materialFloatingActionButton2.TextImageRelation = TextImageRelation.ImageAboveText;
            materialFloatingActionButton2.UseVisualStyleBackColor = true;
            // 
            // materialFloatingActionButton1
            // 
            materialFloatingActionButton1.Depth = 0;
            materialFloatingActionButton1.Icon = (Image)resources.GetObject("materialFloatingActionButton1.Icon");
            materialFloatingActionButton1.Image = (Image)resources.GetObject("materialFloatingActionButton1.Image");
            materialFloatingActionButton1.Location = new Point(531, 29);
            materialFloatingActionButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton1.Name = "materialFloatingActionButton1";
            materialFloatingActionButton1.Size = new Size(56, 56);
            materialFloatingActionButton1.TabIndex = 8;
            materialFloatingActionButton1.Text = "materialFloatingActionButton1";
            materialFloatingActionButton1.TextImageRelation = TextImageRelation.ImageAboveText;
            materialFloatingActionButton1.UseVisualStyleBackColor = true;
            materialFloatingActionButton1.Click += materialFloatingActionButton1_Click;
            // 
            // artistPlaying
            // 
            artistPlaying.AutoSize = true;
            artistPlaying.BackColor = Color.Transparent;
            artistPlaying.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            artistPlaying.ForeColor = SystemColors.ScrollBar;
            artistPlaying.Location = new Point(170, 44);
            artistPlaying.Name = "artistPlaying";
            artistPlaying.Size = new Size(58, 25);
            artistPlaying.TabIndex = 7;
            artistPlaying.Text = "Artist";
            artistPlaying.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(10, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(101, 101);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // musicPlaying
            // 
            musicPlaying.AutoSize = true;
            musicPlaying.BackColor = Color.Transparent;
            musicPlaying.Font = new Font("Montserrat", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            musicPlaying.ForeColor = Color.FromArgb(48, 207, 255);
            musicPlaying.Location = new Point(117, 11);
            musicPlaying.Name = "musicPlaying";
            musicPlaying.Size = new Size(167, 33);
            musicPlaying.TabIndex = 6;
            musicPlaying.Text = "Music Playing";
            musicPlaying.TextAlign = ContentAlignment.TopCenter;
            // 
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = (Image)resources.GetObject("materialButton1.Icon");
            materialButton1.Location = new Point(1852, -2);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(40, 40);
            materialButton1.TabIndex = 6;
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            // 
            // materialButton2
            // 
            materialButton2.AutoSize = false;
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = (Image)resources.GetObject("materialButton2.Icon");
            materialButton2.Location = new Point(1737, -2);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(107, 40);
            materialButton2.TabIndex = 7;
            materialButton2.Text = "User";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 23, 26);
            ClientSize = new Size(1904, 1041);
            Controls.Add(materialButton2);
            Controls.Add(materialButton1);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel4);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label lovedLabel;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label playlistSelectedLabel;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label uploadedMusicLabel;
        private Panel panel1;
        private Label artistPlaying;
        private PictureBox pictureBox1;
        private Label musicPlaying;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton1;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton3;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton2;
        private MaterialSkin.Controls.MaterialSlider materialSlider1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
    }
}
