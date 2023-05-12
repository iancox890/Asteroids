using UnityEngine;

namespace AsteroidsApp.Player
{
    /// <summary>
    /// Plays the death particles from the ship when the
    /// OnDeath event is called.
    /// </summary>
    public class PlayerShipDeathParticles : MonoBehaviour
    {
        [SerializeField] private PlayerShipDeathHandler _deathHandler;

        private ParticleSystem _particleSystem;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _deathHandler.OnDeath += Play;
        }

        private void OnDestroy()
        {
            _deathHandler.OnDeath -= Play;
        }

        private void Play()
        {
            _particleSystem.Play();
        }
    }
}