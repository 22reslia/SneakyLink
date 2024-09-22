using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Windows.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SneakyLink;

public class KeyboardController : IController<Keys>
{
    private Dictionary<Keys, ICommand> controllerMappings;

    public KeyboardController()
    {
        controllerMappings = new Dictionary<Keys, ICommand>();
    }
    public void RegisterCommand(Keys key, ICommand command)
    {
        controllerMappings.Add(key, command);
    }

    public void Update()
    {
        Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

        foreach (Keys key in pressedKeys)
        {
            if (controllerMappings.ContainsKey(key))
            {
                controllerMappings[key].Execute();
            }
        }
    }
}
public class MouseController : IController<MouseButton>
{

    private Dictionary<MouseButton, ICommand> controllerMappings;
    private MouseState oldState;
    private Game1 game;

    public MouseController(Game1 game)
    {
        controllerMappings = new Dictionary<MouseButton, ICommand>();
        this.game = game;
    }
    public void RegisterCommand(MouseButton button, ICommand command)
    {
        controllerMappings.Add(button, command);
    }

    public void Update()
    {
        MouseState newState = Mouse.GetState();

        if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released && newState.X <= game._graphics.PreferredBackBufferWidth / 2 && newState.Y <= game._graphics.PreferredBackBufferHeight / 2)
        {
            controllerMappings[MouseButton.leftButton0].Execute();
        }
        else if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released && newState.X >= game._graphics.PreferredBackBufferWidth / 2 && newState.Y <= game._graphics.PreferredBackBufferHeight / 2)
        {
            controllerMappings[MouseButton.leftButton1].Execute();
        }
        else if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released && newState.X <= game._graphics.PreferredBackBufferWidth / 2 && newState.Y >= game._graphics.PreferredBackBufferHeight / 2)
        {
            controllerMappings[MouseButton.leftButton2].Execute();
        }
        else if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released && newState.X >= game._graphics.PreferredBackBufferWidth / 2 && newState.Y >= game._graphics.PreferredBackBufferHeight / 2)
        {
            controllerMappings[MouseButton.leftButton3].Execute();
        }
        else if (newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
        {
            controllerMappings[MouseButton.rightButton].Execute();
        }

        oldState = newState;
    }
}