using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.GameContext.BulletSystem;
using Game.Scripts.GameContext.EnemySystem.Behaviours;
using Game.Scripts.GameContext.EntityPool;
using Game.Scripts.Utils;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Game.Scripts.GameContext.EnemySystem.Installers
{
    public class ZombieSystemInstaller : SceneEntityInstallerBase
    {
        [Title("PoolSystem")]
        [SerializeField] private SceneEntity _zombiePrefab;
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private Transform _worldContainer;
        [SerializeField] private int _initialNumbOfZombiesInPool;

        [Title("Spawn Params")]
        [SerializeField] private float _spawnInterval;
        [SerializeField] private float _spawnDistance = 15f;
        
        public override void Install(IEntity entity)
        {
            SceneEntity playerEntity = GameContext.Instance.GetPlayer();
            
            //Player or other target
            entity.AddTargetTransform(playerEntity.GetTransform());
            
            // Events
            entity.AddOnEnemySpawnRequested(new BaseEvent());
            entity.AddOnEnemyIsSpawning(new BaseEvent<Vector3>());
            
            // Pool
            entity.AddPrefab(_zombiePrefab);
            entity.AddPoolContainer(_poolContainer);
            entity.AddWorldContainer(_worldContainer);
            entity.AddInitalCount(_initialNumbOfZombiesInPool);
            
            
            //Spawn
            entity.AddCanSpawn(new AndExpression());
            entity.AddSpawnDistance(_spawnDistance);
            entity.AddTimer(new Timer());
            entity.AddTimerDuration(_spawnInterval);
            
            
            // PlayerScore
            entity.AddScore(playerEntity.GetScore());

            InstallBehaviours(entity);
            
            EntityInstalledLogger.Instance.Log(entity);
        }

        private void InstallBehaviours(IEntity entity)
        {
            entity.AddBehaviour(new SceneEntityPool());
            entity.AddBehaviour(new ZombiesSystem());
            entity.AddBehaviour(new SpawnTimeCalculator());
            entity.AddBehaviour(new SpawnPointCalculator());
        }
    }
}