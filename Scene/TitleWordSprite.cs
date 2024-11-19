using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;

namespace SneakyLink.Scene
{
    public class TitleWordSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;

        public TitleWordSprite(Texture2D text)
        {
            sourceRectangle = new Rectangle(1, 11, 256, 224);
            image = text;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(x, y, 800, 640), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
