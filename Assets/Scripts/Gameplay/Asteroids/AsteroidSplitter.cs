using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Controls whether or not an asteroid gets split on collision.
    /// 
    /// If so, it splits the asteroid up into two halves of the destroyed asteroids scale
    /// distributed randomly across the two new asteroids.
    /// </summary>
    public class AsteroidSplitter : MonoBehaviour
    {
        private const int SPLIT_COUNT = 2;

        [SerializeField] private float _splitScaleThreshold;

        private ObjectPool _objectPool;

        private AsteroidDestroyer _asteroidDestruction;
        private Transform _transform;

        private void Awake()
        {
            _objectPool = FindObjectOfType<ObjectPool>();

            _asteroidDestruction = GetComponent<AsteroidDestroyer>();
            _transform = GetComponent<Transform>();

            _asteroidDestruction.OnAsteroidDestroyed += Split;
        }

        private void OnDestroy()
        {
            _asteroidDestruction.OnAsteroidDestroyed -= Split;
        }

        private void Split(string tag)
        {
            float asteroidScale = _transform.localScale.x;

            if (asteroidScale < _splitScaleThreshold)
            {
                return;
            }

            Vector2 position = _transform.position;
            float scalePercent = Random.Range(0.5f, 0.65f);

            for (int i = 0; i < SPLIT_COUNT; i++)
            {
                Vector2 scale = Vector2.one * asteroidScale * scalePercent;
                AsteroidSpawner.Spawn(scale, position, Random.insideUnitCircle);
            }
        }
    }
}