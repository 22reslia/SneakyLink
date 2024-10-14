using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Blocks
{
    public class Statue2 : IBlock
    {
        private ISprite statue2Sprite;
        private int x, y;
        public CollisionBox collisionBox;
        public Statue2(int positionX, int positionY)
        {
            statue2Sprite = new Statue2Sprite();
            x = positionX;
            y = positionY;
            collisionBox = new CollisionBox(CollisionObjectType.Block, 40, 40, x, y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            statue2Sprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {

        }
    }
}
