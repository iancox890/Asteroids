using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.UI
{
    /// <summary>
    /// Base class for all UI scripts.
    /// </summary>
    public class UISlider : MonoBehaviour
    {
        protected Slider _slider;

        private void Start()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        protected void OnValueChanged(float value) { }
    }
}