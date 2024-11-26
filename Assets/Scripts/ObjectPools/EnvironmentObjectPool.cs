using System;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObjectPool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Transform objectTransform;
    }

    [SerializeField] Pool[] pools = null;

    private GameObject _poolUpdateObject;


    public static bool creatablePlayerBullet;

    private GameObject instantiateObject;

    [SerializeField] EnvironmentData environmentData;


    void Start()
    {
        CreateAndEnqueueObject();
    }

    public void CreateAndEnqueueObject()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            environmentData.pools[j].pooledObjects = new Queue<GameObject>();


            // Pool objects exactly poolSize times
            for (int i = 0; i < environmentData.pools[j].poolSize; i++)
            {
                GameObject pooledObject = InstantiateObject(j, environmentData.pools[j], pools[j]);
                if (pooledObject == null)
                {
                    return;
                }

                pooledObject.SetActive(false);
                environmentData.pools[j].pooledObjects.Enqueue(pooledObject); // Add only one object per iteration
            }
        }
    }

    // Helper Method to Instantiate Object Once
    GameObject InstantiateObject(int poolIndex, EnvironmentData.Pool staticPool, Pool dynamicPool)
    {
        int prefabIndex = 0; // Default prefab index
        Transform objTransform = dynamicPool.objectTransform;

        // Select prefab index based on the poolIndex
        switch (poolIndex)
        {
            case 0: // Destroy Group Coin Particle
            case 1: // Destroy BulletCoin
            case 2: // Health Particle
            case 3: // Mushroom Particle
            case 4: // Destroy Coin Particle
            case 5: // Destroy Key Particle
            case 6: // Destroy Collect Particle
                prefabIndex = 0;
                break;
            default:
                return null; // Return null if poolIndex is out of range
        }

        if (objTransform)
        {
            instantiateObject = Instantiate(staticPool.objectPrefab[prefabIndex], objTransform.position, objTransform.rotation, objTransform);
        }
        else
        {
            Debug.Log($"{prefabIndex} object pool indeksinde transform girilmedi.");

            instantiateObject = Instantiate(staticPool.objectPrefab[prefabIndex]);
        }

        return instantiateObject;
    }

    public GameObject GetPooledObject(int objectType)
    {
        if (objectType >= pools.Length)
        {
            return null;
        }

        _poolUpdateObject = environmentData.pools[objectType].pooledObjects.Dequeue();

        _poolUpdateObject.SetActive(true);

        environmentData.pools[objectType].pooledObjects.Enqueue(_poolUpdateObject);

        return _poolUpdateObject;
    }
}