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
    public class Aquamentus : IEnemy
    {
        private AquamentusStateMachine stateMachine;
        public CollisionBox collisionBox;
        private ISprite aquamentusSprite;
        private int x;
        private int y;

        public int X{ get => x; set => x = value; }
        public int Y{ get => y; set => y = value; }
        public ISprite AquamentusSprite{ get => aquamentusSprite; set => aquamentusSprite = value; }

        public Aquamentus()
        {
            x = 400;
            y = 240;
            stateMachine = new AquamentusStateMachine();
            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 40, 40, x, y);
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

            collisionBox.x = x; collisionBox.y = y;
        }
    }
}
