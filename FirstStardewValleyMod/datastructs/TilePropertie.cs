using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStardewValleyMod.datastructs
{

    
    public class TilePropertie
    {
        public string layer;

        public string key;

        public string value;


        public TilePropertie()
        {

        }

        public TilePropertie(String layer, String key, String value)
        {
            this.layer = layer;
            this.key = key;
            this.value = value;
        }
        
    }
}
