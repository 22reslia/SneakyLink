using SneakyLink.Collision;
using SneakyLink.Enemies;
using SneakyLink.Items;
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
            Random random = new Random();
            foreach(IEnemy enemy in game.enemies)
            {
                if (enemy.cHealth <= 0)
                {
                    enemyDie.Add(enemy);
                    game.itemList.Add(new RupeeObject(enemy.X, enemy.Y));
                    int drop = random.Next(0,100);
                    if (drop <= 25)
                    {
                        game.itemList.Add(new HeartContainer(enemy.X + 20, enemy.Y + 20));
                    }
                    else if (drop <= 50)
                    {
                        game.itemList.Add(new BombObject(enemy.X - 20, enemy.Y - 20));
                    }
                }
            }
            foreach(IEnemy enemy in enemyDie)
            {
                game.enemies.Remove(enemy);
                game.itemList.Add(new EnemyDeath(enemy.X, enemy.Y));
            }

            //check if player is dead, if so game over
            if (game.link.currentHealth <= 0)
            {
                game.gameState = GameState.GameOver;
            }

            if (game.boss.cHealth <= 0)
            {
                game.gameState = GameState.GameWin;
            }
        }
    }
}
