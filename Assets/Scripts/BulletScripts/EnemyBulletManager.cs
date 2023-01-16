using System.Collections;
using UnityEngine;

public class EnemyBulletManager : AbstractBullet<EnemyBulletManager>
{
    public LayerMask layerMask;
    public EnemyData enemyData;
    public BulletData bulletData;
    private ClownSpawner _clownSpawner;
    public static bool isFirable;

    private void Awake()
    {
        isFirable = true;
        _clownSpawner = FindObjectOfType<ClownSpawner>();
    }
    void Update()
    {
        if (!enemyData.isDying)
        {
            RayBullet();
        }
    }
    void RayBullet()
    {
        RaycastHit hit;
        if (bulletData.enemyBulletDelayCounter == 0 && enemyData.isActivateMagnet && isFirable)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                
                bulletData.enemyBulletDelayCounter++;
                enemyData.isFiring = true;
                enemyData.isWalking = false;
                StartCoroutine(Delay(bulletData.enemyBulletDelay));
                StartCoroutine(FiringFalse());
            }
        }
    }
    IEnumerator Delay(float delayValue)
    {
        yield return new WaitForSeconds(delayValue);
        CreateBullet(gameObject.transform, bulletData.enemyBulletSpeed, 1, _clownSpawner._objectPool);
    }
    IEnumerator FiringFalse()
    {
        if (!isFirable)
        {
            enemyData.isFiring = false;
        }
        yield return new WaitForSeconds(4f);
        if (bulletData.enemyBulletDelayCounter >= 1)
        {
            Debug.Log(bulletData.enemyBulletDelayCounter);
            bulletData.enemyBulletDelayCounter = 0;
            enemyData.isFiring = false;
            enemyData.isWalking = true;
        }        
    }

}
