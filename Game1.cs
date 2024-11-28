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
using SneakyLink.Scene;
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

    public Player.Link link;

    //title scene info
    private TitleScene titleScene;

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
    //the collision box of elements in the room
    //public List<IBlock> blocks = new List<IBlock>();
    //public List<Doors> doors = new List<Doors>();
    public List<CollisionBox> boundaryCollisionBox = new List<CollisionBox>();

    public List<IItem> itemList = new List<IItem>();
    public List<IEnemy> enemies = new List<IEnemy>();

    public int sceneCount;
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
        menuKeyboardController.RegisterCommand(Keys.R, new ResetCommand(this), true);

        //Initilizing game win and over related Commands to specific keys
        gameOverKeyboardController.RegisterCommand(Keys.Q, new GameExit(this), true);
        gameOverKeyboardController.RegisterCommand(Keys.R, new ResetCommand(this), true);

        //debug change room
        menuMouseController.RegisterCommand(MouseButton.Left, new PreviousSceneCommand(this), true);
        menuMouseController.RegisterCommand(MouseButton.Right, new NextSceneCommand(this), true);
        sceneCount = 0;
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
        gameOverScene = new GameOverScene(this);
        roomTransmission = new RoomTransmission(GraphicsDevice);

        //load room
        this.roomList = new Dictionary<string, Room>();
        this.roomList.Add("Room0", new Room(this, "..\\..\\..\\Scene\\RoomZero.csv"));
        this.roomList.Add("Room1", new Room(this, "..\\..\\..\\Scene\\RoomOne.csv"));
        this.roomList.Add("Room2", new Room(this, "..\\..\\..\\Scene\\RoomTwo.csv"));
        this.roomList.Add("Room3", new Room(this, "..\\..\\..\\Scene\\RoomThree.csv"));
        this.roomList.Add("Room4", new Room(this, "..\\..\\..\\Scene\\RoomFour.csv"));
        this.roomList.Add("Room5", new Room(this, "..\\..\\..\\Scene\\RoomFive.csv"));
        this.roomList.Add("Room6", new Room(this, "..\\..\\..\\Scene\\RoomSix.csv"));
        this.roomList.Add("Room7", new Room(this, "..\\..\\..\\Scene\\RoomSeven.csv"));
        this.roomList.Add("Room8", new Room(this, "..\\..\\..\\Scene\\RoomEight.csv"));
        this.roomList.Add("Room9", new Room(this, "..\\..\\..\\Scene\\RoomNine.csv"));
        this.roomList.Add("Room10", new Room(this, "..\\..\\..\\Scene\\RoomTen.csv"));
        this.roomList.Add("Room11", new Room(this, "..\\..\\..\\Scene\\RoomEleven.csv"));
        this.roomList.Add("Room12", new Room(this, "..\\..\\..\\Scene\\RoomTwelve.csv"));
        this.roomList.Add("Room13", new Room(this, "..\\..\\..\\Scene\\RoomThirteen.csv"));
        this.roomList.Add("Room14", new Room(this, "..\\..\\..\\Scene\\RoomFourteen.csv"));
        this.roomList.Add("Room15", new Room(this, "..\\..\\..\\Scene\\RoomFifteen.csv"));
        this.roomList.Add("Room16", new Room(this, "..\\..\\..\\Scene\\RoomSixteen.csv"));
        this.roomList.Add("Room17", new Room(this, "..\\..\\..\\Scene\\RoomSeventeen.csv"));
        room = roomList["Room1"];
        enemies = room.enemyList;
        itemList = room.itemList;
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