using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    [SerializeField] ObjectPool _objectPool;
    public LayerMask layerMask;
    public EnemyData enemyData;
    private int counter = 0;
    //[SerializeField] ObjectPool _objectPool;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (counter == 0)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                counter++;
                enemyData.isFiring = true;
                enemyData.isWalking = false;
                StartCoroutine(DelaySpawn(gameObject.transform, enemyData.enemyBulletSpeed, 1));
            }
        }        
        if (enemyData.isFiring)
        {
            StartCoroutine(DelayFiring());
        }
    }

    public IEnumerator DelaySpawn(Transform bulletSpawn, float bulletSpeed, int objectpoolCount)
    {
        GameObject bulletObject = _objectPool.GetPooledObject(objectpoolCount);
        bulletObject.transform.position = gameObject.transform.position;
        bulletObject.transform.rotation = bulletSpawn.rotation;

        bulletObject.GetComponent<Rigidbody>().velocity = (bulletSpawn.TransformDirection(Vector3.forward * bulletSpeed));

        yield return new WaitForSeconds(2f);
        bulletObject.transform.rotation = bulletSpawn.rotation;

        bulletObject.SetActive(false);
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(DelaySpawn(gameObject.transform, enemyData.enemyBulletSpeed, 1));
    }
    IEnumerator DelayFiring()
    {
        yield return new WaitForSeconds(2f);
        if (counter >= 1)
        {
            counter = 0;
            enemyData.isFiring = false;
            enemyData.isWalking = true;
        }        
    }

}
