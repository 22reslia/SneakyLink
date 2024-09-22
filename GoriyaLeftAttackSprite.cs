using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class GoriyaLeftAttackSprite : ISprite
    {
        private Rectangle sourceRectangular;
        private Texture2D texture;
        private int currentFrame;
        private int counter;

        public GoriyaLeftAttackSprite(Texture2D texture)
        {
            this.texture = texture;
            this.currentFrame = 0;
            this.counter = 0;
        }

        public void Draw(SpriteBatch sb, int x, int y)
        {
            if (currentFrame == 0)
            {
                sourceRectangular = new Rectangle(272, 11, -16, 16);
            }
            else if (currentFrame == 1)
            {
                sourceRectangular = new Rectangle(289, 11, -16, 16);
            }
            sb.Begin(samplerState: SamplerState.PointClamp);
            sb.Draw(texture, new Rectangle(x, y, 64, 64), sourceRectangular, Color.White);
            sb.End();
        }

        public void Update()
        {
            if (counter < 15)
            {
                counter++;
            }
            else
            {
                currentFrame++;
                if (currentFrame > 1)
                    currentFrame = 0;
                counter = 0;
            }
        }
    }
}
