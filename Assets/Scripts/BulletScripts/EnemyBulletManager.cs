using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBulletManager : AbstractBullet<EnemyBulletManager>
{
    public EnemyData enemyData;
    public BulletData bulletData;
    private EnemySpawner _clownSpawner;

    [SerializeField] Transform _bulletSpawnTransform;

    private void Awake()
    {
        bulletData.enemyBulletDelayCounter = 0;
        bulletData.isFirable = true;
        _clownSpawner = FindObjectOfType<EnemySpawner>();
    }
    void FixedUpdate()
    {
        RayBullet(bulletData.enemyFireFrequency);
    }
    void RayBullet(float enemyFireFrequency)
    {
        if (!enemyData.isDying && bulletData.enemyBulletDelayCounter < 1 && bulletData.enemyBulletDelayCounter >= 0 && enemyData.isActivateMagnet && bulletData.isFirable)
        {
            GameObject enemySpawner = GameObject.Find("EnemySpawner");

            RaycastHit hit;
            if (enemySpawner != null) 
            {
                if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, enemySpawner.GetComponent<EnemySpawner>().layerMask))
                {
                    Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                    bulletData.enemyBulletDelayCounter += 0.5f;
                    enemyData.isFiring = true;
                    enemyData.isWalking = false;
                    StartCoroutine(Delay(bulletData.enemyBulletDelay, 2f));
                    StartCoroutine(FiringFalse(enemyFireFrequency));
                }
                else
                {
                    Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                }
            }            
        }        
    }
    public IEnumerator Delay(float delayValue, float delayDestroy)
    {
        yield return new WaitForSeconds(delayValue);
        CreateBullet(_bulletSpawnTransform.transform, bulletData.enemyBulletSpeed, 1, _clownSpawner._objectPool, 0f, delayDestroy);
    }
    public IEnumerator FiringFalse(float enemyFireFrequency)
    {
        if (!bulletData.isFirable)
        {
            enemyData.isFiring = false;
        }
        yield return new WaitForSeconds(enemyFireFrequency);
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
