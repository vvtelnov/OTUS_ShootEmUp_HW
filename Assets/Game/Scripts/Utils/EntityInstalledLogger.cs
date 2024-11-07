using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Utils
{
    [DisallowMultipleComponent]
    public class EntityInstalledLogger : MonoBehaviour
    {
        [SerializeField] public bool IsEnable;
        public static EntityInstalledLogger Instance;

        public void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
            }
            // else
            // {
            //     throw new Exception("EntityInstalledLogger is a Singleton, but was created multiple times");
            // }
        }

        public void Log(IEntity entity)
        {
#if UNITY_EDITOR
            if (!IsEnable)
                return;
            
            Debug.Log($"<color=#32CD32>{entity.Name} has been successfully installed</color>");
#endif
        }
    }
}