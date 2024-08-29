using GameSystem.DependencySystem.DI;
using UnityEngine;

namespace GameSystem.DependencySystem.StaticServices
{
    [InjectionNeeded]
    public class GameObjectInstantiator : MonoBehaviour
    {
        public static GameObjectInstantiator Instance;

        private DependencyInjector _injector;

        private void Awake()
        {
            if (Instance is null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        public void Constructor(DependencyInjector injector)
        {
            _injector = injector;
        }

        public GameObject InstantiateGameObject(GameObject prefab)
        {
            GameObject obj = Instantiate(prefab);
            
            ((IDependencyInjector)_injector).InjectInGameObject(obj);

            return obj;
        }
    }
}