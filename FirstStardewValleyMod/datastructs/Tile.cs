using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStardewValleyMod
{
    /// <summary>Defines an override to apply to a tile position.</summary>
    public class Tile
    {
        /*********
        ** Properties
        *********/
        /// <summary>The tile layer.</summary>
        public TileLayer Layer { get; }

        /// <summary>The tile layer name.</summary>
        public string LayerName { get; }

        /// <summary>The X tile coordinate.</summary>
        public int X { get; }

        /// <summary>The Y tile coordinate.</summary>
        public int Y { get; }

        /// <summary>The tile ID in the tilesheet.</summary>
        public int TileID { get; }

        /// <summary>The tilesheet for the <see cref="TileID"/>.</summary>
        public string Tilesheet { get; }

        
        public Tile()
        {

        }


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="layer">The tile layer.</param>
        /// <param name="x">The X tile coordinate.</param>
        /// <param name="y">The Y tile coordinate.</param>
        /// <param name="tileID">The tile ID in the tilesheet.</param>
        /// <param name="tilesheet">The tilesheet for the <paramref name="tileID"/>.</param>
        public Tile(TileLayer layer, int x, int y, int tileID, string tilesheet)
        {
            this.Layer = layer;
            this.LayerName = layer.ToString();
            this.X = x;
            this.Y = y;
            this.TileID = tileID;
            this.Tilesheet = tilesheet;
        }


        public static TileLayer TileLayerFormString(String tileLayerString)
        {
            if (tileLayerString.Equals("Back"))
                return TileLayer.Back;
            if (tileLayerString.Equals("Buildings"))
                return TileLayer.Buildings;
            if (tileLayerString.Equals("Paths"))
                return TileLayer.Paths;
            if (tileLayerString.Equals("Front"))
                return TileLayer.Front;
            if (tileLayerString.Equals("AlwaysFront"))
                return TileLayer.AlwaysFront;
            return TileLayer.Back;
        }
    }
}