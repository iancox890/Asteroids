using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Emits particles at the blaster controller position when it is fired.
    /// </summary>
    public class BlasterParticles : MonoBehaviour
    {
        [SerializeField] private Vector2 _particleCount;
        [SerializeField] private Vector2 _opacityRange;

        private Transform _transform;
        private ParticleSystem _particleSystem;
        private ParticleSystem.EmitParams _emitParams;
        private IBlaster _blaster;

        private void Start()
        {
            _transform = GetComponent<Transform>();
            _particleSystem = GetComponent<ParticleSystem>();

            _emitParams = new ParticleSystem.EmitParams();
            _emitParams.applyShapeToPosition = true;

            _blaster = GetComponent<IBlaster>();
            _blaster.OnFire += Play;
        }

        private void OnDestroy()
        {
            _blaster.OnFire -= Play;
        }

        private void Play()
        {
            _emitParams.position = _transform.position;
            int emissionCount = (int)Random.Range(_particleCount.x, _particleCount.y);

            for (int i = 0; i < emissionCount; i++)
            {
                _emitParams.startColor = Color.white.SetOpacity(Mathf.Clamp(Random.value, _opacityRange.x, _opacityRange.y));
                _particleSystem.Emit(_emitParams, 1);
            }
        }
    }
}