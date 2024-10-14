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

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Stalfos()
        {
            x = 400;
            y = 240;
            stateMachine = new StalfosStateMachine();
            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 40, 40, x, y);
            stalfosSprite = EnemySpriteFactory.Instance.CreateStalfosEnemySprite();
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

            collisionBox.x = x; collisionBox.y = y;
        }
    }
}

