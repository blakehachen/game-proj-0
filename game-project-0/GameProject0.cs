using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using game_project_0.StateManagement;
using game_project_0.Screens;
using game_project_0.ParticleSystem;

namespace game_project_0
{
    public class GameProject0 : Game
    {
        private GraphicsDeviceManager graphics;
        private readonly ScreenManager _screenManager;
       
        
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
            
            
            
            base.Initialize();
        }

        /// <summary>
        /// Loads background texture, sprite font and bullet sprite.
        /// </summary>
        protected override void LoadContent()
        {
            
        }

        /// <summary>
        /// Updates the sprites within the game based on certain criteria
        /// </summary>
        /// <param name="gameTime">elapsed game time</param>
        protected override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the initialized sprites given there content and criteria
        /// </summary>
        /// <param name="gameTime">elapsed gametime</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
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
