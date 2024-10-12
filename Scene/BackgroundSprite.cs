using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;

namespace SneakyLink.Scene
{
    public class BackgroundSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;

        public BackgroundSprite(Texture2D text)
        {
            image = text;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            sourceRectangle = new Rectangle(521, 11, 256, 176);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(x, y, 640, 440), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
