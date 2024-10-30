using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SneakyLink.Blocks;
using SneakyLink.Collision;
using SneakyLink.Commands;
using SneakyLink.Enemies;
using SneakyLink.Player;
using SneakyLink.Scene;
using System.Collections.Generic;

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
    private IController<Keys> _KeyboardController;
    private IController<MouseButton> _MouseController;
    //private ICommand initialize;w

    public Player.Link link;
    public List<ISprite> itemList;

    //title scene info
    private IScene titleScene;

    //inventory scene info
    private InventoryScene inventoryScene;

    //dungeon scene info
    public Room room;
    //the collision box of elements in the room
    public List<IBlock> blocks = new List<IBlock>();
    public List<IBlock> doors = new List<IBlock>();
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
        _KeyboardController = new KeyboardController();
        _MouseController = new MouseController(this);

        //the first showing scene should be title
        isTitleScene = true;
        isDungeonScene = false;
        isInventoryScene = false;
        MediaPlayer.Volume = 0.5f;

        //initializes Link contructor
        link = new Link();

        //initializes all object
        InitializeObject.initializeObject(this);

        //Initilizing Commands to specific keys
        _KeyboardController.RegisterCommand(Keys.Q, new GameExit(this), false);
        _KeyboardController.RegisterCommand(Keys.Right, new MoveRight(link), false);
        _KeyboardController.RegisterCommand(Keys.D, new MoveRight(link), false);
        _KeyboardController.RegisterCommand(Keys.Left, new MoveLeft(link), false);
        _KeyboardController.RegisterCommand(Keys.A, new MoveLeft(link), false);
        _KeyboardController.RegisterCommand(Keys.Up, new MoveUp(link), false);
        _KeyboardController.RegisterCommand(Keys.W, new MoveUp(link), false);
        _KeyboardController.RegisterCommand(Keys.Down, new MoveDown(link), false);
        _KeyboardController.RegisterCommand(Keys.S, new MoveDown(link), false);
        _KeyboardController.RegisterCommand(Keys.Z, new WoodenAttack(link), false);
        _KeyboardController.RegisterCommand(Keys.N, new WoodenAttack(link), false);
        _KeyboardController.RegisterCommand(Keys.E, new DamagePlayer(link), false);
        _KeyboardController.RegisterCommand(Keys.D1, new UseItem(link), false);
        _KeyboardController.RegisterCommand(Keys.D2, new UseItem(link), false);
        _KeyboardController.RegisterCommand(Keys.D3, new UseItem(link), false);

        //command for start game and change scene
        _MouseController.RegisterCommand(MouseButton.Left, new StartGameCommand(this), true);
        _KeyboardController.RegisterCommand(Keys.Tab, new SwitchInventoryCommand(this), true);

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
        //if (!isTitleScene)
        //{
            _KeyboardController.Update();
        //}
        _MouseController.Update();

        if (isDungeonScene)
        {
            foreach (IEnemy enemy in enemies)
            {
                enemy.Update();
            }

            //link (player) update
            link.Update(gameTime);

            //check collision
            CollisionsCheck.collisionCheck(this);
        }
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

        }
        base.Draw(gameTime);
    }
}