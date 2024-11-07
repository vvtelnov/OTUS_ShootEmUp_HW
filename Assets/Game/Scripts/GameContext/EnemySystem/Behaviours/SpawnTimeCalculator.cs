using Atomic.Elements;
using Atomic.Entities;

namespace Game.Scripts.GameContext.EnemySystem.Behaviours
{
    //TODO: Lописать логику тайпера
    public class SpawnTimeCalculator : IEntityInit, IEntityFixedUpdate, IEntityDispose
    {
        private BaseEvent _onEnemySpawnRequested;
        
        private Timer _timer;
        private float _spawnInterval;
        private float _spawnIntervalReduction;
        private float _spawnQuantity;        
        
        
        void IEntityInit.Init(IEntity entity)
        {
            _onEnemySpawnRequested = entity.GetOnEnemySpawnRequested();
            _spawnInterval = entity.GetTimerDuration();
            InitializeSpawnTimer(entity);
            
            _onEnemySpawnRequested.Invoke();
        }

        void IEntityFixedUpdate.OnFixedUpdate(IEntity entity, float deltaTime)
        {
            if (!entity.GetCanSpawn().Invoke())
                return;
            
            _timer.Tick(deltaTime);
        }

        void IEntityDispose.Dispose(IEntity entity)
        {
            _timer.OnEnded -= OnTimerEnded;
        }

        private void OnTimerEnded()
        {
            for (var i = 0; i < _spawnQuantity; i++)
            {
                _onEnemySpawnRequested.Invoke();
            }
            
            _spawnQuantity++;
        }

        private void InitializeSpawnTimer(IEntity entity)
        {
            _timer = entity.GetTimer();
            _timer.SetDuration(_spawnInterval);
            _timer.Loop = true;
            _timer.Start();
            _timer.OnEnded += OnTimerEnded;
        }
    }
}