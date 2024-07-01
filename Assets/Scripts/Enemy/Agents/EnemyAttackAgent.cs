using Components;
using UnityEngine;

namespace Enemy.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField] private AttackComponent _attackComponent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private float _countdown = 3;
        [SerializeField] private float _currentTime = 3;
        [SerializeField] private GameObject _target;
        [SerializeField] private bool _isAutoAttackEnable;


        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        private void OnEnable()
        {
            _currentTime = _countdown;

            DisableAutoAttack();
            _moveAgent.OnDestinationReached += EnableAutoAttack;
        }

        private void OnDisable()
        {
            DisableAutoAttack();
            _moveAgent.OnDestinationReached -= EnableAutoAttack;
        }

        private void FixedUpdate()
        {
            if (!_isAutoAttackEnable)
                return;

            _currentTime -= Time.fixedDeltaTime;
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