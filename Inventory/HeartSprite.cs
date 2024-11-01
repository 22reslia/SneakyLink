using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SneakyLink.Inventory
{
    public class HeartSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;
        public HeartSprite(Texture2D text, bool isEmpty)
        {
            image = text;
            if (isEmpty) 
            {
                sourceRectangle = new Rectangle(627, 117, 8, 8);
            }
            else
            {
                sourceRectangle = new Rectangle(645, 117, 8, 8);
            }
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(x, y, 24, 24), sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            
        }
    }
}
