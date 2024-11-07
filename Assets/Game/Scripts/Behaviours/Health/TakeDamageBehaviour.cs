using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Behaviours.Health
{
    public class TakeDamageBehaviour: IEntityInit
    {
        private BaseEvent _onDamageIsTaken;
        private ReactiveVariable<int> _hitPoints;
        private IEntity _entity;

        void IEntityInit.Init(IEntity entity)
        {
            _entity = entity;
            _onDamageIsTaken = entity.GetOnDamageIsTaken();
            _hitPoints = entity.GetHitPoints(); 
        }

        public void Invoke(int damage)
        {
            if (!_entity.GetCanTakeDamage().Invoke())
                return;

            _hitPoints.Value = Math.Max(0, _hitPoints.Value - damage);
            _onDamageIsTaken.Invoke();
        }
    }
}