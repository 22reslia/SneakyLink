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
            // Update PlayerPosition using a temporary Vector2
            var position = game.link.PlayerPosition;
            position.X = 200;
            position.Y = 200;
            game.link.PlayerPosition = position;

            // Update StateMachine properties
            game.link.StateMachine.currentDirection = Player.PlayerDirection.playerDown;
            game.link.StateMachine.currentState = Player.PlayerState.playerIdle;

            // Initialize other fields
            game.link.CoinNum = 0;
            game.link.KeyNum = 0;   
            game.link.BombNum = 0;
            game.link.MaxHealth = 5;
            game.link.Damage = 1;
            game.link.CurrentHealth = game.link.MaxHealth;

            game.mapPicked = false;

            // Initialize potion-related fields
            game.link.HasRedPotion = false;
            game.link.HasBluePotion = false;
        }
    }
}
