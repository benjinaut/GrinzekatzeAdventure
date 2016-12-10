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
    class Enemy
    {
        public Texture2D texture;
        Vector2 position;
        float speed;
        Player target;

        public Enemy(Texture2D enemyTexture, Vector2 enemyPosition, float speed, Player target)
        {
            texture = enemyTexture;
            position = enemyPosition;
            this.speed = speed;
            this.target = target;
        }
        public void Update(TileMap tileMap)
        {
            Vector2 move = target.position - position;
            move.Normalize();
            move *= speed;
            if (tileMap.Walkable(position + move)
                && tileMap.Walkable(position + move + new Vector2(texture.Width, 0))
                && tileMap.Walkable(position + move + new Vector2(0, texture.Height))
                && tileMap.Walkable(position + move + new Vector2(texture.Width, texture.Height)))
            {
                position += move;
            }
          
            Rectangle rectE = new Rectangle(position.ToPoint(), new Point(texture.Width, texture.Height));
            Rectangle rectP = new Rectangle(target.position.ToPoint(), new Point(target.texture.Width, target.texture.Height));

            if (rectE.X<rectP.X + rectP.Size.X && rectE.X + rectE.Size.X > rectP.X && rectE.Y < rectP.Y+ rectP.Size.Y && rectE.Y +rectE.Size.Y> rectP.Y)
            {
                target.ApplyDamage(100);
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
