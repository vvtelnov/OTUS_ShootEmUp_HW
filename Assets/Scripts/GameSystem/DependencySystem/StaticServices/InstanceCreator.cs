using System;
using GameSystem.DependencySystem.DI;
using GameSystem.DependencySystem.ServiceLocator;
using UnityEngine;

namespace GameSystem.DependencySystem.StaticServices
{
    [InjectionNeeded]
    public class InstanceCreator : MonoBehaviour
    {
        public static InstanceCreator Instance;
        
        private IServiceLocator _serviceLocator;

        private void Awake()
        {
            if (Instance is null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        public void Constructor(ServiceLocator.Logger serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
        
        public T CreateInstance<T>()
        {
            Type type = typeof(T);
            
            return (T) CreateInstanceOfType(type);
        }

        public object CreateInstanceOfType(Type type)
        {
            //GameObjectName is only applicable for getting Unity.Object form service Locator
            return _serviceLocator.GetService(type, DependencyResolvePrinciple.CREATE_NEW_INSTANCE);
        }
    }
}