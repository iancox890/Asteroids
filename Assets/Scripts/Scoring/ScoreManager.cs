using UnityEngine;
using AsteroidsApp.WaveManagement;

namespace AsteroidsApp.ScoreManagement
{
    /// <summary>
    /// Manages the score and notifies any event listeners when it is updated.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private float _waveMultiplier;

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
            _waveManager = FindObjectOfType<WaveManager>();
        }
    }
}