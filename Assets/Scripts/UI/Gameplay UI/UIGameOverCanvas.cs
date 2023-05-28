using UnityEngine;
using Asteroids.Gameplay;

namespace Asteroids.UI
{
    /// <summary>
    /// Activates the game over screen and deactivates
    /// tje gameplay canvas.
    /// </summary>
    public class UIGameOverCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _gameplayCanvas;
        [SerializeField] private GameObject _gameOverPanel;

        private void Start()
        {
            GameManager.OnGameOver += Activate;
        }

        private void OnDestroy()
        {
            GameManager.OnGameOver -= Activate;
        }

        private void Activate()
        {
            _gameplayCanvas.SetActive(false);
            _gameOverPanel.SetActive(true);
        }
    }
}