using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Handles the chromatic aberration intensity level via a trauma modifier.
    /// </summary>
    public class ChromaticAberrationHandler : MonoBehaviour
    {
        [SerializeField] private float _traumaCooldown;

        private ChromaticAberration _chromaticAberration;

        private float _trauma;
        public float Trauma { get => _trauma; set => _trauma = Mathf.Clamp01(value); }

        private void Start()
        {
            VolumeProfile profile = GetComponent<Volume>().profile;
            profile.TryGet<ChromaticAberration>(out _chromaticAberration);
        }

        private void OnDestroy() => _chromaticAberration.intensity.value = 0;

        private void Update()
        {
            if (_trauma == 0)
            {
                return;
            }

            _chromaticAberration.intensity.value = Mathf.Clamp01(_trauma * _trauma);

            float coolDown = (_traumaCooldown * Time.deltaTime);
            _trauma = Mathf.Clamp01(_trauma - (coolDown * coolDown));
        }
    }
}