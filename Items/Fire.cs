using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Items;
using SneakyLink.Player;

namespace SneakyLink.Projectiles
{
    public class LinkFire : IProjectile
    {
        private Vector2 position;      // Position as Vector2
        private Vector2 velocity;      // Velocity as Vector2
        private ISprite fireSprite;    // Sprite for the fire projectile
        public CollisionBox collisionBox;

        // Implementing Position property
        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                //collisionBox.UpdatePosition((int)position.X, (int)position.Y); // Update collision box position
            }
        }

        // Implementing HasCollided property as required by IProjectile
        public bool HasCollided { get; private set; }

        public LinkFire(int x, int y)
        {
            position = new Vector2(x, y); // Initialize position
            fireSprite = new FireSprite();
            collisionBox = new CollisionBox(CollisionObjectType.Interactive, 40, 40, x, y);
            velocity = Vector2.Zero; // Initialize velocity
            HasCollided = false;
        }

        // Updated Shoot method to take float parameters for velocity
        public void Shoot(float velocityX, float velocityY)
        {
            velocity = new Vector2(velocityX, velocityY); // Set velocity as Vector2
        }

        // Update method to move the fire projectile and check for boundaries
        public void Update()
        {
            position += velocity; // Move the projectile
            fireSprite.Update();
            //collisionBox.UpdatePosition((int)position.X, (int)position.Y); // Update collision box position

            if (IsOutOfBounds()) // Check if it goes out of bounds
            {
                HasCollided = true;
            }
        }

        // Draw method to render the fire sprite at the current position
        public void Draw(SpriteBatch spriteBatch)
        {
            fireSprite.Draw(spriteBatch, (int)position.X, (int)position.Y);
        }

        // Implementing IsOutOfBounds to check if projectile is outside game boundaries
        public bool IsOutOfBounds()
        {
            // Example boundary conditions; adjust to actual game boundaries
            return position.X < 0 || position.X > 800 || position.Y < 0 || position.Y > 600;
        }
    }
}