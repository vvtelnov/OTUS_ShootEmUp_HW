using UnityEngine;

namespace GameSystem.DependencySystem.ServiceLocator.StaticServices
{
    public class InactiveGameObjectLocator : MonoBehaviour
    {
        public static InactiveGameObjectLocator Instance;
        
        [SerializeField] private GameObject[] _inactiveGameObjects;

        private void Awake()
        {
            if (Instance is null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public GameObject[] GetInactiveGameObjects()
        {
            return _inactiveGameObjects;
        }
    }
}