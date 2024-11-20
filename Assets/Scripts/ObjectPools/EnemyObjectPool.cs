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

    void Awake()
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
            case 0:
            case 2:
            case 3:
                prefabIndex = LevelData.currentLevelId;
                break;
            case 1: 
            case 4: 
            case 5: 
                prefabIndex = 0;
                break;
            case 6:
                prefabIndex = BulletData.currentWeaponID;
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
