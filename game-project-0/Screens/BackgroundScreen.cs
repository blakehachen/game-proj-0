using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


using game_project_0.StateManagement;

namespace game_project_0.Screens
{
    public class BackgroundScreen : GameScreen
    {
        private ContentManager _content;
        private Texture2D _backgroundTexture;
        private AsteroidSprite _asteroid;
        private ShipSprite _ship;
        private SoundEffect _explosionSound;
        private SoundEffect _laserSound;
        

        public BackgroundScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }

        public override void Activate()
        {
            if(_content == null)
            {
                _content = new ContentManager(ScreenManager.Game.Services, "Content");
            }

            _ship = new ShipSprite();
            _asteroid = new AsteroidSprite();

            _ship.LoadContent(_content);
            _asteroid.LoadContent(_content);

            _backgroundTexture = _content.Load<Texture2D>("space");
            _explosionSound = _content.Load<SoundEffect>("Explosion_sound");
            _laserSound = _content.Load<SoundEffect>("Laser_Shoot");
            MediaPlayer.IsRepeating = false;

        }

        public override void Unload()
        {
            _content.Unload();
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);
            _ship.directionTimer += gameTime.ElapsedGameTime.TotalSeconds;
            _asteroid.directionTimer += gameTime.ElapsedGameTime.TotalSeconds;
            _ship.Bullet.directionTimer += gameTime.ElapsedGameTime.TotalSeconds;
            
            if (_asteroid.Destroyed == false && _ship.Bullet.Bounds.CollidesWith(_asteroid.Bounds) && _ship.Bullet.Fired)
            {
                _explosionSound.Play();
                _asteroid.Destroyed = true;
                _ship.Bullet.Hit = true;
                _asteroid.ExplosionPosition = _asteroid.Position;
                _ship.Bullet.Fired = false;

            }

            if (_ship.directionTimer > 1.4 && _ship.directionTimer < 1.45)
            {
                _laserSound.Play();
                _ship.Bullet.Position = new Vector2(_ship.Position.X - 16, _ship.Position.Y - 12);
                _ship.Bullet.Fired = true;
            }

            //_ship.Bullet.Update(gameTime);

            if(_ship.directionTimer > 5.6)
            {
                switch (_ship.Direction)
                {
                    case Direction.Left:
                        _ship.Direction = Direction.Right;
                        
                        break;
                    case Direction.Right:
                        _ship.Direction = Direction.Left;
                        
                        break;
                }
                switch (_ship.Bullet.Direction)
                {
                    case Direction.Left:
                        _ship.Bullet.Direction = Direction.Right;
                        break;
                    case Direction.Right:
                        _ship.Bullet.Direction = Direction.Left;
                        break;
                }
                switch (_asteroid.Direction)
                {
                    case Direction.Left:
                        _asteroid.Direction = Direction.Right;
                        _asteroid.Position = new Vector2(100, 150);
                        break;
                    case Direction.Right:
                        _asteroid.Direction = Direction.Left;
                        _asteroid.Position = new Vector2(815, 150);
                        break;
                }
                _ship.directionTimer -= 5.6;
                _ship.Bullet.directionTimer -= 5.6;
                _ship.Bullet.Hit = false;
                _asteroid.Destroyed = false;
                _asteroid.directionTimer -= 5.6;
            }

            


            _ship.Update(gameTime);
            _ship.Bullet.Update(gameTime);
            
            _asteroid.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = ScreenManager.SpriteBatch;
            var viewport = ScreenManager.GraphicsDevice.Viewport;
            var fullscreen = new Rectangle(0, 0, viewport.Width, viewport.Height);

            spriteBatch.Begin();
            spriteBatch.Draw(_backgroundTexture, fullscreen, new Color(TransitionAlpha, TransitionAlpha, TransitionAlpha));
            _ship.Draw(gameTime, spriteBatch);
            _asteroid.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
    }
}
