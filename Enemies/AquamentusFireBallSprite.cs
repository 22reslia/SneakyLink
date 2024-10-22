using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;

namespace SneakyLink.Enemies
{
    public class AquamentusFireBallSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;

        public AquamentusFireBallSprite(Texture2D text)
        {
            image = text;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            sourceRectangle = new Rectangle(119, 11, 8, 16);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(x, y, 16, 32), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
