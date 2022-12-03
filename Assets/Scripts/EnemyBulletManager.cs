using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    [SerializeField] ObjectPool _objectPool;
    public LayerMask layerMask;
    public EnemyData enemyData;
    //[SerializeField] ObjectPool _objectPool;
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            StartCoroutine(Delay());
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
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(DelaySpawn(gameObject.transform, enemyData.enemyBulletSpeed, 1));
    }
}
