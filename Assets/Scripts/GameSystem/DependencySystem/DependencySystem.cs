using System;
using GameSystem.DependencySystem.DI;
using GameSystem.DependencySystem.ServiceLocator;
using UnityEngine;

namespace GameSystem.DependencySystem
{
    public class DependencySystem : IDependencySystem, IServiceLocator
    {
        private IDependencyInjector _injector;
        private IServiceLocator _objectLocator;
        private IPrefabLocator _prefabLocator;
        private IGameObjectLocator _gameObjectLocator;

        public void Construct(IDependencyInjector injector,
        IServiceLocator serviceLocator,
        IPrefabLocator prefabLocator,
        IGameObjectLocator gameObjectLocator)
        {
            _injector = injector; 
            _objectLocator = serviceLocator; 
            _prefabLocator = prefabLocator;
            _gameObjectLocator = gameObjectLocator;
        }
        
        object IServiceLocator.GetService(Type type,
            DependencyResolvePrinciple resolvePrinciple, string gameObjectName, object injectionObj)
        {
            return _objectLocator.GetService(type, resolvePrinciple, gameObjectName, injectionObj);
        }
        
        
        void IDependencySystem.InjectDependencyInGameObjects(GameObject[] gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                _injector.InjectRecursivelyInGameObject(gameObject);
            }
        }

        
        object IDependencySystem.GetInjectedInstance(Type type)
        {
            object obj = _objectLocator.GetService(type, DependencyResolvePrinciple.FROM_CASHED_INSTANCE);
            
            _injector.InjectInSingleService(obj);

            return obj;
        }
        
        object IDependencySystem.GetInjectedNewInstance(Type type)
        {
            object obj = _objectLocator.GetService(type, DependencyResolvePrinciple.CREATE_NEW_INSTANCE);
            
            _injector.InjectInSingleService(obj);

            return obj;
        }
        
        UnityEngine.Object IDependencySystem.GetPrefab(string gameObjectName)
        {
            return _prefabLocator.GetPrefab(gameObjectName);
        }
        
        UnityEngine.Object IDependencySystem.GetGameObject(string gameObjectName)
        {
            return _gameObjectLocator.GetGameObject(gameObjectName);
        }
    }
}