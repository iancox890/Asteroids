using UnityEngine;
using UnityEngine.UI;
using Asteroids.Data;

namespace Asteroids.UI
{
    /// <summary>
    /// Sets the image component to the ship upgrade sprite in the store item.
    /// </summary>
    public class UIShipUpgrade : MonoBehaviour
    {
        private void Start()
        {
            Sprite shipUpgrade = (GetComponentInParent<UIStoreItem>().StoreData as ShipUpgradeData).ShipUpgrade.GetComponentInChildren<SpriteRenderer>().sprite;
            GetComponent<Image>().sprite = shipUpgrade;
        }
    }
}