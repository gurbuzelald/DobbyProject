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

    [SerializeField] private Pool[] pools = null;

    private GameObject _playerBulletObject;
    private GameObject _enemyBulletObject;
    private GameObject _playerSwordObject;

    private GameObject _poolUpdateObject;

    void Start()
    {
        if (playerData)
        {
            SetEnemyBulletID();
        }
        SetWeaponId();
        CreateAndEnqueueObject();
    }
    private void Update()
    {
        if (pools.Length != 0)
        {
            if (pools[0].bulletData != null)
            {
                CreateWeaponBullet();
            }
            if (pools[1].bulletData != null && playerData)
            {
                CreateEnemyBullet();
            }
        }
    }
    void CreateEnemyBullet()
    {
        if (playerData.currentEnemyName == PlayerData.clown)
        {
            BulletData.currentEnemyBulletID = 0;

            CreateAndEnqueueObject();
        }
        else if (playerData.currentEnemyName == PlayerData.monster)
        {
            BulletData.currentEnemyBulletID = 1;

            CreateAndEnqueueObject();
        }
        else if (playerData.currentEnemyName == PlayerData.prisoner)
        {
            BulletData.currentEnemyBulletID = 2;

            CreateAndEnqueueObject();
        }
        else if (playerData.currentEnemyName == PlayerData.pedroso)
        {
            BulletData.currentEnemyBulletID = 3;

            CreateAndEnqueueObject();
        }
        else if (playerData.currentEnemyName == PlayerData.cop)
        {
            BulletData.currentEnemyBulletID = 4;

            CreateAndEnqueueObject();
        }
        /*else if (playerData.currentEnemyName == PlayerData.morak)
        {
            BulletData.currentEnemyBulletID = 5;

            CreateAndEnqueueObject();
        }*/
        else if (playerData.currentEnemyName == PlayerData.ortiz)
        {
            BulletData.currentEnemyBulletID = 6;

            CreateAndEnqueueObject();
        }
        else if (playerData.currentEnemyName == PlayerData.skeleton)
        {
            BulletData.currentEnemyBulletID = 7;

            CreateAndEnqueueObject();
        }
        else if (playerData.currentEnemyName == PlayerData.uriel)
        {
            BulletData.currentEnemyBulletID = 8;

            CreateAndEnqueueObject();
        }
        else if (playerData.currentEnemyName == PlayerData.goblin)
        {
            BulletData.currentEnemyBulletID = 9;

            CreateAndEnqueueObject();
        }
    }
    void CreateWeaponBullet()
    {
        if (pools[0].bulletData.isPistol)
        {
            BulletData.currentWeaponID = 0;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isAxe)
        {
            BulletData.currentWeaponID = 1;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isBulldog)
        {
            BulletData.currentWeaponID = 2;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isCow)
        {
            BulletData.currentWeaponID = 3;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isCrystal)
        {
            BulletData.currentWeaponID = 4;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isDemon)
        {
            BulletData.currentWeaponID = 5;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isIce)
        {
            BulletData.currentWeaponID = 6;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isNegev)
        {
            BulletData.currentWeaponID = 7;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isAk47)
        {
            BulletData.currentWeaponID = 8;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isM4a4)
        {
            BulletData.currentWeaponID = 9;

            CreateAndEnqueueObject();
        }

    }

    void SetWeaponId()
    {
        if (pools != null)
        {
            if (pools[0].bulletData != null)
            {
                switch (pools[0].bulletData.currentWeaponName)
                {
                    case BulletData.pistol:
                        BulletData.currentWeaponID = 0;
                        break;
                    case BulletData.axe:
                        BulletData.currentWeaponID = 1;
                        break;
                    case BulletData.bulldog:
                        BulletData.currentWeaponID = 2;
                        break;
                    case BulletData.cow:
                        BulletData.currentWeaponID = 3;
                        break;
                    case BulletData.crystal:
                        BulletData.currentWeaponID = 4;
                        break;
                    case BulletData.demon:
                        BulletData.currentWeaponID = 5;
                        break;
                    case BulletData.ice:
                        BulletData.currentWeaponID = 6;
                        break;
                    case BulletData.negev:
                        BulletData.currentWeaponID = 7;
                        break;
                    case BulletData.ak47:
                        BulletData.currentWeaponID = 8;
                        break;
                    case BulletData.m4a4:
                        BulletData.currentWeaponID = 9;
                        break;
                    default:
                        BulletData.currentEnemyBulletID = 0;
                        break;
                }
            }
        }
    }

    void SetEnemyBulletID()
    {
        switch (playerData.currentEnemyName)
        {
            case PlayerData.clown:
                BulletData.currentEnemyBulletID = 0;
                break;
            case PlayerData.monster:
                BulletData.currentEnemyBulletID = 1;
                break;
            case PlayerData.prisoner:
                BulletData.currentEnemyBulletID = 2;
                break;
            case PlayerData.pedroso:
                BulletData.currentEnemyBulletID = 3;
                break;
            case PlayerData.cop:
                BulletData.currentEnemyBulletID = 4;
                break;
            case PlayerData.ortiz:
                BulletData.currentEnemyBulletID = 5;
                break;
            case PlayerData.skeleton:
                BulletData.currentEnemyBulletID = 6;
                break;
            case PlayerData.uriel:
                BulletData.currentEnemyBulletID = 7;
                break;
            case PlayerData.goblin:
                BulletData.currentEnemyBulletID = 8;
                break;
            default:
                BulletData.currentEnemyBulletID = 0;
                break;
        }
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