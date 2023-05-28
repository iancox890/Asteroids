using UnityEngine;

namespace Asteroids.Data
{
    /// <summary>
    /// Holds the custom data for the player, such as their
    /// currently equipped
    /// </summary>
    [System.Serializable]
    public class PlayerFile
    {
        [SerializeField] private Color _shipColor;
        public Color ShipColor { get => _shipColor; set => _shipColor = value; }

        [SerializeField] private string _ship;
        public string Ship { get => _ship; set => _ship = value; }

        [SerializeField] private int _points;
        public int Points { get => _points; set => _points = value; }
    }
}