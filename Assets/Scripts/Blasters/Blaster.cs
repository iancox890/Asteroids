using UnityEngine;

namespace AsteroidsApp.Blasters
{
    /// <summary>
    /// The default blaster for the player, firing
	/// a projectile when the space button is clicked. (not held)
    /// </summary>
    public class Blaster : MonoBehaviour, IBlaster
    {
        [SerializeField] private float _blastForce;
        [SerializeField] private float _coolDown;

        private ObjectPool _objectPool;
        private Transform _transform;
        private float _coolDownTime;

        private void Start()
        {
            _objectPool = FindObjectOfType<ObjectPool>();
            _transform = GetComponent<Transform>();
        }

        public void Fire()
        {
            Rigidbody2D projectile = _objectPool.PullObjectFromPool<Rigidbody2D>("Projectile");

            projectile.transform.position = _transform.position;
            projectile.gameObject.SetActive(true);

            projectile.velocity = _transform.up * _blastForce;
        }

        public bool HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _coolDownTime)
            {
                _coolDownTime = Time.time + _coolDown;
                return true;
            }

            return false;
        }
    }
}