﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class KeeseStateMachine
    {
        private enum KeeseState { LeftNormal, RightNormal, UpNormal, DownNormal, Idle, LeftUpNormal, LeftDownNormal, RightUpNormal, RightDownNormal};
        private KeeseState currentState = KeeseState.Idle;
        private Random randomMove;
        private int moveCount = 0;

        public void ChangeDirection()
        {
            randomMove = new Random();
            int nextDirection = randomMove.Next(0,9);
            switch (nextDirection) 
            { 
                case 0:
                    currentState = KeeseState.LeftNormal;
                    break;
                case 1:
                    currentState = KeeseState.RightNormal;
                    break;
                case 2:
                    currentState = KeeseState.UpNormal;
                    break;
                case 3:
                    currentState = KeeseState.DownNormal;
                    break;
                case 4:
                    currentState = KeeseState.Idle;
                    break;
                case 5:
                    currentState = KeeseState.LeftUpNormal;
                    break;
                case 6:
                    currentState = KeeseState.LeftDownNormal;
                    break;
                case 7:
                    currentState = KeeseState.RightUpNormal;
                    break;
                case 8:
                    currentState = KeeseState.RightDownNormal;
                    break;

            }
        }

        public void Move(Keese keese)
        {
            if (moveCount == 40)
            {
                moveCount = 0;
                this.ChangeDirection();
            }
            
            switch (currentState)
            {
                case KeeseState.LeftNormal:
                    keese.X -= 1;
                    moveCount++;
                    break;
                case KeeseState.RightNormal:
                    keese.X += 1;
                    moveCount++;
                    break;
                case KeeseState.DownNormal:
                    keese.Y += 1;
                    moveCount++;
                    break;
                case KeeseState.UpNormal:
                    keese.Y -= 1;
                    moveCount++;
                    break;
                case KeeseState.Idle:
                    moveCount++;
                    break;
                case KeeseState.LeftUpNormal:
                    keese.X -= 1;
                    keese.Y -= 1;
                    moveCount++;
                    break;
                case KeeseState.LeftDownNormal:
                    keese.X -= 1;
                    keese.Y += 1;
                    moveCount++;
                    break;
                case KeeseState.RightUpNormal:
                    keese.X -= 1;
                    keese.Y -= 1;
                    moveCount++;
                    break;
                case KeeseState.RightDownNormal:
                    keese.X -= 1;
                    keese.Y += 1;
                    moveCount++;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, ISprite keeseSprite, int x, int y)
        {
            keeseSprite.Draw(spriteBatch, x, y);
        }
        public void Update(Keese keese)
        {
            Move(keese);
        }

    }
}
