using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMU_Mod_Importer
{
    class Config
    {
        public string CEMU_path;

        public Config(string fileName)
        {
            CEMU_path = fileName;
        }
    }
}
