using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
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

    public PlayerData playerData;


    void Start()
    {
        CreateAndEnqueueObject();
    }

    private void Update()
    {
        SetPlayerBulletsAndExplosionsAtUpdate();
    }

    public void SetPlayerBulletsAndExplosionsAtUpdate()
    {

        if (pools.Length != 0)
        {
            if (creatablePlayerBullet)
            {
                CreateAndEnqueueObject();

                creatablePlayerBullet = false;
            }
        }
    }

    public void CreateAndEnqueueObject()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            playerData.pools[j].pooledObjects = new Queue<GameObject>();


            // Pool objects exactly poolSize times
            for (int i = 0; i < playerData.pools[j].poolSize; i++)
            {
                GameObject pooledObject = InstantiateObject(j, playerData.pools[j], pools[j]);
                if (pooledObject == null)
                {
                    return;
                }

                pooledObject.SetActive(false);
                playerData.pools[j].pooledObjects.Enqueue(pooledObject); // Add only one object per iteration
            }
        }        
    }

    // Helper Method to Instantiate Object Once
    GameObject InstantiateObject(int poolIndex,PlayerData.Pool staticPool, Pool dynamicPool)
    {
        int prefabIndex = 0; // Default prefab index
        Transform objTransform = dynamicPool.objectTransform;

        // Select prefab index based on the poolIndex
        switch (poolIndex)
        {       
            case 0: // Player Bullet
            
            case 2: // Bullet Explosion
             
            case 7: //Enemy Death Particle By Player Bullet
            
                prefabIndex = BulletData.currentWeaponID;
                break;
            case 1: // Player Sword Bullet
            case 3: // Player Sword Explosion
            case 4: // Player Burning Touch Particle
            case 5: // Player Touch Particle   
            case 6: // Player Death Particle   
            case 8: // Player Run Particle         
                prefabIndex = PlayerData.currentCharacterID;
                break;
            default:
                return null; // Return null if poolIndex is out of range
        }
        if (objTransform)
        {
            if (poolIndex == 0 || poolIndex == 1)
            {
                if (PlayerManager.GetInstance)
                {
                    if (PlayerManager.GetInstance.transform)
                    {
                        if (PlayerManager.GetInstance.transform.childCount >= 1)
                        {
                            if (PlayerManager.GetInstance.transform.GetChild(0).childCount >= 6)
                            {
                                instantiateObject = Instantiate(staticPool.objectPrefab[prefabIndex],
                                    PlayerManager.GetInstance.transform.GetChild(0).GetChild(5).position,
                                  PlayerManager.GetInstance.transform.GetChild(0).GetChild(5).rotation,
                                  objTransform);
                            }
                        }
                    }
                }
            }
            else
            {
                instantiateObject = Instantiate(staticPool.objectPrefab[prefabIndex], objTransform.position, objTransform.rotation, objTransform);
            }           
        }
        else
        {
            if (prefabIndex != 0)
            {
                Debug.Log($"{prefabIndex} object pool indeksinde transform girilmedi.");
            }
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

        _poolUpdateObject = playerData.pools[objectType].pooledObjects.Dequeue();

        _poolUpdateObject.SetActive(true);

        playerData.pools[objectType].pooledObjects.Enqueue(_poolUpdateObject);

        return _poolUpdateObject;
    }
}