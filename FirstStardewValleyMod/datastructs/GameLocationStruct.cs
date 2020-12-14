using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.TerrainFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStardewValleyMod
{
    public class GameLocationStruct
    {
        public List<Tile> Tiles;
        public String name;
        public int height;
        public int width;

        public SerializableDictionary<Vector2, TerrainFeature> terrainFeatures;// = new Dictionary<Vector2, TerrainFeature>();
        public SerializableDictionary<Vector2, LargeTerrainFeature> largeTerrainFeatures;// = new Dictionary<Vector2, LargeTerrainFeature>();

        public GameLocationStruct()
        {
            Tiles = new List<Tile>();
        }

    }
}
