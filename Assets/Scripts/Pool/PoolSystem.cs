using System;
using System.Collections.Generic;
using GameSystem.DependencySystem.DI;
using GameSystem.DependencySystem.StaticServices;
using UnityEngine;

namespace Pool
{
    [InjectionNeeded]
    public sealed class PoolSystem
    {
        private Transform _visibleContainer;
        private Transform _hiddenContainer;
        private GameObject _prefab;
        private int _poolSize;
        
        private readonly Queue<GameObject> _pool = new();
        private bool _isPoolCreated;

        [Inject(DependencyResolvePrinciple.FROM_GAME_OBJECT, objectName: "[WORLD]")]
        public void ConstructWithInjection(GameObject visibleContainer)
        {
            _visibleContainer = visibleContainer.transform;
        }

        public void Construct(GameObject prefab, int size, GameObject hiddenContainer)
        {
            _prefab = prefab;
            _poolSize = size;
            _hiddenContainer = hiddenContainer.transform;
        }
        
        public void CreatePool()
        {
            ValidatePoolCreation();

            for (int i = 0; i < _poolSize; i++)
            {
                GameObject poolObject = CreateObject();
                
                poolObject.transform.SetParent(_hiddenContainer);
                _pool.Enqueue(poolObject); 
            }
            
            _isPoolCreated = true;
        }

        public GameObject TryToGet()
        {
            if (!_pool.TryDequeue(out var poolObject))
                return null;

            poolObject.transform.SetParent(_visibleContainer);

            return poolObject;
        }

        public void Release(GameObject poolObject)
        {
            poolObject.transform.SetParent(_hiddenContainer);
            _pool.Enqueue(poolObject);
        }

        public void PutNewObject()
        {
            GameObject obj = CreateObject();

            obj.transform.SetParent(_hiddenContainer);
            _pool.Enqueue(obj);
        }

        public bool HasObject()
        {
            return _pool.Count > 0;
        }

        private GameObject CreateObject()
        {
            return GameObjectInstantiator.Instance.InstantiateGameObject(_prefab);
        }
        
        private void ValidatePoolCreation()
        {
            if (_isPoolCreated)
            {
                throw new AccessViolationException(
                    "Pool has already been created in this instanse. " +
                    "Each PoolSystem instance can contain only one pool. " +
                    "To create different pool create new class PoolSystem instance."
                );
            }
        }
    }
}
