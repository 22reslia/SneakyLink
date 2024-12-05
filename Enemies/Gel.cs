﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Enemies
{
    public class Gel : IEnemy
    {
        private GelStateMachine stateMachine;
        public CollisionBox collisionBox;
        private ISprite GelSprite;
        private int x, y;
        private int maxHealth;
        private int currentHealth;
        private bool isAlive;
        private bool isV;
        private int vCounter;
        public bool isBlockedTop;
        public bool isBlockedBottom;
        public bool isBlockedLeft;
        public bool isBlockedRight;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int mHealth { get => maxHealth; set => maxHealth = value; }
        public int cHealth { get => currentHealth; set => currentHealth = value; }
        public bool isBlockedL { get => isBlockedLeft; set => isBlockedLeft = value; }
        public bool isBlockedR { get => isBlockedRight; set => isBlockedRight = value; }
        public bool isBlockedT { get => isBlockedTop; set => isBlockedTop = value; }
        public bool isBlockedB { get => isBlockedBottom; set => isBlockedBottom = value; }
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }
        public bool IsV { get => isV; set => isV = value; }

        public Gel(int x, int y) {
            this.x = x;
            this.y = y;
            isAlive = true;
            maxHealth = 1;
            vCounter = 0;
            currentHealth = maxHealth;
            stateMachine = new GelStateMachine();
            collisionBox = new CollisionBox(CollisionObjectType.Enemy, 24, 48, x, y);
            GelSprite = EnemySpriteFactory.Instance.CreateGelSprite();
            isV = false;
            isBlockedTop = false;
            isBlockedBottom = false;
            isBlockedLeft = false;
            isBlockedRight = false;
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch, GelSprite, x, y);
        }

        public void Update()
        {
            GelSprite.Update();
            stateMachine.Update(this);
            if (cHealth <= 0)
            {
                isAlive = false;
            }
            if (collisionBox.side == CollisionType.None)
            {
                isBlockedTop = false;
                isBlockedBottom = false;
                isBlockedLeft = false;
                isBlockedRight = false;
            }

            //update if enemy is invincible
            if (isV)
            {
                vCounter++;
                if (vCounter == 60)
                {
                    isV = false;
                    vCounter = 0;
                }
            }

            collisionBox.x = x; collisionBox.y = y;
        }
    }
}
