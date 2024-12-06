using SneakyLink;
using SneakyLink.Player;
using Microsoft.Xna.Framework;

namespace SneakyLink.Commands
{
    public class MoveUp : ICommand
    {
        private Link link;

        public MoveUp(Link player)
        {
            link = player;
        }

        public void Execute()
        {
            link.StateMachine.currentDirection = PlayerDirection.playerUp;
            if (link.IsMovable)
            {
                link.StateMachine.currentState = PlayerState.playerMoving;
                if (!link.IsBlockedTop)
                {
                    Vector2 position = link.PlayerPosition;
                    position.Y -= link.Velocity;
                    link.PlayerPosition = position;
                }
            }
        }
    }
}
