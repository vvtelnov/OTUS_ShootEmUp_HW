using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Effects.Soldier
{
    public class TakeDamageAnimation : IEntityInit
    {
        private Animator _animator;
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");

        void IEntityInit.Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            entity.GetOnDamageIsTaken().Subscribe(Play);
        }

        private void Play()
        {
            _animator.SetTrigger(TakeDamage);
        }
    }
}