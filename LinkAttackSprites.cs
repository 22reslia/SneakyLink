using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

public class LinkWoodenSwordForward : ISprite
{
    public Texture2D linkSprite;
    private Vector2 position;
    int currentFrame = 0;
    int maxFrame = 30;

    public LinkWoodenSwordForward(Texture2D texture)
    {
        linkSprite = texture;
    }
    public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
    {
        position.X = xPosition;
        position.Y = yPosition;

        Rectangle destinationRectangle = new Rectangle();
        Rectangle sourceRectangle = new Rectangle();

        if (currentFrame < maxFrame / 4)
        {
         sourceRectangle = new Rectangle(1, 47, 16, 16);
         destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 5*16, 5*16);
        }
        else if (currentFrame >= maxFrame / 4 && currentFrame < maxFrame / 2)
        {
         sourceRectangle = new Rectangle(18, 47, 16, 27);
         destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 5*16, 5*27);
        }
        else if (currentFrame >= maxFrame / 2 && currentFrame < 3 * (maxFrame / 4))
        {
         sourceRectangle = new Rectangle(35, 47, 16, 22);
         destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 5*16, 5*22);
        }
        else if (currentFrame >= 3 * (maxFrame / 4))
        {
         sourceRectangle = new Rectangle(52, 47, 16, 18);
         destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 5*16, 5*18);
        }

        spriteBatch.Begin();
        spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }

    public void Update()
    {
        currentFrame++;
        if (currentFrame == maxFrame)
        {
            currentFrame = 0;
        }
    }
}