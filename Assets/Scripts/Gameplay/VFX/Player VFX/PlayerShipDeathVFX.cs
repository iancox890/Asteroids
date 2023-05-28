using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Handles the VFX on player death, such as chromatic aberration/camera shake.
    /// </summary>
    public class PlayerShipDeathVFX : MonoBehaviour
    {
        [SerializeField][Range(0, 1)] private float _chromaticAberrationTrauma;
        [SerializeField][Range(0, 1)] private float _cameraShakeTrauma;

        private ChromaticAberrationHandler _chromaticAberrationHandler;
        private CameraShakeHandler _cameraShakeHandler;
        private PlayerShipDeathHandler _deathHandler;

        private void Start()
        {
            _chromaticAberrationHandler = FindObjectOfType<ChromaticAberrationHandler>();
            _cameraShakeHandler = Camera.main.GetComponent<CameraShakeHandler>();

            _deathHandler = GetComponent<PlayerShipDeathHandler>();

            _deathHandler.OnDeath += ApplyVFX;
        }

        private void OnDestroy()
        {
            _deathHandler.OnDeath -= ApplyVFX;
        }

        private void ApplyVFX()
        {
            _chromaticAberrationHandler.Trauma += _chromaticAberrationTrauma;
            _cameraShakeHandler.Trauma += _cameraShakeTrauma;
        }
    }
}