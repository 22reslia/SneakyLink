using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SneakyLink
{
    public class GoriyaBoomerang
    {
        public int x, y;
        private int startX, startY;
        private int velocityX;
        private int flightTime = 0;
        private int maxFlightTime = 80;
        private bool isReturning = false;
        private ISprite boomerangSprite;

        public GoriyaBoomerang(int startX, int startY)
        {
            this.startX = startX;
            this.startY = startY;
            this.x = startX;
            this.y = startY;
            boomerangSprite = EnemySpriteFactory.Instance.CreateGoriyaBoomerangSprite();
        }

        public void Shoot(int velocityX)
        {
            this.velocityX = velocityX;
        }

        public bool HasReturned()
        {
            return !isReturning && flightTime >= maxFlightTime;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boomerangSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {
            if (!isReturning)
            {
                x += velocityX;
                flightTime++;

                if (flightTime >= maxFlightTime)
                {
                    isReturning = true;
                }
            }
            else
            {
                int returnSpeedX = -velocityX;
                x += returnSpeedX;

                if (Math.Abs(x - startX) < 5)
                {
                    x = startX;
                    isReturning = false;
                }
            }
            boomerangSprite.Update();
        }
    }
}
