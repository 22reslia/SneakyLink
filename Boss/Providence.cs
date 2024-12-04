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
        private Texture2D healthBarBackground;
        private Texture2D healthBarFill;
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

        public Providence(int x, int y, Game1 game)
        {
            this.x = x;
            this.y = y;
            link = game.link;
            maxHealth = 50;
            currentHealth = maxHealth;
            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 210, 150, x, y);
            bossSprite = EnemySpriteFactory.Instance.ProvidenceIdleSprite();
            projectile = new List<BossProjectile>();
            projectileRemove = new List<BossProjectile>();
            stateMachine = new BossStateMachine();

            isV = false;
            vCounter = 0;

            //create health bar
            healthBarBackground = new Texture2D(game.GraphicsDevice, 1, 1);
            healthBarBackground.SetData([Color.Gray]);
            healthBarFill = new Texture2D(game.GraphicsDevice, 1, 1);
            healthBarFill.SetData([Color.Red]);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BossProjectile fireBall in projectile)
            {
                fireBall.Draw(spriteBatch);
            }
            stateMachine.Draw(spriteBatch, bossSprite, x, y);

            //draw the health bar
            int width = 800;
            int height = 20;

            spriteBatch.Begin();
            spriteBatch.Draw(healthBarBackground, new Rectangle(0, 0, width, height), Color.Gray);
            float healthPercentage = (float)currentHealth / (float)maxHealth;
            spriteBatch.Draw(healthBarFill, new Rectangle(0, 0, (int)(healthPercentage * width), height), Color.Red);
            spriteBatch.End();
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
