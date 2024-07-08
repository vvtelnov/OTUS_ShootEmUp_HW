using System;
using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace Bullets
{
    //TODO: remove comment
    // Я не знаю как назвать класс + тут нарушается SRP:
    // 1 ответственность - работа с пулом;
    // 2 - Состояние ( HashSet<Bullet> _activeBullets )
    // По-скольку есть состояние, а не просто работа с пулом, решил добавить state в нейминг
    public sealed class StatePoolInteractor : MonoBehaviour
    {
        [SerializeField] private PoolSystem _pool;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private int _poolSize;

        [SerializeField] private DeathObserver _deathObserver;
        
        private readonly HashSet<Bullet> _activeBullets = new();
        
        public Bullet GetBullet()
        {
            if (!_pool.HasObject())
                _pool.PutNewObject();

            GameObject bulletObject = _pool.TryToGet();
            Bullet bullet = (Bullet)bulletObject.GetComponent(typeof(Bullet));

            if (!_activeBullets.Add(bullet))
                throw new InvalidOperationException("There is the same bullet on scene");

            _deathObserver.SubscribeObserver(bullet);

            return bullet;
        }
        
        public void RemoveBullet(Bullet bullet)
        {
            if (!_activeBullets.Remove(bullet))
                throw new InvalidOperationException("There is NO passed bullet on scene");
            
            _deathObserver.UnsubscribeObserver(bullet);
            
            _pool.Release(bullet.gameObject);
        }

        private void Start()
        {
            _pool.CreatePool(_bulletPrefab, _poolSize);
        }
    }
}