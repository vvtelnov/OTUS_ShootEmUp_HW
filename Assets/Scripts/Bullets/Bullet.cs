using System;
using Components;
using GameSystem.DependencySystem.DI;
using GameSystem.GameContext;
using Level;
using UnityEngine;

namespace Bullets
{
    [InjectionNeeded]
    public sealed class Bullet : MonoBehaviour, 
        IFixedUpdateElement,
        IGamePauseElement, IGameResumeElement,
        IGameFinishElement
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

        [Inject]
        [SerializeField] private LevelBounds _bounds;
        
        private Vector2 _savedVelocityForPauseTime;

        
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
        
        void IFixedUpdateElement.FixedUpdateElement(float _)
        {
            if (!_bounds.InBounds(Position))
                OnOutTheBounds?.Invoke(this);
        }
        
        void IGamePauseElement.Pause()
        {
            _savedVelocityForPauseTime = _rigidbody2D.velocity;

            _rigidbody2D.velocity = new Vector2(0, 0);
        }

        void IGameResumeElement.Resume()
        {
            SetVelocity(_savedVelocityForPauseTime);
        }
        
        void IGameFinishElement.Finish()
        {
            IGameElement.Unregister(this);

            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
            
            DealDamage(collision.gameObject);
        }
        
        private void DealDamage(GameObject target)
        {
            if (!target.TryGetComponent(out MonoTeamComponent team))
                return;

            if (IsPlayer == team.IsPlayer)
                return;
            
            if (target.TryGetComponent(out MonoHitPointsComponent hitPoints))
                hitPoints.TakeDamage(Damage);
        }
    }
}