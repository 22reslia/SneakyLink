using Microsoft.Xna.Framework.Input;
using SneakyLink.Enemies;
using SneakyLink.Player;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Collision
{
    public class PlayerEnemyHandler
    {
        public static void HandleCollision(Link link, CollisionType side)
        {
            switch (side)
            {
                case CollisionType.None:
                    link.isBlockedLeft = false;
                    link.isBlockedRight = false;
                    link.isBlockedTop = false;
                    link.isBlockedBottom = false;
                    break;
                case CollisionType.Left:
                    link.isBlockedLeft = true;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    break;
                case CollisionType.Right:
                    link.isBlockedRight = true;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    break;
                case CollisionType.Top:
                    link.isBlockedTop = true;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    break;
                case CollisionType.Bottom:
                    link.isBlockedBottom = true;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    break;
            }
        }
    }
}
