using UnityEngine;

namespace Asteroids
{
    /// <summary>
    /// Disables a projectile after its lifetime is reached, 
	/// shrinking the scale over the course of its lifetime.
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") == false)
            {
                gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (Time.time > _disableTime)
            {
                gameObject.SetActive(false);
                return;
            }

            _transform.localScale = _scale * Mathf.InverseLerp(_disableTime, _enableTime, Time.time);
        }
    }
}