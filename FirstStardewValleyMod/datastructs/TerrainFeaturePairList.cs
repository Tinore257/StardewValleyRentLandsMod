using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStardewValleyMod
{
    public class TerrainFeaturePairList
    {

        public List<TerrainFeaturePair> terrainFeaturePairs;

        public TerrainFeaturePairList()
        {
            terrainFeaturePairs = new List<TerrainFeaturePair>();
        }

        public TerrainFeaturePairList(TerrainFeaturePair terrainFeaturePair)
        {
            terrainFeaturePairs = new List<TerrainFeaturePair>();
            this.terrainFeaturePairs.Add(terrainFeaturePair);
        }

    }
}
