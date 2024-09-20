
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
         sourceRectangle = new Rectangle(18, 11, width, height);
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

public class LinkRight : ISprite
{
    public Texture2D linkSprite;
    private Vector2 position;
    int currentFrame = 0;
    int maxFrame = 30;

    public LinkRight(Texture2D texture)
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
         sourceRectangle = new Rectangle(35, 11, width, height);
         destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 15*width, 15*height);
        }
        else if (currentFrame >= maxFrame / 2)
        {
         sourceRectangle = new Rectangle(52, 11, width, height);
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

public class LinkLeft : ISprite
{
    public Texture2D linkSprite;
    private Vector2 position;
    int currentFrame = 0;
    int maxFrame = 30;

    public LinkLeft(Texture2D texture)
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
         sourceRectangle = new Rectangle(35, 11, width, height);
         destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 15*width, 15*height);
        }
        else if (currentFrame >= maxFrame / 2)
        {
         sourceRectangle = new Rectangle(52, 11, width, height);
         destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 15*width, 15*height);
        }

        spriteBatch.Begin();
        spriteBatch.Draw(linkSprite, destinationRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
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

public class LinkBack : ISprite
{
    public Texture2D linkSprite;
    private Vector2 position;
    int currentFrame = 0;
    int maxFrame = 30;

    public LinkBack(Texture2D texture)
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
         sourceRectangle = new Rectangle(69, 11, width, height);
         destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 15*width, 15*height);
        }
        else if (currentFrame >= maxFrame / 2)
        {
         sourceRectangle = new Rectangle(86, 11, width, height);
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