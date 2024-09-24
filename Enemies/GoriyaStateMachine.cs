using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class GoriyaStateMachine
    {
        private enum GoriyaState { LeftNormal, RightNormal, UpNormal, DownNormal, LeftAttack, RightAttack };
        private GoriyaState currentState = GoriyaState.RightNormal;
        private Random randomMove;
        private int moveCount = 0;
        private GoriyaBoomerang boomerang;
        private bool isAttacking = false;

        public void ChangeDirection(Goriya goriya)
        {
            randomMove = new Random();
            int nextState = randomMove.Next(0, 6);
            switch (nextState)
            {
                case 0:
                    currentState = GoriyaState.LeftNormal;
                    goriya.GoriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaLeftIdleSprite();
                    break;
                case 1:
                    currentState = GoriyaState.RightNormal;
                    goriya.GoriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaRightIdleSprite();
                    break;
                case 2:
                    currentState = GoriyaState.UpNormal;
                    goriya.GoriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaUpIdleSprite();
                    break;
                case 3:
                    currentState = GoriyaState.DownNormal;
                    goriya.GoriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaDownIdleSprite();
                    break;
                case 4:
                    currentState = GoriyaState.LeftAttack;
                    goriya.GoriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaLeftAttackSprite();
                    break;
                case 5:
                    currentState = GoriyaState.RightAttack;
                    goriya.GoriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaRightAttackSprite();
                    break;
            }
        }

        public void Draw(SpriteBatch sb, ISprite GoriyaSprite, int x, int y)
        {
            GoriyaSprite.Draw(sb, x, y);
            if (isAttacking)
            {
                boomerang.Draw(sb);
            }
        }

        public void Move(Goriya goriya)
        {
            if (moveCount == 80)
            {
                moveCount = 0;
                this.ChangeDirection(goriya);
            }

            switch (currentState)
            {
                case GoriyaState.LeftNormal:
                    goriya.x -= 1;
                    moveCount++;
                    break;
                case GoriyaState.RightNormal:
                    goriya.x += 1;
                    moveCount++;
                    break;
                case GoriyaState.UpNormal:
                    goriya.y -= 1;
                    moveCount++;
                    break;
                case GoriyaState.DownNormal:
                    goriya.y += 1;
                    moveCount++;
                    break;
            }
        }

        public void Attack(Goriya goriya)
        {
            if (!isAttacking)
            {
                switch (currentState)
                {
                    case GoriyaState.LeftAttack:
                        boomerang = new GoriyaBoomerang(goriya.x - 20, goriya.y);
                        boomerang.Shoot(-5);
                        break;
                    case GoriyaState.RightAttack:
                        boomerang = new GoriyaBoomerang(goriya.x + 52, goriya.y);
                        boomerang.Shoot(5);
                        break;
                }
                isAttacking = true;
            }
            boomerang.Update();

            if (boomerang.HasReturned())
            {
                isAttacking = false;
                boomerang = null;

                if (currentState == GoriyaState.LeftAttack)
                {
                    currentState = GoriyaState.LeftNormal;
                    goriya.GoriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaLeftIdleSprite();
                }
                else if (currentState == GoriyaState.RightAttack)
                {
                    currentState = GoriyaState.RightNormal;
                    goriya.GoriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaRightIdleSprite();
                }
            }
        }

        public void Update(Goriya goriya)
        {
            if (!isAttacking) Move(goriya);
            if (currentState == GoriyaState.LeftAttack || currentState == GoriyaState.RightAttack) Attack(goriya);
        }
    }
}
