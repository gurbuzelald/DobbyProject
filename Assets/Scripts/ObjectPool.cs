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

    [SerializeField] Pool[] pools = null;

    private GameObject _poolUpdateObject;


    public static bool creatablePlayerBullet;
    public static bool creatableEnemyBullet;
    public static bool creatableSwordBullet;


    void Start()
    {
        CreateAndEnqueueObject();
    }
    private void Update()
    {
        /*if (pools.Length != 0)
        {
            if ((pools[0].bulletData != null && creatablePlayerBullet && pools[8].bulletData != null && pools[17].bulletData != null) ||
                (pools[1].bulletData != null && levelData && creatableEnemyBullet))
            {
                CreateAndEnqueueObject();

                creatablePlayerBullet = false;

                creatableEnemyBullet = false;
            }
        }*/
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
    void SetEnemyBulletID(int objectPoolLine)
    {
        if (pools[objectPoolLine].bulletData != null)
        {
            int bulletID = GetEnemyWeaponId(levelData);
            if (bulletID != -1)
            {
                BulletData.currentEnemyBulletID = bulletID;
            }
        }
    }

    private int GetEnemyWeaponId(LevelData levelData)
    {
        if (levelData.currentLevel == LevelData.Levels.Level1) return 0;
        if (levelData.currentLevel == LevelData.Levels.Level2) return 1;
        if (levelData.currentLevel == LevelData.Levels.Level3) return 2;
        if (levelData.currentLevel == LevelData.Levels.Level4) return 3;
        if (levelData.currentLevel == LevelData.Levels.Level5) return 4;
        if (levelData.currentLevel == LevelData.Levels.Level6) return 5;
        if (levelData.currentLevel == LevelData.Levels.Level7) return 6;
        if (levelData.currentLevel == LevelData.Levels.Level8) return 7;
        if (levelData.currentLevel == LevelData.Levels.Level9) return 8;
        if (levelData.currentLevel == LevelData.Levels.Level10) return 9;
        return -1;
    }

    private int GetPlayerWeaponId(BulletData bulletData)
    {
        if (bulletData.isPistol) return 0;
        if (bulletData.isAxe) return 1;
        if (bulletData.isBulldog) return 2;
        if (bulletData.isCow) return 3;
        if (bulletData.isCrystal) return 4;
        if (bulletData.isDemon) return 5;
        if (bulletData.isIce) return 6;
        if (bulletData.isElectro) return 7;
        if (bulletData.isAk47) return 8;
        if (bulletData.isM4a4) return 9;
        return -1;
    }


    public void CreateAndEnqueueObject()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>();

            // Initialize ID once based on the pool type (Player Bullet, Enemy Bullet, etc.)
            if (j == 0)
            {
                SetPlayerBulletID(0);  // Set Player Bullet ID once for this pool
            }
            else if (j == 1)
            {
                SetEnemyBulletID(1);  // Set Enemy Bullet ID once for this pool
            }
            else if (j == 8)
            {
                SetPlayerBulletID(8);  // Set Player Bullet Explosion ID once for this pool
            }
            else if (j == 17)
            {
                SetPlayerBulletID(17);  // Enemy
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

        if (poolIndex == 0)
        {
            // Instantiate Player Bullet
            obj = Instantiate(pool.objectPrefab[BulletData.currentWeaponID],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 1)
        {
            // Instantiate Enemy Bullet
            obj = Instantiate(pool.objectPrefab[BulletData.currentEnemyBulletID],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if(poolIndex == 2)
        {
            // Instantiate Player Sword
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 3)
        {
            // Instantiate Player Coin Particle
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 4)
        {//Destroy BulletCoin
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 5)
        {//Enemy Destroy Particle
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 6)
        {//Health Particle
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 7)
        {//Mushroom Particle
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 8)
        {//Bullet Explosion
            obj = Instantiate(pool.objectPrefab[BulletData.currentWeaponID],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 9)
        {//Sword Explosion
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 10)
        {// Bottom Particle
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 11)
        {// Mid Particle
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 12)
        { // Top Particle
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 13)
        {//Burning Particle
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 14)
        {//Burning Particle
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 15)
        {//Birth Particle
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 16)
        {//Death Particle
            obj = Instantiate(pool.objectPrefab[0],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else if (poolIndex == 17)
        {//Enemies
            obj = Instantiate(pool.objectPrefab[BulletData.currentEnemyBulletID],
                              pool.objectTransform.position,
                              pool.objectTransform.rotation,
                              pool.objectTransform);
            return obj;
        }
        else
        {
            return null;
        }

        
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