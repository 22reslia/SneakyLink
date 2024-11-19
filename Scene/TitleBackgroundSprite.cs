using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;

namespace SneakyLink.Scene
{
    public class TitleBackgroundSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;

        public TitleBackgroundSprite(Texture2D text)
        {
            image = text;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            sourceRectangle = new Rectangle(0, 0, 798, 480);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(x, y, 1120, 800), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
