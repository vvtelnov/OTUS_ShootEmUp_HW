using UnityEngine;

namespace GameSystem.DependencySystem.ServiceLocator.StaticServices
{
    public class ConfigLocator : MonoBehaviour
    {
        public static ConfigLocator Instance;

        [SerializeField] private ScriptableObject[] _configs;
    
        private void Awake()
        {
            if (Instance is null)
                Instance = this;
            else
                Destroy(gameObject);
        }
    
        public ScriptableObject[] GetConfigs()
        {
            return _configs;
        }
    }
}