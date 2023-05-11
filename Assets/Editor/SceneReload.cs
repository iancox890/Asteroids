using UnityEditor.SceneManagement;
using UnityEditor;

namespace AsteroidsApp.Editor
{
    public class SceneReload
    {
        [MenuItem("Asteroids/Reload _R")]
        public static void Reload()
        {
            EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().path);
        }
    }
}