using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Items;
using SneakyLink.Player;

namespace SneakyLink.Projectiles
{
    public class LinkArrow : IProjectile
    {
        private Vector2 position;      // Position as Vector2
        private Vector2 velocity;      // Velocity as Vector2
        private ISprite arrowSprite;   // Sprite for the arrow
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

        // Implementing HasCollided property
        public bool HasCollided { get; private set; }

        public LinkArrow(int x, int y)
        {
            position = new Vector2(x, y); // Set initial position
            arrowSprite = new ArrowSprite();
            collisionBox = new CollisionBox(CollisionObjectType.Projectile, 40, 40, x, y);
            velocity = Vector2.Zero;      // Initialize velocity to zero
            HasCollided = false;          // Initialize collision state
        }

        // Updated Shoot method to accept float parameters for velocity
        public void Shoot(float velocityX, float velocityY)
        {
            velocity = new Vector2(velocityX, velocityY); // Set velocity as Vector2
        }

        // Update method to move the arrow and check boundaries
        public void Update()
        {
            position += velocity; // Move the arrow
            arrowSprite.Update();
            //collisionBox.UpdatePosition((int)position.X, (int)position.Y); // Update collision box position

            // if (IsOutOfBounds()) // Check if it goes out of bounds
            // {
            //     HasCollided = true;
            // }
        }

        // Draw method to render the arrow sprite at the current position
        public void Draw(SpriteBatch spriteBatch)
        {
            arrowSprite.Draw(spriteBatch, (int)position.X, (int)position.Y);
        }

        // Implementing IsOutOfBounds method
        public bool IsOutOfBounds()
        {
            // Example boundary conditions; adjust to match actual game boundaries
            return position.X < 0 || position.X > 800 || position.Y < 0 || position.Y > 600;
        }
    }
}