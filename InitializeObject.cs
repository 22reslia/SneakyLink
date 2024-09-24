using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class InitializeObject : ICommand
    {
        Game1 game;
        public InitializeObject(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //load enemy part
            IEnemy Keese = new Enemies.Keese();
            IEnemy Zol = new Enemies.Zol();
            IEnemy Aquamentus = new Enemies.Aquamentus();
            IEnemy Gel = new Enemies.Gel();
            IEnemy Goriya = new Enemies.Goriya();
            IEnemy Stalfos = new Enemies.Stalfos();
            game.enemyList = new List<IEnemy>();
            game.enemyList.Add(Keese);
            game.enemyList.Add(Zol);
            game.enemyList.Add(Aquamentus);
            game.enemyList.Add(Gel);
            game.enemyList.Add(Goriya);
            game.enemyList.Add(Stalfos);
            game.currentEnemy = game.enemyList[0];
        }
    }
}
