using UnityEngine;

namespace Asteroids.Data
{
    public enum ShipUpgrades { }

    /// <summary>
    /// Represents any ship upgrade store item. 
    /// </summary>
    [CreateAssetMenu(menuName = "Asteroids/Store Items/Ship Upgrade", fileName = "Ship Upgrade")]
    public class ShipUpgradeData : StoreData
    {
        [Header("Upgrade Data")]
        [SerializeField] private GameObject _shipUpgrade;
        public GameObject ShipUpgrade => _shipUpgrade;

        [SerializeField] private string _upgradeDescription;
        public string UpgradeDescription => _upgradeDescription;

        public override void Equip(PlayerData playerData)
        {
            playerData.File.Ship = _shipUpgrade.name;
            playerData.SavePlayerFile();
        }
    }
}