using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class Aquamentus : IEnemy
    {
        private AquamentusStateMachine stateMachine;
        public ISprite aquamentusSprite;
        public int x;
        public int y;

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
    }
}
