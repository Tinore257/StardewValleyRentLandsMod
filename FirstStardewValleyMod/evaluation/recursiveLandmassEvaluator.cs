using FirstStardewValleyMod.datastructs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStardewValleyMod.evaluation
{
    class recursiveLandmassEvaluator
    {
        TileType[,] tyleMap;
        bool[,] visited;
        public recursiveLandmassEvaluator(TileType[,] tileMapParam)
        {
            this.tyleMap = tileMapParam;
            visited = new bool[tileMapParam.GetLength(0), tileMapParam.GetLength(1)];
            for (int i=0; i < visited.GetLength(0); i++)
            {
                for(int j = 0; j < visited.GetLength(1); j++)
                {
                    visited[i, j] = false;
                }
            }
        }

        public void recursive(Vector2 position)
        {
            if (!isWalkable(position))
                return;
            visited[(int)position.X, (int)position.Y] = true;
            //links
            if (position.X-1 >= 0)
            {
                Vector2 posPosition = position;
                posPosition.X = posPosition.X - 1;
                if(!visited[(int)posPosition.X, (int)posPosition.Y]){
                    recursive(posPosition);
                }
            }
            //rechts
            if (position.X + 1 < visited.GetLength(0))
            {
                Vector2 posPosition = position;
                posPosition.X = posPosition.X + 1;
                if (!visited[(int)posPosition.X, (int)posPosition.Y])
                {
                    recursive(posPosition);
                }
            }
            //oben
            if (position.Y- 1 >= 0)
            {
                Vector2 posPosition = position;
                posPosition.Y = posPosition.Y - 1;
                if (!visited[(int)posPosition.X, (int)posPosition.Y])
                {
                    recursive(posPosition);
                }
            }
            //unten
            if (position.Y + 1 < visited.GetLength(0))
            {
                Vector2 posPosition = position;
                posPosition.Y = posPosition.Y + 1;
                if (!visited[(int)posPosition.X, (int)posPosition.Y])
                {
                    recursive(posPosition);
                }
            }

            return;
        }

        private bool isWalkable(Vector2 position)
        {
            if (this.tyleMap[(int) position.X,(int) position.Y].Equals(TileType.grass))
                return true;
            return false;
        }
    }
}
