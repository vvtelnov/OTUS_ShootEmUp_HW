using UnityEngine;

namespace Components
{
    public sealed class MoveComponent
    {
        private Rigidbody2D _rigidbody2D;

        private float _speed = 5.0f;

        public void Construct(Rigidbody2D rb)
        {
            _rigidbody2D = rb;
        }
        
        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = _rigidbody2D.position + vector * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }
    }
}