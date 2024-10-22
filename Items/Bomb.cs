using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Items;

namespace SneakyLink.Projectiles
{
    public class LinkBomb
    {
        private int x;
        private int y;
        private ISprite bombSprite;
        private int velocityX;
        private int velocityY;

        public LinkBomb(int x, int y)
        {
            this.x = x;
            this.y = y;
            bombSprite = new BombSprite();
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
            bombSprite.Update();
        }

        // Draw the arrow on the screen
        public void Draw(SpriteBatch spriteBatch)
        {
            bombSprite.Draw(spriteBatch, x, y);
        }
    }
}