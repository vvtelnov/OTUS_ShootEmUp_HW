using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private PoolSystem _pool;
        [SerializeField] private PoolObjectsCreator _poolObjectsCreator;

        [SerializeField] private EnemySpawner _enemySpawner;

        private readonly HashSet<GameObject> _activeEnemies = new();
        private Coroutine _enemySpawnCoroutine;

        private void Start()
        {
            CreatePool();

            StartSpawnRotine();
        }

        private IEnumerator SpawnRotine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);


                GameObject enemyRaw = _pool.Get();

                if (enemyRaw == null)
                {
                    _enemySpawnCoroutine = null;

                    yield break;
                }

                GameObject enemy = _enemySpawner.SpawnEnemy(enemyRaw);

                TryToAddEnemy(enemy);
            }
        }

        private void StartSpawnRotine()
        {
            if (_enemySpawnCoroutine != null)
            {
                return;
            }

            _enemySpawnCoroutine = StartCoroutine(SpawnRotine());
        }

        private void CreatePool()
        {
            GameObject[] Enemies = _poolObjectsCreator.GetCreatedObjects();
            _pool.CreatePool(Enemies);
        }

        private void TryToAddEnemy(GameObject enemy)
        {
            if (_activeEnemies.Add(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().HpEmpty += OnDestroyed;
                return;
            }

            throw new InvalidOperationException("Enemy cannot be added to HashSet<GameObject> _activeEnemies ");
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().HpEmpty -= OnDestroyed;

                _pool.Release(enemy);

                StartSpawnRotine();
            }
        }
    }
}