using System.Collections;
using UnityEngine;

public class EnemyBulletManager : AbstractBullet<EnemyBulletManager>
{
    public EnemyData enemyData;
    public BulletData bulletData;
    private EnemySpawner _clownSpawner;

    [SerializeField] Transform _bulletSpawnTransform;

    private void Awake()
    {
        bulletData.isFirable = true;
        _clownSpawner = FindObjectOfType<EnemySpawner>();
    }
    void FixedUpdate()
    {
        //RayBullet();
    }
    void RayBullet()
    {
        //if (!enemyData.isDying)
        //{
        //    RaycastHit hit;
        //    if (bulletData.enemyBulletDelayCounter == 0 && enemyData.isActivateMagnet && bulletData.isFirable)
        //    {
        //        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        //        {
        //            Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        //            bulletData.enemyBulletDelayCounter++;
        //            enemyData.isFiring = true;
        //            enemyData.isWalking = false;
        //            StartCoroutine(Delay(bulletData.enemyBulletDelay, 2f));
        //            StartCoroutine(FiringFalse());
        //        }
        //        else
        //        {
        //            Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        //        }
        //    }
        //}        
    }
    public IEnumerator Delay(float delayValue, float delayDestroy)
    {
        yield return new WaitForSeconds(delayValue);
        CreateBullet(_bulletSpawnTransform.transform, bulletData.enemyBulletSpeed, 1, _clownSpawner._objectPool, 0f, delayDestroy);
    }
    public IEnumerator FiringFalse()
    {
        if (!bulletData.isFirable)
        {
            enemyData.isFiring = false;
        }
        yield return new WaitForSeconds(5f);
        if (bulletData.enemyBulletDelayCounter >= 1)
        {
            //Debug.Log(bulletData.enemyBulletDelayCounter);
            bulletData.enemyBulletDelayCounter = 0;
            enemyData.isFiring = false;
            enemyData.isWalking = true;
            bulletData.isFirable = false;
        }        
    }

}
