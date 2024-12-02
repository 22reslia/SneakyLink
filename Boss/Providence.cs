using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using System;
using System.Collections.Generic;
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

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int mHealth { get => maxHealth; set => maxHealth = value; }
        public int cHealth { get => currentHealth; set => currentHealth = value; }
        public ISprite BossSprite { get => bossSprite; set => bossSprite = value; }
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public Providence(int x, int y)
        {
            this.x = x;
            this.y = y;
            maxHealth = 50;
            currentHealth = maxHealth;
            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 210, 150, x, y);
            bossSprite = EnemySpriteFactory.Instance.ProvidenceIdleSprite();
            stateMachine = new BossStateMachine();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch, bossSprite, x, y);
        }
        public void Update()
        {
            bossSprite.Update();
            stateMachine.Update(this);
            collisionBox.x = x; collisionBox.y = y;
        }
    }
}
