using System;
using Components;
using Level;
using UnityEngine;

namespace Bullets
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;
        public event Action<Bullet> OnOutTheBounds;
        
        [NonSerialized] public bool IsPlayer;
        [NonSerialized] public int Damage;

        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private LevelBounds _bounds;

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

        public void SetLevelBounds(LevelBounds bounds)
        {
            _bounds = bounds;
        }
        
        private void FixedUpdate()
        {
            if (!_bounds.InBounds(Position))
                OnOutTheBounds?.Invoke(this);
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
            
            DealDamage(collision.gameObject);
        }
        
        private void DealDamage(GameObject target)
        {
            if (!target.TryGetComponent(out TeamComponent team))
                return;

            if (IsPlayer == team.IsPlayer)
                return;
            
            if (target.TryGetComponent(out HitPointsComponent hitPoints))
                hitPoints.TakeDamage(Damage);
        }
    }
}