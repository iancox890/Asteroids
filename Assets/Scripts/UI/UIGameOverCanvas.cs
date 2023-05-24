using UnityEngine;

namespace Asteroids
{
    /// <summary>
    /// Activates the game over screen and deactivates
    /// tje gameplay canvas.
    /// </summary>
    public class UIGameOverCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _gameplayCanvas;
        [SerializeField] private GameObject _gameOverPanel;

        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.OnGameOver += Activate;
        }

        private void OnDestroy()
        {
            _gameManager.OnGameOver -= Activate;
        }

        private void Activate()
        {
            _gameplayCanvas.SetActive(false);
            _gameOverPanel.SetActive(true);
        }
    }
}