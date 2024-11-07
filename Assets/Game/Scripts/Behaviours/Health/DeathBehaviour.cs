using System.Xml;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Behaviours.Health
{
    public class DeathBehaviour : IEntityInit, IEntityLateUpdate
    {
        private ReactiveVariable<int> _hitPoints; 
        
        void IEntityInit.Init(IEntity entity)
        {
            _hitPoints = entity.GetHitPoints();
        }

        void IEntityLateUpdate.OnLateUpdate(IEntity entity, float deltaTime)
        {
            if (entity.GetIsDead().Value)
                return;
            
            if (entity.GetHitPoints().Value > 0)
                return;
            
            entity.SetIsDead(true);
            entity.GetOnDeath().Invoke(entity);
        }
    }
}