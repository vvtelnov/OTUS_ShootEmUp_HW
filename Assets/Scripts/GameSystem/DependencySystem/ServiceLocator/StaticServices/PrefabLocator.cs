using UnityEngine;

namespace GameSystem.DependencySystem.ServiceLocator.StaticServices
{
    public class PrefabLocator : MonoBehaviour
    {
        public static PrefabLocator Instance;

        [SerializeField] private GameObject[] _prefabs;
        
        private void Awake()
        {
            if (Instance is null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        
        public GameObject[] GetPrefabs()
        {
            return _prefabs;
        }
    }
}