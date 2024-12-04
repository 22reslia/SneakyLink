using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class InitializeObject
    {
        public static void initializeObject(Game1 game)
        {   
            game.link.playerPosition.X = 200;
            game.link.playerPosition.Y = 200;
            game.link.stateMachine.currentDirection = Player.PlayerDirection.playerDown;
            game.link.stateMachine.currentState = Player.PlayerState.playerIdle;
            game.link.coinNum = 0;
            game.link.keyNum = 0;   
            game.link.bombNum = 1;
            game.link.currentHealth = game.link.maxHealth;
            game.mapPicked = false;
        }
    }
}
