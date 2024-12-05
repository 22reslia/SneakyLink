using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Blocks
{
    public class TreasureBox : IBlock
    {
        private ISprite treasureBoxSprite;
        private int x, y;
        private CollisionBox collisionBox;
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }
        public TreasureBox(int positionX, int positionY)
        {
            treasureBoxSprite = new TreasureBoxSprite();
            x = positionX;
            y = positionY;
            collisionBox = new CollisionBox(CollisionObjectType.Box, 40, 40, x, y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            treasureBoxSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {

        }
    }
}
