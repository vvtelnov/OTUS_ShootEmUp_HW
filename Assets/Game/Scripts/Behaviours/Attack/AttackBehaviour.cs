using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.Behaviours.Health;
using UnityEngine;

namespace Game.Scripts.Behaviours.Attack
{
    public class AttackBehaviour : IEntityInit, IEntityUpdate
    {
        private BaseEvent<int> _onAttacked;
        private int _attackDamage;
        private Transform _transform;
        private Transform _targetTransform;
        private bool _isThisEnemy;
        private ReactiveVariable<float> _attackRadius;

        void IEntityInit.Init(IEntity entity)
        {
            _onAttacked = entity.GetOnAttacked();
            _attackDamage = entity.GetAttackDamage();
            _transform = entity.GetTransform();
            _targetTransform = entity.GetTargetTransform();
            _isThisEnemy = entity.HasEnemyTag();
            _attackRadius = entity.GetAttackRadius();
        }

        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            // Вот эти все условия для того что бы можно было этот компонент использовать и на игроке, если мы добавим ближний бой.
            
            if (!entity.GetCanAttack().Invoke())
                return;

            if (!Physics.Raycast(
                    _transform.position,
                    _transform.forward,
                    out RaycastHit hit,
                    _attackRadius.Value
                ))
            {
                return;
            }

            if (!hit.transform.gameObject.TryGetComponent<SceneEntity>(out var entityComponent))
                return;

            if (entityComponent.GetIsDead().Value)
                return;

            if (entityComponent.HasEnemyTag() == _isThisEnemy)
                return;

            if (!entityComponent.HasBehaviour<TakeDamageBehaviour>())
                return;
                
            entityComponent.GetBehaviour<TakeDamageBehaviour>().Invoke(_attackDamage);
            
            _onAttacked.Invoke(_attackDamage);
        }
    }
}