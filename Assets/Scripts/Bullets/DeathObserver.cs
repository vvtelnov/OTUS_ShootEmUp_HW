using Level;
using UnityEngine;

namespace Bullets
{
    public class DeathObserver : MonoBehaviour
    {
        [SerializeField] private LevelBounds _bounds;
        [SerializeField] private StatePoolInteractor _statePoolInteractor;
        
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