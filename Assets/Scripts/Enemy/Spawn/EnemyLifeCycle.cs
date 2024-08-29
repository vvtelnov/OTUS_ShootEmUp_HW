using System.Collections;
using GameSystem.DependencySystem.DI;
using GameSystem.GameContext;
using Pool;
using UnityEngine;

namespace Enemy.Spawn
{
    // Оставил Монобехом ради корутины
    [InjectionNeeded]
    public sealed class EnemyLifeCycle : MonoBehaviour, 
        IGameReadyElement, IGameStartElement, IGameFinishElement,
        IGamePauseElement, IGameResumeElement
    {
        [Inject(DependencyResolvePrinciple.FROM_PREFAB, "Enemy")]
        private GameObject _enemyPrefab;
        
        [Inject(DependencyResolvePrinciple.CREATE_NEW_INSTANCE)]
        private PoolSystem _pool;

        [Inject(DependencyResolvePrinciple.FROM_INACTIVE_GAME_OBJECT, objectName: "EnemyPoolHiddenContainer")]
        private GameObject _hiddenContainer; 
        
        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        private EnemySpawner _enemySpawner;
        
        [SerializeField] private int _timeInterval = 1;
        [SerializeField] private int _poolSize = 7;

        private Coroutine _spawnCoroutine;

        private bool _isPaused;

        
        public void Remove(GameObject enemy)
        {
            ReleaseToPool(enemy);
            
            TryToStartCoroutine();
        }

        void IGameReadyElement.Ready()
        {
            _enemySpawner.Construct(this);
            CreatePool();
        }
    
        void IGameStartElement.OnStart()
        {
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
            _pool.Construct(_enemyPrefab, _poolSize, _hiddenContainer);
            _pool.CreatePool();
        }
    }
}