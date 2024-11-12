using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Items;

namespace SneakyLink.Projectiles
{
    public class LinkBomb : IProjectile
    {
        private Vector2 position;  // Using Vector2 for position
        private Vector2 velocity;  // Using Vector2 for velocity
        private ISprite bombSprite;

        // Implementing the Position property
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }

        // Implementing HasCollided as a boolean to indicate collision state
        public bool HasCollided { get; private set; }

        public LinkBomb(int x, int y)
        {
            position = new Vector2(x, y); // Initialize position
            bombSprite = new BombSprite();
            velocity = Vector2.Zero; // Initialize velocity to zero
            HasCollided = false;     // Initialize collision state
        }

        // Implementing Shoot method to set velocity
        public void Shoot(float velocityX, float velocityY)
        {
            velocity = new Vector2(velocityX, velocityY); // Set velocity using Vector2
        }

        // Update the position of the bomb and check for boundaries
        public void Update()
        {
            position += velocity; // Move the bomb
            bombSprite.Update();

            if (IsOutOfBounds()) // Check if it goes out of bounds
            {
                HasCollided = true;
            }
        }

        // Draw method to render the bomb sprite at the current position
        public void Draw(SpriteBatch spriteBatch)
        {
            bombSprite.Draw(spriteBatch, (int)position.X, (int)position.Y);
        }

        // Implementing IsOutOfBounds to check if bomb is outside game boundaries
        public bool IsOutOfBounds()
        {
            // Example boundary conditions; replace with actual game boundaries
            return position.X < 0 || position.X > 800 || position.Y < 0 || position.Y > 600;
        }
    }
}