using UnityEngine;

namespace AsteroidsApp
{
    /// <summary>
    /// Helper class for accessing and manipulating
    /// screen bounds.
    /// </summary>
    public static class ScreenBounds
    {
        private static Vector2 _bounds;
        public static Vector2 Bounds => _bounds;

        static ScreenBounds()
        {
            _bounds = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        }

        public static Vector2 GetRandomBoundsPosition(float offset)
        {
            Vector2 position = _bounds;
            int PositiveOrNegative() => Random.Range(0, 2) * 2 - 1;

            // Choose randomly between getting a random horizontal/vertical position.
            if (Random.value > 0.5)
            {
                position.x = Random.Range(_bounds.x, -_bounds.x);
                position.y += offset;
            }
            else
            {
                position.x += offset;
                position.y = Random.Range(_bounds.y, -_bounds.y);
            }

            position.x *= PositiveOrNegative();
            position.y *= PositiveOrNegative();

            return position;
        }
    }
}