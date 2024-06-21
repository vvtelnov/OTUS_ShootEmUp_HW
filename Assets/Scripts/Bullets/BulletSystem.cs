using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private PoolSystem _pool;
        [SerializeField] private PoolObjectsCreator _poolObjectsCreator;
        [SerializeField] private LevelBounds levelBounds;

        private readonly HashSet<Bullet> _activeBullets = new();

        private void Start()
        {
            GameObject[] Bullets = _poolObjectsCreator.GetCreatedObjects();
            _pool.CreatePool(Bullets);
        }

        private void FixedUpdate()
        {
            RemoveBulletIfNotInBounds();
        }

        private void RemoveBulletIfNotInBounds()
        {
            foreach (Bullet bullet in _activeBullets.ToArray())
            {
                if (!levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public Bullet GetBullet()
        {
            if (!_pool.HasObject())
                _pool.PutNewObject(_poolObjectsCreator.GetCreatedObject());

            GameObject bulletObject = _pool.Get();
            Bullet bullet = (Bullet)bulletObject.GetComponent(typeof(Bullet));

            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += this.OnBulletCollision;
            }

            return bullet;
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            print("bullet hited");
            BulletDamage.DealDamage(bullet, collision.gameObject);
            this.RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (this._activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= this.OnBulletCollision;

                _pool.Release(bullet.gameObject);
            }
        }
    }
}