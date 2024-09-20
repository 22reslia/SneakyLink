using Microsoft.Xna.Framework.Graphics;

public interface ISprite
{
    void Update();
    void Draw(SpriteBatch spriteBatch, int x, int y);
}