using System.Collections;
using GameSystem;
using Pool;
using UnityEngine;

namespace Enemy.Spawn
{
    public sealed class SpawnInitializer : MonoBehaviour, 
        IGameStartElement, IGameFinishElement,
        IGamePauseElement, IGameResumeElement
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _poolSize;
        [SerializeField] private PoolSystem _pool;
        
        [SerializeField] private EnemySpawner enemyEnemySpawner;
        [SerializeField] private int _timeInterval;

        private Coroutine _spawnCoroutine;

        private bool _isPaused;
        
        private void Awake()
        {
            // TODO: Change to a constructor method.
            // Я понимаю, что не следуют исплользовать Awake в задании, но решил такую реализацию сделать установки зависимостей
            IGameElement.Register(this);
        }

        public void Remove(GameObject enemy)
        {
            ReleaseToPool(enemy);
            
            TryToStartCoroutine();
        }        
        
        void IGameStartElement.OnStart()
        {
            CreatePool();
            TryToStartCoroutine();
        }
        
        void IGamePauseElement.Pause()
        {
            _isPaused = true;
        }

        void IGameResumeElement.Resume()
        {
            _isPaused = false;
        }
    
        void IGameFinishElement.Finish()
        {
            IGameElement.Unregister(this);

            Destroy(gameObject);
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
                yield return new WaitWhile(() => _isPaused);
                
                yield return new WaitForSeconds(_timeInterval);
                
                yield return new WaitWhile(() => _isPaused);
                
                GameObject rawEnemy = GetFromPool();
            
                if (rawEnemy is null)
                    break;
            
                enemyEnemySpawner.Spawn(rawEnemy);
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