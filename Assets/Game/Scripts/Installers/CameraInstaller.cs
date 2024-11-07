using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Installers
{
    public class CameraInstaller : IEntityInstaller
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _thisTransform;
        [SerializeField] private float _speed;
        [SerializeField] private float _followRadius;
        private bool _hasInertness = false;
        // private AndExpression _canMove;

        
        public void Install(IEntity entity)
        {
            entity.AddTargetTransform(_target);
            entity.AddTransform(_thisTransform);
            entity.AddMoveSpeed(_speed);
            _hasInertness = entity.AddHasInertness(_hasInertness);
            entity.AddCanMove(new AndExpression());
            entity.AddFollowRadius(_followRadius);

            // EntityInstalledLogger.Instance.Log(entity);
        }
    }
}