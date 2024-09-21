using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SneakyLink;

public class Game1 : Game
{
    public GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private IController<Keys> KeyboardController;

    Player.Link link;
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

        link = new Player.Link();

        //Initilizing Commands to specific keys
        KeyboardController.RegisterCommand(Keys.Q, new GameExit(this));
        KeyboardController.RegisterCommand(Keys.Right, new MoveRight(this, link));
        KeyboardController.RegisterCommand(Keys.Left, new MoveLeft(this, link));
        KeyboardController.RegisterCommand(Keys.Up, new MoveUp(this, link));
        KeyboardController.RegisterCommand(Keys.Down, new MoveDown(this, link));

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Player.PlayerSpriteFactory.Instance.LoadAllTextures(Content);
        Enemies.EnemySpriteFactory.Instance.LoadAllTextures(Content);

        
        currentEnemy = new Enemies.Stalfos();

    }

    protected override void Update(GameTime gameTime)
    {
        //input update
        KeyboardController.Update();
        
        //current Enemy
        currentEnemy.Update();

        //link (player) update
        link.Update();


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        currentEnemy.Draw(_spriteBatch);

        //Draw player link
        link.Draw(_spriteBatch);

        base.Draw(gameTime);
    }
}
