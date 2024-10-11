using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Blocks
{
    public class StairSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;

        public StairSprite()
        {
            image = BlockSpriteFactory.Instance.GetSheet();
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            sourceRectangle = new Rectangle(1035, 28, 16, 16);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(x, y, 40, 40), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
