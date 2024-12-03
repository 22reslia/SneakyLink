using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;

namespace SneakyLink.Enemies
{
    public class ProjectileSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;
        private int frame;
        private int frameCounter;

        public ProjectileSprite(Texture2D text)
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
                if (frame <= 4)
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
            switch (frame)
            {
                case 0:
                    sourceRectangle = new Rectangle(0, 0, 64, 64);
                    break;
                case 1:
                    sourceRectangle = new Rectangle(0, 64, 64, 64);
                    break;
                case 2:
                    sourceRectangle = new Rectangle(0, 128, 64, 64);
                    break;
                case 3:
                    sourceRectangle = new Rectangle(0, 192, 64, 64);
                    break;
                case 4:
                    sourceRectangle = new Rectangle(0, 256, 64, 64);
                    break;
            }
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(x, y, 32, 32), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
