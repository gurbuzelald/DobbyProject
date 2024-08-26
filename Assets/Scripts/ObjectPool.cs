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

    private GameObject _playerBulletObject;
    private GameObject _enemyBulletObject;
    private GameObject _playerSwordObject;

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
        if (pools.Length != 0)
        {
            if (pools[0].bulletData != null && creatablePlayerBullet)
            {
                CreateAndEnqueueObject();

                creatablePlayerBullet = false;
            }
            if (pools[1].bulletData != null && levelData && creatableEnemyBullet)
            {
                CreateAndEnqueueObject();

                creatableEnemyBullet = false;
            }
        }
    }
    
    void SetPlayerBulletID(int objectPoolLine)
    {
        if (pools[0].bulletData != null)
        {
            int weaponId = GetPlayerWeaponId(pools[objectPoolLine].bulletData);
            if (weaponId != -1)
            {
                BulletData.currentWeaponID = weaponId;
            }
        }
    }
    void SetEnemyBulletID()
    {
        if (pools[1].bulletData != null)
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
        if (bulletData.isNegev) return 7;
        if (bulletData.isAk47) return 8;
        if (bulletData.isM4a4) return 9;
        return -1;
    }


    public void CreateAndEnqueueObject()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>();


            for (int i = 0; i < pools[j].poolSize; i++)
            {
                if (j == 0)
                {
                    SetPlayerBulletID(0);

                    _playerBulletObject = Instantiate(pools[j].objectPrefab[BulletData.currentWeaponID],
                                             pools[j].objectTransform.position,
                                             pools[j].objectTransform.rotation,
                                             pools[j].objectTransform);
                    _playerBulletObject.SetActive(false);

                    pools[j].pooledObjects.Enqueue(_playerBulletObject);
                }
                else if(j == 1)
                {
                    SetEnemyBulletID();


                    _enemyBulletObject = Instantiate(pools[j].objectPrefab[BulletData.currentEnemyBulletID],
                                             pools[j].objectTransform.position,
                                             pools[j].objectTransform.rotation,
                                             pools[j].objectTransform);
                    _enemyBulletObject.SetActive(false);

                    pools[j].pooledObjects.Enqueue(_enemyBulletObject);
                }
                else
                {
                    _playerSwordObject = Instantiate(pools[j].objectPrefab[0],
                                             pools[j].objectTransform.position,
                                             pools[j].objectTransform.rotation,
                                             pools[j].objectTransform);
                    _playerSwordObject.SetActive(false);

                    pools[j].pooledObjects.Enqueue(_playerSwordObject);
                }
                
            }
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