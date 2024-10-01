using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class PreviousItemCommand : ICommand
    {
        private Game1 game;
        private int itemCount;
        private bool isTriggred;
        private int clock;

        public PreviousItemCommand(Game1 game)
        {
            this.game = game;
            isTriggred = false;
            clock = 0;
        }

        public void Execute()
        {
            if (isTriggred)
            {
                if (clock <= 10)
                {
                    clock++;
                }
                else
                {
                    isTriggred = false;
                    clock = 0;
                }
            }
            else
            {
                itemCount = game.itemList.IndexOf(game.currentItem);
                if (itemCount > 0)
                {
                    game.currentItem = game.itemList[itemCount - 1];
                }
                else
                {
                    game.currentItem = game.itemList[game.itemList.Count - 1];
                }
                isTriggred = true;
            }
        }
    }
}
