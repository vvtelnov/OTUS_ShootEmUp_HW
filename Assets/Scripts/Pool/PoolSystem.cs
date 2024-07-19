using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public sealed class PoolSystem : MonoBehaviour
    {
        [SerializeField] private Transform _visibleContainer;
        [SerializeField] private Transform _hiddenContainer;

        private readonly Queue<GameObject> _pool = new();
        private GameObject _prefab;
        private int _poolSize;
        
        private bool _isPoolCreated ;

        public void CreatePool(GameObject prefab, int size)
        {
            ValidatePoolCreation();
            
            _prefab = prefab;
            _poolSize = size;

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
            return Instantiate(_prefab);
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
