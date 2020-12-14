using Microsoft.Xna.Framework;
using StardewValley.TerrainFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStardewValleyMod
{
    public class TerrainFeaturePair
    {
        public Vector2 vector2;

        public TerrainFeature terrainFeature;

        public TerrainFeaturePair()
        {
            
        }

        public TerrainFeaturePair(Vector2 vector2, TerrainFeature terrainFeature)
        {
            this.vector2 = (vector2);
            this.terrainFeature = (terrainFeature);
        }

        public void setTerrainFeature(Vector2 vector2, TerrainFeature terrainFeature)
        {
            this.vector2   = (vector2);
            this.terrainFeature =(terrainFeature);
        }

    }
}
