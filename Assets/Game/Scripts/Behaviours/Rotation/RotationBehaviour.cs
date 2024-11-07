using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Behaviours.Rotation
{
    public class RotationBehaviour : IEntityInit, IEntityUpdate
    {
        private Transform _transform;
        private AndExpression _canMove;
        private Vector3 _rotation;


        void IEntityInit.Init(IEntity entity)
        {
            _transform = entity.GetTransform(); 
            _canMove = entity.GetCanMove();
        }

        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            if (!_canMove.Invoke())
                return;
            
            _transform.rotation = Quaternion.Euler(_rotation);
        }

        public void SetRotation(Vector3 rotation)
        {
            _rotation = rotation;
        }
    }
}