using System;
using System.Collections.Generic;

namespace CEMU_Mod_Importer
{
    class GameInfo : IComparable<GameInfo>
    {
        public string Name;
        public List<string> Ids = new List<string>();

        public override string ToString()
        {
            return Name;
        }
        public int CompareTo(GameInfo that)
        {
            return Name.CompareTo(that.Name);
        }
    }
}