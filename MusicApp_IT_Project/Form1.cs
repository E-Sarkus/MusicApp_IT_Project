using MaterialSkin;
using System.Windows.Forms;
using TagLib;
using NAudio.Wave;
using System.Security.Policy;
using TagLib.Mpeg;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using TagLib.Png;

namespace MusicApp_IT_Project
{
    public partial class Form1 : Form
    {
        string uploadFolder = Path.Combine(Application.StartupPath, "UploadedMusic");
        string lovedFolderPath = Path.Combine(Application.StartupPath, "Loved");

        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;

        private System.Windows.Forms.Timer playbackTimer;

        private bool isPlaying = false;
        private bool isSongFinished = false;

        string playIconPath = Path.Combine(Application.StartupPath, "Resources", "play_icon.png");
        string pauseIconPath = Path.Combine(Application.StartupPath, "Resources", "pause_icon.png");
        string redHeart = Path.Combine(Application.StartupPath, "Resources", "red_heart.png");
        string whiteHeart = Path.Combine(Application.StartupPath, "Resources", "white_heart.png");
        string addIcon = Path.Combine(Application.StartupPath, "Resources", "plusIcon.png");

        public string currentSongPath;
        ContextMenuStrip songContextMenu = new ContextMenuStrip();
        ContextMenuStrip playlistContextMenu = new ContextMenuStrip();

        private PlaybackSource currentSource;
        private List<string> uploadedSongPaths = new List<string>();
        private List<string> playlistSongPaths = new List<string>();
        private List<string> lovedSongPaths = new List<string>();
        private int currentSongIndex = -1;

        ToolStripMenuItem uploadToPlaylistMenuItem = new ToolStripMenuItem("Upload to Playlist");
        ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete");
        ToolStripMenuItem deleteItemPlaylist = new ToolStripMenuItem("Delete");

        string playlistFolder;


        public Form1()
        {
            InitializeComponent();
            LoadUploadedMusic();
            LoadLovedSongs();
            AddCreatePlaylistBlock();
            LoadPlaylistsFromDisk();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey50, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue400, TextShade.BLACK);


            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }


            if (!Directory.Exists(lovedFolderPath))
            {
                Directory.CreateDirectory(lovedFolderPath);
            }

            materialFloatingActionButton2.Cursor = Cursors.Hand;
            playStopBtn.Cursor = Cursors.Hand;
            materialFloatingActionButton3.Cursor = Cursors.Hand;
            heartIcon.Cursor = Cursors.Hand;
            volumeSlider.Cursor = Cursors.Hand;
            materialButton1.Cursor = Cursors.Hand;
            musicProgressBar.Cursor = Cursors.Hand;



            uploadToPlaylistMenuItem.DropDownItems.Clear();
            List<string> playlists = GetAllPlaylists();

            foreach (var playlist in playlists)
            {
                ToolStripMenuItem playlistItem = new ToolStripMenuItem(playlist);
                playlistItem.Click += UploadToPlaylist_SubMenu_Click;
                uploadToPlaylistMenuItem.DropDownItems.Add(playlistItem);
            }

            deleteItem.Click += DeleteSong_Click;
            deleteItemPlaylist.Click += DeletePlaylist_Click;

            songContextMenu.Items.Add(uploadToPlaylistMenuItem);
            songContextMenu.Items.Add(deleteItem);

