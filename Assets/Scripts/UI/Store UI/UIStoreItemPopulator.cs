using UnityEngine;
using Asteroids.Data;
using System.Linq;

namespace Asteroids.UI
{
    /// <summary>
    /// Given a list of store items, instantiates a UIStoreItem prefab assigning each 
    /// store data to a store item data from the list.
    /// </summary>
    public class UIStoreItemPopulator : MonoBehaviour
    {
        [SerializeField] private StoreData[] _storeItems;
        [SerializeField] private UIStoreItem _itemPrefab;

        private void Awake()
        {
            _storeItems = _storeItems.OrderBy(item => item.Price).ToArray();

            for (int i = 0; i < _storeItems.Length; i++)
            {
                UIStoreItem item = Instantiate<UIStoreItem>(_itemPrefab, transform);
                item.StoreData = _storeItems[i];
            }
        }
    }
}