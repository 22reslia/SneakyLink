using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SneakyLink
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, int x, int y);
    }
}