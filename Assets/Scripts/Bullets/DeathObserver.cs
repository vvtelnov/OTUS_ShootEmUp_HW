using GameSystem.DependencySystem.DI;
using Level;
using UnityEngine;

namespace Bullets
{
    [InjectionNeeded]
    public class DeathObserver
    {
        [Inject]
        private LevelBounds _bounds;
        private StatePoolInteractor _statePoolInteractor;

        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        public void Construct(StatePoolInteractor statePoolInteractor)
        {
            _statePoolInteractor = statePoolInteractor;
        }
        
        public void SubscribeObserver(Bullet bullet)
        {
            bullet.OnCollisionEntered += HandleCollision;
            bullet.OnOutTheBounds += RemoveBullet;
        }
        
        public void UnsubscribeObserver(Bullet bullet)
        {
            bullet.OnCollisionEntered -= HandleCollision;
            bullet.OnOutTheBounds -= RemoveBullet;
        }
        
        private void RemoveBullet(Bullet bullet)
        {
            _statePoolInteractor.RemoveBullet(bullet);
        }

        private void HandleCollision(Bullet bullet, Collision2D _)
        {
            RemoveBullet(bullet);
        }
    }
}