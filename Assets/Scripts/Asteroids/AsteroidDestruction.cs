using UnityEngine;

namespace Asteroids
{
    /// <summary>
    /// Handles the destruction for a given asteroid. (i.e., getting hit by a projectile)
    /// </summary>
    public class AsteroidDestruction : MonoBehaviour
    {
        public event System.Action OnDestroyed;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Projectile") == false)
            {
                return;
            }

            OnDestroyed?.Invoke();
            gameObject.SetActive(false);
        }
    }
}