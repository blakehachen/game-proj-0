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
        public int X_Offset;
        public int Y_Offset;
        public Vector2 Position;
        public MenuButtonState Type;

        private Texture2D texture;
        private Texture2D texture_hov;
        private SpriteFont font;
        
        public void LoadContent(ContentManager content)
        {
            
            texture = content.Load<Texture2D>("grey_button");
            font = content.Load<SpriteFont>("kenvector_thin");
            texture_hov = content.Load<Texture2D>("grey_button_hover");
        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            float center_x = Position.X + X_Offset;
            float center_y = Position.Y + Y_Offset;
            
            var text_pos = new Vector2(center_x, center_y);

            spriteBatch.Draw(texture, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, Text, text_pos, Color.Black);
        }
        
        public void Select(GameTime gameTime, MenuButtonState menuButton, SpriteBatch spriteBatch)
        {
            float center_x = Position.X + X_Offset;
            float center_y = Position.Y + Y_Offset;

            var text_pos = new Vector2(center_x, center_y);

            switch (menuButton)
            {
                case MenuButtonState.Play:
                    spriteBatch.Draw(texture_hov, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
                    spriteBatch.DrawString(font, Text, text_pos, Color.CornflowerBlue);
                    break;
                case MenuButtonState.Settings:
                    spriteBatch.Draw(texture_hov, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
                    spriteBatch.DrawString(font, Text, text_pos, Color.CornflowerBlue);
                    break;
                case MenuButtonState.Quit:
                    spriteBatch.Draw(texture_hov, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
                    spriteBatch.DrawString(font, Text, text_pos, Color.CornflowerBlue);
                    break;
                default:
                    spriteBatch.Draw(texture, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
                    spriteBatch.DrawString(font, Text, text_pos, Color.CornflowerBlue);
                    break;
            }
        }
        
        
    }
}
