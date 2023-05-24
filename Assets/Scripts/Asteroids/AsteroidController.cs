using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Handles the asteroid movement and position/scale.
    /// </summary>
    public class AsteroidController : MonoBehaviour
    {
        [SerializeField] private Vector2 _spawnVelocityRange;
        [SerializeField] private Vector2 _spawnAngularVelocityRange;

        private Rigidbody2D _rigidbody;
        private Transform _transform;

        public void Initialize(Vector2 scale, Vector2 position, Vector2 direction)
        {
            if (_transform == null || _rigidbody == null)
            {
                _transform = GetComponent<Transform>();
                _rigidbody = GetComponent<Rigidbody2D>();
            }

            _transform.localScale = scale;
            _transform.position = position;

            gameObject.SetActive(true);

            SetMotion(direction);
        }

        private void SetMotion(Vector2 direction)
        {
            _rigidbody.velocity = direction * Random.Range(_spawnVelocityRange.x, _spawnVelocityRange.y);
            _rigidbody.angularVelocity = Random.Range(_spawnAngularVelocityRange.x, _spawnAngularVelocityRange.y);
        }
    }
}