﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Items
{
    public class ArrowSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;

        public ArrowSprite()
        {
            image = ItemSpriteFactory.Instance.GetSheet();
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            sourceRectangle = new Rectangle(154, 0, 5, 16);
            Rectangle destinationRectangle = new Rectangle(500, 200, 3 * sourceRectangle.Width, 3 * sourceRectangle.Height);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
