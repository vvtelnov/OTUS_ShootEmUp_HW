using UnityEngine;

namespace ShootEmUp
{
    public class PoolObjectsCreator : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int NumbOfGameObjectToCreate;

        private GameObject[] Objects;

        private void Awake()
        {
            Objects = new GameObject[NumbOfGameObjectToCreate];
        }
        public GameObject[] GetCreatedObjects()
        {
            for (int i = 0; i < NumbOfGameObjectToCreate; i++)
            {
                GameObject poolObject = Instantiate(_prefab);
                Objects[i] = poolObject;
            }

            return Objects;
        }

        public GameObject GetCreatedObject()
        {
            return Instantiate(_prefab);
        }
    }
}