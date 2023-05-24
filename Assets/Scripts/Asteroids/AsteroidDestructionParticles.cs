using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Handles destruction particles for an asteroid by
    /// re-using one instance of the destruction particle obj via
    /// the emit method.
    /// </summary>
    public class AsteroidDestructionParticles : MonoBehaviour
    {
        [SerializeField] private int _particleCount;

        private ParticleSystem _particleSystem;
        private ParticleSystem.EmitParams _emitParams;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _emitParams = new ParticleSystem.EmitParams();

            _emitParams.applyShapeToPosition = true;

            AsteroidDestroyer.OnAnyAsteroidDestroyed += Play;
        }

        private void OnDestroy()
        {
            AsteroidDestroyer.OnAnyAsteroidDestroyed -= Play;
        }

        private void Play(Transform transform)
        {
            _emitParams.position = transform.position;
            _particleSystem.Emit(_emitParams, Mathf.RoundToInt((_particleCount * transform.localScale.x)));
        }
    }
}