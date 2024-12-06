using SneakyLink;
using SneakyLink.Player;

namespace SneakyLink.Commands
{
    public class DamagePlayer : ICommand
    {
        private Link link;

        public DamagePlayer(Link player)
        {
            link = player;
        }

        public void Execute()
        {
            link.stateMachine.currentState = PlayerState.playerDamaged;
        }
    }
}
