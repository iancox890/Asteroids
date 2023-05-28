using UnityEngine;

namespace Asteroids.Data
{
    /// <summary>
    /// Represents any ship color store item.
    /// </summary>
    [CreateAssetMenu(menuName = "Asteroids/Store Items/Ship Color", fileName = "Ship Color")]
    public class ShipColorData : StoreData
    {
        [Header("Color Data")]
        [SerializeField] private Color _color;
        public Color Color => _color;

        public override void Equip(PlayerData playerData)
        {
            playerData.File.ShipColor = _color;
            playerData.SavePlayerFile();
        }
    }
}