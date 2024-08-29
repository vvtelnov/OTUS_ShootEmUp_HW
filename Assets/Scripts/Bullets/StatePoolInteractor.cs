using System;
using System.Collections.Generic;
using GameSystem.DependencySystem.DI;
using GameSystem.GameContext;
using Pool;
using UnityEngine;

namespace Bullets
{
    [InjectionNeeded]
    public sealed class StatePoolInteractor : IGameReadyElement, IGameFinishElement
    {
        [Inject(DependencyResolvePrinciple.CREATE_NEW_INSTANCE)]
        private PoolSystem _pool;
        
        [Inject(DependencyResolvePrinciple.FROM_PREFAB, "Bullet")]
        private GameObject _bulletPrefab;
        
        [Inject(DependencyResolvePrinciple.FROM_INACTIVE_GAME_OBJECT, objectName: "BulletPoolHiddenContainer")]
        private GameObject _hiddenContainer;

        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        private DeathObserver _deathObserver;
        
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly int _poolSize = 50;

     
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
            _pool.Construct(_bulletPrefab, _poolSize, _hiddenContainer);
            _pool.CreatePool();
        }
        
        void IGameFinishElement.Finish()
        {
            IGameElement.Unregister(this);
        }
    }
}