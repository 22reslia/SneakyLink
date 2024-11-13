using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Projectiles
{
    public interface IProjectile
    {
        Vector2 Position { get; set; }
        void Shoot(float velocityX, float velocityY);
        void Update();
        void Draw(SpriteBatch spriteBatch);
        bool HasCollided { get; }
        //bool IsOutOfBounds();


    }
}