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
   
    private void Awake()
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
        if (PlayerManager.GetInstance)
        {
            playerData = PlayerManager.GetInstance._playerData;
        }
    }
    public void RayBullet()
    {
        if (_enemyManager.enemyData.enemyStats[_enemyManager.GetEnemyIndex()].enemyDying[_enemyManager.enemyChildID] ||
            enemySpawner == null) return;
        
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward),
                            out hit, 50, enemySpawner.layerMask))
        {
            float bulletSpread = (gameObject.transform.parent.parent.name == "bossEnemyTransform") ? 1f : 1f;

            if (_enemyManager.bulletData.enemyBulletDelayCounter == 0)
            {

                _bulletSpawnTransform.LookAt(PlayerManager.GetInstance.gameObject.transform.position);
                CreateEnemyBullet(_bulletSpawnTransform,
                              _enemyManager.bulletData.enemyBulletSpeed,
                              playerData.enemyBulletParticleObjectPoolID,
                              _enemySpawner.enemyObjectPool,
                              0f, bulletSpread);

                _enemyManager.SetCurrentEnemyBulletDamage(ref _enemyManager.bulletData);
            }
        }
    }

}
