using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;

namespace SneakyLink;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D blockSheet;
    private Texture2D itemSheet;
    private Rectangle[] blockSourceRectangles = new Rectangle[15];

    private Block currentBlock;
    private IItem currentItem;
    private KeyboardController keyboardController;

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

        blockSheet = Content.Load<Texture2D>("Blocks");
        itemSheet = Content.Load<Texture2D>("Items");

        blockSourceRectangles = setRectangles.Instance.LoadBlock();
        setRectangles.Instance.LoadItem();

        currentBlock = new Block(blockSheet, blockSourceRectangles);

        keyboardController = new KeyboardController();
        keyboardController.RegisterCommand(Keys.Y, new NextImageCommand(currentBlock));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        keyboardController.Update();
        currentBlock.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        currentBlock.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
