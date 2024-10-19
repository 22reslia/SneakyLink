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
    public class Zol : IEnemy
    {
        private ZolStateMachine stateMachine;
        public CollisionBox collisionBox;
        private ISprite ZolSprite;
        private int x;
        private int y;
        public bool isBlockedTop;
        public bool isBlockedBottom;
        public bool isBlockedLeft;
        public bool isBlockedRight;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public bool isBlockedL { get => isBlockedLeft; set => isBlockedLeft = value; }
        public bool isBlockedR { get => isBlockedRight; set => isBlockedRight = value; }
        public bool isBlockedT { get => isBlockedTop; set => isBlockedTop = value; }
        public bool isBlockedB { get => isBlockedBottom; set => isBlockedBottom = value; }
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public Zol()
        {
            x = 400;
            y = 240;
            stateMachine = new ZolStateMachine();
            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 40, 40, x, y);
            ZolSprite = EnemySpriteFactory.Instance.CreateZolSprite();
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
            stateMachine.Draw(spriteBatch, ZolSprite, x, y);
        }

        public void Update()
        {
            ZolSprite.Update();
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
