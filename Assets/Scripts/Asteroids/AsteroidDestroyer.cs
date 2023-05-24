using UnityEngine;
using System;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Handles the destruction for a given asteroid. (i.e., getting hit by a projectile)
    /// </summary>
    public class AsteroidDestroyer : MonoBehaviour
    {
        private Transform _transform;

        public event Action<string> OnAsteroidDestroyed;
        public static event Action<Transform> OnAnyAsteroidDestroyed;

        private void Start()
        {
            _transform = GetComponent<Transform>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Projectile") == false && other.CompareTag("Player") == false)
            {
                return;
            }

            OnAsteroidDestroyed?.Invoke(other.tag);
            OnAnyAsteroidDestroyed?.Invoke(_transform);

            gameObject.SetActive(false);
        }
    }
}