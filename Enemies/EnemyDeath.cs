using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class EnemyDeath : IEnemy
    {
        private ISprite deathSprite;
        private int x;
        private int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int mHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int cHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool isBlockedL { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool isBlockedR { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool isBlockedT { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool isBlockedB { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CollisionBox CollisionBox { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public EnemyDeath(int x, int y)
        {
            this.x = x;
            this.y = y;
            deathSprite = EnemySpriteFactory.Instance.CreateEnemyDeathSprite();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            deathSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {
            deathSprite.Update();
        }
    }
}
