using UnityEngine;

namespace Asteroids.WaveManagement
{
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