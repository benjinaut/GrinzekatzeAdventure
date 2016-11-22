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

        Texture2D texture;
        public Vector2 position;




        public Player(Texture2D playerTexture, Vector2 playerPosition)
        {
            texture = playerTexture;
            position = playerPosition;


        }
        public void Update()
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Left))
            {
                position.X -= 1;
            }
            if (key.IsKeyDown(Keys.Right))
            {
                position.X += 1;
            }
            if (key.IsKeyDown(Keys.Up))
            {
                position.Y -= 1;
            }
            if (key.IsKeyDown(Keys.Down))
            {
                position.Y += 1;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
