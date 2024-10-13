using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class Aquamentus : IEnemy, ICollision
    {
        private AquamentusStateMachine stateMachine;
        private ISprite aquamentusSprite;
        private int x;
        private int y;
        public int width = 40, height = 40;

        public int X{ get => x; set => x = value; }
        public int Y{ get => y; set => y = value; }
        public ISprite AquamentusSprite{ get => aquamentusSprite; set => aquamentusSprite = value; }

        public Rectangle CollisionBox => new Rectangle(x, y, width, height);

        public CollisionObjectType ObjectType => throw new NotImplementedException();

        public Aquamentus()
        {
            x = 400;
            y = 240;
            stateMachine = new AquamentusStateMachine();
            aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusLeftIdleEnemySprite();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch, aquamentusSprite, x, y);
        }
        public void Update()
        {
            aquamentusSprite.Update();
            stateMachine.Update(this);
        }

        public void OnCollision(ICollision other, CollisionType collisionType)
        {
            throw new NotImplementedException();
        }
    }
}
