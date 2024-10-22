using System.Collections.Generic;
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
    private Game1 game;
    private MouseState oldMouseState;

    public MouseController(Game1 game)
    {
        controllerMappings = new Dictionary<MouseButton, ICommand>();
        this.game = game;
        oldMouseState = Mouse.GetState();
    }
    public void RegisterCommand(MouseButton button, ICommand command)
    {
        controllerMappings[button] = command;
    }

    public void Update()
    {
        MouseState newMouseState = Mouse.GetState();
        if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released && controllerMappings.ContainsKey(MouseButton.Left))
        {
            controllerMappings[MouseButton.Left].Execute();
        }

        if (newMouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released && controllerMappings.ContainsKey(MouseButton.Right))
        {
            controllerMappings[MouseButton.Right].Execute();
        }

        oldMouseState = newMouseState;
    }
}