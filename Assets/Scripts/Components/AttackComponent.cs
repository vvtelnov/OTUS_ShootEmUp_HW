using UnityEngine;

namespace ShootEmUp
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

        public void FlyBulletByConfig(Vector2 attackDirection)
        {
            Bullet bullet = _bulletSystem.GetBullet();

            SetBulletFields(bullet, attackDirection);
        }

        private void SetBulletFields(Bullet bullet, Vector2 direction)
        {
            bullet.SetPosition(Position);
            bullet.SetColor(_bulletConfig.color);
            bullet.SetPhysicsLayer((int)_bulletConfig.physicsLayer);
            bullet.damage = _bulletConfig.damage;
            bullet.isPlayer = _bulletConfig.isPlayer;
            bullet.SetVelocity(direction * _bulletConfig.speed);
        }
    }
}
