
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Runtime.ConstrainedExecution;

namespace SneakyLink.Player
{
    public class DamagedLinkForward : ISprite
    {
        public Texture2D linkDamageSpriteSheet;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 30;

        public DamagedLinkForward(Texture2D texture)
        {
            linkDamageSpriteSheet = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            int width = 16;
            int height = 16;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 3)
            {
            sourceRectangle = new Rectangle(69, 1, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }
            else if (currentFrame >= maxFrame / 3 && currentFrame <= 2 * (maxFrame / 3))
            {
            sourceRectangle = new Rectangle(69, 18, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }
            else if (currentFrame >= 2 * (maxFrame / 3))
            {
            sourceRectangle = new Rectangle(69, 35, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkDamageSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == maxFrame)
            {
                currentFrame = 0;
            }
        }
    }

    public class DamagedLinkRight : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 30;

        public DamagedLinkRight(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            int width = 16;
            int height = 16;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 3)
            {
            sourceRectangle = new Rectangle(1, 1, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }
            else if (currentFrame >= maxFrame / 3 && currentFrame <= 2 * (maxFrame / 3))
            {
            sourceRectangle = new Rectangle(1, 18, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }
            else if (currentFrame >= 2 * (maxFrame / 3))
            {
            sourceRectangle = new Rectangle(1, 35, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == maxFrame)
            {
                currentFrame = 0;
            }
        }
    }

    public class DamagedLinkLeft : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 30;

        public DamagedLinkLeft(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            int width = 16;
            int height = 16;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 3)
            {
            sourceRectangle = new Rectangle(1, 1, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }
            else if (currentFrame >= maxFrame / 3 && currentFrame <= 2 * (maxFrame / 3))
            {
            sourceRectangle = new Rectangle(1, 18, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }
            else if (currentFrame >= 2 * (maxFrame / 3))
            {
            sourceRectangle = new Rectangle(1, 35, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
            spriteBatch.End();
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == maxFrame)
            {
                currentFrame = 0;
            }
        }
    }

    public class DamagedLinkBack : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 30;

        public DamagedLinkBack(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            int width = 16;
            int height = 16;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 3)
            {
            sourceRectangle = new Rectangle(35, 1, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }
            else if (currentFrame >= maxFrame / 3 && currentFrame <= 2 * (maxFrame / 3))
            {
            sourceRectangle = new Rectangle(35, 18, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }
            else if (currentFrame >= 2 * (maxFrame / 3))
            {
            sourceRectangle = new Rectangle(35, 35, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*width, 3*height);
            }

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == maxFrame)
            {
                currentFrame = 0;
            }
        }
    }
}
