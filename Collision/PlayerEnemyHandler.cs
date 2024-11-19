using SneakyLink.Player;
using System.Runtime.CompilerServices;

namespace SneakyLink.Collision
{
    public class PlayerEnemyHandler
    {
        public static void HandleCollision(Link link, CollisionType side, PlayerSounds sound)
        {
            int knockbackDistance = 20;
            bool nearWall = link.isBlockedLeft || link.isBlockedRight || link.isBlockedTop || link.isBlockedBottom;

            switch (side)
            {   
                case CollisionType.None:
                    link.isBlockedLeft = false;
                    link.isBlockedRight = false;
                    link.isBlockedTop = false;
                    link.isBlockedBottom = false;
                    break;
                case CollisionType.Left:
                    if (!nearWall) link.playerPosition.X += knockbackDistance;
                    link.isBlockedLeft = true;
                    link.isMovable = false;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.isV)
                    {
                        sound.PlayLinkHurt();
                        link.currentHealth--;
                        link.isV = true;
                    }
                    break;
                case CollisionType.Right:
                    if (!nearWall) link.playerPosition.X -= knockbackDistance;
                    link.isBlockedRight = true;
                    link.isMovable = false;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.isV)
                    {
                        sound.PlayLinkHurt();
                        link.currentHealth--;
                        link.isV = true;
                    }
                    break;
                case CollisionType.Top:
                    if (!nearWall) link.playerPosition.Y += knockbackDistance;
                    link.isBlockedTop = true;
                    link.isMovable = false;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.isV)
                    {
                        sound.PlayLinkHurt();
                        link.currentHealth--;
                        link.isV = true;
                    }
                    break;
                case CollisionType.Bottom:
                    if (!nearWall) link.playerPosition.Y -= knockbackDistance;
                    link.isBlockedBottom = true;
                    link.isMovable = false;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.isV)
                    {
                        sound.PlayLinkHurt();
                        link.currentHealth--;
                        link.isV = true;
                    }
                    break;
            }
        }
    }
}
