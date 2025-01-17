﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class ZolStateMachine
    {
        private enum ZolState { LeftNormal, RightNormal, UpNormal, DownNormal, Idle };
        private ZolState currentState = ZolState.LeftNormal;
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
                    currentState = ZolState.LeftNormal;
                    break;
                case 1:
                    currentState = ZolState.RightNormal;
                    break;
                case 2:
                    currentState = ZolState.UpNormal;
                    break;
                case 3:
                    currentState = ZolState.DownNormal;
                    break;
            }
        }

        public void Draw(SpriteBatch sb, ISprite ZolSprite, int x, int y)
        {
            ZolSprite.Draw(sb, x, y);
        }

        public void Update(Zol zol)
        {
            if (currentState == ZolState.Idle)
            {
                counter++;
                if (counter >= 30)
                {
                    counter = 0;
                    this.ChangeDirection();
                }
            }

            if (moveCount == 80)
            {
                moveCount = 0;
                currentState = ZolState.Idle;
            }

            switch (currentState)
            {
                case ZolState.LeftNormal:
                    if (!zol.isBlockedLeft)
                    {
                        zol.X -= 1;
                        moveCount++;
                    }
                    else
                    {
                        moveCount = 80;
                    }
                    break;
                case ZolState.RightNormal:
                    if (!zol.isBlockedRight)
                    {
                        zol.X += 1;
                        moveCount++;
                    }
                    else
                    {
                        moveCount = 80;
                    }
                    break;
                case ZolState.UpNormal:
                    if (!zol.isBlockedTop)
                    {
                        zol.Y -= 1;
                        moveCount++;
                    }
                    else
                    {
                        moveCount = 80;
                    }
                    break;
                case ZolState.DownNormal:
                    if (!zol.isBlockedBottom)
                    {
                        zol.Y += 1;
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
