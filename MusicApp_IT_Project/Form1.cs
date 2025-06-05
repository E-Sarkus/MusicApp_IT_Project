using MaterialSkin;
using System.Windows.Forms;
using TagLib;

namespace MusicApp_IT_Project
{
    public partial class Form1 : Form
    {
        string uploadFolder = Path.Combine(Application.StartupPath, "UploadedMusic");

        public Form1()
        {
            InitializeComponent();
            LoadUploadedMusic();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
        }

        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {

        }

        private void LoadUploadedMusic()
        {
            string musicFolder = Path.Combine(Application.StartupPath, "UploadedMusic");

            if (!Directory.Exists(musicFolder)) Directory.CreateDirectory(musicFolder);

            uploadedMusicList.Controls.Clear();

            string[] musicFiles = Directory.GetFiles(musicFolder, "*.*")
                                           .Where(f => f.EndsWith(".mp3") || f.EndsWith(".wav") || f.EndsWith(".wma"))
                                           .ToArray();

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

        private void AddSongToUploadedList(string filePath, string songName, string artistName, Image albumCover)
        {
            var tfile = TagLib.File.Create(filePath); 

            Panel songPanel = new Panel();
            songPanel.Width = 300;
            songPanel.Height = 90;
            songPanel.Margin = new Padding(5);
            songPanel.BorderStyle = BorderStyle.FixedSingle;

            PictureBox pic = new PictureBox();
            pic.Image = albumCover;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Width = 90;
            pic.Height = 90;
            pic.Location = new Point(10, 0);

            string shortName = songName.Length > 18 ? songName.Substring(0, 18) + "…" : songName;

            Label lblTitle = new Label();
            lblTitle.Text = shortName;
            lblTitle.Font = new Font("Montserrat", 12, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(100, 15);

            Label lblArtist = new Label();
            lblArtist.Text = artistName;
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

            songPanel.Controls.Add(lblDuration);
            songPanel.Controls.Add(pic);
            songPanel.Controls.Add(lblTitle);
            songPanel.Controls.Add(lblArtist);

            uploadedMusicList.Controls.Add(songPanel);
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

    }
}
