using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GrinzeKatzeAdventure
{
    class TileMap
    {
        Tile[,] tilemap;
        int tileSize;

        public TileMap(Texture2D[] texture, Texture2D bitMap, int tileSize)
        {
            this.tileSize = tileSize;
            tilemap = new Tile[bitMap.Width, bitMap.Height];

        }
        private void BuildMap(Texture2D[] texture, Texture2D bitMap)
        {
            Color[] colores = new Color[bitMap.Width * bitMap.Height];
            bitMap.GetData(colores);

            for (int y = 0; y < tilemap.GetLength(1); y++)
            {
                for (int x = 0; x < tilemap.GetLength(1); x++)
                {
                    if (colores[y * tilemap.GetLength(0) + x] == Color.White)
                    {
                        //Grass
                        tilemap[x, y] = new Tile(texture[0], new Vector2(x * tileSize, y * tileSize), 0);
                    }
                    else
                    {
                        //Stein
                        tilemap[x, y] = new Tile(texture[0], new Vector2(x * tileSize, y * tileSize), 1);
                    }
                }
            }
        }
    }
}

