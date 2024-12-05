using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Enemies;
using SneakyLink.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Boss
{
    public class TrackProjectile : BossProjectile
    {
        private float x;
        private float y;
        private Link link;
        private float velocityX;
        private float velocityY;
        private float speed;
        private float trackTime;
        private ISprite projectileSprite;
        public CollisionBox collisionBox;
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public bool isActive { get; set; }

        public TrackProjectile(float x, float y, Link link, float speed)
        {
            this.x = x;
            this.y = y;
            this.speed = speed;
            this.link = link;

            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 32, 32, (int)x, (int)y);
            projectileSprite = EnemySpriteFactory.Instance.ProvidenceProjectileSprite();
            velocityX = 0;
            velocityY = 0;

            trackTime = 0f;
            isActive = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                projectileSprite.Draw(spriteBatch, (int)X, (int)Y);
            }
        }

        public void Update(GameTime gameTime)
        {
            projectileSprite.Update();
            
            Vector2 playerPosition = new Vector2(link.playerPosition.X, link.playerPosition.Y);
            Vector2 currentPosition = new Vector2(X, Y);

            Vector2 direction = playerPosition - currentPosition;
            direction.Normalize();

            velocityX = direction.X * speed;
            velocityY = direction.Y * speed;

            X += velocityX;
            Y += velocityY;

            trackTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (trackTime >= 3.0f)
            {
                isActive = false;
            }

            collisionBox.x = (int)x; collisionBox.y = (int)y;
        }
    }
}
