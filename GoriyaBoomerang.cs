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
        private enum BoomerangState { Show, Disappear }
        private BoomerangState currentState = BoomerangState.Show;

        public int x, y;
        private int startX, startY;
        private int velocityX;
        private int flightTime = 0;
        private int maxFlightTime = 80;
        private bool isReturning = false;
        private ISprite boomerangSprite;

        public GoriyaBoomerang (int startX, int startY)
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
            flightTime = 0;
            isReturning = false;
            currentState = BoomerangState.Show;
        }

        public bool HasReturned()
        {
            return currentState == BoomerangState.Disappear;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentState == BoomerangState.Show)
            {
                boomerangSprite.Draw(spriteBatch, x, y);
            }
        }

        public void Update()
        {
            if (currentState == BoomerangState.Show)
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
                        y = startY;
                        isReturning = false;
                        currentState = BoomerangState.Disappear;
                    }
                }
                boomerangSprite.Update();
            }
        }
    }
}
