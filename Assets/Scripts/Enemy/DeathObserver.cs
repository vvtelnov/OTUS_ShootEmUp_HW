using Components;
using Enemy.Spawn;
using UnityEngine;

namespace Enemy
{
    public class DeathObserver : MonoBehaviour
    {
        private SpawnSystem _spawnSystem;
        private HitPointsComponent _hpComponent;

        public void AddObserver(HitPointsComponent hpComponent, SpawnSystem spawnSystem)
        {
            _hpComponent = hpComponent;
            _spawnSystem = spawnSystem;
            
            _hpComponent.HpEmpty += OnDestroyed;
        }

        private void OnDestroyed(GameObject enemy)
        {
            _spawnSystem.Remove(enemy);
            
            _hpComponent.HpEmpty -= OnDestroyed;
        }
    }
}