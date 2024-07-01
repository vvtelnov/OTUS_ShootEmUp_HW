using System;
using UnityEngine;

namespace Bullets
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;
        
        [NonSerialized] public bool IsPlayer;
        [NonSerialized] public int Damage;

        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

        public void SetVelocity(Vector2 velocity)
        {
            _rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }
    }
}