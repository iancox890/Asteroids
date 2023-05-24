using UnityEngine;
using Asteroids.Gameplay;

namespace Asteroids
{
    /// <summary>
    /// Manages the game over state.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private PlayerLifeManager _lifeManager;

        public event System.Action OnGameOver;

        private void Start()
        {
            _lifeManager = FindObjectOfType<PlayerLifeManager>();
            _lifeManager.OnLifeLost += UpdateGameOverState;
        }

        private void OnDestroy()
        {
            _lifeManager.OnLifeLost -= UpdateGameOverState;
        }

        private void UpdateGameOverState(int lives)
        {
            if (lives <= 0)
            {
                OnGameOver?.Invoke();
            }
        }
    }
}