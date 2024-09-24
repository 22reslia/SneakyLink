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
            IEnemy Keese = new Keese();
            IEnemy Zol = new Zol();
            IEnemy Aquamentus = new Aquamentus();
            IEnemy Gel = new Gel();
            IEnemy Goriya = new Goriya();
            IEnemy Stalfos = new Stalfos();
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
