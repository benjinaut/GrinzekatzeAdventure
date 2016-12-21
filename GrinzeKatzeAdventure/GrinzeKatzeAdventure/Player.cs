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
        Rectangle wallColider;
        float gForce=0.1f;
        bool jump;
        bool drop;
        bool wallslide;



        public Player(Texture2D playerTexture, Vector2 playerPosition, float speed, float health)
        {
            this.speed = speed;
            this.health = health;

            wallColider = new Rectangle(playerPosition.ToPoint(), new Point(playerTexture.Width, playerTexture.Height));

            texture = playerTexture;
            position = playerPosition;

            move = Vector2.Zero;
            size = new Vector2(playerTexture.Width, playerTexture.Height);

            jump = true;



        }

        void KeyboardInput()
        {
            KeyboardState key = Keyboard.GetState();

            move.Y += gForce;
            move.X = 0;

            

            if (key.IsKeyDown(Keys.Left) || key.IsKeyDown(Keys.A))
            {
                move.X -= 3;
            }
            if (key.IsKeyDown(Keys.Right) || key.IsKeyDown(Keys.D))
            {
                move.X += 3;

            }
            if (key.IsKeyDown(Keys.Down)|| key.IsKeyDown(Keys.S)) //drop
            {
                if (move.Y<0 && !drop && !key.IsKeyDown(Keys.Space))
                {

                    move.Y *= -4;
                    drop = true;

                }
            }

            if (key.IsKeyDown(Keys.Space))  //jump
            {
                if (!jump)
                {
                    move.Y = -7;
                    jump = true;
                }
               

            }

            TileMap tileMap = GameStuff.Instance.tilemap;
            if (move.Y>0 && ( !tileMap.Walkable(new Vector2(position.X, position.Y+move.Y+texture.Height))                   
                || !tileMap.Walkable(new Vector2(position.X+(texture.Width/2) , position.Y + move.Y + texture.Height))      
                || !tileMap.Walkable(new Vector2(position.X + (texture.Width / 4), position.Y + move.Y + texture.Height))   
                || !tileMap.Walkable(new Vector2(position.X + ((3*texture.Width) / 4), position.Y + move.Y + texture.Height))
                || !tileMap.Walkable(new Vector2(position.X+texture.Width , position.Y + move.Y + texture.Height))))

                // abfrage ob bestimmte punkte auf nicht begehbar tiles trefen durch die schwerkraft
                // also wenn move in y richtung größer als 0 ist
                // ja ja, ich weis man stellt sich schwerkraft eher als was negatives vor 
                // is halt so, der dreht das koordinatensystem
            {
                
                    move.Y = 0;
                    jump = false;
                    drop = false;
            }

             if ((move.Y<0 && (!tileMap.Walkable(new Vector2(position.X, position.Y + move.Y))
                || !tileMap.Walkable(new Vector2(position.X + (texture.Width / 2), position.Y + move.Y))
                || !tileMap.Walkable(new Vector2(position.X + (texture.Width / 4), position.Y + move.Y))
                || !tileMap.Walkable(new Vector2(position.X + ((3 * texture.Width) / 4), position.Y + move.Y))
                || !tileMap.Walkable(new Vector2(position.X + texture.Width, position.Y + move.Y)))))

                // hier das selbe noch mal in grün 
                // wenn man im sprung ist soll er nach oben überprüfen 
                // die punkte sind so gewählt das die pixel zahl zwischen den punkten kleiner ist als die pixel eines tiles
                // 50/4= 12,5 dazu kommt noch der punkt "null" der start punkt der reihe 
                // sonst fängt man bei 12
                // denn scheiss muss man aufteilen weil er sonst jump bei decken klatschern immer wieder false setzt
            {
                move.Y = 0;
            }

            if ((move.X<0 && (!tileMap.Walkable(new Vector2(position.X+move.X, position.Y))
                || !tileMap.Walkable(new Vector2(position.X + move.X, position.Y+texture.Height))
                || !tileMap.Walkable(new Vector2(position.X + move.X, position.Y + (texture.Height/2)))))

                // hier wird die kollision mit Wänden ab gefangen

                ||( move.X>0 && (!tileMap.Walkable(new Vector2(position.X + move.X+texture.Width , position.Y))
                || !tileMap.Walkable(new Vector2(position.X + move.X + texture.Width, position.Y+texture.Height))
                || !tileMap.Walkable(new Vector2(position.X + move.X + texture.Width, position.Y + (texture.Height/2)))))
                )
            {
                move.X = 0;

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
