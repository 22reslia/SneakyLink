using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SneakyLink.Enemies
{
    public class EnemyDeathSprite : ISprite
    {
        private Rectangle sourceRectangular;
        private Texture2D texture;
        private int currentFrame;
        private int counter;
        private bool isFinished;

        public EnemyDeathSprite(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            counter = 0;
            isFinished = false;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            if (isFinished)
                return;

            if (currentFrame == 0)
            {
                sourceRectangular = new Rectangle(0, 0, 16, 16);
            }
            else if (currentFrame == 1)
            {
                sourceRectangular = new Rectangle(16, 0, 16, 16);
            }
            else if (currentFrame == 2)
            {
                sourceRectangular = new Rectangle(32, 0, 16, 16);
            }
            else if (currentFrame == 3)
            {
                sourceRectangular = new Rectangle(32, 0, 16, 16);
            }
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(texture, new Rectangle(x, y, 48, 48), sourceRectangular, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            if (isFinished)
                return;

            if (counter < 20)
            {
                counter++;
            }
            else
            {
                if (currentFrame > 3)
                {
                    isFinished = true;
                }
                currentFrame++;
            }
        }
    }
}
