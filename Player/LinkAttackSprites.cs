using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SneakyLink.Player
{
    public class LinkWoodenSwordForward : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 30;
        public LinkWoodenSwordForward(Texture2D texture)
        {
           linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
           position.X = xPosition;
           position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 4)
            {
            sourceRectangle = new Rectangle(1, 47, 16, 16);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*16);
            }
            else if (currentFrame >= maxFrame / 4 && currentFrame < maxFrame / 2)
            {
            sourceRectangle = new Rectangle(18, 47, 16, 27);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*27);
            }
            else if (currentFrame >= maxFrame / 2 && currentFrame < 3 * (maxFrame / 4))
            {
            sourceRectangle = new Rectangle(35, 47, 16, 22);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*22);
            }
            else if (currentFrame >= 3 * (maxFrame / 4))
            {
            sourceRectangle = new Rectangle(52, 47, 16, 18);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*18);
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

    public class LinkWoodenSwordRight : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 30;

        public LinkWoodenSwordRight(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 4)
            {
             sourceRectangle = new Rectangle(1, 77, 16, 16);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*16);
            }
            else if (currentFrame >= maxFrame / 4 && currentFrame < maxFrame / 2)
            {
             sourceRectangle = new Rectangle(18, 77, 27, 17);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*27, 3*17);
            }
            else if (currentFrame >= maxFrame / 2 && currentFrame < 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(46, 77, 23, 17);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*23, 3*17);
            }
            else if (currentFrame >= 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(70, 77, 19, 17);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*19, 3*17);
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

    public class LinkWoodenSwordLeft : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 30;
        public LinkWoodenSwordLeft(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 4)
            {
             sourceRectangle = new Rectangle(1, 77, 16, 16);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*16);
            }
            else if (currentFrame >= maxFrame / 4 && currentFrame < maxFrame / 2)
            {
             sourceRectangle = new Rectangle(18, 77, 27, 17);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*27, 3*17);
            }
            else if (currentFrame >= maxFrame / 2 && currentFrame < 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(46, 77, 23, 17);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*23, 3*17);
            }
            else if (currentFrame >= 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(70, 77, 19, 17);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*19, 3*17);
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

    public class LinkWoodenSwordTop : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 30;

        public LinkWoodenSwordTop(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 4)
            {
             sourceRectangle = new Rectangle(1, 109, 16, 16);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*16);
            }
            else if (currentFrame >= maxFrame / 4 && currentFrame < maxFrame / 2)
            {
             sourceRectangle = new Rectangle(18, 97, 16, 28);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*28);
            }
            else if (currentFrame >= maxFrame / 2 && currentFrame < 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(35, 98, 16, 27);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*27);
            }
            else if (currentFrame >= 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(52, 106, 16, 19);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*19);
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