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
        
        public Texture2D texture;
        public Vector2 position;

        public Vector2 move;
        
        public Vector2 size;

        float health;
        float gForce=0.1f;
        float speed;
        float jumpMove;

        bool jump;
        bool drop;
        bool wallslideR;
        bool wallslideL;
        bool walljumpR;
        bool walljumpL;
        bool phaseOne;
       


        public Player(Texture2D playerTexture, Vector2 playerPosition, float speed, float health)
        {
            this.speed = speed;
            this.health = health;

            texture = playerTexture;

            position = playerPosition;
            move = Vector2.Zero;
            jumpMove = 0;
            size = new Vector2(playerTexture.Width, playerTexture.Height);

            jump = true;
            drop = false;
            wallslideL = false;
            wallslideR = false;
            walljumpL = false;
            walljumpR = false;
            phaseOne = false;
        }

        void KeyboardInput()
        {
            KeyboardState key = Keyboard.GetState();

            move.Y += gForce;
            move.X = 0;



            // KEY BLOCK

            if ((key.IsKeyDown(Keys.Left) || key.IsKeyDown(Keys.A)) && !(wallslideR||wallslideL||(phaseOne && walljumpL)))
            {
                if (!jump)
                {
                    move.X -= 2;
                }
                move.X -= 3;
            }

            if ((key.IsKeyDown(Keys.Right) || key.IsKeyDown(Keys.D)) && !(wallslideR || wallslideL || (phaseOne && walljumpR)))
            {
                if (!jump)
                { 
                    move.X += 2;
                }
                move.X += 3;
            }

            if (key.IsKeyDown(Keys.Down)|| key.IsKeyDown(Keys.S) && move.Y < 0) 
            {
                move.Y =2;
                drop = true;
                wallslideL = false;
                wallslideR = false;
            }

            if (key.IsKeyDown(Keys.Space) && !jump)  
            {
                    move.Y = -4;
                    jump = true;

                if(move.X < 0)
                {
                    jumpMove = -2;
                }
                if(move.X > 0)
                {
                    jumpMove = 2;
                }
                if (move.X == 0)
                {
                    jumpMove = 0;
                }

                if (wallslideR)
                {
                    wallslideR = false;
                    walljumpR = true;
                }

                if (wallslideL)
                {
                    wallslideL = false;
                    walljumpL = true;
                }

            }

            //EXECUTIV BLOCK

            if (walljumpR)
            {
                move.X -= 1;
                if (move.Y < 0)
                {
                    phaseOne = true;
                }
                else
                {
                    phaseOne = false;
                }
            }

            if (walljumpL)
            {
                move.X += 1;
                if (move.Y < 0)
                {
                    phaseOne = true;
                }
                else
                {
                    phaseOne = false;
                }
            }
            if (jump)
            {
                move.X += jumpMove;
            }



            // COLLISON BLOCK

            TileMap tileMap = GameStuff.Instance.tilemap;
            if (move.Y>0 && ( !tileMap.Walkable(new Vector2(position.X, position.Y+move.Y+texture.Height))                   
                || !tileMap.Walkable(new Vector2(position.X+texture.Width , position.Y + move.Y + texture.Height))))
            { 
                    move.Y = 0;


                // DROP POINT
                    jump = false;
                    drop = false;
                    wallslideL = false;
                    wallslideR = false;
                    walljumpL = false;
                    walljumpR = false;
                    phaseOne = false;

            }

             if ((move.Y<0 && (!tileMap.Walkable(new Vector2(position.X, position.Y + move.Y))
                || !tileMap.Walkable(new Vector2(position.X + texture.Width, position.Y + move.Y)))))
                
            {
                move.Y = 0;
            }

            if ((move.X<0 && (!tileMap.Walkable(new Vector2(position.X+move.X, position.Y))
                || !tileMap.Walkable(new Vector2(position.X + move.X, position.Y+texture.Height))))
                ||( move.X>0 && (!tileMap.Walkable(new Vector2(position.X + move.X+texture.Width , position.Y))
                || !tileMap.Walkable(new Vector2(position.X + move.X + texture.Width, position.Y+texture.Height)))))
            {

                if (tileMap.Walkable(new Vector2(position.X, 1+position.Y + 3 * texture.Height))
                    && tileMap.Walkable(new Vector2(position.X, 1+position.Y + 2 * texture.Height))
                    && tileMap.Walkable(new Vector2(position.X, 1 + position.Y + texture.Height))
                    && move.X < 0)
                {
                    wallslideL = true;
                    walljumpR = false;
                    jump = false;
                }

                if((tileMap.Walkable(new Vector2(position.X+texture.Width, 1 + position.Y + 3 * texture.Height))
                    && tileMap.Walkable(new Vector2(position.X + texture.Width, 1 + position.Y + 2 * texture.Height))
                    && tileMap.Walkable(new Vector2(position.X + texture.Width, 1 + position.Y + texture.Height))
                    && move.X > 0))
                {
                    wallslideR = true;
                    walljumpL = false;
                    jump = false;
                }

                move.X = 0;
            }

            if(move.Y > 0)
            {
                jump = true ;
            }
                       
            position += move ;
            

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
        public void Update(GameTime gameTime)
        {
            KeyboardInput();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
