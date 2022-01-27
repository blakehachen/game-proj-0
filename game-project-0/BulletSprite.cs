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
        public Vector2 Position;
        private Texture2D texture;
        private BoundingCircle bounds;
        
        private double directionTimer;

        public Direction Direction = Direction.Left;
        public BoundingCircle Bounds => bounds;

        public bool Fired { get; set; } = false;

        public BulletSprite()
        {
            
            this.bounds = new BoundingCircle(Position + new Vector2(4, 4), 4);
        }

        public void Update(GameTime gameTime)
        {
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (Fired && directionTimer > 5.6)
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
                
            }
            directionTimer -= 5.6;

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

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("bullet");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.WhiteSmoke, 0, new Vector2(4, 4), 2.5f, SpriteEffects.None, 0);
        }
    }
}
