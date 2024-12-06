using SneakyLink;
using SneakyLink.Player;

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
            link.stateMachine.currentDirection = PlayerDirection.playerRight;
            if (link.isMovable)
            {
                link.stateMachine.currentState = PlayerState.playerMoving;
                if (!link.isBlockedRight)
                {
                    link.playerPosition.X += link.velocity;
                }
            }
        }
    }
}
