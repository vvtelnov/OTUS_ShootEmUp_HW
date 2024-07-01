using Components;
using UnityEngine;

namespace Bullets.Handlers
{
    public class CollisionHandler : MonoBehaviour, IBulletHandler
    {
        public static IBulletHandler Instance { get; private set; }

        [SerializeField] private BulletSystem _bulletSystem;
        
        private void Awake()
        {
            ImplementSingleton();
        }
        
        public void OnAddHandle(Bullet[] _, Bullet bullet)
        {
            bullet.OnCollisionEntered += HandleCollision;
        }

        public void OnRemoveHandle(Bullet[] _, Bullet bullet)
        {
            bullet.OnCollisionEntered -= HandleCollision;
        }

        private void HandleCollision(Bullet bullet, Collision2D collision)
        {
            DealDamage(bullet, collision.gameObject);

            _bulletSystem.RemoveBullet(bullet);
        }

        private void DealDamage(Bullet bullet, GameObject target)
        {
            if (!target.TryGetComponent(out TeamComponent team))
                return;

            if (bullet.IsPlayer == team.IsPlayer)
                return;
            
            if (target.TryGetComponent(out HitPointsComponent hitPoints))
                hitPoints.TakeDamage(bullet.Damage);
        }

        private void ImplementSingleton()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
    }
}