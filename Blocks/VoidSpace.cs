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
    public class VoidSpace : IBlock, ICollision
    {
        private ISprite voidSprite;
        private int x, y;
        private int width = 40, height = 40;
        public Rectangle CollisionBox => new Rectangle(x, y, width, height);
        public CollisionObjectType ObjectType => CollisionObjectType.Block;
        public VoidSpace(int positionX, int positionY)
        {
            voidSprite = new VoidSprite();
            x = positionX;
            y = positionY;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            voidSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {

        }
        public void OnCollision(ICollision other, CollisionType collisionType)
        {
            
        }
    }
}
