using SneakyLink;
using SneakyLink.Player;
using Microsoft.Xna.Framework;

namespace SneakyLink.Commands
{
    public class MoveRight : ICommand
    {
        private Link link;

        public MoveRight(Link player)
        {
            link = player;
        }

        public void Execute()
        {
            link.StateMachine.currentDirection = PlayerDirection.playerRight;
            if (link.IsMovable)
            {
                link.StateMachine.currentState = PlayerState.playerMoving;
                if (!link.IsBlockedRight)
                {
                    Vector2 position = link.PlayerPosition;
                    position.X += link.Velocity;
                    link.PlayerPosition = position;
                }
            }
        }
    }
}
