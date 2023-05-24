using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Handles the current IBlaster attached to this object.
    /// </summary>
    public class BlasterController : MonoBehaviour
    {
        private IBlaster _blaster;

        private void Start()
        {
            _blaster = GetComponent<IBlaster>();
        }

        private void Update()
        {
            if (_blaster.HandleInput())
            {
                _blaster.Fire();
            }
        }
    }
}