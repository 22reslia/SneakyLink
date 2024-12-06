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
            if (link.hasRedpotion && link.coinNum >= 1)
            {
                link.coinNum--;
                link.isDrinkingRedpotion = true;
            }
        }
    }
}
