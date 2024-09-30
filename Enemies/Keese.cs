using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class Keese : IEnemy
    {
        private KeeseStateMachine stateMachine;
        private ISprite keeseSprite;
        private int x;
        private int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Keese()
        {
            x = 400;
            y = 240;
            stateMachine = new KeeseStateMachine();
            keeseSprite = EnemySpriteFactory.Instance.CreateKeeseEnemySprite();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch, keeseSprite, x, y);
        }
        public void Update()
        {
            keeseSprite.Update();
            stateMachine.Update(this);
        }
    }
}
