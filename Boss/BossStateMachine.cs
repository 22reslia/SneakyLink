﻿using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Boss;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class BossStateMachine
    {
        private enum BossState { Attack, Idle, Up, Left, Down, Right, Rush};
        private BossState currentState = BossState.Idle;
        private Random randomAction;
        private int moveCount = 0;
        private bool isAttacking = false;
        private int projectileNum;
        private bool isMoving = false;

        private float speed = 4f;
        private float targetX, targetY;
        private float currentX, currentY;

        public bool isSecondStage;

        public BossStateMachine()
        {
            currentX = 290;
            currentY = 0;
            targetX = currentX;
            targetY = currentY;
            projectileNum = 5;
            isSecondStage = false;
        }
        public void changeState(Providence providence)
        {
            if (!isSecondStage)
            {
                if(!isMoving && moveCount >= 10)
                {
                    randomAction = new Random();
                    int nextAction = randomAction.Next(0, 10);
                    if (nextAction == 0)
                    {
                        currentState = BossState.Attack;
                        isAttacking = true;
                    }
                    else if (nextAction >= 1 && nextAction <= 8)
                    {
                        currentState = BossState.Idle;
                    }
                    else if (nextAction >= 9 && nextAction <= 10)
                    {
                        if (currentState >= BossState.Up && currentState < BossState.Right)
                        {
                            currentState++;
                        }
                        else
                        {
                            int position = randomAction.Next(0, 3);
                            switch (position)
                            {
                                case 0:
                                    currentState = BossState.Up;
                                    break;
                                case 1:
                                    currentState = BossState.Left;
                                    break;
                                case 2:
                                    currentState = BossState.Down;
                                    break;
                                case 3:
                                    currentState = BossState.Right;
                                    break;
                            }
                        }
                        isMoving = true;
                    }
                    setTarget();
                    moveCount = 0;
                }
            }
            else
            {

            }
            
        }

        public void setTarget()
        {
            switch (currentState)
            {
                case BossState.Up:
                    targetX = 290;
                    targetY = 0;
                    break;
                case BossState.Left:
                    targetX = 50;
                    targetY = 180;
                    break;
                case BossState.Down:
                    targetX = 290;
                    targetY = 330;
                    break;
                case BossState.Right:
                    targetX = 550;
                    targetY = 180;
                    break;

            }
        }

        public void Move(Providence providence)
        {
            if(isMoving)
            {
                float deltaX = targetX - currentX;
                float deltaY = targetY - currentY;
                float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
                if (distance > 2f)
                {
                    currentX += deltaX / distance * speed;
                    currentY += deltaY / distance * speed;
                }
                else
                {
                    currentX = targetX; 
                    currentY = targetY;
                    isMoving = false;
                }

                providence.X = (int)currentX;
                providence.Y = (int)currentY;
            }
            
        }

        public void Attack(Providence providence)
        {
            isAttacking = true;
            int offset = 0;
            for (int i = 0; i < projectileNum; i++)
            {
                offset += 50;
                BossProjectile projectile = new StraightLineProjectile(providence.X + 105 + offset, providence.Y + 75 + offset, providence.link.playerPosition.X, providence.link.playerPosition.Y);
                providence.projectile.Add(projectile);
            }
            isAttacking = false;
        }
        public void Draw(SpriteBatch spriteBatch, ISprite bossSprite, int x, int y)
        {
            bossSprite.Draw(spriteBatch, x, y);
            
        }
        public void Update(Providence providence)
        {
            if (providence.cHealth <= providence.mHealth / 2)
            {
                isSecondStage = true;
            }
            if (!isMoving)
            {
                moveCount++;
            }
            changeState(providence);
            if (isAttacking)
            {
                Attack(providence);
            }
            Move(providence);
        }

    }
}
