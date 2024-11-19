using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class EnemyDeath : IItem
    {
        private ISprite deathSprite;
        private int x, y;
        private CollisionBox collisionBox;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }

        public EnemyDeath(int x, int y)
        {
            this.x = x;
            this.y = y;
            deathSprite = EnemySpriteFactory.Instance.CreateEnemyDeathSprite();
            collisionBox = new CollisionBox(CollisionObjectType.roomItem, 0, 0, x, y);
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
