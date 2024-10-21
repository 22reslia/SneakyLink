using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using SneakyLink.Player;
using SneakyLink.Enemies;
using SneakyLink.Scene;
using SneakyLink.Collision;
using SneakyLink.Blocks;
using System.Drawing;

namespace SneakyLink;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    //for collision testing
    public Gel gel;

    //Controllers for input
    private IController<Keys> _KeyboardController;
    //private IController<MouseButton> _MouseController;
    private ICommand initialize;

    public IEnemy currentEnemy;
    public List<IEnemy> enemyList;

    public Player.Link link;
    //public List<ISprite> blockList;
    public List<ISprite> itemList;
    //public ISprite currentBlock;
    //public ISprite currentItem;

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

        //initializes Link contructor
        link = new Link();

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

        initialize = new InitializeObject(this);
        _KeyboardController.RegisterCommand(Keys.R, initialize);
        _KeyboardController.RegisterCommand(Keys.O, new PreviousEnemyCommand(this));
        _KeyboardController.RegisterCommand(Keys.P, new NextEnemyCommand(this));

        //_KeyboardController.RegisterCommand(Keys.Y, new NextBlockCommand(this));
        //_KeyboardController.RegisterCommand(Keys.T, new PreviousBlockCommand(this));
        //_KeyboardController.RegisterCommand(Keys.I, new NextItemCommand(this));
        //_KeyboardController.RegisterCommand(Keys.U, new PreviousItemCommand(this));

        _KeyboardController.RegisterCommand(Keys.M, new ChangeSceneCommand(this));

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

        initialize.Execute();

        //for collision testing
        gel = new Gel();

        room = new Room(this, "..\\..\\..\\Scene\\RoomOne.csv");
    }

    protected override void Update(GameTime gameTime)
    {
        //currentItem.Update();
        //input update
        _KeyboardController.Update();

        //current Enemy
        //currentEnemy.Update();

        //for collision test
        gel.Update();

        //link (player) update
        link.Update(gameTime);

        //CollisionDetector.CheckCollision(link.collisionBox, gel.collisionBox);

        //collision detect check for room element
        for (int x = 0; x < room.blockList.Count; x++)
        {
            if (blocks[x].CollisionBox != null)
            {
                CollisionType side = CollisionDetector.CheckCollision(link.collisionBox, blocks[x].CollisionBox);
                CollisionType side2 = CollisionDetector.CheckCollision(gel.CollisionBox, blocks[x].CollisionBox);
                if (side != CollisionType.None)
                {
                    PlayerBlockHandler.HandleCollision(link, side);
                }
                if (side2 != CollisionType.None)
                {
                    EnemyBlockHandler.HandleCollision(gel, side2);
                }
            }
        }
        for (int x = 0; x < boundaryCollisionBox.Count; x++)
        {
            link.collisionBox.side = CollisionDetector.CheckCollision(link.collisionBox, boundaryCollisionBox[x]);
            gel.CollisionBox.side = CollisionDetector.CheckCollision(gel.CollisionBox, boundaryCollisionBox[x]);
            if (link.collisionBox.side != CollisionType.None)
            {
                PlayerBlockHandler.HandleCollision(link, link.collisionBox.side);
                PlayerEnemyHandler.HandleCollision(link, link.collisionBox.side);
            }
            if (gel.CollisionBox.side != CollisionType.None)
            {
                EnemyBlockHandler.HandleCollision(gel, gel.CollisionBox.side);
            }

        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {

        GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);

        room.Draw(_spriteBatch);
        //currentBlock.Draw(_spriteBatch, 0, 0);
        //currentItem.Draw(_spriteBatch, 0, 0);

        //currentEnemy.Draw(_spriteBatch);

        //for collision testing
        gel.Draw(_spriteBatch);

        //Draw player link
        link.Draw(_spriteBatch);

        base.Draw(gameTime);
    }
}