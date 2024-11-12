using Microsoft.Xna.Framework;

namespace SneakyLink.Projectiles
{
    public interface IProjectile
    {
        Vector2 Position { get; set; }
        void Shoot(float velocityX, float velocityY);
        void Update();
        bool HasCollided { get; }
        //bool IsOutOfBounds();


    }
}