using UnityEngine;

namespace AsteroidsApp.Player
{
    /// <summary>
    /// Controls when and if the player ship dies.
    /// </summary>
    public class PlayerShipDeathHandler : MonoBehaviour
    {
        public event System.Action OnDeath;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Asteroid") == false)
            {
                return;
            }

            gameObject.SetActive(false);
            OnDeath?.Invoke();
        }
    }
}