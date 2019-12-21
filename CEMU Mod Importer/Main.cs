using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using System.Xml;

namespace CEMU_Mod_Importer
{
    public partial class Main : Form
    {
        readonly Mod CurrentMod = new Mod();
        string[] titleids;
        int wrongids = 0;
        bool CEMU_Set = false;
        public Main()
        {
            InitializeComponent();
            //load config.json
            if (File.Exists(".\\Config.json"))
            {
                try
                {
                    if (File.Exists(JsonConvert.DeserializeObject<Config>(File.ReadAllText(".\\Config.json")).CEMU_path))
                    {
                        CEMU_path.FileName = JsonConvert.DeserializeObject<Config>(File.ReadAllText(".\\Config.json")).CEMU_path;
                        CEMU_Set = true;
                    }
                }
                catch (Exception e)
                {
                    Color forecolor = Debug.ForeColor;
                    Debug.ForeColor = Color.FromArgb(0xFF, 0x00, 0x00);
                    Debug.AppendText(e.Message);
                    Debug.ForeColor = forecolor;
                }
            }
            //load GameList and populate dropdown
            if (File.Exists(".\\GameList.json"))
            {
                try
                {
                    foreach (GameInfo info in JsonConvert.DeserializeObject<GameInfo[]>(File.ReadAllText(".\\GameList.json")))
                    {
                        JSON_importer.Instance.gameInfos.Add(info);
                    }
                    foreach (GameInfo item in JSON_importer.Instance.gameInfos)
                    {
                        GameDropdown.Items.Add(item);
                    }
                }
                catch (Exception e)
                {
                    Color forecolor = Debug.ForeColor;
                    Debug.ForeColor = Color.FromArgb(0xFF, 0x00, 0x00);
                    Debug.AppendText(e.Message);
                    Debug.ForeColor = forecolor;
                }
            }

        }

        private void NewModButton_Click(object sender, EventArgs e)
        {
            if (CurrentMod.Name == null || CurrentMod.TitleIds == null || CurrentMod.Description == null)
                return;
            if (CEMU_Set == false)
            {
                if (CEMU_path.ShowDialog() != DialogResult.OK)
                    return;
            }
            if (wrongids != 0)
            {
                return;
            }
            string ModRules = $"[Definition]\ntitleIds = {string.Join(", ", CurrentMod.TitleIds)}\nname = {CurrentMod.Name}\npath = \"{GameNameTextbox.Text}/Mods/{CurrentMod.Name}\"\ndescription = {CurrentMod.Description}\nversion = {CurrentMod.Version}\nfsPriority = {CurrentMod.fsPriority}";
            Debug.AppendText(ModRules + "\n");
            FileInfo file = new FileInfo(Path.GetDirectoryName(CEMU_path.FileName) + "\\graphicPacks\\mods\\" + GameNameTextbox.Text + " " + CurrentMod.Name + "\\rules.txt");
            Debug.AppendText(file.FullName);
            Directory.CreateDirectory(file.DirectoryName);
            File.WriteAllText(file.FullName, ModRules);
            foreach (String folder in ModFolders)
            {
                Copy(folder, file.DirectoryName);
            }
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            CurrentMod.Name = NameBox.Text;
            if (NameBox.Text == "")
            {
                NameBox.BackColor = Color.FromArgb(0xFF, 0x00, 0x00);
            }
            else
            {
                NameBox.BackColor = Color.FromArgb(0x00, 0xFF, 0x00);
            }
        }

        private void DescriptionBox_TextChanged(object sender, EventArgs e)
        {
            CurrentMod.Description = DescriptionBox.Text;
            if (DescriptionBox.Text == "")
            {
                DescriptionBox.BackColor = Color.FromArgb(0xf4, 0x65, 0x00);
            }
            else
            {
                DescriptionBox.BackColor = Color.FromArgb(0x00, 0xFF, 0x00);
            }
        }

        private void TitleIdBox_TextChanged(object sender, EventArgs e)
        {
            titleids = Regex.Replace(TitleIdBox.Text, @"\ \[[^[\]]*\]", "").Replace(" ", "").Split(',');
            wrongids = 0;
            foreach (string titleid in titleids)
            {
                if (titleid.Length != 16)
                {
                    wrongids++;
                }
            }
            if (wrongids == 0)
            {
                CurrentMod.TitleIds = titleids;
                TitleIdBox.BackColor = Color.FromArgb(0x00, 0xff, 0x00);
            }
            else if (wrongids != 0 && wrongids != titleids.Length)
            {
                TitleIdBox.BackColor = Color.FromArgb(0xf4, 0x65, 0x00);
            }
            else if (wrongids == titleids.Length)
            {
                TitleIdBox.BackColor = Color.FromArgb(0xff, 0x00, 0x00);
            }
        }

