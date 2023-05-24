using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Spawns an asteroid from the object pool at a set position, scale, 
    /// and with a given linear/angular velocity.
    /// </summary>
    public static class AsteroidSpawner
    {
        private static ObjectPool _objectPool;
        private const string ASTEROID_KEY = "Asteroid";

        public static void Spawn(Vector2 scale, Vector2 position, Vector2 direction)
        {
            if (_objectPool == null)
            {
                _objectPool = GameObject.FindObjectOfType<ObjectPool>();
            }

            _objectPool.PullObjectFromPool<AsteroidController>(ASTEROID_KEY).Initialize(scale, position, direction);
        }
    }
}