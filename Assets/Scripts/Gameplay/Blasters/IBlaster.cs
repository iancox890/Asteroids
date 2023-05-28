namespace Asteroids.Gameplay
{
    /// <summary>
    /// Defines the blaster fire method and input handling.
    /// </summary>
    public interface IBlaster
    {
        void Fire();
        bool HandleInput();
        event System.Action OnFire;
    }
}