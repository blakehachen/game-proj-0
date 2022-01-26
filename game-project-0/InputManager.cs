using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game_project_0
{
    public enum MenuButtonState
    {
        Quit,
        Settings,
        Play,
        None
    }
    public class InputManager
    {
        KeyboardState currentKeyboardState;
        KeyboardState priorKeyboardState;
        MouseState currentMouseState;
        MouseState priorMouseState;
        GamePadState currentGamePadState;
        GamePadState priorGamePadState;
        MenuButtonState priorMenuButtonState;

        public MenuButtonState Selection { get; private set; } = MenuButtonState.None;

        public Vector2 Direction { get; private set; }

        public void Update(GameTime gameTime)
        {
            priorKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            if((currentKeyboardState.IsKeyDown(Keys.S) && priorKeyboardState.IsKeyUp(Keys.S)) || (currentKeyboardState.IsKeyDown(Keys.Down) && priorKeyboardState.IsKeyUp(Keys.Down)))
            {
                priorMenuButtonState = Selection;
                if (Selection == MenuButtonState.None)
                {
                    Selection = MenuButtonState.Play;
                }else if (Selection == MenuButtonState.Quit)
                {
                    Selection = MenuButtonState.Play;
                }
                else
                {
                    Selection -= 1;
                } 
            }

            if((currentKeyboardState.IsKeyDown(Keys.W) && priorKeyboardState.IsKeyUp(Keys.W)) || (currentKeyboardState.IsKeyDown(Keys.Up) && priorKeyboardState.IsKeyUp(Keys.Up)))
            {
                priorMenuButtonState = Selection;
                if(Selection == MenuButtonState.None)
                {
                    Selection = MenuButtonState.Quit;
                }else if(Selection == MenuButtonState.Play)
                {
                    Selection = MenuButtonState.Quit;
                }
                else
                {
                    Selection += 1;
                }
            }

            


        }
    }
}
