using Components;
using GameSystem;
using UnityEngine;

namespace Enemy.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour, 
        IGameFinishElement, IFixedUpdateElement
    {
        [SerializeField] private AttackComponent _attackComponent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private float _countdown = 3;
        [SerializeField] private float _currentTime = 3;
        [SerializeField] private GameObject _target;
        [SerializeField] private bool _isAutoAttackEnable;
        
        private void Awake()
        {
            // TODO: Change to a constructor method.
            // Я понимаю, что не следуют исплользовать Awake в задании, но решил такую реализацию сделать установки зависимостей
            IGameElement.Register(this);
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public void Construct()
        {
            _currentTime = _countdown;

            DisableAutoAttack();
            _moveAgent.OnDestinationReached += EnableAutoAttack;
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
            Destroy(gameObject);
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