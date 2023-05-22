namespace AsteroidsApp.StoreManagement
{
    /// <summary>
    /// Defines an interface for equipping/unequipping store items.
    /// </summary>
    public interface IEquippable
    {
        void SetEquippedState(bool equipped);
    }
}