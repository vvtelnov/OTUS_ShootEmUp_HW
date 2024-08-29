using System;
using UnityEngine;

namespace GameSystem.DependencySystem
{
    public interface IDependencySystem
    {
        internal void InjectDependencyInGameObjects(GameObject[] gameObjects);
        
        public object GetInjectedInstance(Type type);
        public object GetInjectedNewInstance(Type type);
        public UnityEngine.Object GetPrefab(string gameObjectName);
        public UnityEngine.Object GetGameObject(string gameObjectName);
    }
}