using SneakyLink.Collision;
using SneakyLink.Enemies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class StateCheck
    {
        public static void stateCheck(Game1 game)
        {
            //check if enemy is dead, if so remove it from enemy list
            List<IEnemy> enemyDie = new List<IEnemy>();
            foreach(IEnemy enemy in game.enemies)
            {
                if (enemy.cHealth <= 0)
                {
                    enemyDie.Add(enemy);
                    game.link.coinNum++;
                }
            }
            foreach(IEnemy enemy in enemyDie)
            {
                game.enemies.Remove(enemy);
            }

            //check if player is dead, if so game over
            if (game.link.currentHealth <= 0)
            {
                game.gameState = GameState.GameOver;
            }

            if (game.link.coinNum == 10)
            {
                game.gameState = GameState.GameWin;
            }
        }
    }
}
