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
        float gForce=0.1f;
        float speedY;
        bool jumpOne;
        bool doubleJump;



        public Player(Texture2D playerTexture, Vector2 playerPosition, float speed, float health)
        {
            this.speed = speed;
            this.health = health;

            texture = playerTexture;
            position = playerPosition;

            move = Vector2.Zero;
            size = new Vector2(playerTexture.Width, playerTexture.Height);

            jumpOne = false;



        }

        void KeyboardInput(TileMap tileMap)
        {
            KeyboardState key = Keyboard.GetState();

            move.Y += gForce;
            move.X = 0;



            if (key.IsKeyDown(Keys.Left))
            {
                move.X -= 1;
            }
            if (key.IsKeyDown(Keys.Right))
            {
                move.X += 1;

            }

            if (key.IsKeyDown(Keys.Space)&& !jumpOne)
            {
                position.Y -= 1;
                move.Y = -3;
            }

            if (position.Y <= 400)
            {
                position.Y += move.Y;  
                jumpOne = true;
            }
            else
            {
                jumpOne = false; 
            }
            position.X += move.X;




            
            /**
            if (tileMap.Walkable(position + move)
                && tileMap.Walkable(position + move + new Vector2(texture.Width,0))
                && tileMap.Walkable(position + move + new Vector2(0,texture.Height))
                && tileMap.Walkable(position + move + new Vector2(texture.Width, texture.Height)))
            {
                position += move;
            }
            **/

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
