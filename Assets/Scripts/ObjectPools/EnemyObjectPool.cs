using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Transform objectTransform;
    }

    [SerializeField] LevelData levelData;
    [SerializeField] EnemyData enemyData;

    public Pool[] pools = null;

    private GameObject _poolUpdateObject;

    void Awake()
    {
        CreateAndEnqueueObject();
    }

    public void CreateAndEnqueueObject()
    {
        for (int j = 0; j < enemyData.pools.Length; j++)
        {
            enemyData.pools[j].pooledObjects = new Queue<GameObject>();

            // Pool objects exactly poolSize times
            for (int i = 0; i < enemyData.pools[j].poolSize; i++)
            {
                GameObject pooledObject = InstantiateObject(j, enemyData.pools[j], pools[j]);
                if (pooledObject == null)
                {
                    return;
                }

                pooledObject.SetActive(false);
                enemyData.pools[j].pooledObjects.Enqueue(pooledObject); // Add only one object per iteration
            }
        }
    }

    // Helper Method to Instantiate Object Once
    GameObject InstantiateObject(int poolIndex, EnemyData.EnemyObjectPoolStruct staticPool, Pool dynamicPool)
    {
        GameObject obj;
        int prefabIndex = 0; // Default prefab index
        Transform objTransform = dynamicPool.objectTransform;

        // Select prefab index based on the poolIndex
        switch (poolIndex)
        {
            case 0://Enemy Bullet
            case 2://EnemyPrefab
            case 3://Boss Enemy Prefab
                prefabIndex = LevelData.currentLevelId;
                break;
            case 1: //Middle Particle
            case 4: //Chest Monster
            case 5: //Tazo
                prefabIndex = 0;
                break;
            default:
                return null; // Return null if poolIndex is out of range
        }

        // Instantiate object with or without specific transform
        if (objTransform)
        {
            obj = Instantiate(staticPool.objectPrefab[prefabIndex], objTransform.position, objTransform.rotation, objTransform);
        }
        else
        {
            Debug.Log($"{prefabIndex} object pool indeksinde transform girilmedi.");
            obj = Instantiate(staticPool.objectPrefab[prefabIndex]);
        }

        return obj;
    }

    public GameObject GetPooledObject(int objectType)
    {
        if (objectType >= enemyData.pools.Length)
        {
            return null;
        }

        _poolUpdateObject = enemyData.pools[objectType].pooledObjects.Dequeue();

        _poolUpdateObject.SetActive(true);

        enemyData.pools[objectType].pooledObjects.Enqueue(_poolUpdateObject);

        return _poolUpdateObject;
    }
}
