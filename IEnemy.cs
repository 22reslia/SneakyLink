using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;

namespace SneakyLink
{
    public interface IEnemy
    {
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}