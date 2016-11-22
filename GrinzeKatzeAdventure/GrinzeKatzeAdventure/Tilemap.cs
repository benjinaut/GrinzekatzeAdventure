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

            public TileMap(Texture2D[] textures, Texture2D bitMap, int tileSize)
            {
                this.tileSize = tileSize;
                tilemap = new Tile[bitMap.Width, bitMap.Height];
                BuildMap(textures, bitMap);
            }
            private void BuildMap(Texture2D[] textures, Texture2D bitMap)
            {
                Color[] colores = new Color[bitMap.Width * bitMap.Height];
                bitMap.GetData(colores);

                for (int y = 0; y < tilemap.GetLength(1); y++)
                {
                    for (int x = 0; x < tilemap.GetLength(0); x++)
                    {
                        if (colores[y * tilemap.GetLength(0) + x] == Color.White)
                        {
                            //Grass
                            tilemap[x, y] = new Tile(textures[0], new Vector2(x * tileSize, y * tileSize), 0);
                        }
                        else
                        {
                            //Stein
                            tilemap[x, y] = new Tile(textures[1], new Vector2(x * tileSize, y * tileSize), 1);
                        }
                    }
                }
            }
        public bool Walkable(Vector2 currentPosition)
        {
            tilemap[(int)(currentPosition.X / tileSize), (int)(currentPosition.Y / tileSize)].Walkable; //Maps and Collision ---36.57 vid 3

        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y=0; y < tilemap.GetLength(1); y++)
            {
                for (int x=0; x<tilemap.GetLength(0); x++)
                {
                    tilemap[x, y].Draw(spriteBatch);

                }
            }
        }

        }
    }

