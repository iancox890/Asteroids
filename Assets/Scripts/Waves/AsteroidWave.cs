using UnityEngine;
using System.Collections;

using AsteroidsApp.Asteroid;

namespace AsteroidsApp.WaveManagement
{
    /// <summary>
    /// Responsible for the spawn details of asteroids for each wave.
    /// </summary>
    public class AsteroidWave : MonoBehaviour
    {
        [Header("Wave Settings")]
        [SerializeField] private int _spawnCount;
        [SerializeField] private float _spawnMultiplier;
        [Space(2)]
        [SerializeField] private Vector2 _spawnScaleRange;
        [SerializeField] private Vector2 _spawnDirectionAngleRange;
        [Space(2)]
        [SerializeField] private float _timeBetweenSpawns;

        private WaveManager _waveManager;
        private WaitForSeconds _spawnTime;

        private void Awake()
        {
            _waveManager = FindObjectOfType<WaveManager>();
            _spawnTime = new WaitForSeconds(_timeBetweenSpawns);

            _waveManager.OnBeginWave += StartSpawnWaveCoroutine;
        }

        private void OnDestroy()
        {
            _waveManager.OnBeginWave -= StartSpawnWaveCoroutine;
        }

        private void StartSpawnWaveCoroutine()
        {
            StopAllCoroutines();
            StartCoroutine(SpawnWave());
        }

        private IEnumerator SpawnWave()
        {
            int asteroidsToSpawn = (int)(_spawnCount + (_spawnMultiplier * (_waveManager.Wave - 1)));

            for (int i = 0; i < asteroidsToSpawn; i++)
            {
                Vector2 spawnScale = Vector2.one * Random.Range(_spawnScaleRange.x, _spawnScaleRange.y);
                Vector2 spawnPosition = ScreenBounds.GetRandomBoundsPosition(spawnScale.x / 2);

                // Calculates a direction towards the origin altered by a random angle.
                // This ensures the spawned asteroid will always be headed towards the player area, 
                // instead of occasionally being trapped on the outside of the screen.
                Quaternion directionAngle = Quaternion.Euler(0, 0, Random.Range(_spawnDirectionAngleRange.x, _spawnDirectionAngleRange.y));
                Vector2 direction = directionAngle * (Vector2.zero - spawnPosition).normalized;

                AsteroidSpawner.Spawn(spawnScale, spawnPosition, direction);

                yield return _spawnTime;
            }
        }
    }
}