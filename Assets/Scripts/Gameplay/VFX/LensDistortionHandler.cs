using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Handles the lens distortion intensity level via a trauma modifier.
    /// </summary>
    public class LensDistortionHandler : MonoBehaviour
    {
        [SerializeField] private float _traumaCooldown;

        private LensDistortion _lensDistortion;

        private float _trauma;
        public float Trauma { get => _trauma; set => _trauma = Mathf.Clamp01(value); }

        private void Start()
        {
            VolumeProfile profile = GetComponent<Volume>().profile;
            profile.TryGet<LensDistortion>(out _lensDistortion);
        }

        private void OnDestroy() => _lensDistortion.intensity.value = 0;

        private void Update()
        {
            if (_trauma == 0)
            {
                return;
            }

            _lensDistortion.intensity.value = -Mathf.Clamp01(_trauma * _trauma);

            float coolDown = (_traumaCooldown * Time.deltaTime);
            _trauma = Mathf.Clamp01(_trauma - (coolDown * coolDown));
        }
    }
}