using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Projectiles
{
    public class LinkArrow
    {
        private int x;
        private int y;
        private ISprite arrowSprite;
        private int velocityX;
        private int velocityY;

        public LinkArrow(int x, int y)
        {
            this.x = x;
            this.y = y;
            arrowSprite = new ArrowSprite();  // Using your ArrowSprite
            velocityX = 0;
            velocityY = 0;
        }

        // Shoot method to control arrow movement speed
        public void Shoot(int velocityX, int velocityY)
        {
            this.velocityX = velocityX;
            this.velocityY = velocityY;
        }

        // Update the position of the arrow
        public void Update()
        {
            x += velocityX;
            y += velocityY;
            arrowSprite.Update();
        }

        // Draw the arrow on the screen
        public void Draw(SpriteBatch spriteBatch)
        {
            arrowSprite.Draw(spriteBatch, x, y);
        }
    }
}