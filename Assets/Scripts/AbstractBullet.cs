using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBullet<T> : MonoBehaviour where T : MonoBehaviour
{
    public abstract void BulletRotation();

    public virtual IEnumerator DelaySpawn(Transform bulletSpawn, float bulletSpeed, int objectpoolCount, ObjectPool objectPool)
    {
        GameObject bulletObject = objectPool.GetComponent<ObjectPool>().GetPooledObject(objectpoolCount);
        bulletObject.transform.position = gameObject.transform.position;
        bulletObject.transform.rotation = bulletSpawn.rotation;

        bulletObject.GetComponent<Rigidbody>().velocity = (bulletSpawn.TransformDirection(Vector3.forward * bulletSpeed));

        yield return new WaitForSeconds(2f);
        bulletObject.transform.rotation = bulletSpawn.rotation;

        bulletObject.SetActive(false);
    }
}
