using System.IO.IsolatedStorage;
using UnityEngine;
using AsteroidsApp.WaveManagement;
using AsteroidsApp.FileManagement;

namespace AsteroidsApp.ScoreManagement
{
    /// <summary>
    /// Manages the score and notifies any event listeners when it is updated.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private float _waveMultiplier;

        private GameManager _gameManager;
        private WaveManager _waveManager;

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value + Mathf.RoundToInt(_waveMultiplier * _waveManager.Wave - 1);
                OnScoreUpdated?.Invoke(_score);
            }
        }

        public event System.Action<int> OnScoreUpdated;

        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _waveManager = FindObjectOfType<WaveManager>();

            _gameManager.OnGameOver += Save;

            var playerPoints = FileUtility.GetFile<PlayerPointsFile>("PlayerPoints");
            Debug.Log(Application.persistentDataPath);

            if (playerPoints != null)
            {
                Debug.Log(playerPoints.Points);
            }
        }

        private void OnDestroy()
        {
            _gameManager.OnGameOver -= Save;
        }

        private void Save()
        {
            PlayerPointsFile playerPoints = FileUtility.GetFile<PlayerPointsFile>("PlayerPoints");

            if (playerPoints == null)
            {
                playerPoints = new PlayerPointsFile();
            }

            playerPoints.Points += _score;
            playerPoints.Save();
        }
    }
}