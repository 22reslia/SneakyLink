using System.Diagnostics.Contracts;
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;

public class Player
{
    int health;
    Vector2 playerPosition;
    private enum PlayerState { LeftNormal, RightNormal, UpNormal, DownNormal };
    public void player()
    {
        health = 10;
        int velocity = 10;
        int sprite = 0;
        playerPosition.X = 100;
        playerPosition.Y = 100;
    }

    public void damage(int damageValue)
    {
        health -= damageValue;
    }

    public void currentPlayerSprite()
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(image, new Rectangle(x, y, 64, 64), sourceRectangle, Color.White);
        spriteBatch.End();
    }

}