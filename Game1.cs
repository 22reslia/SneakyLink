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

        EnemySpriteFactory.Instance.LoadAllTextures(Content);
        
        initialize.Execute();
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
