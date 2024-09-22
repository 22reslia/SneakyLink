using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink
{
    public class GoriyaBoomerangSprite : ISprite
    {
        private Rectangle sourceRectangular;
        private Texture2D texture;
        private int currentFrame;
        private int counter;

        public GoriyaBoomerangSprite(Texture2D texture)
        {
            this.texture = texture;
            this.currentFrame = 0;
            this.counter = 0;
        }

        public void Draw(SpriteBatch sb, int x, int y)
        {
            if (currentFrame == 0)
            {
                sourceRectangular = new Rectangle(290, 11, 8, 16);
            }
            else if (currentFrame == 1)
            {
                sourceRectangular = new Rectangle(299, 11, 8, 16);
            }
            else if (currentFrame == 2)
            {
                sourceRectangular = new Rectangle(308, 11, 8, 16);
            }
            sb.Begin(samplerState: SamplerState.PointClamp);
            sb.Draw(texture, new Rectangle(x, y, 32, 64), sourceRectangular, Color.White);
            sb.End();
        }

        public void Update()
        {
            if (counter < 5)
            {
                counter++;
            }
            else
            {
                currentFrame++;
                if (currentFrame > 2)
                    currentFrame = 0;
                counter = 0;
            }
        }
    }
}
