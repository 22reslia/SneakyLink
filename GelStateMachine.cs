using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class GelStateMachine
    {
        private enum GelState { LeftNormal, RightNormal, UpNormal, DownNormal };
        private GelState currentState = GelState.LeftNormal;
        private Random randomMove;
        private int moveCount = 0;

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
            if (moveCount == 40)
            {
                moveCount = 0;
                this.ChangeDirection();
            }

            switch (currentState)
            {
                case GelState.LeftNormal:
                    gel.x -= 1;
                    moveCount++;
                    break;
                case GelState.RightNormal:
                    gel.x += 1;
                    moveCount++;
                    break;
                case GelState.UpNormal:
                    gel.y -= 1;
                    moveCount++;
                    break;
                case GelState.DownNormal:
                    gel.y += 1;
                    moveCount++;
                    break;
            }
        }
    }
}
