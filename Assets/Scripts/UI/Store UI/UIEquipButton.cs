using UnityEngine;
using Asteroids.Data;

namespace Asteroids.UI
{
    /// <summary>
    /// Equips the currently selected item if it is already purchased. If not,
    /// sets the interactable state to false.
    /// </summary>
    public class UIEquipButton : UIButton
    {
        private UIStoreManager _storeManager;
        private UIStoreEquipHandler _equipHandler;

        private void Start()
        {
            _storeManager = FindObjectOfType<UIStoreManager>();
            _equipHandler = GetComponentInParent<UIStoreEquipHandler>();

            _storeManager.OnSelected += UpdateButtonState;
            _storeManager.OnPurchased += UpdateButtonState;

            Button.interactable = false;
        }

        private void OnDestroy()
        {
            _storeManager.OnSelected -= UpdateButtonState;
            _storeManager.OnPurchased -= UpdateButtonState;
        }

        private void UpdateButtonState()
        {
            if (_storeManager.IsEquippable)
            {
                Button.interactable = true;

                if (_storeManager.SelectedItem.File.IsEquipped)
                {
                    ButtonText.text = "EQUIPPED";
                }
                else
                {
                    ButtonText.text = "EQUIP";
                }
            }
            else
            {
                Button.interactable = false;
                ButtonText.text = "EQUIP";
            }
        }

        protected override void OnClicked()
        {
            _equipHandler.EquipItem();
            ButtonText.text = "EQUIPPED";
        }
    }
}