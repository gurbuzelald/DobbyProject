using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBulletManager : AbstractBullet<EnemyBulletManager>
{
    private EnemyData enemyData;
    private BulletData bulletData;
    private EnemySpawner _enemySpawner;
    private PlayerData playerData;

    [SerializeField] Transform _bulletSpawnTransform;

    private EnemyManager _enemyManager;

    private void Awake()
    {
        _enemyManager = gameObject.transform.parent.GetComponent<EnemyManager>();

        enemyData = _enemyManager.enemyData;
        bulletData = _enemyManager.bulletData;

        bulletData.enemyBulletDelayCounter = 0;
        bulletData.isFirable = true;
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    public virtual void CheckEnemyBulletDamage(ref PlayerData _playerData)
    {
        _playerData.currentEnemyName = gameObject.transform.parent.name;

        if (_playerData.currentEnemyName == PlayerData.clown)
        {
            _playerData.currentEnemyBulletDamage = _playerData.clownEnemyBulletDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.monster)
        {
            _playerData.currentEnemyBulletDamage = _playerData.monsterEnemyBulletDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.prisoner)
        {
            _playerData.currentEnemyBulletDamage = _playerData.prisonerEnemyBulletDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.pedroso)
        {
            _playerData.currentEnemyBulletDamage = _playerData.pedrosoEnemyBulletDamage;
        }
        /*else if (_playerData.currentEnemyName == PlayerData.morak)
        {
            _playerData.currentEnemyBulletDamage = _playerData.morakEnemyBulletDamage;
        }*/
        else if (_playerData.currentEnemyName == PlayerData.ortiz)
        {
            _playerData.currentEnemyBulletDamage = _playerData.ortizEnemyBulletDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.skeleton)
        {
            _playerData.currentEnemyBulletDamage = _playerData.skeletonEnemyBulletDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.uriel)
        {
            _playerData.currentEnemyBulletDamage = _playerData.urielEnemyBulletDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.goblin)
        {
            _playerData.currentEnemyBulletDamage = _playerData.goblinEnemyBulletDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.cop)
        {
            _playerData.currentEnemyBulletDamage = _playerData.copEnemyBulletDamage;
        }
    }
    private void Start()
    {
        playerData = GameObject.Find("Player").GetComponent<PlayerManager>()._playerData;
    }
    void FixedUpdate()
    {
        RayBullet(bulletData.enemyFireFrequency);
    }
    void RayBullet(float enemyFireFrequency)
    {
        if (!enemyData.isDying && bulletData.isFirable &&
            !playerData.isDying && bulletData.enemyBulletDelayCounter == 0)
        {
            GameObject enemySpawner = GameObject.Find("EnemySpawner");

            RaycastHit hit;
            if (enemySpawner != null) 
            {
                if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit, 50, enemySpawner.GetComponent<EnemySpawner>().layerMask))
                {
                    CheckEnemyBulletDamage(ref playerData);
                    //Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                    bulletData.enemyBulletDelayCounter += 1f;
                    enemyData.isFiring = true;
                    enemyData.isWalking = false;
                    StartCoroutine(Delay(bulletData.enemyBulletDelay, 2f));
                    StartCoroutine(FiringFalse(enemyFireFrequency));
                    return;
                }
                else
                {
                    //Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                }
            }            
        }        
    }
    public IEnumerator Delay(float delayValue, float delayDestroy)
    {
        yield return new WaitForSeconds(delayValue);
        CreateBullet(_bulletSpawnTransform.transform, bulletData.enemyBulletSpeed, 1, _enemySpawner._objectPool, 0f, delayDestroy);
    }
    public IEnumerator FiringFalse(float enemyFireFrequency)
    {
        if (!bulletData.isFirable)
        {
            enemyData.isFiring = false;
        }
        yield return new WaitForSeconds(enemyFireFrequency);
        
        if (bulletData.enemyBulletDelayCounter >= 1 && !enemyData.isSpeedZero)
        {
            //Debug.Log(bulletData.enemyBulletDelayCounter);
            bulletData.enemyBulletDelayCounter = 0;
            enemyData.isFiring = false;
            enemyData.isWalking = true;
            //bulletData.isFirable = false;
        }        
    }

}
