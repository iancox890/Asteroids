using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// On [Left-Shift], dashes the player a given distance under 
    /// constraints set via inspector.
    /// </summary>
    public class PlayerShipDash : MonoBehaviour
    {
        [SerializeField] private float _dashDistance;
        [SerializeField] private float _dashCooldown;
        [Space(2)]
        [SerializeField] private float _dashInvincibilityDuration;

        private Transform _transform;
        private Rigidbody2D _rigidbody;
        private PlayerShipInvincibility _playerInvincibility;

        private Vector2 _startDashPosition;
        public Vector2 StartDashPosition => _startDashPosition;

        private Vector2 _endDashPosition;
        public Vector2 EndDashPosition => _endDashPosition;

        private float _nextAvailableDashTime;
        public float NextAvailableDashTime => _nextAvailableDashTime;

        public event System.Action OnDash;

        private void Start()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerInvincibility = GetComponent<PlayerShipInvincibility>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > _nextAvailableDashTime)
            {
                Dash();
            }
        }

        private void Dash()
        {
            StartCoroutine(_playerInvincibility.EnableInvincibility(Time.time + _dashInvincibilityDuration));

            Vector2 dashDirection = _transform.up;

            _startDashPosition = _rigidbody.position;
            _endDashPosition = _startDashPosition + (_dashDistance * dashDirection);

            _nextAvailableDashTime = Time.time + _dashCooldown;

            _rigidbody.MovePosition(_endDashPosition);
            _rigidbody.velocity = dashDirection * _rigidbody.velocity.magnitude;

            OnDash?.Invoke();
        }
    }
}