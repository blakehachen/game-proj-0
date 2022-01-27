using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace game_project_0.Collisions
{
    /// <summary>
    /// struct represents circular bounds
    /// </summary>
    public struct BoundingCircle
    {
        /// <summary>
        /// Center of bounding circle
        /// </summary>
        public Vector2 Center;

        /// <summary>
        /// radius of bounding circle
        /// </summary>
        public float Radius;

        /// <summary>
        /// Constructs Bounding Circle
        /// </summary>
        /// <param name="center">center of circle</param>
        /// <param name="radius">radius of circle</param>
        public BoundingCircle(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// Tests for a collision between this and another Bounding Circle
        /// </summary>
        /// <param name="other">the other bounding circle</param>
        /// <returns>true for collision, false otherwise</returns>
        public bool CollidesWith(BoundingCircle other)
        {
            return CollisionHelper.Collides(this, other);
        }


        /// <summary>
        /// Tests for a collision between this and a Bounding Rectangle
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool CollidesWith(BoundingRectangle other)
        {
            return CollisionHelper.Collides(this, other);
        }
    }
}

