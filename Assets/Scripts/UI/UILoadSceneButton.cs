using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.UI
{
    /// <summary>
    /// Loads the scene by name defined in the inspector when clicked.
    /// </summary>
    public class UILoadSceneButton : UIButton
    {
        [SerializeField] private string _sceneName;

        protected override void OnClicked()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}