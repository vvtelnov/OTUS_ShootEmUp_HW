using System;
using UnityEngine;

namespace GameSystem.DependencySystem.StaticServices
{
    public sealed class ServiceFinder : MonoBehaviour
    {
        public static ServiceFinder Instance;

        private void Awake()
        {
            if (Instance is null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        
        public object FindObjectOnScene(Type type)
        {
            var obj = FindObjectOfType(type);

            if (obj is null)
            {
                throw new Exception($"There is no object of type {type} on the scene");
            }

            return obj;
        }

        public GameObject FindGameObjectOnScene(string objectName)
        {
            return GameObject.Find(objectName);
        }

        public GameObject[] GetRootObjects()
        {
            return UnityEngine.SceneManagement.SceneManager
                .GetActiveScene()
                .GetRootGameObjects();
        }
    }
}