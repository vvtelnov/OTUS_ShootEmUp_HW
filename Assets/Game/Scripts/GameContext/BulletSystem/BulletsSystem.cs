using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.Behaviours;
using Game.Scripts.Behaviours.Movement;
using Game.Scripts.GameContext.EntityPool;
using UnityEngine;

namespace Game.Scripts.GameContext.BulletSystem
{
    public class BulletsSystem : IEntityInit
    {
        private BaseEvent _onShot;
        private Transform _shootPoint;
        
        private IEntityPool _entityPool;
        private MovementBehavior _movementBehavior;

        void IEntityInit.Init(IEntity entity)
        {
            _onShot = entity.GetOnShot();
            _shootPoint = entity.GetShootPoint();
            _entityPool = entity.GetBehaviour<SceneEntityPool>();
            
            _onShot.Subscribe(FireBullet);
        }

        private void FireBullet()
        {
            SceneEntity bullet = _entityPool.Get();
            bullet.GetOnRemoveBullet().Subscribe(RemoveBullet);

            bullet.transform.position = _shootPoint.position;
        }

        private void RemoveBullet(IEntity bullet)
        {
            bullet.GetOnRemoveBullet().Unsubscribe(RemoveBullet);
            _entityPool.Return(bullet);
        }
    }
}