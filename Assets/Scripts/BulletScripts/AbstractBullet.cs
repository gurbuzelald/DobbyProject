using System.Collections;
using UnityEngine;
using Cinemachine;


public abstract class AbstractBullet<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                GameObject objectOfGame = new GameObject();
                objectOfGame.name = typeof(T).Name;
                _instance = objectOfGame.AddComponent<T>();
            }
            return _instance;
        }
    }
    public virtual void BulletRotation(bool isLookingUp, CinemachineVirtualCamera CurrentCamera, Transform bulletSpawnTransform)
    {
        if (CurrentCamera != null)
        {
            bulletSpawnTransform.transform.eulerAngles = new Vector3(CurrentCamera.transform.eulerAngles.x - 13f, 
                                                                     bulletSpawnTransform.transform.eulerAngles.y, 
                                                                     bulletSpawnTransform.transform.eulerAngles.z);

        }
    }

    public virtual void CreateBullet(Transform bulletSpawn, float bulletSpeed, int objectpoolCount, ObjectPool objectPool, float delayDestroy)
    {
        //GameObject bulletObject = Instantiate(_bulletObject, _bulletSpawnTransform.transform.position, _bulletSpawnTransform.transform.rotation);
        //bulletObject.GetComponent<Rigidbody>().velocity = (_bulletSpawnTransform.transform.TransformDirection(Vector3.forward * _playerData.bulletSpeed));

        //StartCoroutine(DelayDestroy(bulletObject));
        GameObject bulletObject = objectPool.GetComponent<ObjectPool>().GetPooledObject(objectpoolCount);
        bulletObject.transform.position = gameObject.transform.position;
        bulletObject.transform.rotation = bulletSpawn.rotation;

        bulletObject.GetComponent<Rigidbody>().velocity = (bulletSpawn.TransformDirection(Vector3.forward * bulletSpeed));
        StartCoroutine(DelaySpawn(bulletObject, bulletSpawn, delayDestroy));
    }
    public IEnumerator DelaySpawn(GameObject bulletObject, Transform bulletSpawn, float delayDestroy)
    {
        yield return new WaitForSeconds(delayDestroy);
        bulletObject.transform.rotation = bulletSpawn.rotation;

        bulletObject.SetActive(false);
    }
}
