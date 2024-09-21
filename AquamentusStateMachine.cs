﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class AquamentusStateMachine
    {
        private enum AquamentusState { LeftNormal, RightNormal, LeftAttack, RightAttack};
        private AquamentusState currentState = AquamentusState.LeftNormal;
        private Random randomMove;
        private int moveCount = 0;
        private AquamentusFireBall fireBallOne;
        private AquamentusFireBall fireBallTwo;
        private AquamentusFireBall fireBallThree;
        private bool isAttacking = false;

        public void ChangeDirection(Aquamentus aquamentus)
        {
            randomMove = new Random();
            int nextDirection = randomMove.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = AquamentusState.LeftNormal;
                    aquamentus.aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusLeftIdleEnemySprite();
                    isAttacking = false;
                    break;
                case 1:
                    currentState = AquamentusState.RightNormal;
                    aquamentus.aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusRightIdleEnemySprite();
                    isAttacking = false;
                    break;
                case 2:
                    currentState = AquamentusState.LeftAttack;
                    aquamentus.aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusLeftAttackEnemySprite();
                    break;
                case 3:
                    currentState = AquamentusState.RightAttack;
                    aquamentus.aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusRightAttackEnemySprite();
                    break;
            }
        }

        public void Move(Aquamentus aquamentus)
        {
            if (moveCount == 60)
            {
                moveCount = 0;
                ChangeDirection(aquamentus);
            }

            switch (currentState)
            {
                case AquamentusState.LeftNormal:
                    aquamentus.x -= 1;
                    moveCount++;
                    break;
                case AquamentusState.RightNormal:
                    aquamentus.x += 1;
                    moveCount++;
                    break;
                case AquamentusState.LeftAttack:
                    moveCount++;
                    break;
                case AquamentusState.RightAttack:
                    moveCount++;
                    break;
            }
        }

        public void Attack(Aquamentus aquamentus)
        {
            if (!isAttacking)
            {
                switch (currentState)
                {
                    case AquamentusState.LeftAttack:
                        fireBallOne = new AquamentusFireBall(aquamentus.x - 20, aquamentus.y);
                        fireBallTwo = new AquamentusFireBall(aquamentus.x - 20, aquamentus.y + 16);
                        fireBallThree = new AquamentusFireBall(aquamentus.x - 20, aquamentus.y + 32);

                        fireBallOne.Shoot(-5, -5);
                        fireBallTwo.Shoot(-5, 0);
                        fireBallThree.Shoot(-5, 5);
                        break;

                    case AquamentusState.RightAttack:
                        fireBallOne = new AquamentusFireBall(aquamentus.x + 92, aquamentus.y);
                        fireBallTwo = new AquamentusFireBall(aquamentus.x + 92, aquamentus.y + 16);
                        fireBallThree = new AquamentusFireBall(aquamentus.x + 92, aquamentus.y + 32);

                        fireBallOne.Shoot(5, -5);
                        fireBallTwo.Shoot(5, 0);
                        fireBallThree.Shoot(5, 5);
                        break;
                }

                isAttacking = true;
            }

            fireBallOne.Update();
            fireBallTwo.Update();
            fireBallThree.Update();
        }

        public void Draw(SpriteBatch spriteBatch, ISprite aquamentusSprite, int x, int y)
        {
            aquamentusSprite.Draw(spriteBatch, x, y);
            if (isAttacking)
            {
                fireBallOne.Draw(spriteBatch);
                fireBallTwo.Draw(spriteBatch);
                fireBallThree.Draw(spriteBatch);
            }
        }
        public void Update(Aquamentus aquamentus)
        {
            Move(aquamentus);
            if (currentState == AquamentusState.LeftAttack || currentState == AquamentusState.RightAttack)
            {
                Attack(aquamentus);
            }
        }

    }
}
