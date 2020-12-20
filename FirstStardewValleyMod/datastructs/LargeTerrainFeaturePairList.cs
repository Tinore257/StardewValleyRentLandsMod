using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStardewValleyMod.datastructs
{
    public class LargeTerrainFeaturePairList
    {

        public List<LargeTerrainFeaturePair> LargeterrainFeaturePairs;

        public LargeTerrainFeaturePairList()
        {
            LargeterrainFeaturePairs = new List<LargeTerrainFeaturePair>();
        }

        public LargeTerrainFeaturePairList(LargeTerrainFeaturePair largeterrainFeaturePair)
        {
            LargeterrainFeaturePairs = new List<LargeTerrainFeaturePair>();
            this.LargeterrainFeaturePairs.Add(largeterrainFeaturePair);
        }

    }
}
