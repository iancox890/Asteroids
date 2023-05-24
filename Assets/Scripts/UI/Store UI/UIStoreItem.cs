using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Asteroids.Data;

namespace Asteroids.UI
{
    /// <summary>
    /// Controls the item selection in the store.
    /// </summary>
    public class UIStoreItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [UnityEngine.Serialization.FormerlySerializedAs("_storeItem")]
        [SerializeField] private StoreData _storeData;
        public StoreData StoreData => _storeData;

        [Space(5)]

        [UnityEngine.Serialization.FormerlySerializedAs("_highlight")]
        [SerializeField] private Image _selectedHighlight;
        [SerializeField] private Image _equippedHighlight;
        [Space(2)]
        [SerializeField] private TextMeshProUGUI _itemText;

        [Space(2)]

        [SerializeField] private float _selectedHighlightOpacity;
        [SerializeField] private float _hoverHighlightOpacity;

        private UIStoreManager _storeManager;
        private UIStoreEquipHandler _equipHandler;
        private bool _isSelected;

        private void Start()
        {
            _storeManager = FindObjectOfType<UIStoreManager>();
            _equipHandler = FindObjectOfType<UIStoreEquipHandler>();

            _storeManager.OnSelected += UpdateSelectedState;
            _storeManager.OnPurchased += UpdateItemState;
            _equipHandler.OnEquipped += UpdateItemState;

            UpdateItemState();
        }

        private void OnDisable()
        {
            _storeManager.OnSelected -= UpdateSelectedState;
            _storeManager.OnPurchased -= UpdateItemState;
            _equipHandler.OnEquipped -= UpdateItemState;
        }

        private void UpdateSelectedState()
        {
            if (_storeManager.SelectedItem == _storeData)
            {
                _isSelected = true;
            }
            else
            {
                _isSelected = false;
                _selectedHighlight.color = _selectedHighlight.color.SetOpacity(0);
            }
        }

        private void UpdateItemState()
        {
            if (_storeData.File.IsPurchased)
            {
                if (_storeData.File.IsEquipped)
                {
                    _itemText.text = "Equipped";
                    _equippedHighlight.enabled = true;
                }
                else
                {
                    _itemText.text = "Owned";
                    _equippedHighlight.enabled = false;
                }
            }
            else
            {
                _itemText.text = string.Format("{0:#,0}", _storeData.Price);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isSelected)
            {
                _storeManager.SelectedItem = null;
                _selectedHighlight.color = _selectedHighlight.color.SetOpacity(_hoverHighlightOpacity);
            }
            else
            {
                _storeManager.SelectedItem = _storeData;
                _selectedHighlight.color = _selectedHighlight.color.SetOpacity(_selectedHighlightOpacity);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_isSelected == false)
            {
                _selectedHighlight.color = _selectedHighlight.color.SetOpacity(_hoverHighlightOpacity);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_isSelected == false)
            {
                _selectedHighlight.color = _selectedHighlight.color.SetOpacity(0);
            }
        }
    }
}