using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class AquamentusFireBall
    {
        private int x;
        private int y;
        private ISprite fireBallSprite;
        private int velocityX;
        private int velocityY;

        public AquamentusFireBall(int x, int y)
        {
            this.x = x;
            this.y = y;
            fireBallSprite = EnemySpriteFactory.Instance.CreateAquamentusFireBall();
            velocityX = 0;
            velocityY = 0;
        }
        public void Shoot(int velocityX, int velocityY)
        {
            this.velocityX = velocityX;
            this.velocityY = velocityY;
        }
        public void Update()
        {
            x += velocityX;
            y += velocityY;
            fireBallSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            fireBallSprite.Draw(spriteBatch, x, y);
        }
    }
}

