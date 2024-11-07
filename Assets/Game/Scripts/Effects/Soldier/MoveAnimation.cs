using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Effects.Soldier
{
    public class MoveAnimation : IEntityInit
    {
        private Animator _animator;
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int IsMovingForward = Animator.StringToHash("IsMovingForward");
        private static readonly int IsMovingForwardLeft = Animator.StringToHash("IsMovingForwardLeft");
        private static readonly int IsMovingForwardRight = Animator.StringToHash("IsMovingForwardRight");
        private static readonly int IsMovingLeft = Animator.StringToHash("IsMovingLeft");
        private static readonly int IsMovingRight = Animator.StringToHash("IsMovingRight");
        private static readonly int IsMovingBackwardLeft = Animator.StringToHash("IsMovingBackwardLeft");
        private static readonly int IsMovingBackwardRight = Animator.StringToHash("IsMovingBackwardRight");
        private static readonly int IsMovingBackward = Animator.StringToHash("IsMovingBackward");

        public void Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            entity.GetMoveDirection().Subscribe(UpdateAnimatorTriggers);
        }
        
        private void UpdateAnimatorTriggers(Vector3 moveDirection)
        {
            bool isMoving = moveDirection != Vector3.zero;
            _animator.SetBool(IsMoving, isMoving);

            if (!isMoving)
            {
                _animator.ResetTrigger(IsMovingForward);
                _animator.ResetTrigger(IsMovingForwardLeft);
                _animator.ResetTrigger(IsMovingForwardRight);
                _animator.ResetTrigger(IsMovingLeft);
                _animator.ResetTrigger(IsMovingRight);
                _animator.ResetTrigger(IsMovingBackwardLeft);
                _animator.ResetTrigger(IsMovingBackwardRight);
                _animator.ResetTrigger(IsMovingBackward);
                return;
            }

            
            if (moveDirection.x < 0 && moveDirection.z > 0)
            {
                _animator.SetTrigger(IsMovingForwardLeft);
            }
            else if (moveDirection.x > 0 && moveDirection.z > 0)
            {
                _animator.SetTrigger(IsMovingForwardRight);
            }
            else if (moveDirection.z < 0 && moveDirection.x < 0)
            {
                _animator.SetTrigger(IsMovingBackwardLeft);
            }
            else if (moveDirection.z < 0 && moveDirection.x > 0)
            {
                _animator.SetTrigger(IsMovingBackwardRight);
            }
            else if (moveDirection.z > 0)
            {
                _animator.SetTrigger(IsMovingForward);
            }
            else if (moveDirection.z < 0)
            {
                _animator.SetTrigger(IsMovingBackward);
            }
            else if (moveDirection.x < 0)
            {
                _animator.SetTrigger(IsMovingLeft);
            }
            else if (moveDirection.x > 0)
            {
                _animator.SetTrigger(IsMovingRight);
            }
        }
    }
}