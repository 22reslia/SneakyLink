using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class Goriya : IEnemy
    {
        private GoriyaStateMachine stateMachine;
        public ISprite GoriyaSprite;
        public int x;
        public int y;

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
    }
}
