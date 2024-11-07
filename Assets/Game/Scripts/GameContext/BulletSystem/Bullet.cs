using System;
using Atomic.Entities;
using Atomic.Elements;
using Game.Scripts.Behaviours;
using Game.Scripts.Behaviours.Movement;
using UnityEngine;

namespace Game.Scripts.GameContext.BulletSystem
{
    public class Bullet : IEntityEnable, 
        IEntityFixedUpdate,
        IEntityDisable
    {
        public BaseEvent<IEntity> OnRemoveBullet;

        private IEntity _entity;
        
        void IEntityEnable.Enable(IEntity entity)
        {
            _entity = entity;
            OnRemoveBullet = entity.GetOnRemoveBullet();
            
            StartMove();
            StartTimer();
        }

        void IEntityFixedUpdate.OnFixedUpdate(IEntity entity, float deltaTime)
        {
            _entity.GetTimer().Tick(deltaTime);
        }

        void IEntityDisable.Disable(IEntity entity)
        {
            StopMove();
            StopTimer();
        }

        private void StartMove()
        {
            _entity.SetMoveDirection(_entity.GetShootPoint().forward);
        }

        private void StopMove()
        {
            _entity.SetMoveDirection(Vector3.zero);
        }

        private void StartTimer()
        {
            var timer = _entity.GetTimer();
            
            timer.Start();
            timer.OnEnded += HandleTimeEnded;
        }
        private void StopTimer()
        {
            var timer = _entity.GetTimer();
            
            timer.Stop();
            timer.OnEnded -= HandleTimeEnded;
        }

        private void HandleTimeEnded()
        {
            OnRemoveBullet.Invoke(_entity);
        }
    }
}