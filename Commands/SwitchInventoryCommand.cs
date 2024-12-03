using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Commands
{
    public class SwitchInventoryCommand : ICommand
    {
        private Game1 game;
        public SwitchInventoryCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            switch (game.gameState)
            {
                case GameState.GamePlay:
                    game.gameState = GameState.Inventory;
                    break;
                case GameState.Inventory:
                    game.gameState = GameState.GamePlay;
                    break;
            }
        }
    }
}
