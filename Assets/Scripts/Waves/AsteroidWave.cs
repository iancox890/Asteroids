using UnityEngine;
using System.Collections;

namespace Asteroids.WaveManagement
{
    public class AsteroidWave : MonoBehaviour
    {
        [Header("Wave Settings")]

        [SerializeField] private int _spawnCount;
        [SerializeField] private int _spawnMultiplier;
        [SerializeField] private float _timeBetweenSpawns;

        [Space(2)]

        [Header("Asteroid Settings")]

        [SerializeField] private Vector2 _spawnScaleRange;
        [SerializeField] private Vector2 _spawnVelocityRange;
        [SerializeField] private Vector2 _spawnAngularVelocityRange;

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
            int asteroidsToSpawn = _spawnCount + (_spawnMultiplier * _waveManager.Wave);

            for (int i = 0; i < asteroidsToSpawn; i++)
            {
                Vector2 spawnScale = Vector2.one * Random.Range(_spawnScaleRange.x, _spawnScaleRange.y);
                Vector2 spawnPosition = ScreenBounds.GetRandomBoundsPosition(spawnScale.x);
                Vector2 spawnVelocity = Random.insideUnitCircle * Random.Range(_spawnVelocityRange.x, _spawnVelocityRange.y);
                float spawnAngularVelocity = Random.Range(_spawnAngularVelocityRange.x, _spawnAngularVelocityRange.y);

                AsteroidSpawner.Spawn(spawnPosition, spawnScale, spawnVelocity, spawnAngularVelocity);

                yield return _spawnTime;
            }
        }
    }
}