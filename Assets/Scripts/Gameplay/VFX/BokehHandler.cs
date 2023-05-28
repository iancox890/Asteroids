using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Toggles the bokeh effect on pause/game over.
    /// </summary>
    public class BokehHandler : MonoBehaviour
    {
        private DepthOfField _bokeh;

        private void Start()
        {
            GetComponent<Volume>().profile.TryGet<DepthOfField>(out _bokeh);

            GameManager.OnGameOver += Toggle;
            PauseHandler.OnPaused += Toggle;
        }

        private void OnDestroy()
        {
            GameManager.OnGameOver -= Toggle;
            PauseHandler.OnPaused -= Toggle;
        }

        private void Toggle()
        {
            _bokeh.active = !_bokeh.active;
        }
    }
}