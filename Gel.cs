using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class Gel : IEnemy
    {
        private GelStateMachine stateMachine;
        public ISprite GelSprite;
        public int x;
        public int y;

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
    }
}
