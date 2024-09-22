using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class Stalfos : IEnemy
    {
        private StalfosStateMachine stateMachine;
        public ISprite stalfosSprite;
        public int x;
        public int y;

        public Stalfos()
        {
            x = 400;
            y = 240;
            stateMachine = new StalfosStateMachine();
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
        }
    }
}

