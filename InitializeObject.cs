using System;
using System.Collections.Generic;
using System.Linq;
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
        }
    }
}
