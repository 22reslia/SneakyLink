using SneakyLink.Player;

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
                    link.playerPosition.X += 20;
                    link.isBlockedLeft = true;
                    link.isMovable = false;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.isV)
                    {
                        link.currentHealth--;
                        link.isV = true;
                    }
                    break;
                case CollisionType.Right:
                    link.playerPosition.X -= 20;
                    link.isBlockedRight = true;
                    link.isMovable = false;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.isV)
                    {
                        link.currentHealth--;
                        link.isV = true;
                    }
                    break;
                case CollisionType.Top:
                    link.playerPosition.Y += 20;
                    link.isBlockedTop = true;
                    link.isMovable = false;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.isV)
                    {
                        link.currentHealth--;
                        link.isV = true;
                    }
                    break;
                case CollisionType.Bottom:
                    link.playerPosition.Y -= 20;
                    link.isBlockedBottom = true;
                    link.isMovable = false;
                    link.stateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.isV)
                    {
                        link.currentHealth--;
                        link.isV = true;
                    }
                    break;
            }
        }
    }
}
