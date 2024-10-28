using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Items;
using SneakyLink.Player;

namespace SneakyLink.Projectiles
{
    public class LinkFire
    {
        private int x;
        private int y;
        private ISprite fireSprite;
        private int velocityX;
        private int velocityY;
        public CollisionBox collisionBox;
        

        public LinkFire(int x, int y)
        {
            this.x = x;
            this.y = y;
            fireSprite = new FireSprite();
            collisionBox = new CollisionBox(CollisionObjectType.Interactive, 40, 40, x, y);
            velocityX = 0;
            velocityY = 0;
        }

        // Shoot method to control fire movement speed
        public void Shoot(PlayerDirection direction)
        {
            switch (direction)
        {   
            //changes the direction of the fire based off direction of player
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
            fireSprite.Update();
        }

        // Draw the arrow on the screen
        public void Draw(SpriteBatch spriteBatch)
        {
            fireSprite.Draw(spriteBatch, x, y);
        }
    }
}