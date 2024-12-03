using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Boss;
using SneakyLink.Collision;
using SneakyLink.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class Providence
    {
        private BossStateMachine stateMachine;
        public CollisionBox collisionBox;
        private ISprite bossSprite;
        private int x;
        private int y;
        private int maxHealth;
        private int currentHealth;
        public bool isBlockedTop;
        public bool isBlockedBottom;
        public bool isBlockedLeft;
        public bool isBlockedRight;
        public List<BossProjectile> projectile;
        public List<BossProjectile> projectileRemove;
        public Link link; 

        //invincible related variable
        public bool isV;
        private int vCounter;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int mHealth { get => maxHealth; set => maxHealth = value; }
        public int cHealth { get => currentHealth; set => currentHealth = value; }
        public ISprite BossSprite { get => bossSprite; set => bossSprite = value; }
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public Providence(int x, int y, Link player)
        {
            this.x = x;
            this.y = y;
            link = player;
            maxHealth = 50;
            currentHealth = maxHealth;
            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 210, 150, x, y);
            bossSprite = EnemySpriteFactory.Instance.ProvidenceIdleSprite();
            projectile = new List<BossProjectile>();
            projectileRemove = new List<BossProjectile>();
            stateMachine = new BossStateMachine();

            isV = false;
            vCounter = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BossProjectile fireBall in projectile)
            {
                fireBall.Draw(spriteBatch);
            }
            stateMachine.Draw(spriteBatch, bossSprite, x, y);
        }
        public void Update()
        {
            foreach (BossProjectile fireBall in projectile)
            {
                fireBall.Update();
                if (!fireBall.isActive)
                {
                    projectileRemove.Add(fireBall);
                }
            }

            //update if boss is invincible
            if (isV)
            {
                vCounter++;
                if (vCounter == 30)
                {
                    isV = false;
                    vCounter = 0;
                }
            }

            foreach (BossProjectile fireBall in projectileRemove)
            {
                projectile.Remove(fireBall);
            }
            bossSprite.Update();
            stateMachine.Update(this);
            collisionBox.x = x; collisionBox.y = y;
        }
    }
}
