using SneakyLink;
using SneakyLink.Player;

namespace SneakyLink.Commands
{
    public class UseItem : ICommand
    {
        private Link link;

        public UseItem(Link player)
        {
            link = player;
        }

        public void Execute()
        {
            if (link.BombNum > 0)
            {
                link.BombNum--;
                link.StateMachine.currentState = PlayerState.playerUseItem;
            }
        }
    }
}
