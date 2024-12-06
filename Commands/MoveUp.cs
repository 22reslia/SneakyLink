using SneakyLink;
using SneakyLink.Player;

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
            link.stateMachine.currentDirection = PlayerDirection.playerUp;
            if (link.isMovable)
            {
                link.stateMachine.currentState = PlayerState.playerMoving;
                if (!link.isBlockedTop)
                {
                    link.playerPosition.Y -= link.velocity;
                }
            }
        }
    }
}
