using Bullets;
using Components;
using Enemy.Agents;
using GameSystem.DependencySystem.DI;
using GameSystem.DependencySystem.StaticServices;
using Level;
using UnityEngine;
using Utils;

namespace Enemy.Spawn
{
    [InjectionNeeded]
    public class EnemySpawner
    {
        [Inject(DependencyResolvePrinciple.FROM_GAME_OBJECT, "Character")]
        private GameObject _character;
        
        [Inject(DependencyResolvePrinciple.FROM_CONFIG, "EnemyBullet")]
        private BulletConfig _enemyBulletConfig;
        
        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        private StatePoolInteractor _statePoolInteractor;
        
        [Inject]
        private EnemyPositions _enemyPositions;

        [Inject]
        private LevelBounds _levelBounds;
        
        private EnemyLifeCycle _enemyLifeCycle;
        
        private int _hitPoints = 3;
        
        public void Construct(EnemyLifeCycle enemyLifeCycle)
        {
            _enemyLifeCycle = enemyLifeCycle;
        }
        

        public GameObject Spawn(GameObject enemy)
        {
            MonoMoveComponent moveComponent = enemy.GetComponent<MonoMoveComponent>();
            EnemyAttackAgent enemyAttackAgent = InstanceCreator.Instance.CreateInstance<EnemyAttackAgent>();
            Transform firePoint = ChildGameObjectGetter.GetChildTransform(enemy, "FirePoint");

            SetupMoveLogic(enemy, moveComponent);
            SetupAttackLogic(enemyAttackAgent, moveComponent, firePoint);
            SetupHpLogic(enemy, enemyAttackAgent);

            return enemy;
        }

        private void SetupMoveLogic(GameObject enemy, MonoMoveComponent moveComponent)
        {
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            var attackPosition = _enemyPositions.RandomAttackPosition();
            Vector2 destination = attackPosition.position;
            
            
            enemy.transform.position = spawnPosition.position;
            
            moveComponent.MoveToPointWithCoroutine(destination);
        }

        private void SetupAttackLogic(EnemyAttackAgent enemyAttackAgent, MonoMoveComponent moveComponent,
            Transform firePoint)
        {
            AttackComponent attackComponent = new();

            attackComponent.Construct(_enemyBulletConfig, firePoint, _statePoolInteractor);
            enemyAttackAgent.Construct(attackComponent, moveComponent);
            enemyAttackAgent.SetTarget(_character);
        }

        private void SetupHpLogic(GameObject enemy, EnemyAttackAgent enemyAttackAgent)
        {
            MonoHitPointsComponent hpComponent = enemy.GetComponent<MonoHitPointsComponent>();
            DeathObserver deathObserver = new();
            
            hpComponent.SetHitPoints(_hitPoints);
            deathObserver.AddObserver(hpComponent, _enemyLifeCycle, enemyAttackAgent);
        }
    }
}