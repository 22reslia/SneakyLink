using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;

namespace SneakyLink
{
    //class for the moving, non-animated sprite
    public class StalfosSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;
        private int frame;
        private int frameCounter;

        public StalfosSprite(Texture2D text)
        {
            image = text;
            frame = 0;
            frameCounter = 0;
        }

        public void Update()
        {
            //deal with the frame number
            if (frameCounter == 12)
            {
                if (frame <= 1)
                {
                    frame++;
                }
                else
                {
                    frame = 0;
                }
                frameCounter = 0;
            }
            else
            {
                frameCounter++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            if (frame == 0)
            {
                sourceRectangle = new Rectangle(1, 59, 16, 16);
            }
            else if (frame == 1)
            {
                sourceRectangle = new Rectangle(17, 59, -16, 16);
            }
            spriteBatch.Begin();
            spriteBatch.Draw(image, new Rectangle(x, y, 64, 64), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
