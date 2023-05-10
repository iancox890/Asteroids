using UnityEngine;

namespace Asteroids
{
    /// <summary>
    /// Controls the asteroid movement and position/scale.
    /// </summary>
    public class AsteroidController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Transform _transform;

        public void Initialize(Vector2 position, Vector2 scale)
        {
            if (_transform == null)
            {
                _transform = GetComponent<Transform>();
            }

            _transform.position = position;
            _transform.localScale = scale;
        }

        public void SetMotion(Vector2 velocity, float angularVelocity)
        {
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }

            _rigidbody.velocity = velocity;
            _rigidbody.angularVelocity = angularVelocity;
        }
    }
}