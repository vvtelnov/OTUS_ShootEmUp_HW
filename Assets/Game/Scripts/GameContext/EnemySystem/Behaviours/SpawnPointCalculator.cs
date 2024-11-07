using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.GameContext.EnemySystem.Behaviours
{
    public class SpawnPointCalculator : IEntityInit, IEntityDispose
    {
        private BaseEvent _onEnemySpawnRequested;
        private BaseEvent<Vector3> _onEnemyIsSpawning;

        private float _spawnDistance;
        private Transform _target;
        
        public void Init(IEntity entity)
        {
            _spawnDistance = entity.GetSpawnDistance();
            _target = entity.GetTargetTransform();
            
            _onEnemySpawnRequested = entity.GetOnEnemySpawnRequested();
            _onEnemySpawnRequested.Subscribe(Calculate);

            _onEnemyIsSpawning = entity.GetOnEnemyIsSpawning();
        }

        void IEntityDispose.Dispose(IEntity entity)
        {
            _onEnemySpawnRequested.Unsubscribe(Calculate);
        }

        private void Calculate()
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized * _spawnDistance;
            Vector3 spawnPosition = new Vector3(randomDirection.x, 0, randomDirection.y) + _target.position;
            
            EmmitSpawnPoint(spawnPosition);
        }

        private void EmmitSpawnPoint(Vector3 spawnPosition)
        {
            _onEnemyIsSpawning.Invoke(spawnPosition);
        }
    }
}