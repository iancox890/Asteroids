using UnityEngine;
using System.Collections.Generic;

namespace Asteroids
{
    /// <summary>
    /// Manages a list of object pools accessible via a string key.
    /// </summary>
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private List<Pool> _pools = new List<Pool>();

        private Dictionary<string, Pool> _poolDictionary = new Dictionary<string, Pool>();
        private Transform parent;

        private void Awake()
        {
            parent = GetComponent<Transform>();

            for (int i = 0; i < _pools.Count; i++)
            {
                Pool pool = _pools[i];
                pool.FillPool(parent);

                _poolDictionary.Add(pool.Key, pool);
            }
        }

        ///<summary>
        /// Pulls an object by key from the pool of a certain type at a set position and rotation.
        /// This object will be set to active upon return.
        ///</summary>
        public T PullObjectFromPool<T>(string key)
        {
            Pool pool = _poolDictionary[key];
            GameObject obj = pool.PullObject(parent);

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

        public void FillPool(Transform parent)
        {
            _objects = new List<GameObject>();

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

            // No inactive object exists, so create a new one and add it to the pool.
            return AddObjectToPool(parent);
        }
    }
}