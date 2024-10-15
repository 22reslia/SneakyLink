using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;

namespace SneakyLink.Scene
{
    public interface IBlock
    {
        public CollisionBox CollisionBox { get; set; }
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}
