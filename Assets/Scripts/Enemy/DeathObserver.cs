using Components;
using Enemy.Agents;
using Enemy.Spawn;
using UnityEngine;

namespace Enemy
{
    public class DeathObserver : MonoBehaviour
    {
        private SpawnInitializer _spawnInitializer;
        private HitPointsComponent _hpComponent;
        private EnemyAttackAgent _attackAgent;

        public void AddObserver(HitPointsComponent hpComponent, SpawnInitializer spawnInitializer, EnemyAttackAgent attackAgent)
        {
            _hpComponent = hpComponent;
            _spawnInitializer = spawnInitializer;
            _attackAgent = attackAgent;
            
            _hpComponent.HpEmpty += OnDestroyed;
        }

        private void OnDestroyed(GameObject enemy)
        {
            _spawnInitializer.Remove(enemy);
            _attackAgent.Destruct();
            
            _hpComponent.HpEmpty -= OnDestroyed;
        }
    }
}