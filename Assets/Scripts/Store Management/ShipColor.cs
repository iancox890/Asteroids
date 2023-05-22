using UnityEngine;

namespace AsteroidsApp.StoreManagement
{
    /// <summary>
    /// Represents any ship color store item.
    /// </summary>
    [CreateAssetMenu(fileName = "ShipColor", menuName = "Store Items/Ship Color")]
    public class ShipColor : StoreItem, IEquippable
    {
        [SerializeField] private Color _color;

        public void SetEquippedState(bool equipped)
        {

        }
    }
}