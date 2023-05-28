using System.Linq;
using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Checks to see if ESC was pressed, and if it is then pause the game
    /// via freezing the time scale and firing the OnPaused event.
    /// </summary>
    public class PauseHandler : MonoBehaviour
    {
        private IPausable[] _behaviorsToPause;

        private static bool _isPaused;
        public static bool IsPaused => _isPaused;

        public static event System.Action OnPaused;

        private void Start()
        {
            _behaviorsToPause = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>().ToArray();
            GameManager.OnGameOver += Disable;
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetPausedState(!_isPaused);
            }
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            _isPaused = false;

            GameManager.OnGameOver -= Disable;
        }

        private void Disable()
        {
            enabled = false;
        }

        public void SetPausedState(bool isPaused)
        {
            _isPaused = isPaused;
            Time.timeScale = _isPaused ? 0 : 1;

            for (int i = 0; i < _behaviorsToPause.Length; i++)
            {
                _behaviorsToPause[i].OnPause();
            }

            OnPaused?.Invoke();
        }
    }
}