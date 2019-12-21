using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;

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
        public void Import(string JSONfile)
        {
            GameInfoJSON[] infoJSON = JsonConvert.DeserializeObject<GameInfoJSON[]>(JSONfile);
            
            foreach (GameInfoJSON gameInfoJSON in infoJSON)
            {
                if (gameInfoJSON.name == null)
                    continue;
                gameInfoJSON.name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gameInfoJSON.name.ToLower());
                bool added = false;
                if(gameInfoJSON.titleID[7] == '0')
                {
                    foreach (GameInfo info in gameInfos)
                    {
                        if(info.Name == gameInfoJSON.name)
                        {
                            info.Ids.Add(gameInfoJSON.titleID + " [" + gameInfoJSON.region + "]");
                            added = true;
                            break;
                        }
                    }
                    if (added == false)
                    {
                        GameInfo gameInfo = new GameInfo();
                        gameInfo.Name = gameInfoJSON.name;
                        gameInfo.Ids.Add(gameInfoJSON.titleID + " [" + gameInfoJSON.region + "]");
                        gameInfos.Add(gameInfo);
                    }
                }
            }
            gameInfos.Sort();
            File.WriteAllText("./GameList.json", JsonConvert.SerializeObject(gameInfos));
        }
    }
}
