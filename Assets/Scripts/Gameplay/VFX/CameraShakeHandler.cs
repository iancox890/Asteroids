using UnityEngine;

namespace Asteroids.Gameplay
{
    public class CameraShakeHandler : MonoBehaviour
    {
        [Header("Shake Parameters")]
        [Space(2)]
        [Tooltip("The max position offset when the camera is shaking.")]
        [SerializeField] private float _maxOffset;
        [Tooltip("The max rotation offset when the camera is shaking.")]
        [SerializeField] private float _maxAngle;
        [Space(2)]
        [Tooltip("How quickly the trauma value is reduced. (this value is squared)")]
        [SerializeField] private float _traumaCooldown;
        [Space(2)]
        [Header("Perlin Noise Parameters")]
        [Space(2)]
        [Tooltip("The sample size of the perlin noise.")]
        [SerializeField] private float _scale;
        [Space(2)]
        [Tooltip("The x offset from the perlin nosie sample.")]
        [SerializeField] private float _xOffset;
        [Tooltip("The y offset from the perlin noise sample.")]
        [SerializeField] private float _yOffset;

        private float _shakeIntensity;
        public float ShakeIntensity { get => _shakeIntensity; set => _shakeIntensity = value; }

        private float _trauma;
        public float Trauma { get => _trauma; set => _trauma = Mathf.Clamp01(value); }

        private Transform _transform;
        private Vector3 _restPosition;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _restPosition = _transform.position;
            _shakeIntensity = PlayerPrefs.GetFloat("Screen_Shake", 1);
        }

        private void Update()
        {
            if (_trauma == 0)
            {
                return;
            }

            float shake = (_trauma * _trauma) * _shakeIntensity;

            Vector3 offset = new Vector2((_maxOffset * shake * GetPerlinNoise(Random.value + 1)) * Random.Range(-1, 2), _maxOffset * shake * GetPerlinNoise(Random.value + 2) * Random.Range(-1, 2));
            float angle = _maxAngle * shake * GetPerlinNoise(Random.value + 3) * Random.Range(-1, 2);

            _transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            float coolDown = (_traumaCooldown * Time.deltaTime);
            _trauma = Mathf.Clamp01(_trauma - (coolDown * coolDown));
        }

        private float GetPerlinNoise(float seed)
        {
            float x = (seed * _scale) + _xOffset;
            float y = (seed * _scale) + _yOffset;

            return Mathf.PerlinNoise(x, y);
        }
    }
}