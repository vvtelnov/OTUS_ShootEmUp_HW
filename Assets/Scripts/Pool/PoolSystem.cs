using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class PoolSystem : MonoBehaviour
    {
        private readonly Queue<GameObject> _pool = new();
        [SerializeField] private Transform _visibleContainer;
        [SerializeField] private Transform _hiddenContainer;

        public void CreatePool(GameObject[] Objects)
        {
            for (int i = 0; i < Objects.Length; i++)
            {
                GameObject poolObject = Objects[i];

                poolObject.transform.SetParent(_hiddenContainer);
                _pool.Enqueue(poolObject);
            }
        }

        public GameObject Get()
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

        public void PutNewObject(GameObject obj)
        {
            obj.transform.SetParent(_hiddenContainer);
            _pool.Enqueue(obj);
        }

        public bool HasObject()
        {
            return _pool.Count > 0;
        }
    }
}