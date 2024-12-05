using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SneakyLink.Blocks;
using SneakyLink.Collision;
using SneakyLink.Commands;
using SneakyLink.Enemies;
using SneakyLink.Inventory;
using SneakyLink.Items;
using SneakyLink.Player;
using SneakyLink.Projectiles;
using SneakyLink.Scene;
using SneakyLink.Boss;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SneakyLink;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    //the game state
    public GameState gameState;

    //Controllers for input
    private IController<Keys> titleKeyboardController;
    private IController<Keys> playerKeyboardController;
    private IController<Keys> menuKeyboardController;
    private IController<Keys> gameOverKeyboardController;
    private IController<MouseButton> playerMouseController;
    private IController<MouseButton> menuMouseController;

    public IController<Keys> PlayerKeyboardController { get => playerKeyboardController; set => playerKeyboardController = value; }

    public Player.Link link;

    //player sound effects
    public PlayerSounds playerSounds;

    //item sound effefcts
    public ItemSounds itemSounds;

    //title scene info
    public TitleScene titleScene;

    //inventory scene info
    private InventoryScene inventoryScene;

    //game over scene info
    private GameOverScene gameOverScene;

    //roomtransmission info
    private RoomTransmission roomTransmission;
    public string nextRoomFilePath;

    //dungeon scene info
    public Dictionary<string, Room> roomList;
    public Room room;
    public Room oldRoom;
    public List<CollisionBox> boundaryCollisionBox = new List<CollisionBox>();

    public List<IItem> itemList = new List<IItem>();
    public List<IEnemy> enemies = new List<IEnemy>();
    public List<IProjectile> projectileList = new List<IProjectile>();
    public Providence boss;
    public bool isMuted = false; // Tracks the mute state


    public int sceneCount;
    public bool mapPicked;
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
        gameOverKeyboardController = new KeyboardController();

        //the first showing scene should be title
        gameState = GameState.Title;

        //initializes Link contructor
        link = new Link(this);

        // Initialize and load sound effects
        playerSounds = new PlayerSounds();
        playerSounds.LoadPlayerSoundEffects(this);

        //Initialize ItemSounds
        itemSounds = new ItemSounds();

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
        playerKeyboardController.RegisterCommand(Keys.J, new WoodenAttack(link, playerSounds), false);
        playerKeyboardController.RegisterCommand(Keys.K, new UseItem(link), true);
        playerKeyboardController.RegisterCommand(Keys.H, new DrinkRedpotion(link), true);

        //Initilizing menu related Commands to specific keys
        titleKeyboardController.RegisterCommand(Keys.Enter, new StartGameCommand(this), true);
        menuKeyboardController.RegisterCommand(Keys.Tab, new SwitchInventoryCommand(this), true);
        menuKeyboardController.RegisterCommand(Keys.Q, new GameExit(this), true);
        menuKeyboardController.RegisterCommand(Keys.R, new ResetCommand(this), true);

        //Initilizing game win and over related Commands to specific keys
        gameOverKeyboardController.RegisterCommand(Keys.Q, new GameExit(this), true);
        gameOverKeyboardController.RegisterCommand(Keys.R, new ResetCommand(this), true);

        //debug change room
        menuMouseController.RegisterCommand(MouseButton.Left, new PreviousSceneCommand(this), true);
        menuMouseController.RegisterCommand(MouseButton.Right, new NextSceneCommand(this), true);
        sceneCount = 0;

        playerKeyboardController.RegisterCommand(Keys.M, new MuteCommand(this), true);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        EnemySpriteFactory.Instance.LoadAllTextures(Content);
        Player.PlayerSpriteFactory.Instance.LoadAllTextures(Content);
        Blocks.BlockSpriteFactory.Instance.LoadAllTextrues(Content);
        Items.ItemSpriteFactory.Instance.LoadAllTextrues(Content);

        //load room
        roomList = new Dictionary<string, Room>();
        roomList.Add("Room0", new Room(this, "..\\..\\..\\Scene\\RoomZero.csv"));
        roomList.Add("Room1", new Room(this, "..\\..\\..\\Scene\\RoomOne.csv"));
        roomList.Add("Room2", new Room(this, "..\\..\\..\\Scene\\RoomTwo.csv"));
        roomList.Add("Room3", new Room(this, "..\\..\\..\\Scene\\RoomThree.csv"));
        roomList.Add("Room4", new Room(this, "..\\..\\..\\Scene\\RoomFour.csv"));
        roomList.Add("Room5", new Room(this, "..\\..\\..\\Scene\\RoomFive.csv"));
        roomList.Add("Room6", new Room(this, "..\\..\\..\\Scene\\RoomSix.csv"));
        roomList.Add("Room7", new Room(this, "..\\..\\..\\Scene\\RoomSeven.csv"));
        roomList.Add("Room8", new Room(this, "..\\..\\..\\Scene\\RoomEight.csv"));
        roomList.Add("Room9", new Room(this, "..\\..\\..\\Scene\\RoomNine.csv"));
        roomList.Add("Room10", new Room(this, "..\\..\\..\\Scene\\RoomTen.csv"));
        roomList.Add("Room11", new Room(this, "..\\..\\..\\Scene\\RoomEleven.csv"));
        roomList.Add("Room12", new Room(this, "..\\..\\..\\Scene\\RoomTwelve.csv"));
        roomList.Add("Room13", new Room(this, "..\\..\\..\\Scene\\RoomThirteen.csv"));
        roomList.Add("Room14", new Room(this, "..\\..\\..\\Scene\\RoomFourteen.csv"));
        roomList.Add("Room15", new Room(this, "..\\..\\..\\Scene\\RoomFifteen.csv"));
        roomList.Add("Room16", new Room(this, "..\\..\\..\\Scene\\RoomSixteen.csv"));
        roomList.Add("Room17", new Room(this, "..\\..\\..\\Scene\\RoomSeventeen.csv"));
        roomList.Add("BossRoom", new Room(this, "..\\..\\..\\Scene\\BossRoom.csv"));
        room = roomList["Room1"];
        enemies = room.enemyList;
        itemList = room.itemList;

        link.SetSprite();
        titleScene = new TitleScene(this);
        inventoryScene = new InventoryScene(this);
        gameOverScene = new GameOverScene(this);
        roomTransmission = new RoomTransmission(GraphicsDevice);

        //load itemSounds
        itemSounds.LoadItemSoundEffects(this);

        //load boss
        boss = new Providence(290, 0, this);
    }

    protected override void Update(GameTime gameTime)
    {
        switch (gameState)
        {
            case GameState.Title:
                titleKeyboardController.Update();
                break;
            case GameState.Inventory:
                menuKeyboardController.Update();
                inventoryScene.Update();
                break;
            case GameState.RoomTransmission:
                roomTransmission.Update(gameTime);
                if (!roomTransmission.isTransitioningIn)
                {
                    room = roomList[nextRoomFilePath];
                    enemies = room.enemyList;
                    itemList = room.itemList;
                    projectileList.Clear();
                }
                if (roomTransmission.isTransmissionComplete)
                {
                    gameState = GameState.GamePlay;
                    roomTransmission.reset();
                }
                break;
            case GameState.GamePlay:
                playerKeyboardController.Update();
                playerMouseController.Update();
                menuKeyboardController.Update();
                menuMouseController.Update();
                foreach (IEnemy enemy in enemies)
                {
                    enemy.Update();
                }
                foreach(IItem item in itemList)
                {
                    item.Update();
                }
                //link (player) update
                link.Update(gameTime);
                //check collision
                if (room == roomList["BossRoom"])
                {
                    boss.Update(gameTime);
                    BossCollisionCheck.collisionCheck(this);
                }
                CollisionsCheck.collisionCheck(this);
                inventoryScene.Update();
                StateCheck.stateCheck(this);
                break;
            case GameState.GameOver:
                gameOverKeyboardController.Update();
                break;
            case GameState.GameWin:
                gameOverKeyboardController.Update();
                break;
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {

        GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
        switch (gameState)
        {
            case GameState.Title:
                titleScene.Draw(_spriteBatch);
                break;
            case GameState.Inventory:
                inventoryScene.Draw(_spriteBatch);
                break;
            case GameState.RoomTransmission:
                roomTransmission.Draw(_spriteBatch, oldRoom, room);
                break;
            case GameState.GamePlay:
                room.Draw(_spriteBatch);
                foreach (IEnemy enemy in enemies)
                {
                    enemy.Draw(_spriteBatch);
                }
                foreach (IItem item in itemList)
                {
                    item.Draw(_spriteBatch);
                }
                if (room == roomList["BossRoom"])
                {
                    boss.Draw(_spriteBatch);
                }
                //Draw player link
                link.Draw(_spriteBatch);
                inventoryScene.DrawOnScene(_spriteBatch);
                break;
            case GameState.GameOver:
                gameOverScene.Draw(_spriteBatch, false);
                break;
            case GameState.GameWin:
                gameOverScene.Draw(_spriteBatch, true);
                break;
        }
        base.Draw(gameTime);
    }
}