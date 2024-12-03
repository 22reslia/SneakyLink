using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Enemies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Boss
{
    public class StraightLineProjectile : BossProjectile
    {
        private float x;
        private float y;
        private float velocityX;
        private float velocityY;
        private float speed = 3f;
        private ISprite projectileSprite;
        public CollisionBox collisionBox;
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public bool isActive { get; set; }

        public StraightLineProjectile(float x, float y, float targetX, float targetY)
        {
            this.x = x;
            this.y = y;

            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 32, 32, (int)x, (int)y);
            projectileSprite = EnemySpriteFactory.Instance.ProvidenceProjectileSprite();
            Vector2 direction = new Vector2(targetX - x, targetY - y);
            direction.Normalize();
            velocityX = direction.X * speed;
            velocityY = direction.Y * speed;
            isActive = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                projectileSprite.Draw(spriteBatch, (int)X, (int)Y);
            }
        }

        public void Update()
        {
            projectileSprite.Update();
            X += velocityX; 
            Y += velocityY;

            if (X < 0 || X > 800 || Y < 0 || Y >  640)
            {
                isActive = false;
            }

            collisionBox.x = (int)x; collisionBox.y = (int)y;
        }
    }
}
