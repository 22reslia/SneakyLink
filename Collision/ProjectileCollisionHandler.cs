using SneakyLink.Blocks;
using SneakyLink.Enemies;
using SneakyLink.Projectiles;

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
                        enemy.cHealth --;;
                    break;
            }

            // Remove the bomb if it has exploded
            if (bomb.HasCollided)
            {
                game.projectileList.Remove(bomb); // Correctly remove the bomb
            }
        }
    }
}
