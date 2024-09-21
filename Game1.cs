using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SneakyLink;

public class Game1 : Game
{
    public GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private IController<Keys> KeyboardController;

    Player.Player link;
    // Player.LinkWoodenSwordForward linkWoodenSwordForward;
    // Player.LinkWoodenSwordRight linkWoodenSwordRight;
    // Player.LinkWoodenSwordLeft linkWoodenSwordLeft;
    // Player.LinkWoodenSwordTop linkWoodenSwordTop;

    public Vector2 linkPosition;

    private IEnemy currentEnemy;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        KeyboardController = new KeyboardController();

        ICommand exitCommand = new GameExit(this);

        //Initilizing Commands to specific keys
        KeyboardController.RegisterCommand(Keys.Q, new GameExit(this));
        KeyboardController.RegisterCommand(Keys.Right, new MoveRight(this));
        KeyboardController.RegisterCommand(Keys.Left, new MoveLeft(this));
        KeyboardController.RegisterCommand(Keys.Up, new MoveUp(this));
        KeyboardController.RegisterCommand(Keys.Down, new MoveDown(this));


        linkPosition.X = 100;
        linkPosition.Y = 100;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Player.PlayerSpriteFactory.Instance.LoadAllTextures(Content);
        Enemies.EnemySpriteFactory.Instance.LoadAllTextures(Content);

        link = new Player.Player();
        currentEnemy = new Enemies.Stalfos();

        // linkWoodenSwordForward = new Player.LinkWoodenSwordForward(linkSpriteSheet);
        // linkWoodenSwordRight = new Player.LinkWoodenSwordRight(linkSpriteSheet);
        // linkWoodenSwordLeft = new Player.LinkWoodenSwordLeft(linkSpriteSheet);
        // linkWoodenSwordTop = new Player.LinkWoodenSwordTop(linkSpriteSheet);
    }

    protected override void Update(GameTime gameTime)
    {
        //input update
        KeyboardController.Update();
        
        //current Enemy
        currentEnemy.Update();

        //link sprites update
        // linkWoodenSwordForward.Update();
        // linkWoodenSwordRight.Update();
        // linkWoodenSwordLeft.Update();
        // linkWoodenSwordTop.Update();

        //link (player) update
        link.Update();


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        currentEnemy.Draw(_spriteBatch);
        link.Draw(_spriteBatch);

        base.Draw(gameTime);
    }
}
