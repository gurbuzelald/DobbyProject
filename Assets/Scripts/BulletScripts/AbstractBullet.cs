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
    public virtual void BulletRotation(CinemachineVirtualCamera CurrentCamera, Transform bulletSpawnTransform)
    {
        if (CurrentCamera != null)
        {
            bulletSpawnTransform.transform.eulerAngles = new Vector3(CurrentCamera.transform.eulerAngles.x - 13f, 
                                                                     bulletSpawnTransform.transform.eulerAngles.y, 
                                                                     bulletSpawnTransform.transform.eulerAngles.z);

        }
    }

    // Oyuncu mermisi üretimi
    public virtual void CreatePlayerBullet(Transform bulletSpawn, float bulletSpeed, int objectpoolCount,
        ObjectPool objectPool, float delayCreate, float delayDestroy)
    {
        StartCoroutine(DelayBulletCreate<ObjectPool>(bulletSpawn, bulletSpeed, objectpoolCount, objectPool, delayCreate, delayDestroy));
    }

    // Düşman mermisi üretimi
    public virtual void CreateEnemyBullet(Transform bulletSpawn, float bulletSpeed, int objectpoolCount, EnemyObjectPool objectPool, float delayCreate, float delayDestroy)
    {
        StartCoroutine(DelayBulletCreate<EnemyObjectPool>(bulletSpawn, bulletSpeed, objectpoolCount, objectPool, delayCreate, delayDestroy));
    }

    // Ortak bir coroutine oluşturup hem ObjectPool hem de EnemyObjectPool için kullanıyoruz
    private IEnumerator DelayBulletCreate<T>(Transform bulletSpawn, float bulletSpeed, int objectpoolCount, T objectPool, float delayCreate, float delayDestroy) where T : Component
    {
        // Belirtilen süre kadar bekle
        yield return new WaitForSeconds(delayCreate);

        // ObjectPool ya da EnemyObjectPool içindeki GetPooledObject metodunu çağırıyoruz
        GameObject bulletObject = (objectPool as ObjectPool)?.GetPooledObject(objectpoolCount) ??
                                  (objectPool as EnemyObjectPool)?.GetPooledObject(objectpoolCount);

        if (bulletObject == null) yield break; // Havuzda geçerli bir obje yoksa çık

        // Mermiyi uygun pozisyon ve rotasyonla yerleştir
        bulletObject.transform.position = bulletSpawn.position;
        bulletObject.transform.rotation = bulletSpawn.rotation;

        // Mermiyi hızlandır
        Rigidbody bulletRigidbody = bulletObject.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = bulletSpawn.TransformDirection(Vector3.forward * bulletSpeed);
        }

        // Belirli bir süre sonra mermiyi devre dışı bırak
        StartCoroutine(DelaySpawn(bulletObject, bulletSpawn, delayDestroy));
    }

    // Merminin devre dışı bırakılması
    private IEnumerator DelaySpawn(GameObject bulletObject, Transform bulletSpawn, float delayDestroy)
    {
        // Belirtilen süre kadar bekle
        yield return new WaitForSeconds(delayDestroy);

        // Mermiyi devre dışı bırak
        bulletObject.SetActive(false);
    }
}
