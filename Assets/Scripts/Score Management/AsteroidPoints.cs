using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Controls how points are calculated/added to the score 
    /// when an asteroid is destroyed.
    /// </summary>
    public class AsteroidPoints : MonoBehaviour
    {
        [SerializeField] private int _points;
        [SerializeField] private float _pointMultiplierFromScale;

        private ScoreManager _scoreManager;
        private AsteroidDestroyer _asteroidDestroyer;
        private Transform _transform;
        private float _scale;

        private void Awake()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();

            _asteroidDestroyer = GetComponent<AsteroidDestroyer>();
            _transform = GetComponent<Transform>();

            _asteroidDestroyer.OnAsteroidDestroyed += AddPointsToScore;
        }

        private void OnEnable()
        {
            _scale = _transform.localScale.x;
        }

        private void OnDestroy()
        {
            _asteroidDestroyer.OnAsteroidDestroyed -= AddPointsToScore;
        }

        private void AddPointsToScore(string tag)
        {
            if (tag.Equals("Projectile"))
            {
                _scoreManager.Points += _points + Mathf.RoundToInt(_pointMultiplierFromScale * _scale);
            }
        }
    }
}