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
            lovedLayout = new FlowLayoutPanel();
            lovedLabel = new Label();
            label1 = new Label();
            playlistPanel = new FlowLayoutPanel();
            playlistSelectedList = new FlowLayoutPanel();
            playlistSelectedLabel = new Label();
            uploadedMusicList = new FlowLayoutPanel();
            uploadedMusicLabel = new Label();
            musicPlayerPanel = new Panel();
            heartIcon = new PictureBox();
            volumeSlider = new MaterialSkin.Controls.MaterialSlider();
            materialFloatingActionButton3 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            materialFloatingActionButton2 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            playStopBtn = new MaterialSkin.Controls.MaterialFloatingActionButton();
            artistPlaying = new Label();
            musicPictureCover = new PictureBox();
            musicPlaying = new Label();
            musicProgressBar = new MaterialSkin.Controls.MaterialProgressBar();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            musicPlayerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)heartIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)musicPictureCover).BeginInit();
            SuspendLayout();
            // 
            // lovedLayout
            // 
            lovedLayout.AutoScroll = true;
            lovedLayout.BackColor = Color.FromArgb(35, 35, 36);
            lovedLayout.FlowDirection = FlowDirection.TopDown;
            lovedLayout.ForeColor = Color.FromArgb(48, 207, 255);
            lovedLayout.Location = new Point(12, 57);
            lovedLayout.Name = "lovedLayout";
            lovedLayout.Size = new Size(358, 780);
            lovedLayout.TabIndex = 0;
            lovedLayout.WrapContents = false;
            // 
            // lovedLabel
            // 
            lovedLabel.AutoSize = true;
            lovedLabel.BackColor = Color.Transparent;
            lovedLabel.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lovedLabel.ForeColor = Color.White;
            lovedLabel.Location = new Point(12, -1);
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
            label1.Location = new Point(364, -1);
            label1.Name = "label1";
            label1.Size = new Size(162, 49);
            label1.TabIndex = 1;
            label1.Text = "Playlists";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // playlistPanel
            // 
            playlistPanel.AutoScroll = true;
            playlistPanel.Location = new Point(376, 47);
            playlistPanel.Name = "playlistPanel";
            playlistPanel.Size = new Size(1250, 227);
            playlistPanel.TabIndex = 2;
            // 
            // playlistSelectedList
            // 
            playlistSelectedList.AutoScroll = true;
            playlistSelectedList.BackColor = Color.FromArgb(35, 35, 36);
            playlistSelectedList.FlowDirection = FlowDirection.TopDown;
            playlistSelectedList.ForeColor = Color.FromArgb(48, 207, 255);
            playlistSelectedList.Location = new Point(376, 334);
            playlistSelectedList.Name = "playlistSelectedList";
            playlistSelectedList.Size = new Size(1231, 224);
            playlistSelectedList.TabIndex = 3;
            // 
            // playlistSelectedLabel
            // 
            playlistSelectedLabel.AutoSize = true;
            playlistSelectedLabel.BackColor = Color.Transparent;
            playlistSelectedLabel.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playlistSelectedLabel.ForeColor = Color.White;
            playlistSelectedLabel.Location = new Point(376, 282);
            playlistSelectedLabel.Name = "playlistSelectedLabel";
            playlistSelectedLabel.Size = new Size(354, 49);
            playlistSelectedLabel.TabIndex = 6;
            playlistSelectedLabel.Text = "No Playlist Selected";
            playlistSelectedLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // uploadedMusicList
            // 
            uploadedMusicList.AutoScroll = true;
            uploadedMusicList.BackColor = Color.FromArgb(35, 35, 36);
            uploadedMusicList.FlowDirection = FlowDirection.TopDown;
            uploadedMusicList.Font = new Font("Montserrat", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uploadedMusicList.ForeColor = Color.FromArgb(48, 207, 255);
            uploadedMusicList.Location = new Point(376, 613);
            uploadedMusicList.Name = "uploadedMusicList";
            uploadedMusicList.Size = new Size(1231, 224);
            uploadedMusicList.TabIndex = 4;
            // 
            // uploadedMusicLabel
            // 
            uploadedMusicLabel.AutoSize = true;
            uploadedMusicLabel.BackColor = Color.Transparent;
            uploadedMusicLabel.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uploadedMusicLabel.ForeColor = Color.White;
            uploadedMusicLabel.Location = new Point(377, 561);
            uploadedMusicLabel.Name = "uploadedMusicLabel";
            uploadedMusicLabel.Size = new Size(292, 49);
            uploadedMusicLabel.TabIndex = 5;
            uploadedMusicLabel.Text = "Uploaded Music";
            uploadedMusicLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // musicPlayerPanel
            // 
            musicPlayerPanel.BackColor = Color.FromArgb(35, 35, 36);
            musicPlayerPanel.Controls.Add(heartIcon);
            musicPlayerPanel.Controls.Add(volumeSlider);
            musicPlayerPanel.Controls.Add(materialFloatingActionButton3);
            musicPlayerPanel.Controls.Add(materialFloatingActionButton2);
            musicPlayerPanel.Controls.Add(playStopBtn);
            musicPlayerPanel.Controls.Add(artistPlaying);
            musicPlayerPanel.Controls.Add(musicPictureCover);
            musicPlayerPanel.Controls.Add(musicPlaying);
            musicPlayerPanel.Location = new Point(377, 856);
            musicPlayerPanel.Name = "musicPlayerPanel";
            musicPlayerPanel.Size = new Size(1121, 118);
            musicPlayerPanel.TabIndex = 5;
            musicPlayerPanel.Visible = false;
            // 
            // heartIcon
            // 
            heartIcon.Image = (Image)resources.GetObject("heartIcon.Image");
            heartIcon.Location = new Point(153, 72);
            heartIcon.Name = "heartIcon";
            heartIcon.Size = new Size(22, 24);
            heartIcon.SizeMode = PictureBoxSizeMode.Zoom;
            heartIcon.TabIndex = 12;
            heartIcon.TabStop = false;
            heartIcon.Click += heartIcon_Click;
            // 
            // volumeSlider
            // 
            volumeSlider.Depth = 0;
            volumeSlider.ForeColor = Color.FromArgb(222, 0, 0, 0);
            volumeSlider.Location = new Point(753, 36);
            volumeSlider.MouseState = MaterialSkin.MouseState.HOVER;
            volumeSlider.Name = "volumeSlider";
            volumeSlider.ShowText = false;
            volumeSlider.ShowValue = false;
            volumeSlider.Size = new Size(352, 40);
            volumeSlider.TabIndex = 11;
            volumeSlider.Text = "";
            volumeSlider.onValueChanged += volumeSlider_onValueChanged;
            // 
            // materialFloatingActionButton3
            // 
            materialFloatingActionButton3.AnimateShowHideButton = true;
            materialFloatingActionButton3.Depth = 0;
            materialFloatingActionButton3.Icon = (Image)resources.GetObject("materialFloatingActionButton3.Icon");
            materialFloatingActionButton3.Image = (Image)resources.GetObject("materialFloatingActionButton3.Image");
            materialFloatingActionButton3.Location = new Point(593, 37);
            materialFloatingActionButton3.Mini = true;
            materialFloatingActionButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton3.Name = "materialFloatingActionButton3";
            materialFloatingActionButton3.Size = new Size(40, 40);
            materialFloatingActionButton3.TabIndex = 10;
            materialFloatingActionButton3.Text = "materialFloatingActionButton3";
            materialFloatingActionButton3.TextImageRelation = TextImageRelation.ImageAboveText;
            materialFloatingActionButton3.UseVisualStyleBackColor = true;
            materialFloatingActionButton3.Click += materialFloatingActionButton3_Click;
            // 
            // materialFloatingActionButton2
            // 
            materialFloatingActionButton2.AnimateShowHideButton = true;
            materialFloatingActionButton2.Depth = 0;
            materialFloatingActionButton2.Icon = (Image)resources.GetObject("materialFloatingActionButton2.Icon");
            materialFloatingActionButton2.Image = (Image)resources.GetObject("materialFloatingActionButton2.Image");
            materialFloatingActionButton2.Location = new Point(485, 36);
            materialFloatingActionButton2.Mini = true;
            materialFloatingActionButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialFloatingActionButton2.Name = "materialFloatingActionButton2";
            materialFloatingActionButton2.Size = new Size(40, 40);
            materialFloatingActionButton2.TabIndex = 9;
            materialFloatingActionButton2.Text = "materialFloatingActionButton2";
            materialFloatingActionButton2.TextImageRelation = TextImageRelation.ImageAboveText;
            materialFloatingActionButton2.UseVisualStyleBackColor = true;
            materialFloatingActionButton2.Click += materialFloatingActionButton2_Click;
            // 
            // playStopBtn
            // 
            playStopBtn.AnimateShowHideButton = true;
            playStopBtn.Depth = 0;
            playStopBtn.Icon = (Image)resources.GetObject("playStopBtn.Icon");
            playStopBtn.Image = (Image)resources.GetObject("playStopBtn.Image");
            playStopBtn.Location = new Point(531, 29);
            playStopBtn.MouseState = MaterialSkin.MouseState.HOVER;
            playStopBtn.Name = "playStopBtn";
            playStopBtn.Size = new Size(56, 56);
            playStopBtn.TabIndex = 8;
            playStopBtn.Text = "materialFloatingActionButton1";
            playStopBtn.TextImageRelation = TextImageRelation.ImageAboveText;
            playStopBtn.UseVisualStyleBackColor = true;
            playStopBtn.Click += materialFloatingActionButton1_Click;
            // 
            // artistPlaying
            // 
            artistPlaying.AutoSize = true;
            artistPlaying.BackColor = Color.Transparent;
            artistPlaying.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            artistPlaying.ForeColor = SystemColors.ScrollBar;
            artistPlaying.Location = new Point(117, 44);
            artistPlaying.Name = "artistPlaying";
            artistPlaying.Size = new Size(58, 25);
            artistPlaying.TabIndex = 7;
            artistPlaying.Text = "Artist";
            artistPlaying.TextAlign = ContentAlignment.TopCenter;
            // 
            // musicPictureCover
            // 
            musicPictureCover.BorderStyle = BorderStyle.FixedSingle;
            musicPictureCover.Location = new Point(10, 7);
            musicPictureCover.Name = "musicPictureCover";
            musicPictureCover.Size = new Size(101, 101);
            musicPictureCover.SizeMode = PictureBoxSizeMode.Zoom;
            musicPictureCover.TabIndex = 0;
            musicPictureCover.TabStop = false;
            // 
            // musicPlaying
            // 
            musicPlaying.AutoSize = true;
            musicPlaying.BackColor = Color.Transparent;
            musicPlaying.Font = new Font("Montserrat", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            musicPlaying.ForeColor = Color.White;
            musicPlaying.Location = new Point(117, 11);
            musicPlaying.Name = "musicPlaying";
            musicPlaying.Size = new Size(167, 33);
            musicPlaying.TabIndex = 6;
            musicPlaying.Text = "Music Playing";
            musicPlaying.TextAlign = ContentAlignment.TopCenter;
            // 
            // musicProgressBar
            // 
            musicProgressBar.BackColor = Color.FromArgb(146, 146, 146);
            musicProgressBar.Depth = 0;
            musicProgressBar.ForeColor = SystemColors.HotTrack;
            musicProgressBar.Location = new Point(377, 852);
            musicProgressBar.Maximum = 0;
            musicProgressBar.MouseState = MaterialSkin.MouseState.HOVER;
            musicProgressBar.Name = "musicProgressBar";
            musicProgressBar.Size = new Size(1121, 5);
            musicProgressBar.Step = 1;
            musicProgressBar.Style = ProgressBarStyle.Continuous;
            musicProgressBar.TabIndex = 8;
            musicProgressBar.Visible = false;
            musicProgressBar.MouseDown += musicProgressBar_MouseDown;
            // 
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.DrawShadows = false;
            materialButton1.HighEmphasis = false;
            materialButton1.Icon = (Image)resources.GetObject("materialButton1.Icon");
            materialButton1.Location = new Point(1567, -1);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(40, 39);
            materialButton1.TabIndex = 6;
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = true;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 23, 26);
            ClientSize = new Size(1643, 975);
            Controls.Add(musicProgressBar);
            Controls.Add(lovedLabel);
            Controls.Add(playlistSelectedLabel);
            Controls.Add(uploadedMusicLabel);
            Controls.Add(materialButton1);
            Controls.Add(musicPlayerPanel);
            Controls.Add(uploadedMusicList);
            Controls.Add(playlistSelectedList);
            Controls.Add(playlistPanel);
            Controls.Add(label1);
            Controls.Add(lovedLayout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Streamerz";
            musicPlayerPanel.ResumeLayout(false);
            musicPlayerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)heartIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)musicPictureCover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel lovedLayout;
        private Label lovedLabel;
        private Label label1;
        private FlowLayoutPanel playlistPanel;
        private FlowLayoutPanel playlistSelectedList;
        private Label playlistSelectedLabel;
        private FlowLayoutPanel uploadedMusicList;
        private Label uploadedMusicLabel;
        private Panel musicPlayerPanel;
        private Label artistPlaying;
        private PictureBox musicPictureCover;
        private Label musicPlaying;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton3;
        private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton2;
        private MaterialSkin.Controls.MaterialSlider volumeSlider;
        private MaterialSkin.Controls.MaterialProgressBar musicProgressBar;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialFloatingActionButton playStopBtn;
        private PictureBox heartIcon;
    }
}
