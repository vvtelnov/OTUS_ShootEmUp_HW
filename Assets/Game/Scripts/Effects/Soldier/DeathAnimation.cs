using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Effects.Soldier
{
    public class DeathAnimation : IEntityInit
    {
        private Animator _animator;
        private static readonly int Die = Animator.StringToHash("Die");

        void IEntityInit.Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            entity.GetOnDeath().Subscribe(Play);
        }

        private void Play(IEntity _)
        {
            _animator.SetTrigger(Die);
        }
    }
}