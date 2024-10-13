using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class Goriya : IEnemy, ICollision
    {
        private GoriyaStateMachine stateMachine;
        private ISprite GoriyaSprite;
        private int x;
        private int y;
        public int width = 40, height = 40;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public ISprite goriyaSprite { get => GoriyaSprite; set => GoriyaSprite = value; }

        public Rectangle CollisionBox => new Rectangle(x, y, width, height);

        public CollisionObjectType ObjectType => CollisionObjectType.Enemy;

        public Goriya()
        {
            x = 400;
            y = 240;
            stateMachine = new GoriyaStateMachine();
            GoriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaRightIdleSprite();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch, GoriyaSprite, x, y);
        }

        public void Update()
        {
            GoriyaSprite.Update();
            stateMachine.Update(this);
        }

        public void OnCollision(ICollision other, CollisionType collisionType)
        {
            throw new NotImplementedException();
        }
    }
}
