using SneakyLink;
using SneakyLink.Player;

namespace SneakyLink.Commands
{
    public class WoodenAttack : ICommand
    {
        private Link link;
        private PlayerSounds playerSounds;

        public WoodenAttack(Link player, PlayerSounds sounds)
        {
            link = player;
            playerSounds = sounds;
        }

        public void Execute()
        {
            link.StateMachine.currentState = PlayerState.playerAttacking;
            playerSounds.PlayLinkSwordSlash();
        }
    }
}
