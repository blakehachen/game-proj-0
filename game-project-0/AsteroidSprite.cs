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
        private Vector2 position;
        private Texture2D texture;
        private BoundingCircle bounds;
        private Direction Direction = Direction.Right;
        private double directionTimer;
        public BoundingCircle Bounds => bounds;

        public bool Destroyed { get; set; } = false;

        public AsteroidSprite(Vector2 position)
        {
            this.position = position;
            this.bounds = new BoundingCircle(position + new Vector2(16, 16), 16);
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
                        position = new Vector2(100, 150);
                        break;
                    case Direction.Right:
                        Direction = Direction.Left;
                        position = new Vector2(815, 150);
                        break;
                }
                Destroyed = false;
                directionTimer -= 5.6;
            }

            switch (Direction)
            {
                case Direction.Left:
                    position += new Vector2(-1, 0) * 50 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    
                    break;
                case Direction.Right:
                    position += new Vector2(1, 0) * 50 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    
                    break;
            }
            bounds.Center.X = position.X - 8;
            bounds.Center.Y = position.Y - 8;
            bounds.Radius = 16;
        }


        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("asteroid_pack");
        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Destroyed) return;
            spriteBatch.Draw(texture, position, null, Color.WhiteSmoke, 0, new Vector2(8, 8), 2.5f, SpriteEffects.None, 0);
        }
    }
}
