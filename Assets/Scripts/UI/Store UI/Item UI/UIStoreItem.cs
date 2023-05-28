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
        [SerializeField] private Image _selectedHighlight;
        [SerializeField] private TextMeshProUGUI _itemText;
        [Space(2)]
        [SerializeField] private float _selectedHighlightOpacity;
        [SerializeField] private float _hoverHighlightOpacity;

        private StoreData _storeData;
        public StoreData StoreData { get => _storeData; set => _storeData = value; }

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

        private void OnDestroy()
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
                }
                else
                {
                    _itemText.text = "Owned";
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