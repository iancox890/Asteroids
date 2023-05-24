using UnityEngine;
using Asteroids.Data;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Sets the player ships sprite renderer color to the currently equipped color value.
    /// </summary>
    public class PlayerShipColor : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;

        private void Start()
        {
            Color shipColor = _playerData.File.ShipColor;
            GetComponent<SpriteRenderer>().color = shipColor;

            var main = GetComponentInChildren<ParticleSystem>().main;
            main.startColor = shipColor;
        }
    }
}