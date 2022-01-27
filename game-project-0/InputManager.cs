using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace game_project_0
{
    public enum MenuButtonState
    {
        Quit,
        Settings,
        Play,
        None,
        Esc
    }
    public class InputManager
    {
        KeyboardState currentKeyboardState;
        KeyboardState priorKeyboardState;

        MouseState currentMouseState;
        MouseState priorMouseState;

        GamePadState currentGamePadState;
        GamePadState priorGamePadState;

        public MenuButtonState Selection { get; private set; } = MenuButtonState.None;

        

        public void Update(GameTime gameTime)
        {
            priorKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            priorGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(0);

            priorMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if((currentKeyboardState.IsKeyDown(Keys.S) && priorKeyboardState.IsKeyUp(Keys.S)) || 
                (currentKeyboardState.IsKeyDown(Keys.Down) && priorKeyboardState.IsKeyUp(Keys.Down)) ||
                    (currentGamePadState.ThumbSticks.Left.Y < 0 && priorGamePadState.ThumbSticks.Left.Y == 0) || 
                    (currentGamePadState.DPad.Down == ButtonState.Pressed && priorGamePadState.DPad.Down == ButtonState.Released))
            
            {
                
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

            if((currentKeyboardState.IsKeyDown(Keys.W) && priorKeyboardState.IsKeyUp(Keys.W)) || 
                (currentKeyboardState.IsKeyDown(Keys.Up) && priorKeyboardState.IsKeyUp(Keys.Up)) ||
                    (currentGamePadState.ThumbSticks.Left.Y > 0 && priorGamePadState.ThumbSticks.Left.Y == 0) ||
                    (currentGamePadState.DPad.Up == ButtonState.Pressed && priorGamePadState.DPad.Up == ButtonState.Released))
            {
                
                if (Selection == MenuButtonState.None)
                {
                    Selection = MenuButtonState.Quit;
                }
                else if (Selection == MenuButtonState.Play)
                {
                    Selection = MenuButtonState.Quit;
                }
                else
                {
                    Selection += 1;
                }
            }

            if((currentKeyboardState.IsKeyDown(Keys.Enter) || currentGamePadState.Buttons.A == ButtonState.Pressed) && Selection == MenuButtonState.Quit)
            {
                Selection = MenuButtonState.Esc;
            }

            


        }
    }
}
