using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using game_project_0.Collisions;

public enum Direction
{
    Left,
    Right
}

namespace game_project_0
{
    public class ShipSprite
    {
        private Texture2D texture;
        public BulletSprite Bullet = new BulletSprite();
        public double directionTimer;
        public bool flipped;
        private int _height;
        public Direction Direction;
        
        public int Height
        {
            get => _height;
            set => _height = value;
        }
        public Vector2 Position = new Vector2(815, 150);

        private BoundingRectangle bounds = new BoundingRectangle(new Vector2(815 - 7, 150 - 7), 14, 14);
        public BoundingRectangle Bounds => bounds;
        /// <summary>
        /// Load bullet texture and ship sprite texture
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            
            texture = content.Load<Texture2D>("blueships");
            Bullet.LoadContent(content);
            _height = 23;
        }

        /// <summary>
        /// Update the movement of the ship and shoot bullet
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            switch (Direction)
            {
                case Direction.Left:
                    Position += new Vector2(-1, 0) * 150 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    flipped = true;
                    break;
                case Direction.Right:
                    Position += new Vector2(1, 0) * 150 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    flipped = false;
                    break;
            }

            bounds.X = Position.X - 14;
            bounds.Y = Position.Y - 14;
        }

        /// <summary>
        /// Draws the ship and bullet
        /// </summary>
        /// <param name="gameTime">elapsed game time</param>
        /// <param name="spriteBatch">sprite batch to draw</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects = (flipped) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            if (Bullet.Fired)
            {
                Bullet.Draw(gameTime, spriteBatch);
            }
            
            spriteBatch.Draw(texture, Position, new Rectangle(82, 23, 14, 14), Color.WhiteSmoke, 0, new Vector2(8,8), 2.5f, spriteEffects, 0);
        }
    }
}
