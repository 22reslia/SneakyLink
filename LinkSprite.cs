
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
public class LinkForward : ISprite
{
    public Texture2D linkSprite;
    private Vector2 position;
    int currentFrame = 0;
    int maxFrame = 30;

    public LinkForward(Texture2D texture)
    {
        linkSprite = texture;
    }
    public void Draw(SpriteBatch spriteBatch, int xPosition , int yPosition)
    {
        position.X = xPosition;
        position.Y = yPosition;

        int width = 16;
        int height = 16;

        Rectangle destinationRectangle = new Rectangle();
        Rectangle sourceRectangle = new Rectangle();

        if (currentFrame < maxFrame / 2)
        {
         sourceRectangle = new Rectangle(1, 11, width, height);
         destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 15*width, 15*height);
        }
        else if (currentFrame >= maxFrame / 2)
        {
         sourceRectangle = new Rectangle(1, 11, width, height);
         destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 15*width, 15*height);
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