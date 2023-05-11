using UnityEngine;

namespace AsteroidsApp.Player
{
    /// <summary>
    /// Handles input and movement for the player ship.
    /// </summary>
    public class PlayerShipController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _turnSpeed;

        private Rigidbody2D _rigidbody;
        private Transform _transform;

        private float _xInput;
        private float _yInput;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _transform = GetComponent<Transform>();
        }

        private void Update()
        {
            _xInput = Input.GetAxisRaw("Horizontal");
            _yInput = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_transform.up * _yInput * _moveSpeed);
            _rigidbody.AddTorque(-_xInput * _turnSpeed);
        }
    }
}