using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObjects;
        public GameObject[] objectPrefab;
        public Transform objectTransform;
        public int poolSize;
        public BulletData bulletData;
    }

    [SerializeField] LevelData levelData;

    [SerializeField] Pool[] pools = null;

    private GameObject _poolUpdateObject;

    public PlayerData playerData;

    void Start()
    {
        CreateAndEnqueueObject();
    }

    public void CreateAndEnqueueObject()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>();

            // Pool objects exactly poolSize times
            for (int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject pooledObject = InstantiateObject(j, pools[j]);
                if (pooledObject == null)
                {
                    return;
                }

                pooledObject.SetActive(false);
                pools[j].pooledObjects.Enqueue(pooledObject); // Add only one object per iteration
            }
        }
    }

    // Helper Method to Instantiate Object Once
    GameObject InstantiateObject(int poolIndex, Pool pool)
    {
        GameObject obj;
        int prefabIndex = 0; // Default prefab index
        Transform objTransform = pool.objectTransform;

        // Select prefab index based on the poolIndex
        switch (poolIndex)
        {
            case 0: // Enemy Bullet
            case 2: // Enemies
            case 3: // Boss Enemy
                prefabIndex = LevelData.currentLevelId;
                break;
            case 1: // Mid Particle
            case 4: // Chest Monsters
            case 5: // Chest Monsters2
                prefabIndex = 0;
                break;
            default:
                return null; // Return null if poolIndex is out of range
        }

        // Instantiate object with or without specific transform
        if (objTransform)
        {
            obj = Instantiate(pool.objectPrefab[prefabIndex], objTransform.position, objTransform.rotation, objTransform);
        }
        else
        {
            Debug.Log($"{prefabIndex} object pool indeksinde transform girilmedi.");
            obj = Instantiate(pool.objectPrefab[prefabIndex]);
        }

        return obj;
    }

    public GameObject GetPooledObject(int objectType)
    {
        if (objectType >= pools.Length)
        {
            return null;
        }

        _poolUpdateObject = pools[objectType].pooledObjects.Dequeue();

        _poolUpdateObject.SetActive(true);

        pools[objectType].pooledObjects.Enqueue(_poolUpdateObject);

        return _poolUpdateObject;
    }
}
