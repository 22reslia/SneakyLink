using SneakyLink;
using SneakyLink.Player;

namespace SneakyLink.Commands
{
    public class DrinkRedPotion : ICommand
    {
        private Link link;

        public DrinkRedPotion(Link player)
        {
            link = player;
        }

        public void Execute()
        {
            if (link.HasRedPotion && link.CoinNum >= 1)
            {
                link.CoinNum--;
                link.IsDrinkingRedPotion = true;
            }
        }
    }
}
