using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Blocks
{
    public class Statue1 : IBlock
    {
        private ISprite statue1Sprite;
        private int x, y;
        private int width = 40, height = 40;
        public Rectangle CollisionBox => new Rectangle(x, y, width, height);
        public CollisionObjectType ObjectType => CollisionObjectType.Block;
        public Statue1(int positionX, int positionY)
        {
            statue1Sprite = new Statue1Sprite();
            x = positionX;
            y = positionY;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            statue1Sprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {

        }
        public void OnCollision(ICollision other, CollisionType collisionType)
        {
            
        }
    }
}
