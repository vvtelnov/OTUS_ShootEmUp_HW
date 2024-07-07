using Bullets;
using Components;
using Enemy.Agents;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.Spawn
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private GameObject _character;
        [SerializeField] private BulletSystem _bulletSystem;

        [FormerlySerializedAs("_spawnSystem")] [SerializeField] private SpawnInitializer spawnInitializer;

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
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(_character);
            enemy.GetComponent<AttackComponent>().SetBulletSystem(_bulletSystem);
        }

        private void SetupHpLogic(GameObject enemy)
        {
            HitPointsComponent hpComponent = enemy.GetComponent<HitPointsComponent>();
            DeathObserver deathObserver = enemy.GetComponent<DeathObserver>();
            
            hpComponent.SetHitPoints(_hitPoints);
            deathObserver.AddObserver(hpComponent, spawnInitializer);
        }
    }
}