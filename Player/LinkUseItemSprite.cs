using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SneakyLink.Player
{
    public class LinkUseItemSouth : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        private int frameDelay = 4;
        private int frameCounter = 0;
        int currentFrame = 0;
        int maxFrame = 10;
        public LinkUseItemSouth(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition, int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 5)
            {
                sourceRectangle = new Rectangle(1, 47, 16, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }

            else if (currentFrame >= maxFrame / 5 && currentFrame < maxFrame / 2)
            {
                sourceRectangle = new Rectangle(1, 11, 16, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }

            else // Default frame if no other condition matches
    {
        sourceRectangle = new Rectangle(1, 47, 16, 16); // This could be any frame you prefer as default
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
    }

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        
        }

        public void Update()
        {
         frameCounter++;

    // Only increment the frame when frameCounter reaches the delay
    if (frameCounter >= frameDelay)
    {
        currentFrame++;
        frameCounter = 0; // Reset frameCounter after incrementing the frame
    }

    // Loop the animation back to the start after reaching the end
    if (currentFrame >= maxFrame)
    {
        currentFrame = 0;
    }
    }
    }

    public class LinkUseItemRight : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        private int frameDelay = 4;
        private int frameCounter = 0;
        int currentFrame = 0;
        int maxFrame = 10;

        public LinkUseItemRight(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition, int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 5)
            {
                sourceRectangle = new Rectangle(124, 11, 16, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }

            else if (currentFrame >= maxFrame / 5 && currentFrame < maxFrame / 2)
            {
                sourceRectangle = new Rectangle(35, 11, 16, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }

            else 
            {
                sourceRectangle = new Rectangle(124, 11, 16, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            frameCounter++;

    // Only increment the frame when frameCounter reaches the delay
    if (frameCounter >= frameDelay)
    {
        currentFrame++;
        frameCounter = 0; // Reset frameCounter after incrementing the frame
    }

    // Loop the animation back to the start after reaching the end
    if (currentFrame >= maxFrame)
    {
        currentFrame = 0;
    }
            
        }
    }

    public class LinkUseItemLeft : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        private int frameDelay = 4;
        private int frameCounter = 0;
        int currentFrame = 0;
        int maxFrame = 10;
        public LinkUseItemLeft(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition, int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 4)
            {
                sourceRectangle = new Rectangle(124, 11, 16, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }

            else if (currentFrame >= maxFrame / 5 && currentFrame < maxFrame / 2)
            {
                sourceRectangle = new Rectangle(35, 11, 16, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }

            else 
            {
                sourceRectangle = new Rectangle(124, 11, 16, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
            spriteBatch.End();
        }

        public void Update()
        {
            frameCounter++;

    // Only increment the frame when frameCounter reaches the delay
    if (frameCounter >= frameDelay)
    {
        currentFrame++;
        frameCounter = 0; // Reset frameCounter after incrementing the frame
    }

    // Loop the animation back to the start after reaching the end
    if (currentFrame >= maxFrame)
    {
        currentFrame = 0;
    }
        }
    }

    public class LinkUseItemNorth : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;
        private int frameDelay = 4;
        private int frameCounter = 0;
        int currentFrame = 0;
        int maxFrame = 10;

        //LinkFacing towards top of the screen
        public LinkUseItemNorth(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition, int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            Rectangle destinationRectangle = new Rectangle();
            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < maxFrame / 5)
            {
                sourceRectangle = new Rectangle(141, 11, 16, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }

            else if (currentFrame >= maxFrame / 5 && currentFrame < maxFrame / 2)
            {
                sourceRectangle = new Rectangle(69, 11, 16, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }

            else 
            {
                sourceRectangle = new Rectangle(141, 11, 16, 16);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);
            }

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public void Update()
        {
            frameCounter++;

    // Only increment the frame when frameCounter reaches the delay
    if (frameCounter >= frameDelay)
    {
        currentFrame++;
        frameCounter = 0; // Reset frameCounter after incrementing the frame
    }

    // Loop the animation back to the start after reaching the end
    if (currentFrame >= maxFrame)
    {
        currentFrame = 0;
    }
        }
    }
}