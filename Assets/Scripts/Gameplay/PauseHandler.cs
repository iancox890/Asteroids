using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Checks to see if ESC was pressed, and if it is then pause the game
    /// via freezing the time scale and firing the OnPaused event.
    /// </summary>
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] _behaviorsToPause;

        private bool _isPaused;
        public bool IsPaused => _isPaused;

        public event System.Action OnPaused;

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetPausedState(!_isPaused);
            }
        }

        public void SetPausedState(bool isPaused)
        {
            _isPaused = isPaused;
            Time.timeScale = _isPaused ? 0 : 1;

            for (int i = 0; i < _behaviorsToPause.Length; i++)
            {
                _behaviorsToPause[i].enabled = !_isPaused;
            }

            OnPaused?.Invoke();
        }
    }
}