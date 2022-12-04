using System.Collections;
using UnityEngine;

public class EnemyBulletManager : AbstractBullet<EnemyBulletManager>
{
    [SerializeField] ObjectPool _objectPool;
    public LayerMask layerMask;
    public EnemyData enemyData;
    private int counter = 0;
    //[SerializeField] ObjectPool _objectPool;
    // Update is called once per frame
    void Update()
    {
        RayBullet();
    }
    void RayBullet()
    {
        RaycastHit hit;
        if (counter == 0)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                counter++;
                enemyData.isFiring = true;
                enemyData.isWalking = false;
                CreateBullet(gameObject.transform, enemyData.enemyBulletSpeed, 1, _objectPool);
                StartCoroutine(FiringFalse());
            }
        }
    }
    IEnumerator FiringFalse()
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
