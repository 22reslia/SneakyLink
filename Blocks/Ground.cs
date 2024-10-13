using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Blocks
{
    public class Ground : IBlock
    {
        private ISprite blueFloorSprite;
        private int x, y;
        public Ground(int positionX, int positionY)
        {
            blueFloorSprite = new BlueFloorSprite();
            x = positionX;
            y = positionY;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            blueFloorSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {

        }
    }
}
