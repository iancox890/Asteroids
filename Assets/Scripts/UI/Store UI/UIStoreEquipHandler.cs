using UnityEngine;
using System.Collections.Generic;
using Asteroids.Data;

namespace Asteroids.UI
{
    /// <summary>
    /// Handles the equip/unequip controls for a given store panel.
    /// </summary>
    public class UIStoreEquipHandler : MonoBehaviour
    {
        private UIStoreManager _storeManager;
        private StoreData _equippedItem;

        public event System.Action OnEquipped;

        private void Start()
        {
            _storeManager = FindObjectOfType<UIStoreManager>();

            UIStoreItem[] storeItems = GetComponentsInChildren<UIStoreItem>();

            for (int i = 0; i < storeItems.Length; i++)
            {
                if (storeItems[i].StoreData.File.IsEquipped)
                {
                    _equippedItem = storeItems[i].StoreData;
                    break;
                }
            }
        }

        public void EquipItem()
        {
            _equippedItem.File.IsEquipped = false;
            _equippedItem.SaveStoreFile();

            _equippedItem = _storeManager.SelectedItem;

            _equippedItem.File.IsEquipped = true;
            _equippedItem.Equip(_storeManager.PlayerData);

            _equippedItem.SaveStoreFile();

            OnEquipped?.Invoke();
        }
    }
}