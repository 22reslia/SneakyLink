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
                    enemy.X -= 20;
                    enemy.isBlockedL = true;
                    enemy.cHealth -= 1;
                    break;
                case CollisionType.Right:
                    enemy.X += 20;
                    enemy.isBlockedR = true;
                    enemy.cHealth -= 1;
                    break;
                case CollisionType.Top:
                    enemy.Y -= 20;
                    enemy.isBlockedT = true;
                    enemy.cHealth -= 1;
                    break;
                case CollisionType.Bottom:
                    enemy.Y += 20;
                    enemy.isBlockedB = true;
                    enemy.cHealth -= 1;
                    break;
            }
        }
    }
}