        private void CEMU_path_button_Click(object sender, EventArgs e)
        {
            CEMU_Set = CEMU_path.ShowDialog() == DialogResult.OK;
            if (CEMU_Set)
            {
                File.WriteAllText("./Config.json", JsonConvert.SerializeObject(new Config(CEMU_path.FileName)));
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CurrentMod.fsPriority = Convert.ToInt32(FsPriority.Value);
        }

        private void ImportGameInfoButton_Click(object sender, EventArgs e)
        {
            int _return = Import_JSON.ShowDialog();
            if (_return == -1) return;
            if (_return == 1)
            {
                TitlekeysJSON_path.ShowDialog();
                if (File.Exists(TitlekeysJSON_path.FileName))
                {
                    JSON_importer.Instance.Import(File.ReadAllText(TitlekeysJSON_path.FileName));
                    foreach (GameInfo item in JSON_importer.Instance.gameInfos)
                    {
                        GameDropdown.Items.Add(item);
                    }
                }
            }
            if (_return == 2)
            {
                string Titlekeyfilter = TitlekeysJSON_path.Filter;
                TitlekeysJSON_path.Filter = "GameList.json|GameList.json";
                TitlekeysJSON_path.ShowDialog();
                if (File.Exists(TitlekeysJSON_path.FileName))
                {
                    JSON_importer.Instance.gameInfos = new List<GameInfo>();
                    foreach (GameInfo info in JsonConvert.DeserializeObject<GameInfo[]>(File.ReadAllText(TitlekeysJSON_path.FileName)))
                    {
                        JSON_importer.Instance.gameInfos.Add(info);
                    }
                    File.WriteAllText("./GameList.json", JsonConvert.SerializeObject(JSON_importer.Instance.gameInfos));
                    foreach (GameInfo item in JSON_importer.Instance.gameInfos)
                    {
                        GameDropdown.Items.Add(item);
                    }
                }
                TitlekeysJSON_path.Filter = Titlekeyfilter;
            }

        }

        private void GameDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameInfo selected = (GameInfo)GameDropdown.SelectedItem;
            TitleIdBox.Text = string.Join(",", selected.Ids);
            GameNameTextbox.Text = selected.Name;
        }

        public List<string> ModFolders = new List<string>();
        private void DragDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void DragDrop_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    if (Directory.Exists(file))
                    {
                        if (!ModFolders.Contains(file))
                            ModFolders.Add(file);
                    }
                }
                DragDrop.Text = string.Join(", ", ModFolders);
                DragDrop.BackColor = Color.FromArgb(0x00, 0xff, 0x00);
            }
        }

        private void ClearModFiles_Click(object sender, EventArgs e)
        {
            ModFolders.Clear();
            DragDrop.Text = "Drop mod folders on me (\"meta / content / aoc\")";
            DragDrop.BackColor = Color.FromArgb(0xFF, 0x00, 0x00);
        }

        private void GameNameTextbox_TextChanged(object sender, EventArgs e)
        {
            if (GameNameTextbox.Text == "")
            {
                GameNameTextbox.BackColor = Color.FromArgb(0xFF, 0x00, 0x00);
            }
            else
            {
                GameNameTextbox.BackColor = Color.FromArgb(0x00, 0xFF, 0x00);
            }
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory + "\\" + diSource.Name);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void LoadMod_Click(object sender, EventArgs e)
        {
            if (Rules_file.ShowDialog() == DialogResult.OK)
            {
                FileIniDataParser parser = new FileIniDataParser();
                IniData data = parser.ReadFile(Rules_file.FileName);
                TitleIdBox.Text = data["Definition"]["titleIds"];
                NameBox.Text = data["Definition"]["name"];
                GameNameTextbox.Text = data["Definition"]["path"].Replace("\"", "").Substring(0, data["Definition"]["path"].Replace("\"", "").IndexOf("/", StringComparison.Ordinal));
                DescriptionBox.Text = data["Definition"]["description"];
                CurrentMod.Version = Convert.ToInt32(data["Definition"]["version"]);
                FsPriority.Value = Convert.ToInt32(data["Definition"]["fsPriority"]);
            }
        }
    }

    public static class Import_JSON
    {
        public static int ShowDialog()
        {
            Form prompt = new Form();
            int _return = -1;
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = "Importing .json";
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Import from .json Titlekeys site or GameList.json", Width = 300 };
            Button Titlekey = new Button() { Text = "Titlekeys.json", Left = 50, Width = 100, Top = 70 };
            Button Gamelist = new Button() { Text = "GameList.json", Left = 200, Width = 100, Top = 70 };
            Titlekey.Click += (sender, e) => { prompt.Close(); _return = 1; };
            Gamelist.Click += (sender, e) => { prompt.Close(); _return = 2; };
            prompt.Controls.Add(Titlekey);
            prompt.Controls.Add(Gamelist);
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();
            return _return;
        }
    }
}