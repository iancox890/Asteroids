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

        private PauseHandler _pauseHandler;

        private void Start()
        {
            _pauseHandler = FindObjectOfType<PauseHandler>();
            _pauseHandler.OnPaused += TogglePanel;
        }

        private void OnDestroy()
        {
            _pauseHandler.OnPaused -= TogglePanel;
        }

        private void TogglePanel()
        {
            _pausePanel.SetActive(_pauseHandler.IsPaused);
        }
    }
}