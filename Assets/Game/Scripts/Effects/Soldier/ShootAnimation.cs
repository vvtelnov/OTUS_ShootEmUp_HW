using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Effects.Soldier
{
    public class ShootAnimation : IEntityInit
    {
        private Animator _animator;
        private static readonly int Shoot = Animator.StringToHash("Shoot");

        void IEntityInit.Init(IEntity entity)
        {
            _animator = entity.GetAnimator();
            entity.GetOnShot().Subscribe(Play);
        }

        private void Play()
        {
            _animator.SetTrigger(Shoot);
        }
    }
}