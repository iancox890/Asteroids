using UnityEngine;
using Asteroids.Data;

namespace Asteroids.UI
{
    /// <summary>
    /// Purchases the currently selected item if it is purchasable.
    /// If not, set the button interactable to false.
    /// </summary>
    public class UIBuyButton : UIButton
    {
        [SerializeField] private PlayerData _playerData;

        private UIStoreManager _storeManager;

        private void Start()
        {
            _storeManager = FindObjectOfType<UIStoreManager>();
            _storeManager.OnSelected += UpdateButtonState;

            Button.interactable = false;
        }

        private void OnDestroy()
        {
            _storeManager.OnSelected -= UpdateButtonState;
        }

        private void UpdateButtonState()
        {
            if (_storeManager.IsPurchasable)
            {
                Button.interactable = true;
            }
            else
            {
                Button.interactable = false;
            }
        }

        protected override void OnClicked()
        {
            _storeManager.Purchase();
            Button.interactable = false;
        }
    }
}