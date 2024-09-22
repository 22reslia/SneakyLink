using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class Zol : IEnemy
    {
        private ZolStateMachine stateMachine;
        public ISprite ZolSprite;
        public int x;
        public int y;

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
    }
}
