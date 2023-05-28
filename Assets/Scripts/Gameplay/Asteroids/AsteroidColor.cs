using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Sets the asteroid to a random gradient value when it is enabled.
    /// </summary>
    public class AsteroidColor : MonoBehaviour
    {
        [SerializeField] private Gradient _asteroidGradient;

        private SpriteRenderer _spriteRenderer;

        private void OnEnable()
        {
            if (_spriteRenderer == null)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }

            _spriteRenderer.color = _asteroidGradient.Evaluate(Random.value);
        }
    }
}