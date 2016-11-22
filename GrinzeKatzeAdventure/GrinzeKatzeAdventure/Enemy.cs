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
        Texture2D texture;
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
        public void Update()
        {
            Vector2 move = target.position - position;
            move.Normalize();
            move *= speed;
            position += move;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
