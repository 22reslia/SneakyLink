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
    public class RupeeSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;
        private int currentFrame;
        private int counter;

        public RupeeSprite()
        {
            image = ItemSpriteFactory.Instance.GetSheet();
            currentFrame = 0;
            counter = 0;
        }

        public void Update()
        {
            if (counter < 15)
            {
                counter++;
            }
            else
            {
                currentFrame++;
                if (currentFrame > 1)
                    currentFrame = 0;
                counter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            if (currentFrame == 0)
            {
                sourceRectangle = new Rectangle(72, 0, 8, 16);
            }
            else if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(72, 16, 8, 16);
            }
            Rectangle destinationRectangle = new Rectangle(x, y, 16, 32);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
