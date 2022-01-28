using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace game_project_0
{


    public class MenuButton
    {

        public string Text;
        public string HelperText;
        public int X_Offset;
        public int Y_Offset;
        public int HelperX_Offset = 0;
        public int HelperY_Offset = 0;
        public Vector2 Position;
        public MenuButtonState Type;

        private static Vector2 helperPosition = new Vector2(300, 430);
        private Texture2D texture;
        private Texture2D texture_hov;
        private SpriteFont font;

        /// <summary>
        /// Load textures for button and selected buttan as well as spritefont
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {

            texture = content.Load<Texture2D>("grey_button");
            font = content.Load<SpriteFont>("kenvector_thin");
            texture_hov = content.Load<Texture2D>("grey_button_hover");
        }

        /// <summary>
        /// Draw buttons onto menu
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        { 
            var text_pos = offsetText(Position, X_Offset, Y_Offset);

            spriteBatch.Draw(texture, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, Text, text_pos, Color.Black);
        }

        
        /// <summary>
        /// Based on MenuButton state select menu button (controlled by user input)
        /// </summary>
        /// <param name="gameTime">elapsed game time</param>
        /// <param name="menuButton">state of menu button</param>
        /// <param name="spriteBatch">spritebatch to draw</param>
        public void Select(GameTime gameTime, MenuButtonState menuButton, SpriteBatch spriteBatch)
        {

            var text_pos = offsetText(Position, X_Offset, Y_Offset);

            switch (menuButton)
            {
                case MenuButtonState.Play:
                    spriteBatch.Draw(texture_hov, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
                    drawSelectString(text_pos, spriteBatch);
                    break;
                case MenuButtonState.Settings:
                    spriteBatch.Draw(texture_hov, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
                    drawSelectString(text_pos, spriteBatch);
                    break;
                case MenuButtonState.Quit:
                    spriteBatch.Draw(texture_hov, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
                    drawSelectString(text_pos, spriteBatch);
                    break;
                default:
                    spriteBatch.Draw(texture, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
                    spriteBatch.DrawString(font, Text, text_pos, Color.CornflowerBlue);
                    break;
            }
        }

        /// <summary>
        /// Helper method for offsetting text for better center position
        /// </summary>
        /// <param name="position"></param>
        /// <param name="x_offset"></param>
        /// <param name="y_offset"></param>
        /// <returns>New offset position</returns>
        private Vector2 offsetText(Vector2 position, int x_offset, int y_offset)
        {
            float offset_x = position.X + x_offset;
            float offset_y = position.Y + y_offset;
            return new Vector2(offset_x, offset_y);
        }

        /// <summary>
        /// Helper method for drawing Text for menu button state
        /// </summary>
        /// <param name="text_position">position to draw main text</param>
        /// <param name="spriteBatch">spritebatch to draw</param>
        private void drawSelectString(Vector2 text_position, SpriteBatch spriteBatch)
        {
            var helper_pos = offsetText(helperPosition, HelperX_Offset, HelperY_Offset);
            spriteBatch.DrawString(font, Text, text_position, Color.CornflowerBlue);
            spriteBatch.DrawString(font, HelperText, helper_pos, Color.White);
        }


    }

}
