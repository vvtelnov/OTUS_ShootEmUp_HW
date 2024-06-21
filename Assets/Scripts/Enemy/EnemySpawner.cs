using UnityEngine;

namespace ShootEmUp
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private GameObject _character;
        [SerializeField] private BulletSystem _bulletSystem;

        public GameObject SpawnEnemy(GameObject enemy)
        {
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(_character);
            enemy.GetComponent<AttackComponent>().SetBulletSystem(_bulletSystem);

            enemy.GetComponent<HitPointsComponent>().SetHitPoints(3);

            return enemy;
        }
    }
}