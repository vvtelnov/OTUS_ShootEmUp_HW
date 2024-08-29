using Components;
using Enemy.Agents;
using Enemy.Spawn;
using UnityEngine;

namespace Enemy
{
    public class DeathObserver
    {
        private EnemyLifeCycle _enemyLifeCycle;
        private MonoHitPointsComponent _hpComponent;
        private EnemyAttackAgent _attackAgent;
        
        public void AddObserver(MonoHitPointsComponent hpComponent, EnemyLifeCycle enemyLifeCycle, EnemyAttackAgent attackAgent)
        {
            _hpComponent = hpComponent;
            _enemyLifeCycle = enemyLifeCycle;
            _attackAgent = attackAgent;
            
            _hpComponent.HpEmpty += OnDestroyed;
        }

        private void OnDestroyed(GameObject enemy)
        {
            _enemyLifeCycle.Remove(enemy);
            _attackAgent.Destruct();
            
            _hpComponent.HpEmpty -= OnDestroyed;
        }
    }
}