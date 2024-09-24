using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SneakyLink.Player;
using System.Collections.Generic;


namespace SneakyLink;

public class Game1 : Game
{
    public GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private IController<Keys> KeyboardController;
    
    Player.Link link;
    private IEnemy currentEnemy;


    //Controllers for input
    private IController<Keys> _KeyboardController;
    private IController<MouseButton> _MouseController;
    private ICommand initialize;

    public IEnemy currentEnemy;
    public List<IEnemy> enemyList;

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
        _KeyboardController = new KeyboardController();
        _MouseController = new MouseController(this);


        initialize = new InitializeObject(this);
        _KeyboardController.RegisterCommand(Keys.R, initialize);
        _KeyboardController.RegisterCommand(Keys.O, new PreviousEnemyCommand(this));
        _KeyboardController.RegisterCommand(Keys.P, new NextEnemyCommand(this));
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);


        Player.PlayerSpriteFactory.Instance.LoadAllTextures(Content);
        Enemies.EnemySpriteFactory.Instance.LoadAllTextures(Content);

        currentEnemy = new Enemies.Stalfos();
        link.SetSprite();
        EnemySpriteFactory.Instance.LoadAllTextures(Content);
        
        initialize.Execute();

    }

    protected override void Update(GameTime gameTime)
    {

        //input update
        KeyboardController.Update();
        
        //current Enemy
        currentEnemy.Update();

        //link (player) update
        link.Update();


        currentEnemy.Update();
        _KeyboardController.Update();

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
