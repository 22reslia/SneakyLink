using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SneakyLink.Player
{
    public class LinkUseItemSouth : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 5;
        public LinkUseItemSouth(Texture2D texture)
        {
           linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
           position.X = xPosition;
           position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 5)
            {
            sourceRectangle = new Rectangle(1, 47, 16, 16);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*16);
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

    public class LinkUseItemRight : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 5;

        public LinkUseItemRight(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 5)
            {
             sourceRectangle = new Rectangle(124, 11, 16, 16);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*16);
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

    public class LinkUseItemLeft : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 5;
        public LinkUseItemLeft(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 5)
            {
             sourceRectangle = new Rectangle(124, 11, 16, 16);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*16);
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

    public class LinkUseItemNorth : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        int currentFrame = 0;
        int maxFrame = 5;

        //LinkFacing towards top of the screen
        public LinkUseItemNorth(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 5)
            {
             sourceRectangle = new Rectangle(141, 11, 16, 16);
             destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 3*16, 3*16);
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