using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class Zol : IEnemy, ICollision
    {
        private ZolStateMachine stateMachine;
        private ISprite ZolSprite;
        private int x;
        private int y;
        public int width = 40, height = 40;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Rectangle CollisionBox => new Rectangle(x, y, width, height);

        public CollisionObjectType ObjectType => CollisionObjectType.Enemy;

        public Zol()
        {
            x = 400;
            y = 240;
            stateMachine = new ZolStateMachine();
            ZolSprite = EnemySpriteFactory.Instance.CreateZolSprite();
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
        }

        public void OnCollision(ICollision other, CollisionType collisionType)
        {
            throw new NotImplementedException();
        }
    }
}
