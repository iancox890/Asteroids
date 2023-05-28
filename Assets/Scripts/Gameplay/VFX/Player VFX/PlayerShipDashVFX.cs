using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Controls the VFX for when the player dashes.
    /// (chromatic abberation, camera shake, lens distortion)
    /// </summary>
    public class PlayerShipDashVFX : MonoBehaviour
    {
        [SerializeField][Range(0, 1)] private float _chromaticAberrationTrauma;
        [SerializeField][Range(0, 1)] private float _lensDistortionTrauma;
        [SerializeField][Range(0, 1)] private float _cameraShakeTrauma;

        private ChromaticAberrationHandler _chromaticAberrationHandler;
        private LensDistortionHandler _lensDistortionHandler;
        private CameraShakeHandler _cameraShakeHandler;
        private PlayerShipDash _playerDash;

        private void Start()
        {
            _chromaticAberrationHandler = FindObjectOfType<ChromaticAberrationHandler>();
            _lensDistortionHandler = FindObjectOfType<LensDistortionHandler>();
            _cameraShakeHandler = Camera.main.GetComponent<CameraShakeHandler>();

            _playerDash = GetComponent<PlayerShipDash>();

            _playerDash.OnDash += ApplyVFX;
        }

        private void OnDestroy()
        {
            _playerDash.OnDash -= ApplyVFX;
        }

        private void ApplyVFX()
        {
            _chromaticAberrationHandler.Trauma += _chromaticAberrationTrauma;
            _lensDistortionHandler.Trauma += _lensDistortionTrauma;
            _cameraShakeHandler.Trauma += _cameraShakeTrauma;
        }
    }
}