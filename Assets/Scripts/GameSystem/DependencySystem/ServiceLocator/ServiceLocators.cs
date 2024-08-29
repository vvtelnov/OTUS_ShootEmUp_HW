using System;
using System.Collections.Generic;
using GameSystem.DependencySystem.DI;
using UnityEngine;

namespace GameSystem.DependencySystem.ServiceLocator
{
    public interface IServiceLocator
    {
        internal System.Object GetService(
            Type type,
            DependencyResolvePrinciple resolvePrinciple,
            string gameObjectName = null,
            // Used to log out information about what service ask for the returned service 
            object injectionTarget = null
            );
    }
    
    public interface IMonoBehaviorLocator : IServiceLocator
    {
        internal MonoBehaviour GetMonoBehavior(Type type);
        
        internal Dictionary<Type, MonoBehaviour> GetLocatorCopy();
    }
    
    public interface INewInstanceLocator : IServiceLocator
    {
        internal System.Object GetNewInstance(Type type);
        
        public static event Action<object> InstanceIsCreated;
        
        internal static void OnCreation(object instance)
        {
            InstanceIsCreated?.Invoke(instance);
        }
    }
    
    public interface IInstanceLocator : IServiceLocator
    {
        internal System.Object GetInstance(Type type);

        internal void UpdateState(Type instanceType, object instance);
        
        internal Dictionary<Type, object> GetLocatorCopy();
    }

    public interface IGameObjectLocator : IServiceLocator
    {
        internal UnityEngine.Object GetGameObject(string name);
        
        internal UnityEngine.Object GetInactiveGameObject(string name);
        
        internal Dictionary<string, GameObject> GetLocatorCopy();
        internal Dictionary<string, GameObject> GetInactiveLocatorCopy();
    }
    
    public interface IPrefabLocator : IServiceLocator
    {
        internal UnityEngine.Object GetPrefab(string name);
        
        internal Dictionary<string, GameObject> GetLocatorCopy();
    }
    
    public interface IConfigLocator : IServiceLocator
    {
        internal UnityEngine.ScriptableObject GetConfig(string name);
        
        internal Dictionary<string, ScriptableObject> GetLocatorCopy();
    }
}