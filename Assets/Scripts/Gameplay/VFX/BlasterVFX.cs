using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Applys camera shake when the blaster is fired.
    /// </summary>
    public class BlasterVFX : MonoBehaviour
    {
        [SerializeField][Range(0, 1)] private float _cameraShakeTrauma;

        private CameraShakeHandler _cameraShakeHandler;
        private IBlaster _blaster;

        private void Start()
        {
            _cameraShakeHandler = Camera.main.GetComponent<CameraShakeHandler>();
            _blaster = GetComponent<IBlaster>();

            _blaster.OnFire += ApplyVFX;
        }

        private void OnDestroy()
        {
            _blaster.OnFire -= ApplyVFX;
        }

        private void ApplyVFX()
        {
            if (_cameraShakeHandler.Trauma < _cameraShakeTrauma)
            {
                _cameraShakeHandler.Trauma = _cameraShakeTrauma;
            }
        }
    }
}