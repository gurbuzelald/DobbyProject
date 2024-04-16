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

    [SerializeField] private Pool[] pools = null;

    void Awake()
    {        
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
        }
    }
    void DeleteWeaponBulletObjects()
    {
        
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
            BulletData.currentWeaponID = 3;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isCow)
        {
            BulletData.currentWeaponID = 4;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isCrystal)
        {
            BulletData.currentWeaponID = 5;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isDemon)
        {
            BulletData.currentWeaponID = 6;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isIce)
        {
            BulletData.currentWeaponID = 7;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isNegev)
        {
            BulletData.currentWeaponID = 8;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isAk47)
        {
            BulletData.currentWeaponID = 9;

            CreateAndEnqueueObject();
        }
        else if (pools[0].bulletData.isM4a4)
        {
            BulletData.currentWeaponID = 10;

            CreateAndEnqueueObject();
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