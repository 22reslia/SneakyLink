using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Enemies
{
    public class GoriyaUpIdleSprite : ISprite
    {
        private Rectangle sourceRectangular;
        private Texture2D texture;
        private int currentFrame;
        private int counter;

        public GoriyaUpIdleSprite(Texture2D texture)
        {
            this.texture = texture;
            this.currentFrame = 0;
            this.counter = 0;
        }

        public void Draw(SpriteBatch sb, int x, int y)
        {
            if (currentFrame == 0)
            {
                sourceRectangular = new Rectangle(239, 11, 16, 16);
            }
            else if (currentFrame == 1)
            {
                sourceRectangular = new Rectangle(255, 11, -16, 16);
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
