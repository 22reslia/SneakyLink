using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Commands
{
    public class StartGameCommand : ICommand
    {
        private Game1 game;
        public StartGameCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            //if(game.isTitleScene)
            //{
            //    game.isTitleScene = false;
            //    game.isDungeonScene = true;
            //}
            game.gameState = GameState.GamePlay;
        }
    }
}
