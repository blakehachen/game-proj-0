using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

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
        private double directionTimer;
        private bool flipped;
        
        private Direction Direction;

        private Vector2 position = new Vector2(815, 150);

        /// <summary>
        /// Load bullet texture and ship sprite texture
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            
            texture = content.Load<Texture2D>("blueships");
            Bullet.LoadContent(content);
        }

        /// <summary>
        /// Update the movement of the ship and shoot bullet
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if(directionTimer > 1.0 && directionTimer < 1.1)
            {
                Bullet.Position = new Vector2(position.X-16, position.Y - 12);
                Bullet.Fired = true;
            }
            
                
            Bullet.Update(gameTime);
            
            

            if(directionTimer > 5.6)
            {
                switch (Direction)
                {
                    case Direction.Left:
                        Direction = Direction.Right;
                        Bullet.Direction = Direction.Right;
                        break;
                    case Direction.Right:
                        Direction = Direction.Left;
                        Bullet.Direction = Direction.Left;
                        break;
                }
                directionTimer -= 5.6;
            }

            switch (Direction)
            {
                case Direction.Left:
                    position += new Vector2(-1, 0) * 150 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    flipped = true;
                    break;
                case Direction.Right:
                    position += new Vector2(1, 0) * 150 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    flipped = false;
                    break;
            }
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
            
            spriteBatch.Draw(texture, position, new Rectangle(82, 23, 14, 14), Color.WhiteSmoke, 0, new Vector2(8,8), 2.5f, spriteEffects, 0);
        }
    }
}
