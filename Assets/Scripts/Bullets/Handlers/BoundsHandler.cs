using Level;
using UnityEngine;

namespace Bullets.Handlers
{
    public class BoundsHandler : MonoBehaviour, IBulletHandler
    {
        public static IBulletHandler Instance { get; private set; }
        
        [SerializeField] private LevelBounds _bounds;
        [SerializeField] private BulletSystem _bulletSystem;  
        
        private Bullet[] _activeBullets;

        public void OnAddHandle(Bullet[] bullets, Bullet bullet)
        {
            _activeBullets = bullets;
        }

        public void OnRemoveHandle(Bullet[] bullets, Bullet bullet)
        {
            _activeBullets = bullets;
        }
        
        private void Awake()
        {
            ImplementSingleton();
        }

        private void FixedUpdate()
        {
            if (_activeBullets is null)
                return;
            
            foreach (Bullet bullet in _activeBullets)
            {
                if (!_bounds.InBounds(bullet.Position))
                {
                    _bulletSystem.RemoveBullet(bullet);
                }
            }
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