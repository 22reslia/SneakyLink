using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class Gel : IEnemy, ICollision
    {
        private GelStateMachine stateMachine;
        private ISprite GelSprite;
        private int x;
        private int y;
        public int width = 40, height = 40;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Rectangle CollisionBox => new Rectangle(x, y, width, height);

        public CollisionObjectType ObjectType => throw new NotImplementedException();

        public Gel() {
            x = 400;
            y = 240;
            stateMachine = new GelStateMachine();
            GelSprite = EnemySpriteFactory.Instance.CreateGelSprite();
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
        }

        public void OnCollision(ICollision other, CollisionType collisionType)
        {
            throw new NotImplementedException();
        }
    }
}
