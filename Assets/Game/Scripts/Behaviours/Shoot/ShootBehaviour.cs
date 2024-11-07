using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Behaviours.Shoot
{
    public class ShootBehaviour : IEntityInit, IEntityDispose
    {
        private BaseEvent _onShootRequested;
        private BaseEvent _onShot;
        
        private Transform _firePoint;
        private ReactiveVariable<uint> _ammo;
        private AndExpression _canShoot;
        
        public void Init(IEntity entity)
        {
            _onShootRequested = entity.GetOnShootRequested();
            _onShot = entity.GetOnShot();
            _ammo = entity.GetAmmo();
            _canShoot = entity.GetCanShoot();
            
            SubscribeToEvents();
        }

        void IEntityDispose.Dispose(IEntity entity)
        {
            UnsubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            _onShootRequested.Subscribe(HandleShootRequest);
        }
        
        private void UnsubscribeToEvents()
        {
            _onShootRequested.Subscribe(HandleShootRequest);
        }

        private void HandleShootRequest()
        {
            if (!_canShoot.Invoke())
                return;

            _onShot.Invoke();
        }
    }
}