using Microsoft.Xna.Framework;
using StardewValley.TerrainFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStardewValleyMod.datastructs
{
    public class LargeTerrainFeaturePair
    {
        public Vector2 vector2;

        public LargeTerrainFeature largeterrainFeature;

        public LargeTerrainFeaturePair()
        {

        }

        public LargeTerrainFeaturePair(Vector2 vector2, LargeTerrainFeature largeterrainFeature)
        {
            this.vector2 = (vector2);
            this.largeterrainFeature = (largeterrainFeature);
        }

        public void setlargeTerrainFeature(Vector2 vector2, LargeTerrainFeature largeterrainFeature)
        {
            this.vector2 = (vector2);
            this.largeterrainFeature = (largeterrainFeature);
        }

    }
}
