using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Items;
using SneakyLink.Player;

namespace SneakyLink.Projectiles
{
    public class LinkArrow
    {
        private int x;
        private int y;
        private ISprite arrowSprite;
        private int velocityX;
        private int velocityY;
        public CollisionBox collisionBox;
        

        public LinkArrow(int x, int y)
        {
            this.x = x;
            this.y = y;
            arrowSprite = new ArrowSprite();
            collisionBox = new CollisionBox(CollisionObjectType.Interactive, 40, 40, x, y);
            velocityX = 0;
            velocityY = 0;
        }

        // Shoot method to control arrow movement speed
        public void Shoot(PlayerDirection direction)
        {
            switch (direction)
        {   
            //changes the direction of the arrow based off direction of player
            case PlayerDirection.playerLeft:
                velocityX = 3;
                break;
            case PlayerDirection.playerRight:
                velocityX = -3;
                break;
            case PlayerDirection.playerUp:
                velocityY = 3;
                break;
            case PlayerDirection.playerDown:
                velocityY = -3;
                break;
        }
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