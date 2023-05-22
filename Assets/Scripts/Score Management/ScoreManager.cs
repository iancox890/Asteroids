using UnityEngine;
using AsteroidsApp.WaveManagement;
using AsteroidsApp.FileData;

namespace AsteroidsApp.ScoreManagement
{
    /// <summary>
    /// Manages the score and notifies any event listeners when it is updated.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private float _waveMultiplier;

        public const string POINTS_DATA_FILE_NAME = "PointsData";

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
        }

        private void OnDestroy()
        {
            _gameManager.OnGameOver -= Save;
        }

        private void Save()
        {
            PointsData pointsData = FileUtility.GetFile<PointsData>(POINTS_DATA_FILE_NAME);

            if (pointsData == null)
            {
                pointsData = new PointsData(POINTS_DATA_FILE_NAME);
            }

            pointsData.Points += _score;
            pointsData.Save();
        }
    }
}