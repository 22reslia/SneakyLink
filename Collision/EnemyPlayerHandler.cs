using SneakyLink.Enemies;

namespace SneakyLink.Collision
{
    public class EnemyPlayerHandler
    {
        public static void HandleCollision(IEnemy enemy, CollisionType side, int damage)
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
                    if (!enemy.IsV)
                    {
                        enemy.cHealth -= damage;
                        enemy.IsV = true;
                    }
                    break;
                case CollisionType.Right:
                    enemy.isBlockedR = true;
                    if (!enemy.IsV)
                    {
                        enemy.cHealth -= damage;
                        enemy.IsV = true;
                    }
                    break;
                case CollisionType.Top:
                    enemy.isBlockedT = true;
                    if (!enemy.IsV)
                    {
                        enemy.cHealth -= damage;
                        enemy.IsV = true;
                    }
                    break;
                case CollisionType.Bottom:
                    enemy.isBlockedB = true;
                    if (!enemy.IsV)
                    {
                        enemy.cHealth -= damage;
                        enemy.IsV = true;
                    }
                    break;
            }
        }
    }
}
