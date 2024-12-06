using SneakyLink;
using SneakyLink.Player;

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
            link.stateMachine.currentDirection = PlayerDirection.playerLeft;
            if (link.isMovable)
            {
                link.stateMachine.currentState = PlayerState.playerMoving;
                if (!link.isBlockedLeft)
                {
                    link.playerPosition.X -= link.velocity;
                }
            }
        }
    }
}
