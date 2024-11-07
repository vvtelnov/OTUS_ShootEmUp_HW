using System.Collections.Generic;
using Atomic.Entities;
using Game.Scripts.Behaviours;
using Game.Scripts.Behaviours.Movement;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class KeyboardInput : IEntityInit, IEntityUpdate
    {
        private MovementBehavior _movementBehavior;
        
        private readonly KeyCode _moveForwardKey = KeyCode.W;
        private readonly KeyCode _moveBackwardKey = KeyCode.S;
        private readonly KeyCode _moveLeftKey = KeyCode.A;
        private readonly KeyCode _moveRightKey = KeyCode.D;

        void IEntityInit.Init(IEntity entity)
        {
            _movementBehavior = entity.GetBehaviour<MovementBehavior>();
        }

        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            Vector3 moveDirection = Vector3.zero;

            if (Input.GetKey(_moveForwardKey))
                moveDirection += Vector3.forward;
            if (Input.GetKey(_moveLeftKey))
                moveDirection += Vector3.left;
            if (Input.GetKey(_moveBackwardKey))
                moveDirection += Vector3.back;
            if (Input.GetKey(_moveRightKey))
                moveDirection += Vector3.right;

            SetMoveDirection(moveDirection.normalized);
        }

        private void SetMoveDirection(Vector3 direction)
        {
            _movementBehavior.SetDirection(direction); 
        }

        
    }
}