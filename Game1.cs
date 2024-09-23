using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SneakyLink.Player;

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

        //initializes Link contructor
        link = new Player.Link();

        //Initilizing Commands to specific keys
        KeyboardController.RegisterCommand(Keys.Q, new GameExit(this));
        KeyboardController.RegisterCommand(Keys.Right, new MoveRight(link));
        KeyboardController.RegisterCommand(Keys.Left, new MoveLeft(link));
        KeyboardController.RegisterCommand(Keys.Up, new MoveUp(link));
        KeyboardController.RegisterCommand(Keys.Down, new MoveDown(link));
        KeyboardController.RegisterCommand(Keys.Z, new WoodenAttack(link));
        KeyboardController.RegisterCommand(Keys.N, new WoodenAttack(link));
        KeyboardController.RegisterCommand(Keys.E, new DamagePlayer(link));

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Player.PlayerSpriteFactory.Instance.LoadAllTextures(Content);
        Enemies.EnemySpriteFactory.Instance.LoadAllTextures(Content);

        currentEnemy = new Enemies.Stalfos();
        link.SetSprite();

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
