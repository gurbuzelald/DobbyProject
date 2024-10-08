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

    [SerializeField] Pool[] pools = null;

    private GameObject _poolUpdateObject;


    public static bool creatablePlayerBullet;
    public static bool creatableEnemyBullet;
    public static bool creatableSwordBullet;


    void Start()
    {
        CreateAndEnqueueObject();
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
    
    void SetPlayerBulletID(int objectPoolLine)
    {
        if (pools[objectPoolLine].bulletData != null)
        {
            int weaponId = GetPlayerWeaponId(pools[objectPoolLine].bulletData);
            if (weaponId != -1)
            {
                BulletData.currentWeaponID = weaponId;
            }
        }
    }

    private int GetPlayerWeaponId(BulletData bulletData)
    {
        if (bulletData.isPistol) return 0;
        else if (bulletData.isAxe) return 1;
        else if (bulletData.isBulldog) return 2;
        else if (bulletData.isCow) return 3;
        else if (bulletData.isCrystal) return 4;
        else if (bulletData.isDemon) return 5;
        else if (bulletData.isIce) return 6;
        else if (bulletData.isElectro) return 7;
        else if (bulletData.isAk47) return 8;
        else if (bulletData.isM4a4) return 9;
        return -1;
    }


    public void CreateAndEnqueueObject()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>();

            // Initialize ID once based on the pool type (Player Bullet, Enemy Bullet, etc.)
            if (j == playerData.playerWeaponBulletObjectPoolCount)
            {
                SetPlayerBulletID(playerData.playerWeaponBulletObjectPoolCount);  // Set Player Bullet ID once for this pool
            }
            else if (j == playerData.playerBulletsExplosionObjectPoolCount)
            {
                SetPlayerBulletID(playerData.playerBulletsExplosionObjectPoolCount);  // Set Player Bullet Explosion ID once for this pool
            }   

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
            case 0: // Player Bullet
            case 6: // Bullet Explosion
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