using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SneakyLink;

public class Game1 : Game
{
    public GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    LinkForward linkForward;
    LinkRight linkRight;
    LinkLeft linkLeft;
    LinkBack linkBack;
    LinkWoodenSwordForward linkWoodenSwordForward;
    LinkWoodenSwordRight linkWoodenSwordRight;
    LinkWoodenSwordLeft linkWoodenSwordLeft;
    LinkWoodenSwordTop linkWoodenSwordTop;

    Vector2 linkPosition;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        linkPosition.X = 100;
        linkPosition.Y = 100;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        Texture2D linkSpriteSheet = Content.Load<Texture2D>("Link Sprite Sheet");

        linkForward = new LinkForward(linkSpriteSheet);
        linkRight = new LinkRight(linkSpriteSheet);
        linkLeft = new LinkLeft(linkSpriteSheet);
        linkBack = new LinkBack(linkSpriteSheet);
        linkWoodenSwordForward = new LinkWoodenSwordForward(linkSpriteSheet);
        linkWoodenSwordRight = new LinkWoodenSwordRight(linkSpriteSheet);
        linkWoodenSwordLeft = new LinkWoodenSwordLeft(linkSpriteSheet);
        linkWoodenSwordTop = new LinkWoodenSwordTop(linkSpriteSheet);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        linkForward.Update();
        linkRight.Update();
        linkLeft.Update();
        linkBack.Update();
        linkWoodenSwordForward.Update();
        linkWoodenSwordRight.Update();
        linkWoodenSwordLeft.Update();
        linkWoodenSwordTop.Update();


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        //linkForward.Draw(_spriteBatch, _graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        linkWoodenSwordTop.Draw(_spriteBatch, (int)linkPosition.X, (int)linkPosition.Y);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
