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
    class Player
    {
        float speed;
        public Texture2D texture;
        public Vector2 position;
        public Vector2 move;
        public Vector2 size;
        float health; 




        public Player(Texture2D playerTexture, Vector2 playerPosition, float speed, float health)
        {
            this.speed = speed;
            this.health = health;

            texture = playerTexture;
            position = playerPosition;

            move = Vector2.Zero;
            size = new Vector2(playerTexture.Width, playerTexture.Height);


        }

        void KeyboardInput(TileMap tileMap)
        {
            KeyboardState key = Keyboard.GetState();

            move = Vector2.Zero;

            if (key.IsKeyDown(Keys.Left))
            {
                move.X -= 1;
            }
            if (key.IsKeyDown(Keys.Right))
            {
                move.X += 1;
            }
            if (key.IsKeyDown(Keys.Up))
            {
                move.Y -= 1;
            }
            if (key.IsKeyDown(Keys.Down))
            {
                move.Y += 1;
            }

            if (tileMap.Walkable(position + move)
                && tileMap.Walkable(position + move + new Vector2(texture.Width,0))
                && tileMap.Walkable(position + move + new Vector2(0,texture.Height))
                && tileMap.Walkable(position + move + new Vector2(texture.Width, texture.Height)))
            {
                position += move;
            }

            
        }
        public void ApplyDamage(float amount)
        {
            if (health > amount)
                health -= amount;
            else
            {
                health = 100;
                position = new Vector2(100, 100);
            }
        }
        public void Update(GameTime gameTime, TileMap tileMap)
        {
            KeyboardInput(tileMap);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
