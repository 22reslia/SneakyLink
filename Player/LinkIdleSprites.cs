using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SneakyLink.Player
{
    public class LinkForwardIdle : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;

        public LinkForwardIdle(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition, int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            int width = 16;
            int height = 16;

            Rectangle sourceRectangle = new Rectangle(1, 11, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {

        }
    }

    public class LinkRightIdle : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;

        public LinkRightIdle(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition, int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            int width = 16;
            int height = 16;

            Rectangle sourceRectangle = new Rectangle(35, 11, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {

        }
    }

    public class LinkLeftIdle : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;

        public LinkLeftIdle(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition, int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            int width = 16;
            int height = 16;

            Rectangle sourceRectangle = new Rectangle(35, 11, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);


            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
            spriteBatch.End();
        }

        public void Update()
        {

        }
    }

    public class LinkBackIdle : ISprite
    {
        public Texture2D linkSprite;
        private Vector2 position;

        public LinkBackIdle(Texture2D texture)
        {
            linkSprite = texture;
        }
        public void Draw(SpriteBatch spriteBatch, int xPosition, int yPosition)
        {
            position.X = xPosition;
            position.Y = yPosition;

            int width = 16;
            int height = 16;

            Rectangle sourceRectangle = new Rectangle(69, 11, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 38);


            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {

        }
    }
}