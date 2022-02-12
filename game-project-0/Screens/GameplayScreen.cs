using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using game_project_0.StateManagement;
namespace game_project_0.Screens
{
    public class GameplayScreen : GameScreen
    {
        private ContentManager _content;
        private SpriteFont _gameFont;
        private Texture2D _backgroundTexture;
        private ShipSprite _ship;
        private const int ASTEROID_COUNT = 50;
        private int _health = 100;
        private double _timer;
        private double _bulletTimer;
        private bool _bulletLock = false;
        private int _drawnAsteroids = 1;
        private List<AsteroidSprite> _asteroids = new List<AsteroidSprite>();
        
        //Needs Random placement of asteroids. Array
        //private AsteroidSprite _asteroid;
        private Vector2 _playerPosition = new Vector2(50, 100);

        private readonly Random _random = new Random();

        private float _pauseAlpha;
        private readonly InputAction _pauseAction;

        public GameplayScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            _pauseAction = new InputAction(
                new[] { Buttons.Start, Buttons.Back },
                new[] { Keys.Back, Keys.Escape }, true);
        }

        public override void Activate()
        {
            if(_content == null)
            {
                _content = new ContentManager(ScreenManager.Game.Services, "Content");
            }

            _gameFont = _content.Load<SpriteFont>("kenvector_thin");
            _backgroundTexture = _content.Load<Texture2D>("space");
            _ship = new ShipSprite();
            _ship.Direction = Direction.Right;
            for(int i = 0; i < ASTEROID_COUNT; i++)
            {
                var a = new AsteroidSprite();
                a.Position = new Vector2(770, _random.Next(100, 400));
                a.Direction = Direction.Left;
                a.LoadContent(_content);
                _asteroids.Add(a);

            }

            _ship.LoadContent(_content);

            ScreenManager.Game.ResetElapsedTime();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Unload()
        {
            _content.Unload();
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);

            if (coveredByOtherScreen)
                _pauseAlpha = Math.Min(_pauseAlpha + 1f / 32, 1);
            else
                _pauseAlpha = Math.Max(_pauseAlpha - 1f / 32, 0);

            if (IsActive)
            {
                // TODO: Add sprite effects, or possible asteroid sprite spawn logic
                _timer += gameTime.ElapsedGameTime.TotalSeconds;
                if (_bulletLock)
                {
                    _bulletTimer += gameTime.ElapsedGameTime.TotalSeconds;
                }
                
                if (_bulletTimer > 0.7)
                {
                    _bulletLock = false;
                    _bulletTimer -= 0.7;
                }
                
                _ship.Update(gameTime);
                if(_timer > 1.1 && _drawnAsteroids < ASTEROID_COUNT)
                {
                    _drawnAsteroids++;
                    _timer -= 1.1;
                }
                
                if(_health <= 0)
                {
                    //END GAME LOST
                    _health = 0;
                    ScreenManager.AddScreen(new LoserScreen(), ControllingPlayer);
                }

                if (_asteroids[_asteroids.Count - 1].Destroyed && _health > 0)
                {
                    //END GAME WIN

                    ScreenManager.AddScreen(new WinnerScreen(), ControllingPlayer);
                    

                }
                for (int i = 0; i < _drawnAsteroids; i++)
                {
                    _asteroids[i].Update(gameTime);
                    
                    if (_asteroids[i].Destroyed == false && _ship.Bullet.Bounds.CollidesWith(_asteroids[i].Bounds) && _ship.Bullet.Fired)
                    {
                        _asteroids[i].Destroyed = true;
                        _ship.Bullet.Hit = true;
                        _ship.Bullet.Fired = false;
                        _asteroids[i].ExplosionPosition = _asteroids[i].Position;


                    }

                    if(_asteroids[i].Destroyed == false && _asteroids[i].Bounds.CollidesWith(_ship.Bounds))
                    {
                        _asteroids[i].Destroyed = true;
                        _asteroids[i].ExplosionPosition = _asteroids[i].Position;
                        _health -= 20;
                    }

                    if(!_asteroids[i].Destroyed && _asteroids[i].Position.X <= -30)
                    {
                        _asteroids[i].Destroyed = true;
                        _asteroids[i].ExplosionPosition = _asteroids[i].Position;
                        _health -= 10;
                    }
                }
                
                _ship.Bullet.Update(gameTime);


            }
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            int playerIndex = (int)ControllingPlayer.Value;

            var keyboardState = input.CurrentKeyboardStates[playerIndex];
            var gamePadState = input.CurrentGamePadStates[playerIndex];

            bool gamePadDisconnected = !gamePadState.IsConnected && input.GamePadWasConnected[playerIndex];

            PlayerIndex player;

            if(_pauseAction.Occurred(input, ControllingPlayer, out player) || gamePadDisconnected)
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
            else
            {
                var movement = Vector2.Zero;
                var thumbstick = gamePadState.ThumbSticks.Left;

                if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down) || thumbstick.Y < 0)
                    movement.Y++;

                if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up) || thumbstick.Y > 0)
                    movement.Y--;
                if (keyboardState.IsKeyDown(Keys.Space) && !_bulletLock)
                {
                    _bulletLock = true;
                    _ship.Bullet.Position = new Vector2(_ship.Position.X - 16, _ship.Position.Y - 12);
                    _ship.Bullet.Fired = true;
                    _ship.Bullet.Hit = false;
                    _ship.Bullet.Direction = Direction.Right;
                   
                }
                
                if (movement.Length() > 1)
                    movement.Normalize();

                _playerPosition += movement * 5f;

                int top = 480 - _ship.Height;
                
                if (_playerPosition.Y > top)
                  _playerPosition.Y = top;
                if (_playerPosition.Y < _ship.Height)
                    _playerPosition.Y = _ship.Height;

            }
        }

        public override void Draw(GameTime gameTime)
        {
            var viewport = ScreenManager.GraphicsDevice.Viewport;
            var fullscreen = new Rectangle(0, 0, viewport.Width, viewport.Height);
            var healthstring = "Health: " + _health;
            var healthColor = Color.Green;
            if(_health <= 60 && _health >= 40)
            {
                healthColor = Color.Yellow;
            }
            if(_health <= 30 &&  _health >= 0)
            {
                healthColor = Color.Red;
            }
            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.Draw(_backgroundTexture, fullscreen, new Color(TransitionAlpha, TransitionAlpha, TransitionAlpha));
            spriteBatch.DrawString(_gameFont, healthstring, new Vector2(640, 440), healthColor);
            _ship.Position = _playerPosition;
            _ship.Draw(gameTime, spriteBatch);
            
            for(int i = 0; i < _drawnAsteroids; i++)
            {
                _asteroids[i].Draw(gameTime, spriteBatch);
            }
                
            spriteBatch.End();

            if(TransitionPosition > 0 || _pauseAlpha > 0)
            {
                float alpha = MathHelper.Lerp(1f - TransitionAlpha, 1f, _pauseAlpha / 2);
                ScreenManager.FadeBackBufferToBlack(alpha);
            }
        }
    }
}
