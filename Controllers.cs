using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Xna.Framework.Input;
using SneakyLink;

public class KeyboardController : IController<Keys>
{
    private Dictionary<Keys, ICommand> controllerMappings;
    private List<Keys> lastPressedKeys;
    private List<Keys> singleTriggerdKeys;

    public KeyboardController()
    {
        controllerMappings = new Dictionary<Keys, ICommand>();
        lastPressedKeys = new List<Keys>();
        singleTriggerdKeys = new List<Keys>();
    }
    public void RegisterCommand(Keys key, ICommand command, bool isSingleTriggered)
    {
        controllerMappings.Add(key, command);
        if (isSingleTriggered)
        {
            singleTriggerdKeys.Add(key);
        }
    }

    public void Update()
    {
        Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

        //check each key if is single triggled key
        foreach (Keys key in pressedKeys)
        {
            if (controllerMappings.ContainsKey(key))
            {
                if (singleTriggerdKeys.Contains(key))
                {
                    //if so, use the single triggered logic
                    if (!lastPressedKeys.Contains(key))
                    {
                        controllerMappings[key].Execute();
                        lastPressedKeys.Add(key);
                    }
                }
                else
                {
                    controllerMappings[key].Execute();
                }
            }  
        }

        //remove key from the last pressed list 
        lastPressedKeys.RemoveAll(key => !pressedKeys.Contains(key));
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
    public void RegisterCommand(MouseButton button, ICommand command, bool isSingleTriggered)
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