using UnityEngine;
using UnityEngine.UI;
using Asteroids.Data;

namespace Asteroids.UI
{
    /// <summary>
    /// Sets the image or text component color value to that of the currently equipped
    /// ship color.
    /// </summary>
    public class UIEquippedShipColor : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;

        private void Start()
        {
            Image image = GetComponent<Image>();
            image.color = _playerData.File.ShipColor.SetOpacity(image.color.a);
        }
    }
}