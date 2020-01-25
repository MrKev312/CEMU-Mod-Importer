using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace CEMU_Mod_Importer
{
    class GameInfoJSON
    {
        public string titleID;
        public string name;
        public string region;
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
        public void Import()
        {
            List<GameInfoJSON> infoJSON = new List<GameInfoJSON>();
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string url = client.DownloadString("https://wiiubrew.org/wiki/Title_database");
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(url);

            var test = htmlDoc.DocumentNode.SelectNodes(xpath: "//html//body//div[@id='content']//div[@id='bodyContent']//div[@id='mw-content-text']//div[@class='mw-parser-output']//table[6]//tbody").ToList();
            test[0].FirstChild.Remove();
            Debug.WriteLine(test.Count);

            foreach (HtmlNode gameRow in test[0].SelectNodes("tr"))
            {
                GameInfoJSON gametemp = new GameInfoJSON();
                Debug.WriteLine("row");
                var nodes = gameRow.SelectNodes("th|td").ToList();
                gametemp.titleID = nodes[0].InnerText;
                gametemp.titleID = gametemp.titleID.Replace("-", "").Replace("\n", "");
                gametemp.name = nodes[1].InnerText;
                gametemp.name = Regex.Replace(
                    gametemp.name.Replace("\n", "")
                    //add renaming of BOTW
                    .Replace("The Legend of Zelda Breath of the Wild", "The Legend of Zelda: Breath of the Wild"),
                    //removal of trademarks
                    @"[®™]", "");
                gametemp.region = nodes[6].InnerText;
                gametemp.region = gametemp.region.Replace("\n", "").Replace("JAP", "JPN");
                infoJSON.Add(gametemp);
            }

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
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Import from the Homebrew database or GitHub (recommended)", Width = 300 };
            Button Titlekey = new Button() { Text = "Homebrew", Left = 50, Width = 100, Top = 70 };
            Button Gamelist = new Button() { Text = "GitHub", Left = 200, Width = 100, Top = 70 };
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