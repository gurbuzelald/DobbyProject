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

    [SerializeField] PlayerData playerData;

    [SerializeField] Pool[] pools = null;

    private GameObject _playerBulletObject;
    private GameObject _enemyBulletObject;
    private GameObject _playerSwordObject;

    private GameObject _poolUpdateObject;

    void Start()
    {
        CreateAndEnqueueObject();
    }
    private void Update()
    {
        if (pools.Length != 0)
        {
            if (pools[0].bulletData != null)
            {
                CreateWeaponBulletAtUpdate(0);
            }
            if (pools[1].bulletData != null && playerData)
            {
                CreateEnemyBulletAtUpdate();
            }
        }
    }
    
    void CreateWeaponBulletAtUpdate(int objectPoolLine)
    {
        if (pools[0].bulletData != null)
        {
            int weaponId = GetPlayerWeaponId(pools[objectPoolLine].bulletData);
            if (weaponId != -1)
            {
                BulletData.currentWeaponID = weaponId;
                CreateAndEnqueueObject();
            }
        }
    }
    void CreateEnemyBulletAtUpdate()
    {
        if (pools[1].bulletData != null)
        {
            int bulletID = GetEnemyWeaponId(playerData);
            if (bulletID != -1)
            {
                BulletData.currentEnemyBulletID = bulletID;
                CreateAndEnqueueObject();
            }
        }
    }

    private int GetEnemyWeaponId(PlayerData playerData)
    {
        if (playerData.currentEnemyName == PlayerData.clown) return 0;
        if (playerData.currentEnemyName == PlayerData.monster) return 1;
        if (playerData.currentEnemyName == PlayerData.prisoner) return 2;
        if (playerData.currentEnemyName == PlayerData.pedroso) return 3;
        if (playerData.currentEnemyName == PlayerData.cop) return 4;
        if (playerData.currentEnemyName == PlayerData.ortiz) return 5;
        if (playerData.currentEnemyName == PlayerData.skeleton) return 6;
        if (playerData.currentEnemyName == PlayerData.uriel) return 7;
        if (playerData.currentEnemyName == PlayerData.goblin) return 8;
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
                    _playerBulletObject= Instantiate(pools[j].objectPrefab[BulletData.currentWeaponID],
                                             pools[j].objectTransform.position,
                                             pools[j].objectTransform.rotation,
                                             pools[j].objectTransform);
                    _playerBulletObject.SetActive(false);

                    pools[j].pooledObjects.Enqueue(_playerBulletObject);
                }
                else if(j == 1)
                {
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