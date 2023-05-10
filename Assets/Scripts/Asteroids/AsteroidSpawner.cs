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
        static AsteroidSpawner() => _objectPool = GameObject.FindObjectOfType<ObjectPool>();

        public static void Spawn(Vector2 position, Vector2 scale, Vector2 velocity, float angularVelocity)
        {
            AsteroidController asteroid = _objectPool.PullObjectFromPool<AsteroidController>("Asteroid");

            asteroid.Initialize(position, scale);
            asteroid.gameObject.SetActive(true);

            asteroid.SetMotion(velocity, angularVelocity);
        }
    }
}