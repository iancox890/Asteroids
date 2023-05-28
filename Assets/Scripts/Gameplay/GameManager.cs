using UnityEngine;
using Asteroids.Data;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Manages the game over state.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private GameObject[] _ships;

        private PlayerLifeManager _lifeManager;

        public static event System.Action OnGameOver;

        private void Awake()
        {
            string currentShip = _playerData.File.Ship;

            for (int i = 0; i < _ships.Length; i++)
            {
                if (_ships[i].name.Equals(currentShip))
                {
                    Instantiate(_ships[i]);
                    break;
                }
            }

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