using UnityEngine;
using System;

namespace AsteroidsApp.Asteroid
{
    /// <summary>
    /// Handles the destruction for a given asteroid. (i.e., getting hit by a projectile)
    /// </summary>
    public class AsteroidDestroyer : MonoBehaviour
    {
        public event Action OnAsteroidDestroyed;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Projectile") == false && other.CompareTag("Player") == false)
            {
                return;
            }

            OnAsteroidDestroyed?.Invoke();
            gameObject.SetActive(false);
        }
    }
}