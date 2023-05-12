using UnityEngine;

namespace AsteroidsApp.Player
{
    /// <summary>
    /// Controls when and if the player ship dies.
    /// </summary>
    public class PlayerShipDeathHandler : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        public event System.Action OnDeath;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Asteroid") == false)
            {
                return;
            }

            _rigidbody.velocity = Vector2.zero;
            _rigidbody.angularVelocity = 0;

            gameObject.SetActive(false);

            OnDeath?.Invoke();
        }
    }
}