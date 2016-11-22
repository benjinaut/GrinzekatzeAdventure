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
    class Tile
    {
        Vector2 position;
        Texture2D texture;
        int id;

        public Tile(Texture2D texture, Vector2 position, int id)
        {
            this.texture = texture;
            this.position = position;
            this.id = id;

        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spritbatch)
        {
            spritbatch.Draw(texture, position, Color.White);
        }


    }
}
