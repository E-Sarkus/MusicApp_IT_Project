using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp_IT_Project
{
    public partial class CreatePlaylistForm : Form
    {
        public CreatePlaylistForm()
        {
            InitializeComponent();

            var materialSkinManager2 = MaterialSkinManager.Instance;
            materialSkinManager2.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager2.ColorScheme = new ColorScheme(Primary.Grey50, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue400, TextShade.BLACK);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PlaylistName { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color PlaylistBackColor { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color PlaylistTextColor { get; private set; }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a playlist name.");
                return;
            }

            PlaylistName = textBox1.Text.Trim();

            string basePath = Path.Combine(Application.StartupPath, "Playlists");

            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            string playlistFolder = Path.Combine(basePath, PlaylistName);
            if (!Directory.Exists(playlistFolder))
            {
                Directory.CreateDirectory(playlistFolder);
            }
            else
            {
                MessageBox.Show("A playlist with this name already exists.");
                return;
            }

            string detailsFile = Path.Combine(playlistFolder, "playlist_details.txt");
            string content = $"Name: {PlaylistName}{Environment.NewLine}" + $"BackColor: {PlaylistBackColor.ToArgb()}{Environment.NewLine}" + $"TextColor: {PlaylistTextColor.ToArgb()}";

            File.WriteAllText(detailsFile, content);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            using (var dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PlaylistTextColor = dlg.Color;
                    textBox3.Text = dlg.Color.ToString();
                }
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            using (var dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PlaylistBackColor = dlg.Color;
                    textBox2.Text = dlg.Color.ToString();
                }
            }
        }
    }
}