            playlistContextMenu.Items.Add(deleteItemPlaylist);


        }

        private void RefreshPlaylistContextMenu()
        {
            uploadToPlaylistMenuItem.DropDownItems.Clear();
            List<string> playlists = GetAllPlaylists();
            foreach (var playlist in playlists)
            {
                ToolStripMenuItem playlistItem = new ToolStripMenuItem(playlist);
                playlistItem.Click += UploadToPlaylist_SubMenu_Click;
                uploadToPlaylistMenuItem.DropDownItems.Add(playlistItem);
            }
        }



        private void DeleteSong_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem &&
                menuItem.Owner is ContextMenuStrip menu &&
                menu.SourceControl is Panel songPanel &&
                songPanel.Tag is SongTag tag)
            {
                string filePath = tag.FilePath;

                var confirm = MessageBox.Show($"Are you sure you want to delete {tag.Title}?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        if (System.IO.File.Exists(filePath))
                            System.IO.File.Delete(filePath);

                        uploadedMusicList.Controls.Remove(songPanel);
                        songPanel.Dispose();
                        LoadUploadedMusic();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeletePlaylist_Click(object sender, EventArgs e)
        {
            

            if (sender is ToolStripMenuItem menuItem &&
                menuItem.Owner is ContextMenuStrip menu &&
                menu.SourceControl is Panel playlistPanel &&
                playlistPanel.Tag is PlaylistTag tag)
            {
                string playlistName = tag.PlaylistName;
                string playlistPath = tag.PlaylistPath;

                var confirm = MessageBox.Show($"Are you sure you want to delete the playlist {playlistName}?","Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        if (Directory.Exists(playlistPath)) Directory.Delete(playlistPath, true);
                        this.playlistPanel.Controls.Remove(playlistPanel);
                        playlistPanel.Dispose();

                        if (playlistSelectedLabel.Text == playlistName)
                        {
                            playlistSelectedLabel.Text = "No Playlist Selected";
                            playlistSelectedList.Controls.Clear();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete playlist:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

          

            RefreshPlaylistContextMenu();
        }



        private List<string> GetAllPlaylists()
        {
            string playlistsRootFolder = Path.Combine(Application.StartupPath, "Playlists");

            if (!Directory.Exists(playlistsRootFolder))
                return new List<string>();

            var playlistFolders = Directory.GetDirectories(playlistsRootFolder);
            List<string> playlistNames = playlistFolders.Select(folder => Path.GetFileName(folder)).ToList();
            return playlistNames;
        }

        private void UploadToPlaylist_SubMenu_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                string selectedPlaylist = menuItem.Text;

                if (songContextMenu.SourceControl is Panel songPanel)
                {
                    var tag = songPanel.Tag;
                    if (tag != null)
                    {
                        dynamic dynTag = tag;

                        string songPath = dynTag.FilePath;

                        string playlistsRootFolder = Path.Combine(Application.StartupPath, "Playlists");
                        string playlistFolder = Path.Combine(playlistsRootFolder, selectedPlaylist);
                        Directory.CreateDirectory(playlistFolder);

                        try
                        {
                            string destFile = Path.Combine(playlistFolder, Path.GetFileName(songPath));
                            System.IO.File.Copy(songPath, destFile, overwrite: true);

                            if (playlistSelectedLabel.Text != "No Playlist Selected")
                            {
                                
                                LoadPlaylistSongs(playlistFolder);
                            }
                            
                            
                            MessageBox.Show($"Song uploaded to playlist {selectedPlaylist}!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error uploading song: " + ex.Message);
                        }
                    }
                }
            }
        }




        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            if (waveOut == null) return;

            if (isPlaying)
            {
                waveOut.Pause();
                isPlaying = false;
                playStopBtn.Icon = Image.FromFile(playIconPath);
            }
            else
            {
                waveOut.Play();
                isPlaying = true;
                playStopBtn.Icon = Image.FromFile(pauseIconPath);
            }
        }

        private void LoadUploadedMusic()
        {
            string musicFolder = Path.Combine(Application.StartupPath, "UploadedMusic");

            if (!Directory.Exists(musicFolder)) Directory.CreateDirectory(musicFolder);

            uploadedMusicList.Controls.Clear();

            string[] musicFiles = Directory.GetFiles(musicFolder, "*.*").Where(f => f.EndsWith(".mp3") || f.EndsWith(".wav") || f.EndsWith(".wma")).ToArray();

            foreach (string musicPath in musicFiles)
            {
                string title = null;
                string artist = null;
                Image albumCover = null;

                try
                {
                    var tfile = TagLib.File.Create(musicPath);

                    title = string.IsNullOrEmpty(tfile.Tag.Title) ? Path.GetFileNameWithoutExtension(musicPath) : tfile.Tag.Title;

                    artist = tfile.Tag.FirstPerformer ?? "Unknown";

                    if (tfile.Tag.Pictures.Length > 0)
                    {
                        var bin = tfile.Tag.Pictures[0].Data.Data;
                        using (var ms = new MemoryStream(bin))
                        {
                            albumCover = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    title ??= Path.GetFileNameWithoutExtension(musicPath);
                    artist ??= "Unknown";
                }

                if (albumCover == null)
                {
                    string defaultCoverPath = Path.Combine(Application.StartupPath, "Resources", "defaultAlbumCover.png");
                    albumCover = Image.FromFile(defaultCoverPath);
                }

                AddSongToUploadedList(musicPath, title, artist, albumCover);

            }
        }

        private void LoadLovedSongs()
        {
            string lovedFolder = Path.Combine(Application.StartupPath, "Loved");

            if (!Directory.Exists(lovedFolder)) Directory.CreateDirectory(lovedFolder);

            lovedLayout.Controls.Clear();

            string[] lovedFiles = Directory.GetFiles(lovedFolder, "*.*").Where(f => f.EndsWith(".mp3") || f.EndsWith(".wav") || f.EndsWith(".wma")).ToArray();

            foreach (string musicPath in lovedFiles)
            {
                string title = null;
                string artist = null;
                Image albumCover = null;

                try
                {
                    var tfile = TagLib.File.Create(musicPath);

                    title = string.IsNullOrEmpty(tfile.Tag.Title) ? Path.GetFileNameWithoutExtension(musicPath) : tfile.Tag.Title;

                    artist = tfile.Tag.FirstPerformer ?? "Unknown";

                    if (tfile.Tag.Pictures.Length > 0)
                    {
                        var bin = tfile.Tag.Pictures[0].Data.Data;
                        using (var ms = new MemoryStream(bin))
                        {
                            albumCover = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    title ??= Path.GetFileNameWithoutExtension(musicPath);
                    artist ??= "Unknown";
                }

                if (albumCover == null)
                {
                    string defaultCoverPath = Path.Combine(Application.StartupPath, "Resources", "defaultAlbumCover.png");
                    albumCover = Image.FromFile(defaultCoverPath);
                }

                AddSongToLovedList(musicPath, title, artist, albumCover);
            }
        }


        private void AddSongToUploadedList(string filePath, string songName, string artistName, Image albumCover)
        {
            uploadedSongPaths.Add(filePath);

            var tfile = TagLib.File.Create(filePath);

            Panel songPanel = new Panel();
            songPanel.Width = 300;
            songPanel.Height = 90;
            songPanel.Margin = new Padding(5);
            songPanel.BorderStyle = BorderStyle.FixedSingle;
            songPanel.Cursor = Cursors.Hand;

            Color hoverColor = Color.FromArgb(24, 23, 26);
            Color normalColor = Color.Transparent;

            songPanel.BackColor = normalColor;

            songPanel.MouseEnter += (s, e) => songPanel.BackColor = hoverColor;
            songPanel.MouseLeave += (s, e) => songPanel.BackColor = normalColor;

            songPanel.Tag = new SongTag
            {
                FilePath = filePath,
                Title = songName,
                Artist = artistName,
                Cover = albumCover,
                Source = PlaybackSource.Uploaded
            };
            songPanel.Click += SongPanel_Click;

            PictureBox pic = new PictureBox();
            pic.Image = albumCover;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Width = 90;
            pic.Height = 90;
            pic.Location = new Point(10, 0);

            string shortName = songName.Length > 18 ? songName.Substring(0, 18) + "…" : songName;
            string shortArtist = artistName.Length > 18 ? artistName.Substring(0, 18) + "…" : artistName;

            Label lblTitle = new Label();
            lblTitle.Text = shortName;
            lblTitle.Font = new Font("Montserrat", 12, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(100, 15);

            Label lblArtist = new Label();
            lblArtist.Text = shortArtist;
            lblArtist.Font = new Font("Montserrat", 10);
            lblArtist.ForeColor = Color.White;
            lblArtist.AutoSize = true;
            lblArtist.Location = new Point(100, 40);

            Label lblDuration = new Label();
            lblDuration.Font = new Font("Montserrat", 10, FontStyle.Bold);
            lblDuration.AutoSize = true;

            TimeSpan duration = tfile.Properties.Duration;
            lblDuration.Text = duration.ToString(@"mm\:ss");
            lblDuration.Location = new Point(100, 65);
            lblDuration.ForeColor = Color.FromArgb(201, 201, 201);

            songPanel.Controls.Add(lblDuration);
            songPanel.Controls.Add(pic);
            songPanel.Controls.Add(lblTitle);
            songPanel.Controls.Add(lblArtist);

            void ApplyHoverEvents(Control control)
            {
                control.MouseEnter += (s, e) => songPanel.BackColor = hoverColor;
                control.MouseLeave += (s, e) => songPanel.BackColor = normalColor;
            }

            ApplyHoverEvents(pic);
            ApplyHoverEvents(lblTitle);
            ApplyHoverEvents(lblArtist);
            ApplyHoverEvents(lblDuration);

            pic.Click += SongPanel_Click;
            lblTitle.Click += SongPanel_Click;
            lblArtist.Click += SongPanel_Click;
            lblDuration.Click += SongPanel_Click;

            songPanel.ContextMenuStrip = songContextMenu;

            uploadedMusicList.Controls.Add(songPanel);
        }

        private void AddSongToLovedList(string filePath, string songName, string artistName, Image albumCover)
        {
            lovedSongPaths.Add(filePath);

            var tfile = TagLib.File.Create(filePath);

            Panel songPanel = new Panel();
            songPanel.Width = 325;
            songPanel.Height = 90;
            songPanel.Margin = new Padding(5);
            songPanel.BorderStyle = BorderStyle.FixedSingle;
            songPanel.Cursor = Cursors.Hand;

            Color hoverColor = Color.FromArgb(24, 23, 26);
            Color normalColor = Color.Transparent;

            songPanel.BackColor = normalColor;

            songPanel.MouseEnter += (s, e) => songPanel.BackColor = hoverColor;
            songPanel.MouseLeave += (s, e) => songPanel.BackColor = normalColor;

            songPanel.Tag = new SongTag
            {
                FilePath = filePath,
                Title = songName,
                Artist = artistName,
                Cover = albumCover,
                Source = PlaybackSource.Loved
            };

            songPanel.Click += SongPanel_Click;

            PictureBox pic = new PictureBox();
            pic.Image = albumCover;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Width = 90;
            pic.Height = 90;
            pic.Location = new Point(10, 0);

            string shortName = songName.Length > 18 ? songName.Substring(0, 18) + "…" : songName;
            string shortArtist = artistName.Length > 18 ? artistName.Substring(0, 18) + "…" : artistName;

            Label lblTitle = new Label();
            lblTitle.Text = shortName;
            lblTitle.Font = new Font("Montserrat", 12, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(100, 15);

            Label lblArtist = new Label();
            lblArtist.Text = shortArtist;
            lblArtist.Font = new Font("Montserrat", 10);
            lblArtist.ForeColor = Color.White;
            lblArtist.AutoSize = true;
            lblArtist.Location = new Point(100, 40);

            Label lblDuration = new Label();
            lblDuration.Font = new Font("Montserrat", 10, FontStyle.Bold);
            lblDuration.AutoSize = true;

            TimeSpan duration = tfile.Properties.Duration;
            lblDuration.Text = duration.ToString(@"mm\:ss");
            lblDuration.Location = new Point(100, 65);
            lblDuration.ForeColor = Color.FromArgb(201, 201, 201);

            songPanel.Controls.Add(lblDuration);
            songPanel.Controls.Add(pic);
            songPanel.Controls.Add(lblTitle);
            songPanel.Controls.Add(lblArtist);

            void ApplyHoverEvents(Control control)
            {
                control.MouseEnter += (s, e) => songPanel.BackColor = hoverColor;
                control.MouseLeave += (s, e) => songPanel.BackColor = normalColor;
            }

            ApplyHoverEvents(pic);
            ApplyHoverEvents(lblTitle);
            ApplyHoverEvents(lblArtist);
            ApplyHoverEvents(lblDuration);

            pic.Click += SongPanel_Click;
            lblTitle.Click += SongPanel_Click;
            lblArtist.Click += SongPanel_Click;
            lblDuration.Click += SongPanel_Click;

            songPanel.ContextMenuStrip = songContextMenu;

            lovedLayout.Controls.Add(songPanel);
        }

        private void AddCreatePlaylistBlock()
        {
            Panel createPlaylistPanel = new Panel
            {
                Width = 200,
                Height = 200,
                BackColor = ColorTranslator.FromHtml("#232324"),
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
            };

            PictureBox plusIcon = new PictureBox
            {
                Image = Image.FromFile(addIcon),
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 64,
                Height = 64,
                Location = new Point((createPlaylistPanel.Width - 64) / 2, (createPlaylistPanel.Height - 64) / 2),
                Cursor = Cursors.Hand,
            };

            Button createButton = new Button
            {
                Text = "Create Playlist",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(201, 201, 201),
                BackColor = Color.Transparent,
                Font = new Font("Montserrat", 14, FontStyle.Bold),
                Width = createPlaylistPanel.Width,
                Height = 30,
                Location = new Point(0, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            createButton.FlatAppearance.BorderSize = 0;
            createButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            createButton.FlatAppearance.MouseDownBackColor = Color.Transparent;

            Color hoverColor = Color.FromArgb(24, 23, 26);
            Color normalColor = ColorTranslator.FromHtml("#232324");

            createPlaylistPanel.BackColor = normalColor;

            createPlaylistPanel.MouseEnter += (s, e) => createPlaylistPanel.BackColor = hoverColor;
            createPlaylistPanel.MouseLeave += (s, e) => createPlaylistPanel.BackColor = normalColor;

            Color normalBorder = Color.FromArgb(35, 35, 35);

            createPlaylistPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, createPlaylistPanel.ClientRectangle, normalBorder, ButtonBorderStyle.Solid);
            };

            EventHandler clickHandler = (s, e) =>
            {
                OpenCreatePlaylistDialog();
            };

            createPlaylistPanel.Click += clickHandler;
            plusIcon.Click += clickHandler;
            createButton.Click += clickHandler;

            createPlaylistPanel.Controls.Add(createButton);
            createPlaylistPanel.Controls.Add(plusIcon);

            void ApplyHoverEvents(Control ctrl)
            {
                ctrl.MouseEnter += (s, e) => createPlaylistPanel.BackColor = hoverColor;
                ctrl.MouseLeave += (s, e) => createPlaylistPanel.BackColor = normalColor;
            }

            ApplyHoverEvents(plusIcon);
            ApplyHoverEvents(createButton);

            playlistPanel.Controls.Add(createPlaylistPanel);
        }

        private void OpenCreatePlaylistDialog()
        {
            using var form = new CreatePlaylistForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPlaylistsFromDisk();
            }
        }

        private void LoadPlaylistsFromDisk()
        {
            playlistPanel.Controls.Clear();
            AddCreatePlaylistBlock();
            RefreshPlaylistContextMenu();

            string playlistsDir = Path.Combine(Application.StartupPath, "Playlists");
            if (!Directory.Exists(playlistsDir))
                return;

            foreach (var folder in Directory.GetDirectories(playlistsDir))
            {
                string detailsFile = Path.Combine(folder, "playlist_details.txt");
                if (!System.IO.File.Exists(detailsFile))
                    continue;

                var lines = System.IO.File.ReadAllLines(detailsFile);
                string name = "";
                Color backColor = Color.Gray;
                Color textColor = Color.White;

                foreach (var line in lines)
                {
                    if (line.StartsWith("Name:"))
                        name = line.Substring("Name:".Length).Trim();

                    else if (line.StartsWith("BackColor:") && int.TryParse(line.Substring("BackColor:".Length).Trim(), out int backArgb))
                        backColor = Color.FromArgb(backArgb);

                    else if (line.StartsWith("TextColor:") && int.TryParse(line.Substring("TextColor:".Length).Trim(), out int textArgb))
                        textColor = Color.FromArgb(textArgb);
                }

                if (!string.IsNullOrEmpty(name))
                    AddPlaylistBlock(name, backColor, textColor);
            }
        }


        private void AddPlaylistBlock(string playlistName, Color backColor, Color textColor)
        {
            Panel playlistBlock = new Panel
            {
                Width = 200,
                Height = 200,
                Margin = new Padding(10),
                BackColor = backColor,
                Cursor = Cursors.Hand,
                Tag = new PlaylistTag
                {
                    PlaylistName = playlistName,
                    PlaylistPath = Path.Combine(Application.StartupPath, "Playlists", playlistName)
                }
            };

            Label nameLabel = new Label
            {
                Text = playlistName,
                ForeColor = textColor,
                Font = new Font("Montserrat", 14, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 80,
                Cursor = Cursors.Hand
            };

            playlistBlock.Click += PlaylistBlock_Click;
            nameLabel.Click += PlaylistBlock_Click;

            Color normalColor = playlistBlock.BackColor;
            Color hoverColor = ControlPaint.Dark(normalColor, 0.1f);

            void ApplyHoverEvents(Control ctrl)
            {
                ctrl.MouseEnter += (s, e) => playlistBlock.BackColor = hoverColor;
                ctrl.MouseLeave += (s, e) => playlistBlock.BackColor = normalColor;
            }

            ApplyHoverEvents(playlistBlock);
            ApplyHoverEvents(nameLabel);

            playlistBlock.ContextMenuStrip = playlistContextMenu;

            playlistBlock.Controls.Add(nameLabel);
            playlistPanel.Controls.Add(playlistBlock);
        }


        private void LoadPlaylistSongs(string playlistFolder)
        {
            playlistSelectedList.Controls.Clear();

            string[] audioExtensions = new[] { ".mp3", ".wav", ".flac", ".aac" };

            var songFiles = Directory.GetFiles(playlistFolder)
                .Where(f => audioExtensions.Contains(Path.GetExtension(f).ToLower()));

            foreach (var songFile in songFiles)
            {
                try
                {
                    var tfile = TagLib.File.Create(songFile);

                    string title = string.IsNullOrEmpty(tfile.Tag.Title)
                        ? Path.GetFileNameWithoutExtension(songFile)
                        : tfile.Tag.Title;

                    string artist = tfile.Tag.FirstPerformer ?? "Unknown Artist";

                    Image albumCover = null;

                    if (tfile.Tag.Pictures.Length > 0)
                    {
                        var bin = tfile.Tag.Pictures[0].Data.Data;
                        using var ms = new MemoryStream(bin);
                        albumCover = Image.FromStream(ms);
                    }
                    else
                    {
                        string defaultCoverPath = Path.Combine(Application.StartupPath, "Resources", "defaultAlbumCover.png");
                        albumCover = Image.FromFile(defaultCoverPath);
                    }

                        AddSongsToPlaylist(songFile, title, artist, albumCover);

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading {songFile}: {ex.Message}");
                }
            }
        }

        private void PlaylistBlock_Click(object sender, EventArgs e)
        {
            Control clickedControl = sender as Control;

            Panel playlistPanel = null;
            if (clickedControl is Panel panel)
                playlistPanel = panel;
            else if (clickedControl?.Parent is Panel parentPanel)
                playlistPanel = parentPanel;

            if (playlistPanel == null || playlistPanel.Tag is not PlaylistTag tag)
            {
                MessageBox.Show("Playlist information not found.");
                return;
            }

            string playlistName = tag.PlaylistName;
            playlistFolder = tag.PlaylistPath;

            playlistSelectedLabel.Text = playlistName;

            if (!Directory.Exists(playlistFolder))
            {
                MessageBox.Show("Playlist folder not found.");
                return;
            }

            LoadPlaylistSongs(playlistFolder);
        }



        private void AddSongsToPlaylist(string filePath, string songName, string artistName, Image albumCover)
        {
            playlistSongPaths.Add(filePath);

            var tfile = TagLib.File.Create(filePath);

            Panel songPanel = new Panel();
            songPanel.Width = 300;
            songPanel.Height = 90;
            songPanel.Margin = new Padding(5);
            songPanel.BorderStyle = BorderStyle.FixedSingle;
            songPanel.Cursor = Cursors.Hand;

            Color hoverColor = Color.FromArgb(24, 23, 26);
            Color normalColor = Color.Transparent;

            songPanel.BackColor = normalColor;

            songPanel.MouseEnter += (s, e) => songPanel.BackColor = hoverColor;
            songPanel.MouseLeave += (s, e) => songPanel.BackColor = normalColor;

            songPanel.Tag = new SongTag
            {
                FilePath = filePath,
                Title = songName,
                Artist = artistName,
                Cover = albumCover,
                Source = PlaybackSource.Playlist
            };
            songPanel.Click += SongPanel_Click;

            PictureBox pic = new PictureBox();
            pic.Image = albumCover;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Width = 90;
            pic.Height = 90;
            pic.Location = new Point(10, 0);

            string shortName = songName.Length > 18 ? songName.Substring(0, 18) + "…" : songName;
            string shortArtist = artistName.Length > 18 ? artistName.Substring(0, 18) + "…" : artistName;

            Label lblTitle = new Label();
            lblTitle.Text = shortName;
            lblTitle.Font = new Font("Montserrat", 12, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(100, 15);

            Label lblArtist = new Label();
            lblArtist.Text = shortArtist;
            lblArtist.Font = new Font("Montserrat", 10);
            lblArtist.ForeColor = Color.White;
            lblArtist.AutoSize = true;
            lblArtist.Location = new Point(100, 40);

            Label lblDuration = new Label();
            lblDuration.Font = new Font("Montserrat", 10, FontStyle.Bold);
            lblDuration.AutoSize = true;

            TimeSpan duration = tfile.Properties.Duration;
            lblDuration.Text = duration.ToString(@"mm\:ss");
            lblDuration.Location = new Point(100, 65);
            lblDuration.ForeColor = Color.FromArgb(201, 201, 201);

            songPanel.Controls.Add(lblDuration);
            songPanel.Controls.Add(pic);
            songPanel.Controls.Add(lblTitle);
            songPanel.Controls.Add(lblArtist);

            void ApplyHoverEvents(Control control)
            {
                control.MouseEnter += (s, e) => songPanel.BackColor = hoverColor;
                control.MouseLeave += (s, e) => songPanel.BackColor = normalColor;
            }

            ApplyHoverEvents(pic);
            ApplyHoverEvents(lblTitle);
            ApplyHoverEvents(lblArtist);
            ApplyHoverEvents(lblDuration);

            pic.Click += SongPanel_Click;
            lblTitle.Click += SongPanel_Click;
            lblArtist.Click += SongPanel_Click;
            lblDuration.Click += SongPanel_Click;

            songPanel.ContextMenuStrip = songContextMenu;

            playlistSelectedList.Controls.Add(songPanel);
        }



        private void SongPanel_Click(object sender, EventArgs e)
        {
            Control clickedControl = sender as Control;
            Panel panel = null;

            if (clickedControl is Panel)
                panel = (Panel)clickedControl;
            else if (clickedControl.Parent is Panel)
                panel = (Panel)clickedControl.Parent;

            if (panel != null && panel.Tag is SongTag tag)
            {
                if (uploadedMusicList.Controls.Contains(panel))
                {
                    currentSource = PlaybackSource.Uploaded;
                    currentSongIndex = uploadedSongPaths.IndexOf(tag.FilePath);
                }
                else if (playlistSelectedList.Controls.Contains(panel))
                {
                    currentSource = PlaybackSource.Playlist;
                    currentSongIndex = playlistSongPaths.IndexOf(tag.FilePath);
                }
                else if (lovedLayout.Controls.Contains(panel))
                {
                    currentSource = PlaybackSource.Loved;
                    currentSongIndex = lovedSongPaths.IndexOf(tag.FilePath);
                }
                else
                {
                    currentSource = PlaybackSource.Uploaded;
                    currentSongIndex = uploadedSongPaths.IndexOf(tag.FilePath);
                }

                UpdateUIForSong(tag);
                PlayAudio(tag.FilePath);
            }
        }






        private void PlayAudio(string filePath)
        {
            try
            {
                if (waveOut != null)
                {
                    waveOut.PlaybackStopped -= WaveOut_PlaybackStopped;
                    waveOut.Dispose();
                }

                audioFileReader = new AudioFileReader(filePath);
                audioFileReader.Volume = volumeSlider.Value / 100f;
                waveOut = new WaveOutEvent();
                waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
                waveOut.Init(audioFileReader);
                isPlaying = true;
                waveOut.Play();
                playStopBtn.Icon = Image.FromFile(pauseIconPath);

                musicProgressBar.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
                musicProgressBar.Value = 0;

                if (playbackTimer == null)
                {
                    playbackTimer = new System.Windows.Forms.Timer();
                    playbackTimer.Tick += PlaybackTimer_Tick;
                }

                playbackTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing file: " + ex.Message);
            }
        }

        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            if (audioFileReader != null && waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
            {
                musicProgressBar.Value = Math.Min(musicProgressBar.Maximum, (int)audioFileReader.CurrentTime.TotalSeconds);
            }
        }


        private void StopAudio()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                playStopBtn.Icon = Image.FromFile(playIconPath);
                isPlaying = false;
                waveOut.Dispose();
                waveOut = null;

            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
        }


        private void materialButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Music Files|*.mp3;*.wav;*.wma";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    string fileName = Path.GetFileName(filePath);
                    string destinationPath = Path.Combine(uploadFolder, fileName);

                    if (!System.IO.File.Exists(destinationPath))
                    {
                        System.IO.File.Copy(filePath, destinationPath);
                    }
                }
            }

            LoadUploadedMusic();

        }

        private void volumeSlider_onValueChanged(object sender, int newValue)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Volume = volumeSlider.Value / 100f;
            }
        }

        private void materialFloatingActionButton3_Click(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                var newPosition = audioFileReader.CurrentTime + TimeSpan.FromSeconds(10);
                if (newPosition < audioFileReader.TotalTime)
                {
                    audioFileReader.CurrentTime = newPosition;
                }
                else
                {
                    audioFileReader.CurrentTime = audioFileReader.TotalTime;
                }
            }
        }

        private void materialFloatingActionButton2_Click(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                var newPosition = audioFileReader.CurrentTime - TimeSpan.FromSeconds(10);
                if (newPosition > TimeSpan.Zero)
                {
                    audioFileReader.CurrentTime = newPosition;
                }
                else
                {
                    audioFileReader.CurrentTime = TimeSpan.Zero;
                }
            }
        }

        private void heartIcon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentSongPath)) return;

            string fileName = Path.GetFileName(currentSongPath);
            string lovedPath = Path.Combine(lovedFolderPath, fileName);

            if (System.IO.File.Exists(lovedPath))
            {
                System.IO.File.Delete(lovedPath);
                heartIcon.Image = Image.FromFile(whiteHeart);
                LoadLovedSongs();
            }
            else
            {
                System.IO.File.Copy(currentSongPath, lovedPath, overwrite: true);
                heartIcon.Image = Image.FromFile(redHeart);
                LoadLovedSongs();
            }
        }

        private void UpdateHeartIcon()
        {
            string fileName = Path.GetFileName(currentSongPath);
            string lovedPath = Path.Combine(lovedFolderPath, fileName);

            if (System.IO.File.Exists(lovedPath))
                heartIcon.Image = Image.FromFile(redHeart);
            else
                heartIcon.Image = Image.FromFile(whiteHeart);

            heartIcon.Visible = true;
        }

        private void musicProgressBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (audioFileReader != null && audioFileReader.TotalTime.TotalSeconds > 0)
            {
                double clickRatio = (double)e.X / musicProgressBar.Width;
                clickRatio = Math.Min(1.0, Math.Max(0.0, clickRatio));
                TimeSpan newTime = TimeSpan.FromSeconds(audioFileReader.TotalTime.TotalSeconds * clickRatio);
                audioFileReader.CurrentTime = newTime;
            }
        }

        private int GetSongIndexFromSource(PlaybackSource source, string filePath)
        {
            switch (source)
            {
                case PlaybackSource.Uploaded:
                    return uploadedSongPaths.IndexOf(filePath);
                case PlaybackSource.Playlist:
                    return playlistSongPaths.IndexOf(filePath);
                case PlaybackSource.Loved:
                    return lovedSongPaths.IndexOf(filePath);
                default:
                    return -1;
            }
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            PlayNextSong();
        }

        private void PlayNextSong()
        {
            List<string> songList = currentSource switch
            {
                PlaybackSource.Uploaded => uploadedSongPaths,
                PlaybackSource.Playlist => playlistSongPaths,
                PlaybackSource.Loved => lovedSongPaths,
                _ => null
            };

            if (songList == null || currentSongIndex < 0)
                return;

            currentSongIndex++;

            if (currentSongIndex >= songList.Count)
            {
                currentSongIndex = 0;
            }

            string nextSongPath = songList[currentSongIndex];
            PlayAudio(nextSongPath);

            SongTag tag = FindSongTagByPath(nextSongPath);
            if (tag != null)
                UpdateUIForSong(tag);

        }

        private void UpdateUIForSong(SongTag tag)
        {
            string shortTitle = tag.Title.Length > 25 ? tag.Title.Substring(0, 25) + "…" : tag.Title;
            string shortArtist = tag.Artist.Length > 25 ? tag.Artist.Substring(0, 25) + "…" : tag.Artist;

            musicPlayerPanel.Visible = true;
            musicProgressBar.Visible = true;
            musicPlaying.Text = shortTitle;
            artistPlaying.Text = shortArtist;
            musicPictureCover.Image = tag.Cover;

            currentSongPath = tag.FilePath;

            UpdateHeartIcon();
        }


        private SongTag FindSongTagByPath(string filePath)
        {
            foreach (Control ctrl in uploadedMusicList.Controls)
            {
                if (ctrl.Tag is SongTag tag && tag.FilePath == filePath)
                    return tag;
            }

            foreach (Control ctrl in playlistSelectedList.Controls)
            {
                if (ctrl.Tag is SongTag tag && tag.FilePath == filePath)
                    return tag;
            }

            foreach (Control ctrl in lovedLayout.Controls)
            {
                if (ctrl.Tag is SongTag tag && tag.FilePath == filePath)
                    return tag;
            }

            return null; 
        }



    }



    public class SongTag
    {
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public Image Cover { get; set; }
        public PlaybackSource Source { get; set; } 
    }

    public class PlaylistTag
    {
        public string PlaylistName { get; set; }
        public string PlaylistPath { get; set; }
    }

    public enum PlaybackSource
    {
        Uploaded,
        Loved,
        Playlist
    }



}
