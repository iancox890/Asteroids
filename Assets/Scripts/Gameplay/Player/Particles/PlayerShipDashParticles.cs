using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Plays dash particles at the start and end position of the dash.
    /// </summary>
    public class PlayerShipDashParticles : MonoBehaviour
    {
        [SerializeField] private PlayerShipDash _playerDash;
        [SerializeField] private int _particleCount;
        [SerializeField] private Vector2 _opacityRange;

        private ParticleSystem _particleSystem;
        private ParticleSystem.EmitParams _emitParams;
        private Color _particleColor;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();

            _emitParams = new ParticleSystem.EmitParams();
            _emitParams.applyShapeToPosition = true;

            _particleColor = _particleSystem.main.startColor.color;

            _playerDash.OnDash += Play;
        }

        private void OnDestroy()
        {
            _playerDash.OnDash -= Play;
        }

        private void Play()
        {
            Vector2 startDashPosition = _playerDash.StartDashPosition;
            Vector2 endDashPosition = _playerDash.EndDashPosition;

            for (int i = 0; i < _particleCount; i++)
            {
                _emitParams.startColor = _particleColor.SetOpacity(Random.Range(_opacityRange.x, _opacityRange.y));

                _emitParams.position = startDashPosition;
                _particleSystem.Emit(_emitParams, 1);

                _emitParams.position = endDashPosition;
                _particleSystem.Emit(_emitParams, 1);
            }
        }
    }
}