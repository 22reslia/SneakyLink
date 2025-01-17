﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class GelStateMachine
    {
        private enum GelState { LeftNormal, RightNormal, UpNormal, DownNormal, Idle };
        private GelState currentState = GelState.LeftNormal;
        private Random randomMove;
        private int moveCount = 0;
        private int counter = 0;

        public void ChangeDirection()
        {
            randomMove = new Random();
            int nextState = randomMove.Next(0, 4);
            switch (nextState)
            {
                case 0:
                    currentState = GelState.LeftNormal;
                    break;
                case 1:
                    currentState = GelState.RightNormal;
                    break;
                case 2:
                    currentState = GelState.UpNormal;
                    break;
                case 3:
                    currentState = GelState.DownNormal;
                    break;
            }
        }

        public void Draw (SpriteBatch sb, ISprite GelSprite, int x, int y)
        {
            GelSprite.Draw(sb, x, y);
        }

        public void Update (Gel gel)
        {
            if (currentState == GelState.Idle)
            {
                counter++;
                if (counter >= 40)
                {
                    counter = 0;
                    this.ChangeDirection();
                }
            }

            if (moveCount == 80)
            {
                moveCount = 0;
                currentState = GelState.Idle;
            }

            switch (currentState)
            {
                case GelState.LeftNormal:
                    if (!gel.isBlockedLeft)
                    {
                        gel.X -= 1;
                        moveCount++;
                    }
                    else
                    {
                        moveCount = 80;
                    }
                    break;
                case GelState.RightNormal:
                    if (!gel.isBlockedRight)
                    {
                        gel.X += 1;
                        moveCount++;
                    }
                    else
                    {
                        moveCount = 80;
                    }
                    break;
                case GelState.UpNormal:
                    if (!gel.isBlockedTop) {
                        gel.Y -= 1;
                        moveCount++;
                    }
                    else
                    {
                        moveCount = 80;
                    }
                    break;
                case GelState.DownNormal:
                    if (!gel.isBlockedBottom)
                    {
                        gel.Y += 1;
                        moveCount++;
                    }
                    else
                    {
                        moveCount = 80;
                    }
                    break;
            }
        }
    }
}
