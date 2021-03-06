using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace game_project_0
{

    /// <summary>
    /// Enum containing MenuStates
    /// </summary>
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

        public List<MenuButton> menuItems = new List<MenuButton>();

        /// <summary>
        /// The user's menu selection
        /// </summary>
        public MenuButtonState Selection { get; private set; } = MenuButtonState.None;

        
        /// <summary>
        /// Updates user input within the game
        /// </summary>
        /// <param name="gameTime">elapsed game time</param>
        public void Update(GameTime gameTime)
        {
            priorKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            priorGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(0);

            priorMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();


            //Mouse Input
            foreach (var menuItem in menuItems)
            {
                if ((currentMouseState.X > menuItem.Position.X - 150 && currentMouseState.Y < menuItem.Position.Y + 49) && (priorMouseState.X != currentMouseState.X && priorMouseState.Y != currentMouseState.Y))
                {
                    //Selection = menuItem.Type;


                }
            }


            //Y-Axis Movement (Keyboard, GamePad)
            if ((currentKeyboardState.IsKeyDown(Keys.S) && priorKeyboardState.IsKeyUp(Keys.S)) || 
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

            //X-Axis Movement (Keyboard, GamePad)
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

            //Transition GameState to Exit on specific input
            if((currentKeyboardState.IsKeyDown(Keys.Enter) || currentGamePadState.Buttons.A == ButtonState.Pressed || currentMouseState.LeftButton == ButtonState.Pressed)  && Selection == MenuButtonState.Quit)
            {
                Selection = MenuButtonState.Esc;
            }

            
            

            


        }
    }
}
