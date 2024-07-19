using Bullets;
using Components;
using Enemy.Agents;
using Level;
using UnityEngine;

namespace Enemy.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private GameObject _character;
        [SerializeField] private StatePoolInteractor _statePoolInteractor;

        [SerializeField] private SpawnInitializer _spawnInitializer;
        [SerializeField] private LevelBounds _levelBounds;

        private int _hitPoints = 3;

        public GameObject Spawn(GameObject enemy)
        {
            SetupMoveLogic(enemy);
            SetupAttackLogic(enemy);
            SetupHpLogic(enemy);

            return enemy;
        }

        private void SetupMoveLogic(GameObject enemy)
        {
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            var attackPosition = _enemyPositions.RandomAttackPosition();
            
            enemy.transform.position = spawnPosition.position;
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
        }

        private void SetupAttackLogic(GameObject enemy)
        {
            AttackComponent component = enemy.GetComponent<AttackComponent>();
            EnemyAttackAgent agent = enemy.GetComponent<EnemyAttackAgent>();

            agent.Construct();
            agent.SetTarget(_character);
            
            component.SetBulletSpawner(_statePoolInteractor);
            component.SetLevelBounds(_levelBounds);
        }

        private void SetupHpLogic(GameObject enemy)
        {
            HitPointsComponent hpComponent = enemy.GetComponent<HitPointsComponent>();
            EnemyAttackAgent agent = enemy.GetComponent<EnemyAttackAgent>();
            DeathObserver deathObserver = enemy.GetComponent<DeathObserver>();
            
            hpComponent.SetHitPoints(_hitPoints);
            deathObserver.AddObserver(hpComponent, _spawnInitializer, agent);
        }
    }
}