using System;
using System.Collections.Generic;
using System.Linq;
using Pool;
using UnityEngine;

namespace Bullets
{
    public sealed class BulletSystem : MonoBehaviour
    {
        public event EventHandler<Bullet> BulletAdded;
        public event EventHandler<Bullet> BulletRemoved;
        
        [SerializeField] private PoolSystem _pool;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private int _poolSize;
        
        private readonly HashSet<Bullet> _activeBullets = new();
        
        public Bullet GetBullet()
        {
            if (!_pool.HasObject())
                _pool.PutNewObject();

            GameObject bulletObject = _pool.TryToGet();
            Bullet bullet = (Bullet)bulletObject.GetComponent(typeof(Bullet));

            if (_activeBullets.Add(bullet))
            {
                BulletAdded?.Invoke(this, bullet);
            }

            return bullet;
        }
        
        public void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                BulletRemoved?.Invoke(this.GetActiveBullets(), bullet);

                _pool.Release(bullet.gameObject);
            }
        }

        public Bullet[] GetActiveBullets()
        {
            return _activeBullets.ToArray();
        }

        private void Start()
        {
            _pool.CreatePool(_bulletPrefab, _poolSize);
        }
    }
}