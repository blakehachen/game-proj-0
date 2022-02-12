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
    /// <summary>
    /// Class representing Asteroid
    /// </summary>
    public class AsteroidSprite
    {
        
        
        private const float ANIMATION_SPEED = 0.03f;
        private double animationTimer;
        private int animationFrame;
        private Texture2D texture;
        private Texture2D explosion;
        private BoundingCircle bounds;
        public Direction Direction = Direction.Right;
        public double directionTimer;

        public Vector2 ExplosionPosition;
        public Vector2 Position = new Vector2(100, 150);

        /// <summary>
        /// Bounding circle representing asteroid collision zone
        /// </summary>
        public BoundingCircle Bounds => bounds;

        /// <summary>
        /// Bool specifies whether asteroid has been destroyed
        /// </summary>
        public bool Destroyed { get; set; } = false;

        /// <summary>
        /// Construct asteroid sprite and set bounds for Bounding Circle
        /// </summary>
        public AsteroidSprite()
        {
            
            this.bounds = new BoundingCircle(Position + new Vector2(16, 16), 16);
        }

        /// <summary>
        /// Update Asteroid Sprite Direction
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            switch (Direction)
            {
                case Direction.Left:
                    Position += new Vector2(-1, 0) * 50 * (float)gameTime.ElapsedGameTime.TotalSeconds;

                    break;
                case Direction.Right:
                    Position += new Vector2(1, 0) * 50 * (float)gameTime.ElapsedGameTime.TotalSeconds;

                    break;
            }

            bounds.Center.X = Position.X - 12;
            bounds.Center.Y = Position.Y - 12;
            bounds.Radius = 24;
        }


        /// <summary>
        /// Load asteroid texture and explosion pallete
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("asteroid_pack");
            explosion = content.Load<Texture2D>("explosion");
        }


        /// <summary>
        /// Draw the asteroid or explosion if asteroid is destroyed
        /// </summary>
        /// <param name="gameTime">elapsed gametime</param>
        /// <param name="spriteBatch">spritebatch to draw</param>
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
