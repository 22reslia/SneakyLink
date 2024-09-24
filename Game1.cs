using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using SneakyLink.Player;
using System.ComponentModel;
using SneakyLink.Enemies;

namespace SneakyLink;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    //Controllers for input
    private IController<Keys> _KeyboardController;
    //private IController<MouseButton> _MouseController;
    private ICommand initialize;

    public IEnemy currentEnemy;
    public List<IEnemy> enemyList;
    
    Player.Link link;
    private Texture2D blockSheet;
    private Texture2D itemSheet;
    private Rectangle[] blockSourceRectangles = new Rectangle[15];

    private Block currentBlock;
    private Item currentItem;
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
        _KeyboardController = new KeyboardController();

        //initializes Link contructor
        link = new Player.Link();

        //Initilizing Commands to specific keys
        _KeyboardController.RegisterCommand(Keys.Q, new GameExit(this));
        _KeyboardController.RegisterCommand(Keys.Right, new MoveRight(link));
        _KeyboardController.RegisterCommand(Keys.D, new MoveRight(link));
        _KeyboardController.RegisterCommand(Keys.Left, new MoveLeft(link));
        _KeyboardController.RegisterCommand(Keys.A, new MoveLeft(link));
        _KeyboardController.RegisterCommand(Keys.Up, new MoveUp(link));
        _KeyboardController.RegisterCommand(Keys.W, new MoveUp(link));
        _KeyboardController.RegisterCommand(Keys.Down, new MoveDown(link));
        _KeyboardController.RegisterCommand(Keys.S, new MoveDown(link));
        _KeyboardController.RegisterCommand(Keys.Z, new WoodenAttack(link));
        _KeyboardController.RegisterCommand(Keys.N, new WoodenAttack(link));
        _KeyboardController.RegisterCommand(Keys.E, new DamagePlayer(link));

        initialize = new InitializeObject(this);
        _KeyboardController.RegisterCommand(Keys.R, initialize);
        _KeyboardController.RegisterCommand(Keys.O, new PreviousEnemyCommand(this));
        _KeyboardController.RegisterCommand(Keys.P, new NextEnemyCommand(this));

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        EnemySpriteFactory.Instance.LoadAllTextures(Content);
        Player.PlayerSpriteFactory.Instance.LoadAllTextures(Content);

        link.SetSprite();

        blockSheet = Content.Load<Texture2D>("Blocks");
        itemSheet = Content.Load<Texture2D>("Items");

        blockSourceRectangles = setRectanglesBlock.Instance.LoadBlock();

        currentBlock = new Block(blockSheet, blockSourceRectangles);
        currentItem = new Item(itemSheet, 0.2);
        _KeyboardController.RegisterCommand(Keys.Y, new NextBlockCommand(currentBlock));
        _KeyboardController.RegisterCommand(Keys.T, new PreviousBlockCommand(currentBlock));
        _KeyboardController.RegisterCommand(Keys.I, new NextItemCommand(currentItem));
        _KeyboardController.RegisterCommand(Keys.U, new PreviousItemCommand(currentItem));

        initialize.Execute();
    }

    protected override void Update(GameTime gameTime)
    {
        currentBlock.Update();
        currentItem.Update();
        //input update
        _KeyboardController.Update();
        
        //current Enemy
        currentEnemy.Update();

        //link (player) update
        link.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        currentBlock.Draw(_spriteBatch, 0 ,0);
        currentItem.Draw(_spriteBatch, 0, 0);

        currentEnemy.Draw(_spriteBatch);

        //Draw player link
        link.Draw(_spriteBatch);

        base.Draw(gameTime);
    }
}
