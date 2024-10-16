using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EnemyBulletManager : AbstractBullet<EnemyBulletManager>
{
    private EnemySpawner _enemySpawner;
    private PlayerData playerData;

    private Transform _bulletSpawnTransform;

    private EnemyManager _enemyManager;
    private GameObject enemySpawnerObject;
    private EnemySpawner enemySpawner;
    RaycastHit hit;
   
    private void OnEnable()
    {
        enemySpawnerObject = GameObject.Find("EnemySpawner");
        enemySpawner = enemySpawnerObject.GetComponent<EnemySpawner>();

        _bulletSpawnTransform = gameObject.transform.GetChild(0);

        _enemyManager = gameObject.transform.parent.GetComponent<EnemyManager>();

        _enemyManager.bulletData.enemyBulletDelayCounter = 0;
        _enemyManager.bulletData.isFirable = true;

        if (FindObjectOfType<EnemySpawner>())
        {
            _enemySpawner = FindObjectOfType<EnemySpawner>();
        }
    }

    private void Start()
    {
        playerData = PlayerManager.GetInstance._playerData;        
    }
    public void RayBullet()
    {
        if (!_enemyManager.enemyData.isDying && _enemyManager.bulletData.isFirable && _enemyManager.enemyData.isFiring &&
            !playerData.isDying && _enemyManager.bulletData.enemyBulletDelayCounter == 0 && enemySpawner != null &&
            Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit,
                            50, enemySpawner.layerMask))
        {
            _enemyManager.enemyData.isFiring = false;
            _enemyManager.bulletData.isFirable = false;
            //_enemyManager.enemyData.isWalking = false;
            if (gameObject.transform.parent.parent.name == "bossEnemyTransform")
            {
                CreateEnemyBullet(_bulletSpawnTransform.transform,
                         _enemyManager.bulletData.enemyBulletSpeed,
                         playerData.enemyBulletParticleObjectPoolCount, _enemySpawner.enemyObjectPool, 0f, 1f);
            }
            else
            {
                CreateEnemyBullet(_bulletSpawnTransform.transform,
                         _enemyManager.bulletData.enemyBulletSpeed,
                         playerData.enemyBulletParticleObjectPoolCount, _enemySpawner.enemyObjectPool, 0f, 5);
            }

            _enemyManager.CheckEnemyBulletDamage(ref _enemyManager.bulletData);

            PlayerManager.GetInstance.enemyBulletData = _enemyManager.bulletData;
        }        
    }
}
