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
    public class Block : IBlock
    {
        private ISprite squareBlockSprite;
        private int x, y;
        public CollisionBox collisionBox;
        public Block(int positionX, int positionY)
        {
            squareBlockSprite = new SquareBlockSprite();
            x = positionX;
            y = positionY;
            collisionBox = new CollisionBox(CollisionObjectType.Block, 40, 40, x, y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            squareBlockSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {

        }
    }
}
