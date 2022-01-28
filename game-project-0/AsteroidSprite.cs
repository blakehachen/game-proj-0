using System;
using System.Collections.Generic;
using System.Text;
using game_project_0.Collisions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace game_project_0
{
    public class AsteroidSprite
    {
        private const float ANIMATION_SPEED = 0.03f;
        private double animationTimer;
        private int animationFrame;
        public Vector2 ExplosionPosition;
        public Vector2 Position;
        private Texture2D texture;
        private Texture2D explosion;
        private BoundingCircle bounds;
        private Direction Direction = Direction.Right;
        private double directionTimer;
        public BoundingCircle Bounds => bounds;

        public bool Destroyed { get; set; } = false;

        public AsteroidSprite()
        {
            
            this.bounds = new BoundingCircle(Position + new Vector2(16, 16), 16);
        }

        public void Update(GameTime gameTime)
        {
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (directionTimer > 5.6)
            {
                switch (Direction)
                {
                    case Direction.Left:
                        Direction = Direction.Right;
                        Position = new Vector2(100, 150);
                        break;
                    case Direction.Right:
                        Direction = Direction.Left;
                        Position = new Vector2(815, 150);
                        break;
                }
                Destroyed = false;
                directionTimer -= 5.6;
            }

            switch (Direction)
            {
                case Direction.Left:
                    Position += new Vector2(-1, 0) * 50 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    
                    break;
                case Direction.Right:
                    Position += new Vector2(1, 0) * 50 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    
                    break;
            }
            bounds.Center.X = Position.X - 8;
            bounds.Center.Y = Position.Y - 8;
            bounds.Radius = 16;
        }


        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("asteroid_pack");
            explosion = content.Load<Texture2D>("explosion");
        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Destroyed)
            {
                
                animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if(animationTimer > ANIMATION_SPEED)
                {
                    animationFrame--;
                    if (animationFrame < 1) return;
                    animationTimer -= ANIMATION_SPEED;
                }
                var source = new Rectangle(animationFrame * 20, 0, 20, 20);
                spriteBatch.Draw(explosion, ExplosionPosition, source, Color.Aqua, 0, new Vector2(8, 8), 3f, SpriteEffects.None, 0);
            }
            else
            {
                animationFrame = 4;
                animationTimer = 0;
                spriteBatch.Draw(texture, Position, null, Color.WhiteSmoke, 0, new Vector2(8, 8), 2.5f, SpriteEffects.None, 0);
            } 
                
            
        }
    }
}
