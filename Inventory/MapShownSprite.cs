using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Inventory
{
    public class MapShownSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;
        private bool isPlayerPoint;
        public MapShownSprite(Texture2D text, int blockType)
        {
            isPlayerPoint = false;
            image = text;
            switch (blockType)
            {
                case 0:
                    sourceRectangle = new Rectangle(663, 108, 8, 8);
                    break;
                case 1:
                    sourceRectangle = new Rectangle(672, 108, 8, 8);
                    break;
                case 2:
                    sourceRectangle = new Rectangle(681, 108, 8, 8);
                    break;
                case 3:
                    sourceRectangle = new Rectangle(519, 126, 3, 3);
                    isPlayerPoint = true;
                    break;
            }
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            if (isPlayerPoint)
            {
                spriteBatch.Draw(image, new Rectangle(x, y, 9, 9), sourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(image, new Rectangle(x, y, 24, 24), sourceRectangle, Color.White);
            }
            spriteBatch.End();
        }
    }
}
