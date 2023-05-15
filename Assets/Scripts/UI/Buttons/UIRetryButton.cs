using UnityEngine.SceneManagement;

namespace AsteroidsApp.UI
{
    /// <summary>
    /// Reloads the game scene when clicked.
    /// </summary>
    public class UIRetryButton : UIButton
    {
        protected override void OnClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().path);
        }
    }
}