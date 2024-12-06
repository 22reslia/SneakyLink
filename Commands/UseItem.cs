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
            if (link.bombNum > 0)
            {
                link.bombNum--;
                link.stateMachine.currentState = PlayerState.playerUseItem;
            }
        }
    }
}
