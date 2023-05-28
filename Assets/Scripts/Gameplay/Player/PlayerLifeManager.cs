using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Manages how many lives the player has, and notifies
    /// any subscribed objects when a life is lost.
    /// </summary>
    public class PlayerLifeManager : MonoBehaviour
    {
        [SerializeField] private PlayerShipDeathHandler _deathHandler;

        [SerializeField] private int _startingLives;
        public int StartingLives => _startingLives;

        private int _currentLifeCount;

        public event System.Action<int> OnLifeLost;

        private void Start()
        {
            _deathHandler.OnDeath += SubtractLife;
            _currentLifeCount = _startingLives;
        }

        private void OnDestroy()
        {
            _deathHandler.OnDeath -= SubtractLife;
        }

        private void SubtractLife()
        {
            _currentLifeCount = Mathf.Clamp(_currentLifeCount - 1, 0, _startingLives);
            OnLifeLost?.Invoke(_currentLifeCount);
        }
    }
}