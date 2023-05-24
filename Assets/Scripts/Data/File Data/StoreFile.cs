using UnityEngine;

namespace Asteroids.Data
{
    /// <summary>
    /// Holds the purchased state for all store items.
    /// </summary>
    [System.Serializable]
    public class StoreFile
    {
        [SerializeField] private bool _isPurchased;
        public bool IsPurchased { get => _isPurchased; set => _isPurchased = value; }

        [SerializeField] private bool _isEquipped;
        public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }
    }
}