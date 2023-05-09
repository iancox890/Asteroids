using UnityEngine;

namespace Asteroids
{
    /// <summary>
    /// Disables a projectile when it is no longer visible by the camera.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _lifetime;

        private Transform _transform;
        private Vector2 _scale;

        private float _disableTime;
        private float _enableTime;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _scale = _transform.localScale;
        }

        private void OnEnable()
        {
            _transform.localScale = _scale;

            _enableTime = Time.time;
            _disableTime = _enableTime + _lifetime;
        }

        private void Update()
        {
            if (Time.time > _disableTime)
            {
                gameObject.SetActive(false);
                return;
            }

            // Shrinks the projectile over the course of its lifetime.
            _transform.localScale = _scale * Mathf.InverseLerp(_disableTime, _enableTime, Time.time);
        }
    }
}