using Bullets.Handlers;
using UnityEngine;

namespace Bullets
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private BulletSystem _bulletSystem;

        // TODO: rewrite with DI
        // ДЛЯ ПРОВЕРЯЮЩЕГО:
        // Я не нашел способ как serialize интерфейс, поэтому сделал через синглтон.
        // В следующих ДЗ перепишу с DI
        // + тут нарушается OCP
        private IBulletHandler[] _handlers = new []
        {
            BoundsHandler.Instance, 
            CollisionHandler.Instance, 
        };
        
        private void OnEnable()
        {
            _bulletSystem.BulletAdded += HandleOnAdd;
            _bulletSystem.BulletRemoved += HandleOnRemove;
        }

        private void Start()
        {
            _handlers = new []
            {
                BoundsHandler.Instance, 
                CollisionHandler.Instance, 
            };
        }

        private void OnDisable()
        {
            _bulletSystem.BulletAdded -= HandleOnAdd;
            _bulletSystem.BulletRemoved -= HandleOnRemove;
        }

        private void HandleOnAdd(object _, Bullet bullet)
        {
            Bullet[] bullets = _bulletSystem.GetActiveBullets();

            foreach (IBulletHandler handler in _handlers)
            {
                handler.OnAddHandle(bullets, bullet);
            }

        }
        
        private void HandleOnRemove(object _, Bullet bullet)
        {
            Bullet[] bullets = _bulletSystem.GetActiveBullets();
            
            foreach (IBulletHandler handler in _handlers)
                handler.OnRemoveHandle(bullets, bullet);
        }
    }
}