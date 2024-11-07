using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Behaviours.Movement
{
    public class FollowUpBehaviour : IEntityInit, IEntityUpdate
    {
        private Transform _target;
        private Transform _thisTransform;
        private float _followRadius;
        
        private MovementBehavior _movementBehavior;


        void IEntityInit.Init(IEntity entity)
        {
            _target = entity.GetTargetTransform();
            _thisTransform = entity.GetTransform();
            _followRadius = entity.GetFollowRadius();
        }

        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            if (_target is null)
                return;

            Vector3 direction = Vector3.zero;
            Vector3 targetOffset = _target.position - _thisTransform.position;
            
            if (targetOffset.magnitude > _followRadius)
            {
                direction = targetOffset.normalized;
            }

            entity.SetMoveDirection(direction);
        }
    }
}