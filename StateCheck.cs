using SneakyLink.Collision;
using SneakyLink.Enemies;
using SneakyLink.Items;
using System;
using System.Collections.Generic;

namespace SneakyLink
{
    public class StateCheck
    {
        public static void stateCheck(Game1 game)
        {
            List<IEnemy> enemyDie = new List<IEnemy>();
            Random random = new Random();

            foreach (IEnemy enemy in game.enemies)
            {
                if (enemy.cHealth <= 0)
                {
                    enemyDie.Add(enemy);

                    // Grant XP to Link
                    game.link.GainExperience(20); // Adjust XP gain per enemy as needed

                    game.itemList.Add(new RupeeObject(enemy.X, enemy.Y));
                    int drop = random.Next(0, 100);
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

            foreach (IEnemy enemy in enemyDie)
            {
                game.enemies.Remove(enemy);
                game.itemList.Add(new EnemyDeath(enemy.X, enemy.Y));
            }

            if (game.link.CurrentHealth <= 0)
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
