using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class AquamentusStateMachine
    {
        private enum AquamentusState { LeftNormal, RightNormal, UpNormal, DownNormal, LeftAttack, RightAttack};
        private AquamentusState currentState = AquamentusState.LeftNormal;
        private Random randomMove;
        private int moveCount = 0;
        private int attackCount = 0;

        public void ChangeDirection(Aquamentus aquamentus)
        {
            randomMove = new Random();
            int nextDirection = randomMove.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = AquamentusState.LeftNormal;
                    aquamentus.aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusLeftIdleEnemySprite();
                    break;
                case 1:
                    currentState = AquamentusState.RightNormal;
                    aquamentus.aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusRightIdleEnemySprite();
                    break;
                case 2:
                    currentState = AquamentusState.UpNormal;
                    break;
                case 3:
                    currentState = AquamentusState.DownNormal;
                    break;
            }
        }

        public void Move(Aquamentus aquamentus)
        {
            if (moveCount == 40)
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
                case AquamentusState.UpNormal:
                    aquamentus.y -= 1;
                    moveCount++;
                    break;
                case AquamentusState.DownNormal:
                    aquamentus.y += 1;
                    moveCount++;
                    break;
            }
        }

        public void Attack(Aquamentus aquamentus)
        {

        }

        public void Draw(SpriteBatch spriteBatch, ISprite aquamentusSprite, int x, int y)
        {
            aquamentusSprite.Draw(spriteBatch, x, y);
        }
        public void Update(Aquamentus aquamentus)
        {
            Move(aquamentus);
        }

    }
}
