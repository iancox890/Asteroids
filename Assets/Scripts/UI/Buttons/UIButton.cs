using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsApp.UI
{
    /// <summary>
    /// Parent class for any button for easily implementing
    /// on click functionality.
    /// </summary>
    public class UIButton : MonoBehaviour
    {
        private Button _button;
        public Button Button
        {
            get
            {
                if (_button == null)
                {
                    _button = GetComponent<Button>();
                }

                return _button;
            }
            protected set => _button = value;
        }

        private void OnEnable()
        {
            Button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(OnClicked);
        }

        protected virtual void OnClicked() { }
    }
}