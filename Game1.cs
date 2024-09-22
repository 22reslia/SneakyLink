using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SneakyLink;

public class Game1 : Game
{
    public GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    //Controllers for input
    private IController<Keys> _KeyboardController;
    private IController<MouseButton> _MouseController;

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
        _KeyboardController = new KeyboardController();
        _MouseController = new MouseController(this);

        _KeyboardController.RegisterCommand(Keys.O, new PreviousEnemyCommand(this));
        _KeyboardController.RegisterCommand(Keys.P, new NextEnemyCommand(this));
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        EnemySpriteFactory.Instance.LoadAllTextures(Content);

        //all these code and link initial should be put into a command since press 'r' should reset all
        IEnemy Keese = new Keese();
        IEnemy Zol = new Zol();
        IEnemy Aquamentus = new Aquamentus();
        IEnemy Gel = new Gel();
        IEnemy Goriya = new Goriya();
        IEnemy Stalfos = new Stalfos();
        enemyList = new List<IEnemy>();
        enemyList.Add(Keese);
        enemyList.Add(Zol);
        enemyList.Add(Aquamentus);
        enemyList.Add(Gel);
        enemyList.Add(Goriya);
        enemyList.Add(Stalfos);
        currentEnemy = enemyList[0];
    }

    protected override void Update(GameTime gameTime)
    {
        currentEnemy.Update();
        _KeyboardController.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        currentEnemy.Draw(_spriteBatch);

        base.Draw(gameTime);
    }
}
