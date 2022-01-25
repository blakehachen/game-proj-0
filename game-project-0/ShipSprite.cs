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
        private double directionTimer;
        private bool flipped;

        private Direction Direction;

        private Vector2 position = new Vector2(815, 150);

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("blueships");
        }

        public void Update(GameTime gameTime)
        {
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if(directionTimer > 5.6)
            {
                switch (Direction)
                {
                    case Direction.Left:
                        Direction = Direction.Right;
                        break;
                    case Direction.Right:
                        Direction = Direction.Left;
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

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects = (flipped) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(texture, position, new Rectangle(82, 23, 14, 14), Color.WhiteSmoke, 0, new Vector2(8,8), 2.5f, spriteEffects, 0);
        }
    }
}
