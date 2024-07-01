using Components;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private AttackComponent _attackComponent;


        public void Move(float direction)
        {
            _moveComponent.MoveByRigidbodyVelocity(new Vector2(direction, 0) * Time.fixedDeltaTime);
        }

        public void AttackStraightUp()
        {
            Vector2 direction = _attackComponent.Rotation * Vector3.up;

            _attackComponent.FlyBullet(direction);
        }
    }
}