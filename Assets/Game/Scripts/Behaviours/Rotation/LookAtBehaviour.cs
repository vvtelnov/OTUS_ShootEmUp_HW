using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Behaviours.Rotation
{
    public class LookAtBehaviour : IEntityInit, IEntityUpdate
    {
        private Transform _transform;

        void IEntityInit.Init(IEntity entity)
        {
            _transform = entity.GetTransform(); 
        }

        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            if (!entity.GetCanRotate().Invoke())
                return;

            Transform target = entity.GetTargetTransform();
            Vector3 lookPosition = new Vector3(target.position.x, target.position.y, target.position.z);
            
            _transform.LookAt(lookPosition);
        }
    }
}