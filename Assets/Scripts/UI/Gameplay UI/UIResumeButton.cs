using Asteroids.Gameplay;

namespace Asteroids.UI
{
    /// <summary>
    /// Resumes the game via pause handler when clicked.
    /// </summary>
    public class UIResumeButton : UIButton
    {
        protected override void OnClicked()
        {
            FindObjectOfType<PauseHandler>().SetPausedState(false);
        }
    }
}