using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink
{
    public interface IEnemy
    {
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}