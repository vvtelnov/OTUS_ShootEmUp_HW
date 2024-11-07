using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.Behaviours;
using Game.Scripts.Behaviours.Movement;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class KeyboardInput : IEntityUpdate
    {
        private readonly KeyCode _moveForwardKey = KeyCode.W;
        private readonly KeyCode _moveBackwardKey = KeyCode.S;
        private readonly KeyCode _moveLeftKey = KeyCode.A;
        private readonly KeyCode _moveRightKey = KeyCode.D;

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

            entity.GetMoveDirection().Value = moveDirection.normalized;
        }
    }
}