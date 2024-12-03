using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Items;

namespace SneakyLink.Projectiles
{
    public class LinkBomb : IProjectile
    {
        private Vector2 position;
        private ISprite bombSprite;
        private ExplosionSprite explosionSprite;

        private bool isExploding = false; // State flag for explosion
        public bool HasCollided { get; private set; } // Indicates if the bomb is done

        private int frameCounter = 0;
        private const int detonationFrames = 180; // Number of frames before explosion (e.g., 3 seconds at 60 FPS)

        public CollisionBox CollisionBox { get; private set; }

        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                UpdateCollisionBox();
            }
        }

        public LinkBomb(int x, int y)
        {
            position = new Vector2(x, y);
            bombSprite = new BombSprite();
            explosionSprite = new ExplosionSprite();
            HasCollided = false;

            // Initialize collision box with bomb's size
            CollisionBox = new CollisionBox(CollisionObjectType.Projectile, 16, 16, (int)position.X, (int)position.Y);
        }

        public void Shoot(float x, float y) {

        }

        public void Update()
        {
            if (!isExploding)
            {
                // Increment frame counter for detonation
                frameCounter++;

                if (frameCounter >= detonationFrames)
                {
                    isExploding = true; // Trigger the explosion
                    frameCounter = 0;  // Reset for explosion animation duration
                }

                bombSprite.Update(); // Update the bomb sprite
            }
            else
            {
                // Update the explosion animation
                explosionSprite.Update();

                // Check if the explosion animation is complete
                if (explosionSprite.isExploded())
                {
                    HasCollided = true; // Mark the bomb as inactive
                }
            }

            UpdateCollisionBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isExploding)
            {
                // Draw the bomb sprite
                bombSprite.Draw(spriteBatch, (int)position.X, (int)position.Y);
            }
            else
            {
                //Debug.WriteLine($"Explosion position: {position.X}, {position.Y}");
                // Draw the explosion sprite
                explosionSprite.Draw(spriteBatch, (int)position.X - 16, (int)position.Y - 16); // Adjust for centering
            }
        }

        private void UpdateCollisionBox()
        {
            // Update the collision box's position to match the bomb
            CollisionBox.x = (int)position.X;
            CollisionBox.y = (int)position.Y;

            if (isExploding)
            {
                // Expand collision box for the explosion if necessary
                CollisionBox.width = 16;
                CollisionBox.height = 16;
            }
        }
    }
}
