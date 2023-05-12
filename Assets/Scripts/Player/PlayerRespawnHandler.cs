using UnityEngine;

namespace AsteroidsApp.Player
{
    /// <summary>
    /// Handle the respawn for the player if they haven't lost
	/// all of their lives.
    /// </summary>
    public class PlayerRespawnHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _playerShip;
        [SerializeField] private float _respawnDelay;

        private PlayerLifeManager _lifeManager;

        public event System.Action OnRespawn;

        private void Start()
        {
            _lifeManager = GetComponent<PlayerLifeManager>();
            _lifeManager.OnLifeLost += HandleRespawn;
        }

        private void OnDestroy()
        {
            _lifeManager.OnLifeLost -= HandleRespawn;
        }

        private void HandleRespawn(int lives)
        {
            if (lives > 0)
            {
                Invoke(nameof(Respawn), _respawnDelay);
            }
        }

        private void Respawn()
        {
            _playerShip.SetActive(true);
            OnRespawn?.Invoke();
        }
    }
}