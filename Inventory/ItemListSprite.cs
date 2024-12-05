﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Inventory
{
    public class ItemListSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;
        public ItemListSprite(string weaponName, Texture2D text)
        {
            image = text;
            switch (weaponName)
            {
                case "Bomb":
                    sourceRectangle = new Rectangle(604, 137, 8, 16);
                    break;

            }
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(x, y, 24, 48), sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {

        }
    }
}
