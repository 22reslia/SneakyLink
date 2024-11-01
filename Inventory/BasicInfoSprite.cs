using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;
namespace SneakyLink.Inventory
{
    public class BasicInfoSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;

        public BasicInfoSprite(Texture2D text)
        {
            image = text;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            sourceRectangle = new Rectangle(340, 10, 170, 50);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(x, y, 510, 150), sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {

        }
    }
}
