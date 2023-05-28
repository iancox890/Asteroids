using UnityEngine;
using TMPro;
using Asteroids.Data;

namespace Asteroids.UI
{
    /// <summary>
    /// Updates the ship upgrade description text on selection change.
    /// </summary>
    public class UIShipUpgradeDescription : MonoBehaviour
    {
        private UIStoreManager _storeManager;
        private TextMeshProUGUI _description;

        private void OnEnable()
        {
            if (_storeManager == null || _description == null)
            {
                _storeManager = FindObjectOfType<UIStoreManager>();
                _description = GetComponent<TextMeshProUGUI>();
            }

            _description.text = string.Empty;
            _storeManager.OnSelected += UpdateDescription;
        }

        private void OnDisable()
        {
            _storeManager.OnSelected -= UpdateDescription;
        }

        private void UpdateDescription()
        {
            if (_storeManager.SelectedItem != null)
            {
                _description.text = (_storeManager.SelectedItem as ShipUpgradeData).UpgradeDescription;
            }
        }
    }
}