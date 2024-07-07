using Components;
using Enemy.Spawn;
using UnityEngine;

namespace Enemy
{
    public class DeathObserver : MonoBehaviour
    {
        private SpawnInitializer _spawnInitializer;
        private HitPointsComponent _hpComponent;

        public void AddObserver(HitPointsComponent hpComponent, SpawnInitializer spawnInitializer)
        {
            _hpComponent = hpComponent;
            _spawnInitializer = spawnInitializer;
            
            _hpComponent.HpEmpty += OnDestroyed;
        }

        private void OnDestroyed(GameObject enemy)
        {
            _spawnInitializer.Remove(enemy);
            
            _hpComponent.HpEmpty -= OnDestroyed;
        }
    }
}