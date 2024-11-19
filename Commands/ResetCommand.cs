using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Commands
{
    public class ResetCommand : ICommand
    {
        private Game1 game;
        public ResetCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.gameState = GameState.GamePlay;
            game.blocks.Clear();
            game.doors.Clear();
            game.enemies.Clear();
            game.itemList.Clear();
            game.room = new Room(game, "..\\..\\..\\Scene\\RoomOne.csv");
            InitializeObject.initializeObject(game);
        }
    }
}
