using SneakyLink;
using Microsoft.Xna.Framework;
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
            link.StateMachine.currentDirection = PlayerDirection.playerDown;
            if (link.IsMovable)
            {
                link.StateMachine.currentState = PlayerState.playerMoving;
                if (!link.IsBlockedBottom)
                {
                    // Create a temporary variable for PlayerPosition
                    Vector2 position = link.PlayerPosition;
                    position.Y += link.Velocity; // Modify the Y component
                    link.PlayerPosition = position; // Reassign the updated value
                }
            }
        }
    }
}
