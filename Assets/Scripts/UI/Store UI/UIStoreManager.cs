using UnityEngine;
using Asteroids.Data;

namespace Asteroids.UI
{
    /// <summary>
    /// Manages the currently selected store item.
    /// This includes purchasing, and equipping.
    /// </summary>
    public class UIStoreManager : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        public PlayerData PlayerData => _playerData;

        private StoreData _selectedItem;
        public StoreData SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnSelected?.Invoke();
            }
        }

        public event System.Action OnSelected;
        public event System.Action OnPurchased;

        public bool IsPurchasable => _selectedItem != null && _playerData.File.Points >= _selectedItem.Price && _selectedItem.File.IsPurchased == false;
        public bool IsEquippable => _selectedItem != null && _selectedItem.File.IsPurchased;

        public void Purchase()
        {
            _playerData.File.Points -= _selectedItem.Price;
            _selectedItem.File.IsPurchased = true;

            _playerData.SavePlayerFile();
            _selectedItem.SaveStoreFile();

            OnPurchased?.Invoke();
        }
    }
}