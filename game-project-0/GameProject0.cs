using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using game_project_0.StateManagement;
using game_project_0.Screens;

namespace game_project_0
{
    public class GameProject0 : Game
    {
        private GraphicsDeviceManager graphics;
        private readonly ScreenManager _screenManager;
        private SpriteBatch spriteBatch;
        private ShipSprite ship;
        private AsteroidSprite asteroid;
        private Texture2D backgroundTexture;
        private SpriteFont font;
        private MenuButton[] buttons;
        //private InputManager inputManagerKeyboard;
        private Texture2D ball;
        
        /// <summary>
        /// Constructs initial Project and sets graphics device
        /// </summary>
        public GameProject0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            var screenFactory = new ScreenFactory();
            Services.AddService(typeof(IScreenFactory), screenFactory);

            _screenManager = new ScreenManager(this);
            Components.Add(_screenManager);

            AddInitialScreens();
        }

        private void AddInitialScreens()
        {
            _screenManager.AddScreen(new BackgroundScreen(), null);
            _screenManager.AddScreen(new MainMenuScreen(), null);
        }

        /// <summary>
        /// Initializes various sprites appearing within the main menu
        /// </summary>
        protected override void Initialize()
        {
            
            /*buttons = new MenuButton[]
            {
                new MenuButton() {Position = new Vector2(400, 370), Text = "Quit", HelperText = "Press [ENTER] or A to Quit", X_Offset= -30, Y_Offset= -16, HelperX_Offset = -75, Type = MenuButtonState.Quit},
                new MenuButton() {Position = new Vector2(400, 310), Text = "Settings", HelperText = "Not Implemented", X_Offset= -60, Y_Offset= -16, HelperX_Offset = -15, Type = MenuButtonState.Settings},
                new MenuButton() {Position = new Vector2(400, 250), Text = "Play", HelperText = "Not Implemented", X_Offset= -30, Y_Offset= -16, HelperX_Offset = -15, Type = MenuButtonState.Play}
            };
            inputManagerKeyboard = new InputManager();
            foreach(var menuItem in buttons)
            {
                inputManagerKeyboard.menuItems.Add(menuItem);
            }*/
            
            base.Initialize();
        }

        /// <summary>
        /// Loads background texture, sprite font and bullet sprite.
        /// </summary>
        protected override void LoadContent()
        {
            //spriteBatch = new SpriteBatch(GraphicsDevice);
           
            //foreach (var btn in buttons) btn.LoadContent(Content);
            //backgroundTexture = Content.Load<Texture2D>("space");
            //font = Content.Load<SpriteFont>("kenvector");
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Updates the sprites within the game based on certain criteria
        /// </summary>
        /// <param name="gameTime">elapsed game time</param>
        protected override void Update(GameTime gameTime)
        {
            //if (inputManagerKeyboard.Selection == MenuButtonState.Esc) Exit();
            //inputManagerKeyboard.Update(gameTime);

            
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the initialized sprites given there content and criteria
        /// </summary>
        /// <param name="gameTime">elapsed gametime</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            /*spriteBatch.Begin();
            
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

               
            }*/
            //spriteBatch.DrawString(font, "Space Rush", new Vector2(210, 50), Color.White);
            
            //ship.Draw(gameTime, spriteBatch);
            //asteroid.Draw(gameTime, spriteBatch);
            /*var rect = new Rectangle((int)asteroid.Bounds.Center.X - (int)asteroid.Bounds.Radius,
                                       (int)asteroid.Bounds.Center.Y - (int)asteroid.Bounds.Radius,
                                       (int)(2.5*asteroid.Bounds.Radius), (int)(2.5*asteroid.Bounds.Radius));
            spriteBatch.Draw(ball, rect, Color.White);*/

            //spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
