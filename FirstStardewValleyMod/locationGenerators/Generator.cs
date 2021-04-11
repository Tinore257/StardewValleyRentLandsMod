using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStardewValleyMod.locationGenerators
{
    interface Generator
    {
        void generate(string seed, Vector2 groesse);


        datastructs.TileType[,] getEvaluationMap();

        GameLocationStruct getGameLocation();
        void addBridge(Vector2 x, Vector2 y);
    }
}
