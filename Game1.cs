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

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

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

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        //linkForward.Draw(_spriteBatch, _graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        linkWoodenSwordForward.Draw(_spriteBatch, _graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
