using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SneakyLink.Blocks;
using SneakyLink.Collision;
using SneakyLink.Enemies;
using SneakyLink.Player;
using SneakyLink.Scene;
using System.Collections.Generic;

namespace SneakyLink;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    //for collision testing
    public Gel gel;

    //Controllers for input
    private IController<Keys> _KeyboardController;
    private IController<MouseButton> _MouseController;
    //private ICommand initialize;w

    public Player.Link link;
    public List<ISprite> itemList;

    public Room room;
    //the collision box of elements in the room
    public List<IBlock> blocks = new List<IBlock>();
    public List<IBlock> doors = new List<IBlock>();
    public List<CollisionBox> boundaryCollisionBox = new List<CollisionBox>();
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
        _MouseController = new MouseController(this);

        //initializes Link contructor
        link = new Link();

        //initializes all object
        InitializeObject.initializeObject(this);

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
        _KeyboardController.RegisterCommand(Keys.D1, new UseItem(link));
        _KeyboardController.RegisterCommand(Keys.D2, new UseItem(link));
        _KeyboardController.RegisterCommand(Keys.D3, new UseItem(link));

        _MouseController.RegisterCommand(MouseButton.Left, new ChangeSceneCommand(this));

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        EnemySpriteFactory.Instance.LoadAllTextures(Content);
        Player.PlayerSpriteFactory.Instance.LoadAllTextures(Content);
        Blocks.BlockSpriteFactory.Instance.LoadAllTextrues(Content);
        Items.ItemSpriteFactory.Instance.LoadAllTextrues(Content);

        link.SetSprite();

        //for collision testing
        gel = new Gel();

        room = new Room(this, "..\\..\\..\\Scene\\RoomOne.csv");
    }

    protected override void Update(GameTime gameTime)
    {
        //input update
        _KeyboardController.Update();
        _MouseController.Update();

        gel.Update();

        //link (player) update
        link.Update(gameTime);

        //check collision
        CollisionsCheck.collisionCheck(this);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {

        GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);

        room.Draw(_spriteBatch);
        gel.Draw(_spriteBatch);

        //Draw player link
        link.Draw(_spriteBatch);

        base.Draw(gameTime);
    }
}