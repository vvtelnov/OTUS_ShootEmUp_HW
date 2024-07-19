using System;
using System.Collections.Generic;
using GameSystem;
using Pool;
using UnityEngine;

namespace Bullets
{
    public sealed class StatePoolInteractor : MonoBehaviour, 
        IGameReadyElement, IGameFinishElement
    {
        [SerializeField] private PoolSystem _pool;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private int _poolSize;

        [SerializeField] private DeathObserver _deathObserver;
        
        private readonly HashSet<Bullet> _activeBullets = new();
        
        private void Awake()
        {
            // TODO: Change to a constructor method.
            // Я понимаю, что не следуют исплользовать Awake в задании, но решил такую реализацию сделать установки зависимостей
            IGameElement.Register(this);
        }
        
        public Bullet GetBullet()
        {
            if (!_pool.HasObject())
                _pool.PutNewObject();

            GameObject bulletObject = _pool.TryToGet();
            Bullet bullet = (Bullet)bulletObject.GetComponent(typeof(Bullet));

            if (!_activeBullets.Add(bullet))
                throw new InvalidOperationException("There is the same bullet on scene");

            _deathObserver.SubscribeObserver(bullet);

            return bullet;
        }
        
        public void RemoveBullet(Bullet bullet)
        {
            if (!_activeBullets.Remove(bullet))
                throw new InvalidOperationException("There is NO passed bullet on scene");
            
            _deathObserver.UnsubscribeObserver(bullet);
            
            _pool.Release(bullet.gameObject);
        }

        void IGameReadyElement.Ready()
        {
            _pool.CreatePool(_bulletPrefab, _poolSize);
        }
        
        void IGameFinishElement.Finish()
        {
            IGameElement.Unregister(this);

            Destroy(gameObject);
        }
    }
}