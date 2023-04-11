using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleController : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData;
    private int bulletCoinCount;
    private void Awake()
    {
        bulletCoinCount = 0;
    }
    void Update()
    {
        CreateBulletCoin();
    }
    void CreateBulletCoin()
    {
        Transform currentBulletCoinTransform = gameObject.transform;

        if (bulletCoinCount == 0)
        {
            Debug.Log(_enemyData.bulletCoinActivate);
            GameObject bulletCoin = Instantiate(_enemyData._playerBulletObject,
                                            new Vector3(currentBulletCoinTransform.transform.position.x,
                                                        _enemyData._playerBulletObject.transform.position.y,
                                                        currentBulletCoinTransform.transform.position.z),
                                            Quaternion.identity);

            bulletCoin.transform.eulerAngles = new Vector3(0f, currentBulletCoinTransform.transform.eulerAngles.y + 90f, 90f);
            bulletCoinCount++;

            Destroy(bulletCoin, 5f);
            _enemyData.bulletCoinActivate = false;
        }
        
    }
}
