using System;
using System.Collections.Generic;
using GameSystem.DependencySystem.DI;
using GameSystem.DependencySystem.StaticServices;
using UnityEngine;

namespace GameSystem.DependencySystem.ServiceLocator
{
    public class ObjectLocator : IMonoBehaviorLocator, INewInstanceLocator,
        IInstanceLocator, IGameObjectLocator,
        IPrefabLocator, IConfigLocator
    {
        
        private readonly Dictionary<Type, object> _instances = new();
        private readonly Dictionary<Type, MonoBehaviour> _monoBehaviours = new();
        private readonly Dictionary<string, GameObject> _prefabs = new ();
        private readonly Dictionary<string, GameObject> _gameObjects = new ();
        private readonly Dictionary<string, GameObject> _inactiveGameObjects = new ();
        private readonly Dictionary<string, ScriptableObject> _configs = new ();
        
        object IServiceLocator.GetService(Type type, DependencyResolvePrinciple resolvePrinciple, string gameObjectName, object _)
        {
            switch (resolvePrinciple)
            {
                case DependencyResolvePrinciple.FROM_MONO_BEHAVIOR:
                    return ((IMonoBehaviorLocator)this).GetMonoBehavior(type);
                
                case DependencyResolvePrinciple.CREATE_NEW_INSTANCE:
                    return ((INewInstanceLocator)this).GetNewInstance(type);
                
                case DependencyResolvePrinciple.FROM_CASHED_INSTANCE:
                    return ((IInstanceLocator)this).GetInstance(type);
                    
                case DependencyResolvePrinciple.FROM_PREFAB:
                    return ((IPrefabLocator)this).GetPrefab(gameObjectName);
                    
                case DependencyResolvePrinciple.FROM_GAME_OBJECT:
                    return ((IGameObjectLocator)this).GetGameObject(gameObjectName);
                
                case DependencyResolvePrinciple.FROM_INACTIVE_GAME_OBJECT:
                    return ((IGameObjectLocator)this).GetInactiveGameObject(gameObjectName);
                
                case DependencyResolvePrinciple.FROM_CONFIG:
                    return ((IConfigLocator)this).GetConfig(gameObjectName);
                    
                case DependencyResolvePrinciple.DO_NOT_INJECT:
                    return null;
                
                default:
                    return null;
            }
        }

        internal void RegisterInstance(object instance)
        {
            var type = instance.GetType();
            
            _instances.Add(type, instance);
        }
        
        internal GameObject[] GetRootObjects()
        {
            return ServiceFinder.Instance.GetRootObjects();
        }

        MonoBehaviour IMonoBehaviorLocator.GetMonoBehavior(Type type)
        {
            if (!_monoBehaviours.TryGetValue(type, out var monoBehaviour)) 
            {
                monoBehaviour = (MonoBehaviour)ServiceFinder.Instance.FindObjectOnScene(type);;
                RegisterMonoBehavior(type, monoBehaviour);
            }
            
            return monoBehaviour;
        }

        object INewInstanceLocator.GetNewInstance(Type type)
        {
            object instance = Activator.CreateInstance(type);

            INewInstanceLocator.OnCreation(instance);
            
            return instance;
        }
    
        object IInstanceLocator.GetInstance(Type type)
        {
            if (!_instances.TryGetValue(type, out var instance))
            {
                instance = ((INewInstanceLocator)this).GetNewInstance(type);
                _instances.Add(type, instance);
            }

            return instance;
        }

        void IInstanceLocator.UpdateState(Type instanceType, object instance)
        {
            if (!_instances.ContainsKey(instanceType))
                throw new Exception($"You try to update IInstanceLocator with {instanceType}, but there were no instance with that type");

            _instances[instanceType] = instance;
        }


        UnityEngine.Object IGameObjectLocator.GetGameObject(string objectName)
        {
            if (!_gameObjects.TryGetValue(objectName, out var gameObject))
            {
                gameObject = ServiceFinder.Instance.FindGameObjectOnScene(objectName);
                _gameObjects[objectName] = gameObject;
            }

            if (gameObject is null)
            {
                throw new Exception($"There is no GameObject with name {objectName} registered in ObjectLocator" +
                                    $"If you wish to get Inactive Game Object you should use GetInactiveGameObject()");
            }

            return gameObject;
        }

        UnityEngine.Object IGameObjectLocator.GetInactiveGameObject(string objectName)
        {
            if (!_inactiveGameObjects.TryGetValue(objectName, out var gameObject))
            {
                throw new Exception($"There is no Prefab object with name {objectName} registered in ObjectLocator");
            }

            return gameObject;
        }

        UnityEngine.Object IPrefabLocator.GetPrefab(string prefabName)
        {
            if (!_prefabs.TryGetValue(prefabName, out var prefab))
            {
                throw new Exception($"There is no Prefab object with name {prefabName} registered in ObjectLocator");
            }

            return prefab;
        }

        internal void RegisterPrefab(string prefabName, GameObject prefab)
        {
            _prefabs.Add(prefabName, prefab);
        }
        
        internal void RegisterInactiveGameObject(string objectName, GameObject obj)
        {
            _inactiveGameObjects.Add(objectName, obj);
        }
        
        internal void RegisterMonoBehavior(Type type, MonoBehaviour obj)
        {
            _monoBehaviours.Add(type, obj);
        }
        
        internal void RegisterConfig(string configName, ScriptableObject config)
        {
            _configs.Add(configName, config);
        }

        ScriptableObject IConfigLocator.GetConfig(string name)
        {
            if (!_configs.TryGetValue(name, out var config))
            {
                throw new Exception($"There is no Config object with name {name} registered in ObjectLocator");
            }

            return config;
        }

        Dictionary<string, ScriptableObject> IConfigLocator.GetLocatorCopy()
        {
            return new Dictionary<string, ScriptableObject>(_configs);

        }

        Dictionary<Type, MonoBehaviour> IMonoBehaviorLocator.GetLocatorCopy()
        {
            return new Dictionary<Type, MonoBehaviour>(_monoBehaviours);
        }

        Dictionary<Type, object> IInstanceLocator.GetLocatorCopy()
        {
            return new Dictionary<Type, object>(_instances);
        }
        
        Dictionary<string, GameObject> IGameObjectLocator.GetLocatorCopy()
        {
            return new Dictionary<string, GameObject>(_gameObjects);
        }

        Dictionary<string, GameObject> IGameObjectLocator.GetInactiveLocatorCopy()
        {
            return new Dictionary<string, GameObject>(_inactiveGameObjects);
        }
        
        Dictionary<string, GameObject> IPrefabLocator.GetLocatorCopy()
        {
            return new Dictionary<string, GameObject>(_prefabs);
        }
    }
}