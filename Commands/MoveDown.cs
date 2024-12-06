using SneakyLink;
using SneakyLink.Player;

namespace SneakyLink.Commands
{
    public class MoveDown : ICommand
    {
        private Link link;

        public MoveDown(Link player)
        {
            link = player;
        }

        public void Execute()
        {
            link.stateMachine.currentDirection = PlayerDirection.playerDown;
            if (link.isMovable)
            {
                link.stateMachine.currentState = PlayerState.playerMoving;
                if (!link.isBlockedBottom)
                {
                    link.playerPosition.Y += link.velocity;
                }
            }
        }
    }
}
