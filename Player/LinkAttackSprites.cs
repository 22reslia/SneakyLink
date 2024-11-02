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
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }
            else if (currentFrame >= maxFrame / 4 && currentFrame < maxFrame / 2)
            {
            sourceRectangle = new Rectangle(18, 47, 16, 27);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 64);
            }
            else if (currentFrame >= maxFrame / 2 && currentFrame < 3 * (maxFrame / 4))
            {
            sourceRectangle = new Rectangle(35, 47, 16, 22);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 52);
            }
            else if (currentFrame >= 3 * (maxFrame / 4))
            {
            sourceRectangle = new Rectangle(52, 47, 16, 18);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 42);
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
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }
            else if (currentFrame >= maxFrame / 4 && currentFrame < maxFrame / 2)
            {
             sourceRectangle = new Rectangle(18, 77, 27, 17);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 40);
            }
            else if (currentFrame >= maxFrame / 2 && currentFrame < 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(46, 77, 23, 17);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 54, 40);
            }
            else if (currentFrame >= 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(70, 77, 19, 17);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 45, 40);
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
             sourceRectangle = new Rectangle(17, 77, -16, 16);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }
            else if (currentFrame >= maxFrame / 4 && currentFrame < maxFrame / 2)
            {
             sourceRectangle = new Rectangle(44, 77, -27, 17);
             destinationRectangle = new Rectangle((int)position.X - 26, (int)position.Y, 64, 40);
            }
            else if (currentFrame >= maxFrame / 2 && currentFrame < 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(68, 77, -23, 17);
             destinationRectangle = new Rectangle((int)position.X - 16, (int)position.Y, 54, 40);
            }
            else if (currentFrame >= 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(88, 77, -19, 17);
             destinationRectangle = new Rectangle((int)position.X - 7, (int)position.Y, 45, 40);
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
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }
            else if (currentFrame >= maxFrame / 4 && currentFrame < maxFrame / 2)
            {
             sourceRectangle = new Rectangle(18, 97, 16, 28);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y - 26, 38, 64);
            }
            else if (currentFrame >= maxFrame / 2 && currentFrame < 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(35, 98, 16, 27);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y - 14, 38, 52);
            }
            else if (currentFrame >= 3 * (maxFrame / 4))
            {
             sourceRectangle = new Rectangle(52, 106, 16, 19);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y - 4, 38, 42);
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