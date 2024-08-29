using Bullets;
using GameSystem.DependencySystem.DI;
using UnityEngine;

namespace Components
{
    [InjectionNeeded]
    public class AttackComponent
    {
        public Vector2 Position
        {
            get { return _firePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return _firePoint.rotation; }
        }

        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        private StatePoolInteractor _statePoolInteractor;
        
        private BulletConfig _bulletConfig;
        private Transform _firePoint;

        
        public void Construct(BulletConfig bulletConfig, Transform firePoint, 
            StatePoolInteractor statePoolInteractor = null)
        {
            _bulletConfig = bulletConfig;
            _firePoint = firePoint;

            if (statePoolInteractor is not null)
                _statePoolInteractor = statePoolInteractor;
        }

        public void SetBulletSpawner(StatePoolInteractor statePoolInteractor)
        {
            _statePoolInteractor = statePoolInteractor;
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
        }
    }
}
