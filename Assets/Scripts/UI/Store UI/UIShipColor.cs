using UnityEngine;
using UnityEngine.UI;
using Asteroids.Data;

namespace Asteroids.UI
{
    /// <summary>
    /// Sets the image color to the color property defined in the
    /// StoreData in the UIStoreItem component.
    /// </summary>
    public class UIShipColor : MonoBehaviour
    {
        private void Start()
        {
            Color shipColor = (GetComponentInParent<UIStoreItem>().StoreData as ShipColorData).Color;

            Image image = GetComponent<Image>();
            float opacity = image.color.a;

            image.color = shipColor.SetOpacity(opacity);
        }
    }
}