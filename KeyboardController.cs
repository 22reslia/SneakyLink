using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class KeyboardController : IController<Keys>
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private bool wasYKeyPressed;
        private bool wasTKeyPressed;
        private bool wasIKeyPressed;
        private bool wasUKeyPressed;
        private double lastKeyPressTime;
        private const double debounceTime = 100;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            wasYKeyPressed = false;
            wasTKeyPressed = false;
            wasIKeyPressed = false;
            wasUKeyPressed = false;
            lastKeyPressTime = 0;
        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Keys[] pressedKeys = keyboardState.GetPressedKeys();
            bool isYKeyPressed = keyboardState.IsKeyDown(Keys.Y);
            bool isTKeyPressed = keyboardState.IsKeyDown(Keys.T);
            bool isIKeyPressed = keyboardState.IsKeyDown(Keys.I);
            bool isUKeyPressed = keyboardState.IsKeyDown(Keys.U);
            double currentTime = gameTime.TotalGameTime.TotalMilliseconds;

            if (isYKeyPressed && !wasYKeyPressed && (currentTime - lastKeyPressTime > debounceTime))
            {
                if (controllerMappings.ContainsKey(Keys.Y))
                {
                    controllerMappings[Keys.Y].Execute();
                }
                lastKeyPressTime = currentTime;
            }

            if (isTKeyPressed && !wasTKeyPressed && (currentTime - lastKeyPressTime > debounceTime))
            {
                if (controllerMappings.ContainsKey(Keys.T))
                {
                    controllerMappings[Keys.T].Execute();
                }
                lastKeyPressTime = currentTime;
            }

            if (isIKeyPressed && !wasIKeyPressed && (currentTime - lastKeyPressTime > debounceTime))
            {
                if (controllerMappings.ContainsKey(Keys.I))
                {
                    controllerMappings[Keys.I].Execute();
                }
                lastKeyPressTime = currentTime;
            }

            if (isUKeyPressed && !wasUKeyPressed && (currentTime - lastKeyPressTime > debounceTime))
            {
                if (controllerMappings.ContainsKey(Keys.U))
                {
                    controllerMappings[Keys.U].Execute();
                }
                lastKeyPressTime = currentTime;
            }
            wasYKeyPressed = isYKeyPressed;
            wasTKeyPressed = isTKeyPressed;
            wasIKeyPressed = isIKeyPressed;
            wasUKeyPressed = isUKeyPressed;
        }
    }
}
