using SneakyLink.Enemies;

namespace SneakyLink.Collision
{
    public class EnemyPlayerHandler
    {
        public static void HandleCollision(IEnemy enemy, CollisionType side)
        {
            switch (side)
            {
                case CollisionType.None:
                    enemy.isBlockedL = false;
                    enemy.isBlockedR = false;
                    enemy.isBlockedT = false;
                    enemy.isBlockedB = false;
                    break;
                case CollisionType.Left:
                    enemy.isBlockedL = true;
                    enemy.cHealth -= 1;
                    break;
                case CollisionType.Right:
                    enemy.isBlockedR = true;
                    enemy.cHealth -= 1;
                    break;
                case CollisionType.Top:
                    enemy.isBlockedT = true;
                    enemy.cHealth -= 1;
                    break;
                case CollisionType.Bottom:
                    enemy.isBlockedB = true;
                    enemy.cHealth -= 1;
                    break;
            }
        }
    }
}
