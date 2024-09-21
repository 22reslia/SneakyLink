using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;

namespace SneakyLink
{
    public class AquamentusRightAttackSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;
        private int frame;
        private int frameCounter;

        public AquamentusRightAttackSprite(Texture2D text)
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
                sourceRectangle = new Rectangle(25, 11, -24, 32);
            }
            else if (frame == 1)
            {
                sourceRectangle = new Rectangle(50, 11, -24, 32);
            }
            spriteBatch.Begin();
            spriteBatch.Draw(image, new Rectangle(x, y, 72, 96), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
