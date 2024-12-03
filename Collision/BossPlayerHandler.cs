using SneakyLink.Enemies;

namespace SneakyLink.Collision
{
    public class BossPlayerHandler
    {
        public static void HandleCollision(Providence providence, CollisionType side, int damage)
        {
            if (!providence.isV)
            {
                providence.cHealth -= damage;
                providence.isV = true;
            }
        }
    }
}
