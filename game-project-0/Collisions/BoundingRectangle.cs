using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace game_project_0.Collisions
{
    /// <summary>
    /// A bounding rectangle for collision detection
    /// </summary>
    public struct BoundingRectangle
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;

        /// <summary>
        /// Left side of Rectangle
        /// </summary>
        public float Left => X;

        /// <summary>
        /// Right side of Rectangle
        /// </summary>
        public float Right => X + Width;

        /// <summary>
        /// Top of Rectangle
        /// </summary>
        public float Top => Y;

        /// <summary>
        /// Bottom of Rectangle
        /// </summary>
        public float Bottom => Y + Height;

        /// <summary>
        /// Constructs Bounding Rectangle
        /// </summary>
        /// <param name="x">x coord of rectangle</param>
        /// <param name="y">y coord of rectangle</param>
        /// <param name="width">width of rectangle</param>
        /// <param name="height">height of rectangle</param>
        public BoundingRectangle(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Constructs Bounding Rectangle
        /// </summary>
        /// <param name="position">position of rectangle</param>
        /// <param name="width">width of rectangle</param>
        /// <param name="height">height of rectangle</param>
        public BoundingRectangle(Vector2 position, float width, float height)
        {
            X = position.X;
            Y = position.Y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Tests for collision between this and another Bounding Rectangle
        /// </summary>
        /// <param name="other">Bounding Rectangle</param>
        /// <returns>true if collision, false otherwise</returns>
        public bool CollidesWith(BoundingRectangle other)
        {
            return CollisionHelper.Collides(this, other);
        }

        /// <summary>
        /// Tests for collision between this and a Bounding Circle
        /// </summary>
        /// <param name="other">Bounding Circle</param>
        /// <returns>true if collision, false otherwise</returns>
        public bool CollidesWith(BoundingCircle other)
        {
            return CollisionHelper.Collides(this, other);
        }
    }
}
