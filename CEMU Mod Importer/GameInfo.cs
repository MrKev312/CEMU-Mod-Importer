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
            if (Name == that.Name) return 0;
            List<string> names = new List<string>{ Name, that.Name };
            names.Sort();
            if (names[0] == Name)
                return -1;
            return 1;
        }
    }
}