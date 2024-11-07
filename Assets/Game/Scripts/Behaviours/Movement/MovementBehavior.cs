using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Behaviours.Movement
{
    public class MovementBehavior : IEntityInit, IEntityUpdate
    {
        private Transform _transform;
        private float _baseSpeed;
        private float _acceleration;
        private float _deceleration;
        private bool _hasInertness;
        private AndExpression _canMove;
        private Vector3 _moveDirection;
        
        private Vector3 _currentMoveDirection;
        private float _currentSpeed;

        void IEntityInit.Init(IEntity entity)
        {
            _transform = entity.GetTransform(); 
            _baseSpeed = entity.GetMoveSpeed();
            _hasInertness = entity.GetHasInertness();
            _canMove = entity.GetCanMove();
        }

        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            if (!_canMove.Invoke())
                return;

            _moveDirection = entity.GetMoveDirection().Value;

            if (_hasInertness)
            {
                MoveWithInertia(entity, deltaTime);
            }
            else
            {
                Move(deltaTime);
            }
        }

        private void Move(float deltaTime)
        {
            _transform.position += _baseSpeed * _moveDirection * deltaTime;
        }

        private void MoveWithInertia(IEntity entity, float deltaTime)
        {
            if (_moveDirection != Vector3.zero)
            {
                if (Vector3.Dot(_currentMoveDirection.normalized, _moveDirection.normalized) <= 0)
                {
                    ApplyDeceleration(entity, deltaTime);
                }
                else
                {
                    ApplyAcceleration(entity, deltaTime);
                }
                
                _currentMoveDirection = _moveDirection.normalized;
            }
            else
            {
                ApplyDeceleration(entity, deltaTime);
                
                if (_currentSpeed <= 0)
                    _currentMoveDirection = Vector3.zero;
            }

            _transform.position += _currentSpeed * _currentMoveDirection * deltaTime;
        }

        private void ApplyAcceleration(IEntity entity, float deltaTime)
        {
            float acceleration = entity.GetAcceleration();
            
            _currentSpeed += acceleration * deltaTime;
            _currentSpeed = Mathf.Clamp(_currentSpeed, 0, _baseSpeed);
        }
        
        private void ApplyDeceleration(IEntity entity, float deltaTime)
        {
            float deceleration = entity.GetDeceleration();
            
            _currentSpeed -= deceleration * deltaTime;
            _currentSpeed = Mathf.Clamp(_currentSpeed, 0, _baseSpeed);
        }
    }
}