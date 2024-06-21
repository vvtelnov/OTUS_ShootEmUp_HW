using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField] private AttackComponent _attackComponent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private float _countdown = 3;
        [SerializeField] private float _currentTime = 3;
        [SerializeField] private GameObject target;
        [SerializeField] private bool IsAutoAttackEnable = false;


        public void SetTarget(GameObject target)
        {
            this.target = target;
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
            if (!IsAutoAttackEnable)
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
            IsAutoAttackEnable = true;
        }

        private void DisableAutoAttack()
        {
            IsAutoAttackEnable = false;
        }

        private void Fire()
        {
            var startPosition = _attackComponent.Position;
            var vector = (Vector2)this.target.transform.position - startPosition;
            var direction = vector.normalized;

            this._attackComponent.FlyBulletByConfig(direction);
        }
    }
}