using SneakyLink.Player;
using Microsoft.Xna.Framework;

namespace SneakyLink.Collision
{
    public class PlayerEnemyHandler
    {
        public static void HandleCollision(Link link, CollisionType side, PlayerSounds sound)
        {
            int knockbackDistance = 20;
            bool nearWall = link.IsBlockedLeft || link.IsBlockedRight || link.IsBlockedTop || link.IsBlockedBottom;

            switch (side)
            {
                case CollisionType.None:
                    link.IsBlockedLeft = false;
                    link.IsBlockedRight = false;
                    link.IsBlockedTop = false;
                    link.IsBlockedBottom = false;
                    break;

                case CollisionType.Left:
                    link.IsBlockedLeft = true;
                    link.StateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.IsV)
                    {
                        if (!nearWall)
                        {
                            Vector2 position = link.PlayerPosition;
                            position.X += knockbackDistance;
                            link.PlayerPosition = position;
                        }
                        sound.PlayLinkHurt();
                        link.CurrentHealth--;
                        link.IsV = true;
                    }
                    break;

                case CollisionType.Right:
                    link.IsBlockedRight = true;
                    link.StateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.IsV)
                    {
                        if (!nearWall)
                        {
                            Vector2 position = link.PlayerPosition;
                            position.X -= knockbackDistance;
                            link.PlayerPosition = position;
                        }
                        sound.PlayLinkHurt();
                        link.CurrentHealth--;
                        link.IsV = true;
                    }
                    break;

                case CollisionType.Top:
                    link.IsBlockedTop = true;
                    link.StateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.IsV)
                    {
                        if (!nearWall)
                        {
                            Vector2 position = link.PlayerPosition;
                            position.Y += knockbackDistance;
                            link.PlayerPosition = position;
                        }
                        sound.PlayLinkHurt();
                        link.CurrentHealth--;
                        link.IsV = true;
                    }
                    break;

                case CollisionType.Bottom:
                    link.IsBlockedBottom = true;
                    link.StateMachine.currentState = PlayerState.playerDamaged;
                    if (!link.IsV)
                    {
                        if (!nearWall)
                        {
                            Vector2 position = link.PlayerPosition;
                            position.Y -= knockbackDistance;
                            link.PlayerPosition = position;
                        }
                        sound.PlayLinkHurt();
                        link.CurrentHealth--;
                        link.IsV = true;
                    }
                    break;
            }
        }
    }
}
