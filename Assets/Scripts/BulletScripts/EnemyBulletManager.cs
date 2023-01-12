using System.Collections;
using UnityEngine;

public class EnemyBulletManager : AbstractBullet<EnemyBulletManager>
{
    [SerializeField] ObjectPool _objectPool;
    public LayerMask layerMask;
    public EnemyData enemyData;
    public BulletData bulletData;

    
    //[SerializeField] ObjectPool _objectPool;
    // Update is called once per frame
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
        if (bulletData.enemyBulletDelayCounter == 0 && enemyData.isActivateMagnet)
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
        CreateBullet(gameObject.transform, bulletData.enemyBulletSpeed, 1, _objectPool);
    }
    IEnumerator FiringFalse()
    {
        yield return new WaitForSeconds(2f);
        if (bulletData.enemyBulletDelayCounter >= 1)
        {
            bulletData.enemyBulletDelayCounter = 0;
            enemyData.isFiring = false;
            enemyData.isWalking = true;
        }        
    }

}
