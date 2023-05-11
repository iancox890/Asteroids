using UnityEngine;
using System.Collections;

namespace Asteroids.WaveManagement
{
    public class AsteroidWave : MonoBehaviour
    {
        [Header("Wave Settings")]

        [SerializeField] private int _spawnCount;
        [SerializeField] private float _spawnMultiplier;
        [SerializeField] private Vector2 _spawnScaleRange;
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
            int asteroidsToSpawn = (int)(_spawnCount + (_spawnMultiplier * _waveManager.Wave));

            for (int i = 0; i < asteroidsToSpawn; i++)
            {
                Vector2 spawnScale = Vector2.one * Random.Range(_spawnScaleRange.x, _spawnScaleRange.y);
                Vector2 spawnPosition = ScreenBounds.GetRandomBoundsPosition(spawnScale.x);

                AsteroidSpawner.Spawn(spawnScale, spawnPosition);

                yield return _spawnTime;
            }
        }
    }
}