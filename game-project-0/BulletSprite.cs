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
    public class BulletSprite
    {
        
        private Texture2D texture;
        private BoundingCircle bounds;
        
        public double directionTimer;

        public Vector2 Position;

        public Direction Direction = Direction.Left;

        /// <summary>
        /// Bounding circle representing bullet collision zone (hitbox)
        /// </summary>
        public BoundingCircle Bounds => bounds;

        /// <summary>
        /// Boolean value specifies whether this bullet has been fired
        /// </summary>
        public bool Fired { get; set; } = false;

        /// <summary>
        /// Boolean value indicating if the bullet has hit an object
        /// </summary>
        public bool Hit { get; set; } = false;

        /// <summary>
        /// Constructs bullet sprite and sets Bounding circle
        /// </summary>
        public BulletSprite()
        {
            
            this.bounds = new BoundingCircle(Position + new Vector2(4, 4), 4);
        }

        /// <summary>
        /// Updates the position of the bullet in game
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {

            if (!Hit)
            {
                switch (Direction)
                {
                    case Direction.Left:
                        Position += new Vector2(-1, 0) * 500 * (float)gameTime.ElapsedGameTime.TotalSeconds;

                        break;
                    case Direction.Right:
                        Position += new Vector2(1, 0) * 500 * (float)gameTime.ElapsedGameTime.TotalSeconds;

                        break;
                }
            }
            
            
            bounds.Center.X = Position.X - 4;
            bounds.Center.Y = Position.Y - 4;
            bounds.Radius = 4;

        }
        

        /// <summary>
        /// Loads the bullet texture from content manager
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("bullet");
        }

        /// <summary>
        /// Draws the bullet texture on screen
        /// </summary>
        /// <param name="gameTime">elapsed gametime</param>
        /// <param name="spriteBatch">spritebatch to draw</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Hit) return;
            
            spriteBatch.Draw(texture, Position, null, Color.WhiteSmoke, 0, new Vector2(4, 4), 2.5f, SpriteEffects.None, 0);
        }
    }
}
