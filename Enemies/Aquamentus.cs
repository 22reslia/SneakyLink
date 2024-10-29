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
    public class Aquamentus : IEnemy
    {
        private AquamentusStateMachine stateMachine;
        public CollisionBox collisionBox;
        private ISprite aquamentusSprite;
        private int x;
        private int y;
        private int maxHealth;
        private int currentHealth;
        public bool isBlockedTop;
        public bool isBlockedBottom;
        public bool isBlockedLeft;
        public bool isBlockedRight;

        public int X{ get => x; set => x = value; }
        public int Y{ get => y; set => y = value; }
        public int mHealth { get => maxHealth; set => maxHealth = value; }
        public int cHealth { get => currentHealth; set => currentHealth = value; }
        public ISprite AquamentusSprite{ get => aquamentusSprite; set => aquamentusSprite = value; }
        public bool isBlockedL { get => isBlockedLeft; set => isBlockedLeft = value; }
        public bool isBlockedR { get => isBlockedRight; set => isBlockedRight = value; }
        public bool isBlockedT { get => isBlockedTop; set => isBlockedTop = value; }
        public bool isBlockedB { get => isBlockedBottom; set => isBlockedBottom = value; }
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public Aquamentus()
        {
            x = 400;
            y = 240;
            maxHealth = 5;
            currentHealth = maxHealth;
            stateMachine = new AquamentusStateMachine();
            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 40, 40, x, y);
            aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusLeftIdleEnemySprite();
            isBlockedTop = false;
            isBlockedBottom = false;
            isBlockedLeft = false;
            isBlockedRight = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch, aquamentusSprite, x, y);
        }
        public void Update()
        {
            aquamentusSprite.Update();
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
