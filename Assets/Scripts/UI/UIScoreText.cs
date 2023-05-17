using UnityEngine;
using TMPro;
using AsteroidsApp.ScoreManagement;

namespace AsteroidsApp.UI
{
    /// <summary>
    /// Updates the score text when the score is changed.
    /// </summary>
    public class UIScoreText : MonoBehaviour
    {
        [SerializeField] private string _prefix;

        private ScoreManager _scoreManager;
        private TextMeshProUGUI _scoreText;

        private void Start()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
            _scoreText = GetComponent<TextMeshProUGUI>();

            UpdateText(_scoreManager.Score);

            _scoreManager.OnScoreUpdated += UpdateText;
        }

        private void OnDestroy()
        {
            _scoreManager.OnScoreUpdated -= UpdateText;
        }

        private void UpdateText(int score)
        {
            _scoreText.text = _prefix + score.ToString();
        }
    }
}