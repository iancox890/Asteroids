using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
            Color shipColor = _playerData.File.ShipColor;

            Image image = GetComponent<Image>();
            if (image != null)
            {
                image.color = _playerData.File.ShipColor.SetOpacity(image.color.a);
                return;
            }

            TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();
            if (textMesh != null)
            {
                textMesh.color = shipColor.SetOpacity(textMesh.color.a);
            }
        }
    }
}