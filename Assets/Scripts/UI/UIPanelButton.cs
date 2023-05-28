using UnityEngine;

namespace Asteroids.UI
{
    /// <summary>
    /// Switches the panel when clicked.
    /// </summary>
    public class UIPanelButton : UIButton
    {
        [SerializeField] private GameObject _panelToDisable;
        [SerializeField] private GameObject _panelToEnable;

        protected override void OnClicked()
        {
            _panelToDisable.SetActive(false);
            _panelToEnable.SetActive(true);
        }
    }
}