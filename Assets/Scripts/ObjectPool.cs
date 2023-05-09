using UnityEngine;
using System.Collections.Generic;

namespace Asteroids
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private List<Pool> pools = new List<Pool>();

        private Dictionary<string, Pool> poolDictionary = new Dictionary<string, Pool>();
        private Transform parent;

        public Dictionary<string, Pool> PoolDictionary => poolDictionary;

        private void Start()
        {
            parent = GetComponent<Transform>();

            for (int i = 0; i < pools.Count; i++)
            {
                Pool pool = pools[i];
                pool.FillPool(parent);

                poolDictionary.Add(pool.Key, pool);
            }
        }

        ///<summary>
        /// Pulls an object by key from the pool of a certain type at a set position and rotation.
        /// This object will be set to active upon return.
        ///</summary>
        public T PullObjectFromPool<T>(string key)
        {
            Pool pool = poolDictionary[key];

            GameObject obj = pool.PullObject(parent);
            obj.SetActive(true);

            return obj.GetComponent<T>();
        }
    }

    [System.Serializable]
    public struct Pool
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _count;
        [SerializeField] private string _key;

        private List<GameObject> _objects;

        public string Key => _key;

        private GameObject AddObjectToPool(Transform parent)
        {
            var obj = GameObject.Instantiate(_prefab, parent);
            obj.SetActive(false);

            _objects.Add(obj);
            return obj;
        }

        internal void FillPool(Transform parent)
        {
            for (int i = 0; i < _count; i++)
            {
                AddObjectToPool(parent);
            }
        }

        public GameObject PullObject(Transform parent)
        {
            // Find an inactive object in the pool.
            int count = _objects.Count;

            for (int i = 0; i < count; i++)
            {
                var obj = _objects[i];

                if (obj.activeSelf == false) return obj;
            }

            // No inactive object exists, so create a new one 
            // and add it to the pool.
            return AddObjectToPool(parent);
        }
    }
}