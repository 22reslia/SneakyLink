using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Blocks
{
    public class Doors : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;
        private int col;
        private int row;

        public Doors(String doorID)
        {
            col = doorID[doorID.Length - 2] - '0';
            row = doorID[doorID.Length - 1] - '0';
            image = BlockSpriteFactory.Instance.GetSheet();
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            sourceRectangle = new Rectangle(815 + row*33, 11 + col*33, 32, 32);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(x, y, 80, 80), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
