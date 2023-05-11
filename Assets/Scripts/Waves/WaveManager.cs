using UnityEngine;
using System.Collections;

namespace Asteroids.WaveManagement
{
    /// <summary>
    /// Manages the waves of asteroids/enemies on an 
    /// infinite cycle.
    /// </summary>
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private float _secondsBetweenWaves;

        private WaitForSeconds _waveStartTime;

        private int _wave = -1;
        public int Wave => _wave;

        public event System.Action OnBeginWave;

        private void Awake()
        {
            _waveStartTime = new WaitForSeconds(_secondsBetweenWaves);
            WaveEnemy.OnAllWaveEnemiesDestroyed += Start;
        }

        private void Start()
        {
            StopAllCoroutines();
            StartCoroutine(BeginWave());
        }

        private void OnDestroy()
        {
            WaveEnemy.OnAllWaveEnemiesDestroyed -= Start;
        }

        private IEnumerator BeginWave()
        {
            yield return _waveStartTime;

            _wave++;
            OnBeginWave?.Invoke();
        }
    }
}