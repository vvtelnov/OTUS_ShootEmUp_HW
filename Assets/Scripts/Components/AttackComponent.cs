using Bullets;
using UnityEngine;

namespace Components
{
    public class AttackComponent : MonoBehaviour
    {
        public Vector2 Position
        {
            get { return firePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return firePoint.rotation; }
        }

        [SerializeField] private Transform firePoint;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;

        public void SetBulletSystem(BulletSystem bulletSystem)
        {
            _bulletSystem = bulletSystem;
        }

        public void FlyBullet(Vector2 attackDirection)
        {
            Bullet bullet = _bulletSystem.GetBullet();

            SetBulletFields(bullet, attackDirection);
        }

        private void SetBulletFields(Bullet bullet, Vector2 direction)
        {
            bullet.Position = Position;
            bullet.SetColor(_bulletConfig.Color);
            bullet.SetPhysicsLayer((int)_bulletConfig.PhysicsLayer);
            bullet.Damage = _bulletConfig.Damage;
            bullet.IsPlayer = _bulletConfig.IsPlayer;
            bullet.SetVelocity(direction * _bulletConfig.Speed);
        }
    }
}
