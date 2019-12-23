using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace CEMU_Mod_Importer
{
    class GameInfoJSON
    {
        public string titleID;
        public string titleKey;
        public string name;
        public string region;
        public string ticket;
    }
    class JSON_importer
    {
        private static JSON_importer instance = null;
        private static readonly object padlock = new object();

        public static JSON_importer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new JSON_importer();
                    }
                    return instance;
                }
            }
        }
        public List<GameInfo> gameInfos = new List<GameInfo>();
        public string titlekeysite;
        public void Import(string JSONfile)
        {
            GameInfoJSON[] infoJSON = JsonConvert.DeserializeObject<GameInfoJSON[]>(JSONfile);

            foreach (GameInfoJSON gameInfoJSON in infoJSON)
            {
                if (gameInfoJSON.name == null)
                    continue;
                gameInfoJSON.name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gameInfoJSON.name.ToLower());
                bool added = false;
                if (gameInfoJSON.titleID[7] == '0')
                {
                    foreach (GameInfo info in gameInfos)
                    {
                        if (info.Name == gameInfoJSON.name)
                        {
                            info.Ids.Add(gameInfoJSON.titleID + " [" + gameInfoJSON.region + "]");
                            added = true;
                            break;
                        }
                    }
                    if (added == false)
                    {
                        GameInfo gameInfo = new GameInfo
                        {
                            Name = gameInfoJSON.name
                        };
                        gameInfo.Ids.Add(gameInfoJSON.titleID + " [" + gameInfoJSON.region + "]");
                        gameInfos.Add(gameInfo);
                    }
                }
            }
            gameInfos.Sort();
            File.WriteAllText("./GameList.json", JsonConvert.SerializeObject(gameInfos));
        }
        public static int ShowDialog()
        {
            Form prompt = new Form();
            int _return = -1;
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = "Importing .json";
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Import from Titlekeys (manually enter url) site or GitHub", Width = 300 };
            Button Titlekey = new Button() { Text = "Titlekeys", Left = 50, Width = 100, Top = 70 };
            Button Gamelist = new Button() { Text = "GitHub", Left = 200, Width = 100, Top = 70 };
            Titlekey.Click += (sender, e) => { prompt.Close(); _return = 1; };
            Gamelist.Click += (sender, e) => { prompt.Close(); _return = 2; };
            prompt.Controls.Add(Titlekey);
            prompt.Controls.Add(Gamelist);
            prompt.Controls.Add(textLabel);
            prompt.ShowDialog();
            return _return;
        }

        public static int EnterSite()
        {
            Form prompt = new Form();
            int _return = -1;
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = "Importing .json";
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Import from Titlekeys (manually enter url) site or GitHub", Width = 300 };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Text = "Enter URL" };
            Button Titlekey = new Button() { Text = "Done", Left = 350, Width = 100, Top = 70 };
            Titlekey.Click += (sender, e) =>
            {
                prompt.Close();
                if (Uri.IsWellFormedUriString(textBox.Text, UriKind.Absolute))
                {
                    _return = 1;
                    JSON_importer.instance.titlekeysite = textBox.Text;
                }
                else
                    _return = -1;
            };
            prompt.Controls.Add(Titlekey);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();
            return _return;
        }
    }
}