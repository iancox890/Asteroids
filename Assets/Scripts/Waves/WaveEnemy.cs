using UnityEngine;

namespace AsteroidsApp.WaveManagement
{
    /// <summary>
    /// Represents an enemy actor which is a part of a wave.
    /// Adds/subtracts from the overall wave enemy count.
    /// </summary>
    public class WaveEnemy : MonoBehaviour
    {
        private static int _count;
        public static int Count => _count;

        public static event System.Action OnAllWaveEnemiesDestroyed;

        private void OnEnable()
        {
            _count++;
        }

        private void OnDisable()
        {
            _count--;

            if (_count == 0)
            {
                OnAllWaveEnemiesDestroyed?.Invoke();
            }
        }
    }
}