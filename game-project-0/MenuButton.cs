using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using game_project_0.Screens;
namespace game_project_0
{


    public class MenuButton
    {

        //public string Text;
        //public string HelperText;
        private int x_offset;
        private int y_offset;
        private int Helper_x_Offset = 0;
        private int Helper_y_Offset = 0;
        //public Vector2 Position;
        //public MenuButtonState Type;

        private static Vector2 helperPosition = new Vector2(300, 430);
        private Texture2D texture;
        private Texture2D texture_hov;
        //private SpriteFont font;

        private string _text;
        private string _helperText;
        private Vector2 _position;
        private float _selectionFade;

        public string Text
        {
            private get => _text;
            set => _text = value;
        }

        public string HelperText
        {
            private get => _helperText;
            set => _helperText = value;
        }

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public int X_Offset
        {
            get => x_offset;
            set => x_offset = value;
        }

        public int Y_Offset
        {
            get => y_offset;
            set => y_offset = value;
        }

        public int HelperX_Offset
        {
            get => Helper_x_Offset;
            set => Helper_x_Offset = value;
        }

        public int HelperY_Offset
        {
            get => Helper_y_Offset;
            set => Helper_y_Offset = value;
        }

        public event EventHandler<PlayerIndexEventArgs> Selected;

        protected internal virtual void OnSelectEntry(PlayerIndex playerIndex)
        {
            Selected?.Invoke(this, new PlayerIndexEventArgs(playerIndex));
        }

        public MenuButton(string text, Vector2 position, string helperText, int x_offset, int y_offset, int helper_x_offset, int helper_y_offset)
        {
            _text = text;
            _position = position;
            _helperText = helperText;
            this.x_offset = x_offset;
            this.y_offset = y_offset;
            Helper_x_Offset = helper_x_offset;
            Helper_y_Offset = helper_y_offset;

        }

        /// <summary>
        /// Load textures for button and selected buttan as well as spritefont
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {

            texture = content.Load<Texture2D>("grey_button");
            //font = content.Load<SpriteFont>("kenvector_thin");
            texture_hov = content.Load<Texture2D>("grey_button_hover");
        }

        public void Update(MenuScreen screen, bool isSelected, GameTime gameTime)
        {
            float fadeSpeed = (float)gameTime.ElapsedGameTime.TotalSeconds * 4;

            if (isSelected)
                _selectionFade = Math.Min(_selectionFade + fadeSpeed, 1);
            else
                _selectionFade = Math.Max(_selectionFade - fadeSpeed, 0);
        }
        /// <summary>
        /// Draw buttons onto menu
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(MenuScreen screen, bool isSelected, GameTime gameTime)
        { 
            var text_pos = offsetText(Position, x_offset, y_offset);
            var screenManager = screen.ScreenManager;
            var spriteBatch = screenManager.SpriteBatch;
            var font = screenManager.Font;
            if (isSelected)
            {
                spriteBatch.Draw(texture_hov, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
                drawSelectString(screen, text_pos, spriteBatch);
            }
            else
            {
                spriteBatch.Draw(texture, Position, null, Color.LightGray, 0f, new Vector2(95, 24.5f), 1.0f, SpriteEffects.None, 0);
                spriteBatch.DrawString(font, Text, text_pos, Color.Black);
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
        private void drawSelectString(MenuScreen screen, Vector2 text_position, SpriteBatch spriteBatch)
        {
            var helper_pos = offsetText(helperPosition, Helper_x_Offset, Helper_y_Offset);
            spriteBatch.DrawString(screen.ScreenManager.Font, Text, text_position, Color.CornflowerBlue);
            spriteBatch.DrawString(screen.ScreenManager.Font, HelperText, helper_pos, Color.White);
        }

        public virtual int GetHeight(MenuScreen screen)
        {
            return screen.ScreenManager.Font.LineSpacing;
        }

        public virtual int GetWidth(MenuScreen screen)
        {
            return (int)screen.ScreenManager.Font.MeasureString(Text).X;
        }


    }

}
