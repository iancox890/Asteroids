using UnityEngine;

namespace AsteroidsApp.Asteroid
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

        private void OnEnable()
        {
            SetMotion();
        }

        public void Initialize(Vector2 scale, Vector2 position)
        {
            if (_transform == null)
            {
                _transform = GetComponent<Transform>();
            }

            _transform.localScale = scale;
            _transform.position = position;
        }

        private void SetMotion()
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }

            _rigidbody.velocity = Random.insideUnitCircle * Random.Range(_spawnVelocityRange.x, _spawnVelocityRange.y);
            _rigidbody.angularVelocity = Random.Range(_spawnAngularVelocityRange.x, _spawnAngularVelocityRange.y);
        }
    }
}