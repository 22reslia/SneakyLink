using SneakyLink;
using SneakyLink.Player;
using Microsoft.Xna.Framework;

namespace SneakyLink.Commands
{
    public class MoveLeft : ICommand
    {
        private Link link;

        public MoveLeft(Link player)
        {
            link = player;
        }

        public void Execute()
        {
            link.StateMachine.currentDirection = PlayerDirection.playerLeft;
            if (link.IsMovable)
            {
                link.StateMachine.currentState = PlayerState.playerMoving;
                if (!link.IsBlockedLeft)
                {
                    Vector2 position = link.PlayerPosition;
                    position.X -= link.Velocity;
                    link.PlayerPosition = position;
                }
            }
        }
    }
}
