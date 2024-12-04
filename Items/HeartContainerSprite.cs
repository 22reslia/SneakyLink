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
    public class HeartContainerSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;

        public HeartContainerSprite()
        {
            image = ItemSpriteFactory.Instance.GetSheet();
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            sourceRectangle = new Rectangle(25, 1, 13, 13);
            Rectangle destinationRectangle = new Rectangle(x, y, 32, 32);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
