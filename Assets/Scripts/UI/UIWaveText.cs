using UnityEngine;
using TMPro;
using AsteroidsApp.WaveManagement;

namespace AsteroidsApp.UI
{
    /// <summary>
    /// Updates the wave text when a wave begins. 
    /// </summary>
    public class UIWaveText : MonoBehaviour
    {
        private WaveManager _waveManager;
        private TextMeshProUGUI _waveText;

        private void Start()
        {
            _waveManager = FindObjectOfType<WaveManager>();
            _waveText = GetComponent<TextMeshProUGUI>();

            _waveManager.OnBeginWave += UpdateText;
        }

        private void OnDestroy()
        {
            _waveManager.OnBeginWave -= UpdateText;
        }

        private void UpdateText()
        {
            _waveText.text = _waveManager.Wave.ToString();
        }
    }
}