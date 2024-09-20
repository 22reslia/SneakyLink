using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;

namespace SneakyLink
{
    public class AquamentusFireBall : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;

        public AquamentusFireBall(Texture2D text)
        {
            image = text;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            sourceRectangle = new Rectangle(119, 11, 8, 16);
            spriteBatch.Begin();
            spriteBatch.Draw(image, new Rectangle(x, y, 24, 84), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
