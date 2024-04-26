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
                if (pools[0].bulletData.currentWeaponName == BulletData.pistol)
                {
                    BulletData.currentWeaponID = 0;
                }
                else if (pools[0].bulletData.currentWeaponName == BulletData.axe)
                {
                    BulletData.currentWeaponID = 1;
                }
                else if (pools[0].bulletData.currentWeaponName == BulletData.bulldog)
                {
                    BulletData.currentWeaponID = 2;
                }
                else if (pools[0].bulletData.currentWeaponName == BulletData.cow)
                {
                    BulletData.currentWeaponID = 3;
                }
                else if (pools[0].bulletData.currentWeaponName == BulletData.crystal)
                {
                    BulletData.currentWeaponID = 4;
                }
                else if (pools[0].bulletData.currentWeaponName == BulletData.demon)
                {
                    BulletData.currentWeaponID = 5;
                }
                else if (pools[0].bulletData.currentWeaponName == BulletData.ice)
                {
                    BulletData.currentWeaponID = 6;
                }
                else if (pools[0].bulletData.currentWeaponName == BulletData.negev)
                {
                    BulletData.currentWeaponID = 7;
                }
                else if (pools[0].bulletData.currentWeaponName == BulletData.ak47)
                {
                    BulletData.currentWeaponID = 8;
                }
                else if (pools[0].bulletData.currentWeaponName == BulletData.m4a4)
                {
                    BulletData.currentWeaponID = 9;
                }
            }
        }
    }

    void SetEnemyBulletID()
    {
        if (playerData.currentEnemyName  == PlayerData.clown)
        {
            BulletData.currentEnemyBulletID = 0;
        }
        else if (playerData.currentEnemyName == PlayerData.monster)
        {
            BulletData.currentEnemyBulletID = 1;
        }
        else if (playerData.currentEnemyName == PlayerData.prisoner)
        {
            BulletData.currentEnemyBulletID = 2;
        }
        else if (playerData.currentEnemyName == PlayerData.pedroso)
        {
            BulletData.currentEnemyBulletID = 3;
        }
        else if (playerData.currentEnemyName == PlayerData.cop)
        {
            BulletData.currentEnemyBulletID = 4;
        }
        /*else if (playerData.currentEnemyName == PlayerData.morak)
        {
            BulletData.currentEnemyBulletID = 5;
        }*/
        else if (playerData.currentEnemyName == PlayerData.ortiz)
        {
            BulletData.currentEnemyBulletID = 6;
        }
        else if (playerData.currentEnemyName == PlayerData.skeleton)
        {
            BulletData.currentEnemyBulletID = 7;
        }
        else if (playerData.currentEnemyName == PlayerData.uriel)
        {
            BulletData.currentEnemyBulletID = 8;
        }
        else if (playerData.currentEnemyName == PlayerData.goblin)
        {
            BulletData.currentEnemyBulletID = 9;
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
                    GameObject obj = Instantiate(pools[j].objectPrefab[BulletData.currentWeaponID],
                                             pools[j].objectTransform.position,
                                             pools[j].objectTransform.rotation,
                                             pools[j].objectTransform);
                    obj.SetActive(false);

                    pools[j].pooledObjects.Enqueue(obj);
                }
                else if(j == 1)
                {
                    GameObject obj = Instantiate(pools[j].objectPrefab[BulletData.currentEnemyBulletID],
                                             pools[j].objectTransform.position,
                                             pools[j].objectTransform.rotation,
                                             pools[j].objectTransform);
                    obj.SetActive(false);

                    pools[j].pooledObjects.Enqueue(obj);
                }
                else
                {
                    GameObject obj = Instantiate(pools[j].objectPrefab[0],
                                             pools[j].objectTransform.position,
                                             pools[j].objectTransform.rotation,
                                             pools[j].objectTransform);
                    obj.SetActive(false);

                    pools[j].pooledObjects.Enqueue(obj);
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

        GameObject obj = pools[objectType].pooledObjects.Dequeue();

        obj.SetActive(true);

        pools[objectType].pooledObjects.Enqueue(obj);

        return obj;
    }
}