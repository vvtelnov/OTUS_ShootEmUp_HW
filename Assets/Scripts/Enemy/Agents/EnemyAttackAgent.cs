using Components;
using GameSystem.DependencySystem.DI;
using GameSystem.GameContext;
using UnityEngine;

namespace Enemy.Agents
{
    [InjectionNeeded]
    public sealed class EnemyAttackAgent : IGameFinishElement, IFixedUpdateElement
    {
        private AttackComponent _attackComponent;
        private MonoMoveComponent _moveAgent;
        private GameObject _target;
        
        private bool _isAutoAttackEnable;
        private float _countdown = 3;
        private float _currentTime = 3;
        
        public void Construct(AttackComponent attackComponent,
            MonoMoveComponent moveAgent)
        {
            _attackComponent = attackComponent;
            _moveAgent = moveAgent;
            
            _currentTime = _countdown;

            DisableAutoAttack();
            _moveAgent.OnDestinationReached += EnableAutoAttack;
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public void Destruct()
        {
            DisableAutoAttack();
            _moveAgent.OnDestinationReached -= EnableAutoAttack;
        }

        void IGameFinishElement.Finish()
        {
            Destruct();
            
            IGameElement.Unregister(this);
        }

        void IFixedUpdateElement.FixedUpdateElement(float fixedDeltaTime)
        {
            if (!_isAutoAttackEnable)
                return;

            _currentTime -= fixedDeltaTime;
            if (_currentTime <= 0)
            {
                _currentTime = _countdown;
                Fire();
            }
        }

        private void EnableAutoAttack()
        {
            _isAutoAttackEnable = true;
        }

        private void DisableAutoAttack()
        {
            _isAutoAttackEnable = false;
        }

        private void Fire()
        {
            var startPosition = _attackComponent.Position;
            var vector = (Vector2)_target.transform.position - startPosition;
            var direction = vector.normalized;

            _attackComponent.FlyBullet(direction);
        }
    }
}