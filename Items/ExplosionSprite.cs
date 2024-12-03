using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Player;

namespace SneakyLink.Items
{
    public class ExplosionSprite : ISprite
    {
        private Texture2D image;
        private int currentFrame;
        private const int totalFrames = 4; // Number of explosion frames
        private int frameCounter = 0;
        private const int framesPerUpdate = 10; // Adjust this value to slow down animation
        private bool isExplode = false;

        private readonly Rectangle[] sourceRectangles = new Rectangle[4]; // Source rectangles for the animation

        public ExplosionSprite()
        {
            image = PlayerSpriteFactory.Instance.GetLinkSpriteSheet(); // Use the correct sprite sheet
            currentFrame = 0;

            // Define source rectangles for the 4 frames of the explosion
            sourceRectangles[0] = new Rectangle(129, 185, 8, 16); // Frame 1
            sourceRectangles[1] = new Rectangle(138, 185, 16, 16); // Frame 2
            sourceRectangles[2] = new Rectangle(155, 185, 16, 16); // Frame 3
            sourceRectangles[3] = new Rectangle(172, 185, 16, 16); // Frame 4
        }

        public void Update()
        {
            if (isExplode)
                return;
            frameCounter++;

            // Increment the frame only after the delay has been reached
            if (frameCounter >= framesPerUpdate)
            {
                currentFrame++;
                frameCounter = 0; // Reset frame counter

                // Stop the animation once all frames have been displayed
                if (currentFrame >= totalFrames)
                {
                    isExplode = true; // Mark as exploded
                    currentFrame = totalFrames - 1; // Keep it on the last frame
                    
                }

            }
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            if (isExplode)
                return;
            // Use the current frame's source rectangle
            Rectangle sourceRectangle = sourceRectangles[currentFrame];

            // Define the destination rectangle for scaling
            Rectangle destinationRectangle = new Rectangle(x, y, 32, 32); // Center and scale the explosion

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public bool isExploded()
        {
            return isExplode;
        }
    }
}