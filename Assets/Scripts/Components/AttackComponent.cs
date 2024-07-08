using Bullets;
using Level;
using UnityEngine;

namespace Components
{
    public class AttackComponent : MonoBehaviour
    {
        public Vector2 Position
        {
            get { return _firePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return _firePoint.rotation; }
        }

        [SerializeField] private Transform _firePoint;
        [SerializeField] private StatePoolInteractor _statePoolInteractor;
        [SerializeField] private BulletConfig _bulletConfig;

        [SerializeField] private LevelBounds _bounds;

        public void SetBulletSpawner(StatePoolInteractor statePoolInteractor)
        {
            _statePoolInteractor = statePoolInteractor;
        }

        public void SetLevelBounds(LevelBounds bounds)
        {
            _bounds = bounds;
        }
        

        public void FlyBullet(Vector2 attackDirection)
        {
            Bullet bullet = _statePoolInteractor.GetBullet();

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
            bullet.SetLevelBounds(_bounds);
        }
    }
}
