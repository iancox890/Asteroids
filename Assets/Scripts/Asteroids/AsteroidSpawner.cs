using UnityEngine;

namespace Asteroids
{
    /// <summary>
    /// Spawns an asteroid from the object pool at a set position, scale, 
    /// and with a given linear/angular velocity.
    /// </summary>
    public static class AsteroidSpawner
    {
        private static ObjectPool _objectPool;

        public static void Spawn(Vector2 scale, Vector2 position)
        {
            if (_objectPool == null)
            {
                _objectPool = GameObject.FindObjectOfType<ObjectPool>();
            }

            AsteroidController asteroid = _objectPool.PullObjectFromPool<AsteroidController>("Asteroid");

            asteroid.Initialize(scale, position);
            asteroid.gameObject.SetActive(true);
        }
    }
}