using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game_project_0
{
    public class GameProject0 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private ShipSprite ship;
        private Texture2D backgroundTexture;
        private SpriteFont font;
        private MenuButton[] buttons;
        private InputManager inputManagerKeyboard;
        
        public GameProject0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ship = new ShipSprite();
            buttons = new MenuButton[]
            {
                new MenuButton() {Position = new Vector2(400, 370), Text = "Quit", X_Offset= -30, Y_Offset= -16, Type = MenuButtonState.Quit},
                new MenuButton() {Position = new Vector2(400, 310), Text = "Settings", X_Offset= -60, Y_Offset= -16, Type = MenuButtonState.Settings},
                new MenuButton() {Position = new Vector2(400, 250), Text = "Play", X_Offset= -30, Y_Offset= -16, Type = MenuButtonState.Play}
            };
            inputManagerKeyboard = new InputManager();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ship.LoadContent(Content);
            foreach (var btn in buttons) btn.LoadContent(Content);
            backgroundTexture = Content.Load<Texture2D>("space");
            font = Content.Load<SpriteFont>("kenvector");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            inputManagerKeyboard.Update(gameTime);
            // TODO: Add your update logic here
            ship.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            
            spriteBatch.Draw(backgroundTexture, GraphicsDevice.Viewport.Bounds, Color.White);
            foreach (var btn in buttons)
            {
                switch (btn.Type)
                {
                    case MenuButtonState.Quit:
                        if(inputManagerKeyboard.Selection == MenuButtonState.Quit)
                        {
                            btn.Select(gameTime, MenuButtonState.Quit, spriteBatch);
                        }
                        else
                        {
                            btn.Draw(gameTime, spriteBatch);
                        }
                        break;
                    case MenuButtonState.Play:
                        if (inputManagerKeyboard.Selection == MenuButtonState.Play)
                        {
                            btn.Select(gameTime, MenuButtonState.Play, spriteBatch);
                        }
                        else
                        {
                            btn.Draw(gameTime, spriteBatch);
                        }
                        break;
                    case MenuButtonState.Settings:
                        if (inputManagerKeyboard.Selection == MenuButtonState.Settings)
                        {
                            btn.Select(gameTime, MenuButtonState.Settings, spriteBatch);
                        }
                        else
                        {
                            btn.Draw(gameTime, spriteBatch);
                        }
                        break;
                    default:
                        btn.Draw(gameTime, spriteBatch);
                        break;

                }

               
            }
            spriteBatch.DrawString(font, "Space Rush", new Vector2(210, 50), Color.White);
            
            ship.Draw(gameTime, spriteBatch);
            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
