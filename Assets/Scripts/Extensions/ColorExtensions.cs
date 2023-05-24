using UnityEngine;

namespace Asteroids
{
    public static class ColorExtensions
    {
        public static Color SetOpacity(this Color color, float opacity)
        {
            color.a = opacity;
            return color;
        }
    }
}