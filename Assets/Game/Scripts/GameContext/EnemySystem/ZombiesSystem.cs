using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.Behaviours;
using Game.Scripts.Behaviours.Movement;
using Game.Scripts.GameContext.BulletSystem;
using Game.Scripts.GameContext.EntityPool;
using UnityEngine;

namespace Game.Scripts.GameContext.EnemySystem
{
    //TODO: Вынести в базовое поведение и для пули тоже
    public class ZombiesSystem : IEntityInit
    {
        private BaseEvent<Vector3> _onSpawn;
        private IEntityPool _entityPool;
        private ReactiveVariable<int> _playerScore;

        void IEntityInit.Init(IEntity entity)
        {
            _onSpawn = entity.GetOnEnemyIsSpawning();
            _playerScore = entity.GetScore();
            _entityPool = entity.GetBehaviour<SceneEntityPool>();

            _onSpawn.Subscribe(Spawn);
        }

        private void Spawn(Vector3 spawnPoint)
        {
            SceneEntity zombie = _entityPool.Get();
            var onDeath = zombie.GetOnDeath();
            
            onDeath.Subscribe(Remove);
            onDeath.Subscribe(AddScorePoint);

            zombie.transform.position = spawnPoint;
        }

        private void AddScorePoint(IEntity _)
        {
            _playerScore.Value++;
        }

        private void Remove(IEntity zombie)
        {
            var onDeath = zombie.GetOnDeath();
            zombie.SetHitPoints(zombie.GetMaxHitPoints().Value);
            zombie.SetIsDead(false);
            
            onDeath.Unsubscribe(Remove);
            onDeath.Unsubscribe(AddScorePoint);
            
            _entityPool.Return(zombie);
        }
    }
}