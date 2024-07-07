using System.Collections;
using Pool;
using UnityEngine;

namespace Enemy.Spawn
{
    public sealed class SpawnInitializer : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _poolSize;
        [SerializeField] private PoolSystem _pool;
        
        [SerializeField] private Spawner _enemySpawner;
        [SerializeField] private int _timeInterval;

        private Coroutine _spawnCoroutine;

        public void Remove(GameObject enemy)
        {
            ReleaseToPool(enemy);
            
            TryToStartCoroutine();
        }        
        
        private void Start()
        {
            CreatePool();
            TryToStartCoroutine();
        }
        
        private void TryToStartCoroutine()
        {
            if (_spawnCoroutine is not null)
                return;

            _spawnCoroutine = StartCoroutine(SpawnRotine());
        }
        
        private IEnumerator SpawnRotine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeInterval);
                
                GameObject rawEnemy = GetFromPool();
            
                if (rawEnemy is null)
                    break;
            
                _enemySpawner.Spawn(rawEnemy);
            }
            
            _spawnCoroutine = null;
        }

        private GameObject GetFromPool()
        {
            return _pool.TryToGet();
        }

        private void ReleaseToPool(GameObject enemy)
        {
            _pool.Release(enemy);
        }

        private void CreatePool()
        {
            _pool.CreatePool(_enemyPrefab, _poolSize);
        }
    }
}