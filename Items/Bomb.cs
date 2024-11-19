using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Items;

namespace SneakyLink.Projectiles
{
    public class LinkBomb : IProjectile
    {
        private Vector2 position;
        private Vector2 velocity;
        private ISprite bombSprite;

        // Use the existing CollisionBox
        public CollisionBox CollisionBox { get; private set; }

        public bool HasCollided { get; private set; }

        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                // Update the collision box whenever position changes
                UpdateCollisionBox();
            }
        }

        public LinkBomb(int x, int y)
        {
            position = new Vector2(x, y);
            bombSprite = new BombSprite();
            velocity = Vector2.Zero;
            HasCollided = false;

            // Initialize the collision box with dimensions and type
            CollisionBox = new CollisionBox(CollisionObjectType.Projectile, 16, 16, (int)position.X, (int)position.Y);
        }

        public void Shoot(float velocityX, float velocityY)
        {
            velocity = new Vector2(velocityX, velocityY);
            velocity = Vector2.Zero;
        }

        public void Update()
        {
            //position += velocity; // Update position
            bombSprite.Update();

            // Update the collision box to follow the bomb's position
            UpdateCollisionBox();

            // Check if the bomb is out of bounds
            // if (IsOutOfBounds())
            // {
            //     HasCollided = true;
            // }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bombSprite.Draw(spriteBatch, (int)position.X, (int)position.Y);
        }

        private void UpdateCollisionBox()
        {
            CollisionBox.x = (int)position.X;
            CollisionBox.y = (int)position.Y;
        }

        // public bool IsOutOfBounds()
        // {
        //     // Example boundary conditions; replace with actual game boundaries
        //     return position.X < 0 || position.X > 800 || position.Y < 0 || position.Y > 600;
        // }
    }
}
