using UnityEngine;

namespace AsteroidsApp.Player
{
    /// <summary>
    /// Manages how many lives the player has, and notifies
    /// any subscribed objects when a life is lost.
    /// </summary>
    public class PlayerLifeManager : MonoBehaviour
    {
        [SerializeField] private int _lifeCount;

        private PlayerShipDeathHandler _deathHandler;
        private int _currentLifeCount;

        public event System.Action<int> OnLifeLost;

        private void Start()
        {
            _deathHandler = GetComponentInChildren<PlayerShipDeathHandler>();
            _deathHandler.OnDeath += SubtractLife;

            _currentLifeCount = _lifeCount;
        }

        private void OnDestroy()
        {
            _deathHandler.OnDeath -= SubtractLife;
        }

        private void SubtractLife()
        {
            _currentLifeCount--;
            OnLifeLost?.Invoke(_currentLifeCount);
        }
    }
}