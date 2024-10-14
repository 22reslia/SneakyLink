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
    public class VoidSpace : IBlock
    {
        private ISprite voidSprite;
        private int x, y;
        public CollisionBox collisionBox;
        public VoidSpace(int positionX, int positionY)
        {
            voidSprite = new VoidSprite();
            x = positionX;
            y = positionY;
            collisionBox = new CollisionBox(CollisionObjectType.Block, 40, 40, x, y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            voidSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {

        }
    }
}
