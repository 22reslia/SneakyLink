using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SneakyLink.Blocks;
using SneakyLink.Collision;
using SneakyLink.Commands;
using SneakyLink.Enemies;
using SneakyLink.Inventory;
using SneakyLink.Player;
using SneakyLink.Scene;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SneakyLink;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    //bool to choose which scene is showing
    public bool isTitleScene;
    public bool isDungeonScene;
    public bool isInventoryScene;

    //Controllers for input
    private IController<Keys> titleKeyboardController;
    private IController<Keys> playerKeyboardController;
    private IController<Keys> menuKeyboardController;
    private IController<MouseButton> playerMouseController;
    private IController<MouseButton> menuMouseController;
    //private ICommand initialize;w

    public Player.Link link;
    public List<ISprite> itemList;

    //title scene info
    private TitleScene titleScene;

    //inventory scene info
    private InventoryScene inventoryScene;

    //dungeon scene info
    public Room room;
    //the collision box of elements in the room
    public List<IBlock> blocks = new List<IBlock>();
    public List<Doors> doors = new List<Doors>();
    public List<CollisionBox> boundaryCollisionBox = new List<CollisionBox>();

    public List<IEnemy> enemies = new List<IEnemy>();

    //public int sceneCount;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        //set the window size
        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferHeight = 640;
        _graphics.ApplyChanges();

        titleKeyboardController = new KeyboardController();
        playerKeyboardController = new KeyboardController();
        playerMouseController = new MouseController(this);
        menuKeyboardController = new KeyboardController();
        menuMouseController = new MouseController(this);

        //the first showing scene should be title
        isTitleScene = true;
        isDungeonScene = false;
        isInventoryScene = false;

        //initializes Link contructor
        link = new Link();

        //initializes all object
        InitializeObject.initializeObject(this);

        //Initilizing player related Commands
        playerKeyboardController.RegisterCommand(Keys.Right, new MoveRight(link), false);
        playerKeyboardController.RegisterCommand(Keys.D, new MoveRight(link), false);
        playerKeyboardController.RegisterCommand(Keys.Left, new MoveLeft(link), false);
        playerKeyboardController.RegisterCommand(Keys.A, new MoveLeft(link), false);
        playerKeyboardController.RegisterCommand(Keys.Up, new MoveUp(link), false);
        playerKeyboardController.RegisterCommand(Keys.W, new MoveUp(link), false);
        playerKeyboardController.RegisterCommand(Keys.Down, new MoveDown(link), false);
        playerKeyboardController.RegisterCommand(Keys.S, new MoveDown(link), false);
        playerKeyboardController.RegisterCommand(Keys.Z, new WoodenAttack(link), false);
        playerKeyboardController.RegisterCommand(Keys.N, new WoodenAttack(link), false);
        playerKeyboardController.RegisterCommand(Keys.D1, new UseItem(link), false);
        playerKeyboardController.RegisterCommand(Keys.D2, new UseItem(link), false);
        playerKeyboardController.RegisterCommand(Keys.D3, new UseItem(link), false);

        //Initilizing menu related Commands to specific keys
        titleKeyboardController.RegisterCommand(Keys.Enter, new StartGameCommand(this), true);
        menuKeyboardController.RegisterCommand(Keys.Tab, new SwitchInventoryCommand(this), true);
        menuKeyboardController.RegisterCommand(Keys.Q, new GameExit(this), true);

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
        titleScene = new TitleScene(this);
        inventoryScene = new InventoryScene(this);
        room = new Room(this, "..\\..\\..\\Scene\\RoomOne.csv");
    }

    protected override void Update(GameTime gameTime)
    {
        //input update
        if (!isTitleScene)
        {
            menuKeyboardController.Update();
        }
        else
        {
            titleKeyboardController.Update();
        }
        menuMouseController.Update();
        if (isDungeonScene)
        {
            playerKeyboardController.Update();
            playerMouseController.Update();
            foreach (IEnemy enemy in enemies)
            {
                enemy.Update();
            }

            //link (player) update
            link.Update(gameTime);

            //check collision
            CollisionsCheck.collisionCheck(this);
        }

        inventoryScene.Update();

        //Check player, enemy and item state
        ObjectUnload.objectUnload(this);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {

        GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);

        //check which scene is it
        if (isTitleScene)
        {
            titleScene.Draw(_spriteBatch);
        }
        if (isDungeonScene)
        {
            room.Draw(_spriteBatch);
            foreach (IEnemy enemy in enemies)
            {
                enemy.Draw(_spriteBatch);
            }
            //Draw player link
            link.Draw(_spriteBatch);
        }
        if (isInventoryScene)
        {
            inventoryScene.Draw(_spriteBatch);
        }
        else if (!isInventoryScene && !isTitleScene)
        {
            inventoryScene.DrawOnScene(_spriteBatch);
        }
        base.Draw(gameTime);
    }
}