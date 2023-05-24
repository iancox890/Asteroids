using UnityEngine;
using TMPro;
using Asteroids.Data;

namespace Asteroids.UI
{
    /// <summary>
    /// Displays the total number of points from the player data.
    /// </summary>
    public class UITotalPointsText : MonoBehaviour
    {
        private UIStoreManager _storeManager;
        private TextMeshProUGUI _pointsText;

        private void Start()
        {
            _storeManager = FindObjectOfType<UIStoreManager>();
            _pointsText = GetComponent<TextMeshProUGUI>();

            UpdatePointsText();

            _storeManager.OnPurchased += UpdatePointsText;
        }

        private void OnDestroy()
        {
            _storeManager.OnPurchased -= UpdatePointsText;
        }

        private void UpdatePointsText()
        {
            _pointsText.text = string.Format("{0:#,0}", _storeManager.PlayerData.File.Points);
        }
    }
}