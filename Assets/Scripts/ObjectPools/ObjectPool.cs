using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
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
    [SerializeField] PlayerData playerData;
    [SerializeField] BulletData playerBulletData;

    [SerializeField] Pool[] pools = null;

    private GameObject _poolUpdateObject;


    public static bool creatablePlayerBullet;
    public static bool creatableEnemyBullet;
    public static bool creatableSwordBullet;

    private GameObject instantiateObject;


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
            if ((pools[0].bulletData != null && creatablePlayerBullet))
            {
                CreateAndEnqueueObject();

                creatablePlayerBullet = false;

                creatableEnemyBullet = false;
            }
        }
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
        int prefabIndex = 0; // Default prefab index
        Transform objTransform = pool.objectTransform;

        // Select prefab index based on the poolIndex
        switch (poolIndex)
        {
            case 0: // Player Bullet
            case 6: // Bullet Explosion
            case 11: //Enemy Death Particle
                prefabIndex = BulletData.currentWeaponID;
                break;
            case 1: // Player Sword Bullet
            case 2: // Player Coin Particle
            case 3: // Destroy BulletCoin
            case 4: // Health Particle
            case 5: // PlayerMushroom Particle
            case 7: // Player Sword Explosion
            case 8: // Player Burning Touch Particle
            case 9: // Player Touch Particle
            case 10: // Player Death Particle
                prefabIndex = 0;
                break;
            default:
                return null; // Return null if poolIndex is out of range
        }

        if (poolIndex == 0)
        {
            if (PlayerManager.GetInstance)
            {
                if (PlayerManager.GetInstance.transform)
                {
                    if (PlayerManager.GetInstance.transform.childCount >= 1)
                    {
                        if (PlayerManager.GetInstance.transform.GetChild(0).childCount >=6)
                        {
                            instantiateObject = Instantiate(pool.objectPrefab[prefabIndex],
                                PlayerManager.GetInstance.transform.GetChild(0).GetChild(5).position,
                              PlayerManager.GetInstance.transform.GetChild(0).GetChild(5).rotation,
                              objTransform);
                        }
                    }
                }
            }
        }
        else if (objTransform)
        {
            instantiateObject = Instantiate(pool.objectPrefab[prefabIndex], objTransform.position, objTransform.rotation, objTransform);
        }
        else
        {
            if (prefabIndex != 0)
            {
                Debug.Log($"{prefabIndex} object pool indeksinde transform girilmedi.");
            }
            instantiateObject = Instantiate(pool.objectPrefab[prefabIndex]);
        }

        return instantiateObject;
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