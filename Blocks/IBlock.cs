using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Scene
{
    public interface IBlock
    {
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}
