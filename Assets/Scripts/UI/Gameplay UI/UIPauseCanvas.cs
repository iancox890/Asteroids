using UnityEngine;
using Asteroids.Gameplay;

namespace Asteroids.UI
{
    /// <summary>
    /// Enables/disables the pause panel via the on paused event.
    /// </summary>
    public class UIPauseCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;

        private void Start()
        {
            PauseHandler.OnPaused += TogglePanel;
        }

        private void OnDestroy()
        {
            PauseHandler.OnPaused -= TogglePanel;
        }

        private void TogglePanel()
        {
            _pausePanel.SetActive(PauseHandler.IsPaused);
        }
    }
}