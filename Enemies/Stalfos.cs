using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class Stalfos : IEnemy
    {
        private StalfosStateMachine stateMachine;
        public CollisionBox collisionBox;
        private ISprite stalfosSprite;
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
        public bool isBlockedL { get => isBlockedLeft; set => isBlockedLeft = value; }
        public bool isBlockedR { get => isBlockedRight; set => isBlockedRight = value; }
        public bool isBlockedT { get => isBlockedTop; set => isBlockedTop = value; }
        public bool isBlockedB { get => isBlockedBottom; set => isBlockedBottom = value; }
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public Stalfos(int x, int y)
        {
            this.x = x;
            this.y = y;
            maxHealth = 3;
            currentHealth = maxHealth;
            stateMachine = new StalfosStateMachine();
            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 40, 40, x, y);
            stalfosSprite = EnemySpriteFactory.Instance.CreateStalfosEnemySprite();
            isBlockedTop = false;
            isBlockedBottom = false;
            isBlockedLeft = false;
            isBlockedRight = false;
        }
        public void Move()
        {
            stateMachine.Move(this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch, stalfosSprite, x, y);
        }
        public void Update()
        {
            stalfosSprite.Update();
            stateMachine.Update(this);
            if (this.collisionBox.side == CollisionType.None)
            {
                isBlockedTop = false;
                isBlockedBottom = false;
                isBlockedLeft = false;
                isBlockedRight = false;
            }

            collisionBox.x = x; collisionBox.y = y;
        }
    }
}

