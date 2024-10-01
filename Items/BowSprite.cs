using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Items
{
    public class BowSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;

        public BowSprite()
        {
            image = ItemSpriteFactory.Instance.GetSheet();
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            sourceRectangle = new Rectangle(144, 0, 8, 16);
            Rectangle destinationRectangle = new Rectangle(500, 200, 3 * sourceRectangle.Width, 3 * sourceRectangle.Height);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
