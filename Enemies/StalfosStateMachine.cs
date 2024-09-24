using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class StalfosStateMachine
    {
        private enum StalfosState { LeftNormal, RightNormal, UpNormal, DownNormal, Idle};
        private StalfosState currentState = StalfosState.Idle;
        private Random randomMove;
        private int moveCount = 0;

        public void ChangeDirection()
        {
            randomMove = new Random();
            int nextDirection = randomMove.Next(0, 5);
            switch (nextDirection)
            {
                case 0:
                    currentState = StalfosState.LeftNormal;
                    break;
                case 1:
                    currentState = StalfosState.RightNormal;
                    break;
                case 2:
                    currentState = StalfosState.UpNormal;
                    break;
                case 3:
                    currentState = StalfosState.DownNormal;
                    break;
                case 4:
                    currentState = StalfosState.Idle;
                    break;
            }
        }

        public void Move(Stalfos stalfos)
        {
            if (moveCount == 40)
            {
                moveCount = 0;
                this.ChangeDirection();
            }

            switch (currentState)
            {
                case StalfosState.LeftNormal:
                    stalfos.x -= 1;
                    moveCount++;
                    break;
                case StalfosState.RightNormal:
                    stalfos.x += 1;
                    moveCount++;
                    break;
                case StalfosState.DownNormal:
                    stalfos.y += 1;
                    moveCount++;
                    break;
                case StalfosState.UpNormal:
                    stalfos.y -= 1;
                    moveCount++;
                    break;
                case StalfosState.Idle:
                    moveCount++;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, ISprite stalfosSprite, int x, int y)
        {
            stalfosSprite.Draw(spriteBatch, x, y);
        }
        public void Update(Stalfos stalfos)
        {
            Move(stalfos);
        }

    }
}
