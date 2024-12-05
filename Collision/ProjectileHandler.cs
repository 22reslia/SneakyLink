using SneakyLink.Blocks;
using SneakyLink.Enemies;
using SneakyLink.Projectiles;
using static System.Net.Mime.MediaTypeNames;

namespace SneakyLink.Collision
{
    public class BombCollisionHandler
    {
        public static void HandleCollision(LinkBomb bomb, object target, Game1 game)
        {
            switch (target)
            {
                case Block block:
                        //bomb.Explode();
                    break;

                case IEnemy enemy:
                    //bomb.Explode();
                    if (!enemy.IsV)
                    {
                        enemy.cHealth -= 5; 
                        enemy.IsV = true;
                    }
                    break;
                case Providence boss:
                    if (!boss.isV)
                    {
                        boss.cHealth -= 5;
                        boss.isV = true;
                    }
                    break;
            }

            // Remove the bomb if it has exploded
            //  if (bomb.Explode() == true)
            //  {
            //      game.projectileList.Remove(bomb); // Correctly remove the bomb
            //  }
        }
    }
}