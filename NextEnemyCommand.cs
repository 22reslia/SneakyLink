using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class NextEnemyCommand : ICommand
    {
        private Game1 game;
        private int enemyCount;
        public NextEnemyCommand(Game1 game) 
        {
            this.game = game;
        }
        public void Execute()
        {
            enemyCount = game.enemyList.IndexOf(game.currentEnemy);
            if (enemyCount < game.enemyList.Count - 1)
            {
                game.currentEnemy = game.enemyList[enemyCount + 1];
            }
            else
            {
                game.currentEnemy = game.enemyList[0];
            }
        }
    }
}
