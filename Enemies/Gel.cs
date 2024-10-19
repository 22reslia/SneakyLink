using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class Gel : IEnemy
    {
        private GelStateMachine stateMachine;
        public CollisionBox collisionBox;
        private ISprite GelSprite;
        private int x;
        private int y;
        public bool isBlockedTop;
        public bool isBlockedBottom;
        public bool isBlockedLeft;
        public bool isBlockedRight;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Gel() {
            x = 400;
            y = 240;
            stateMachine = new GelStateMachine();
            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 40, 40, x, y);
            GelSprite = EnemySpriteFactory.Instance.CreateGelSprite();
            isBlockedTop = false;
            isBlockedBottom = false;
            isBlockedLeft = false;
            isBlockedRight = false;
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch, GelSprite, x, y);
        }

        public void Update()
        {
            GelSprite.Update();
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
