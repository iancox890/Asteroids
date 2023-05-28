
namespace Asteroids.Gameplay
{
    /// <summary>
    /// Provides an interface for any monobehavior that should be changed in
    /// some form when the game is paused.
    /// </summary>
    public interface IPausable
    {
        void OnPause();
    }
}