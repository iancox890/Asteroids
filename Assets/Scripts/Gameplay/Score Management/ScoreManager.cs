using UnityEngine;
using Asteroids.Gameplay;
using Asteroids.Data;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Manages the score and notifies any event listeners when it is updated.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private float _waveMultiplier;
        [SerializeField] private PlayerData _playerData;

        private GameManager _gameManager;
        private WaveManager _waveManager;

        private int _points;
        public int Points
        {
            get => _points;
            set
            {
                _points = value + Mathf.RoundToInt(_waveMultiplier * _waveManager.Wave - 1);
                OnScoreUpdated?.Invoke(_points);
            }
        }

        public event System.Action<int> OnScoreUpdated;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _waveManager = FindObjectOfType<WaveManager>();

            _gameManager.OnGameOver += Save;
        }

        private void OnDestroy()
        {
            _gameManager.OnGameOver -= Save;
        }

        private void Save()
        {
            _playerData.File.Points += _points;
        }
    }
}