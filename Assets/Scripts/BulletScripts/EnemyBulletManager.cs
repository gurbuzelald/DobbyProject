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

    private void Awake()

    {
        _bulletSpawnTransform = gameObject.transform.GetChild(0);

        _enemyManager = gameObject.transform.parent.GetComponent<EnemyManager>();

        _enemyManager.bulletData.enemyBulletDelayCounter = 0;
        _enemyManager.bulletData.isFirable = true;
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

   
    private void Start()
    {
        playerData = GameObject.Find("Player").GetComponent<PlayerManager>()._playerData;
    }
    void FixedUpdate()
    {
        if (!SceneController.pauseGame)
        {
            RayBullet(_enemyManager.bulletData.enemyFireFrequency);
        }
        else
        {
            _enemyManager.enemyData.isFiring = false;
        }
    }

    private void Update()
    {
        Attack(ref playerData, ref PlayerManager.GetInstance._topCanvasHealthBarSlider,
                           ref PlayerManager.GetInstance.playerObjects.healthBarSlider,
                            ref PlayerManager.GetInstance._healthBarObject,
                            ref PlayerManager.GetInstance._particleTransform);
    }

    public virtual void CheckEnemyBulletDamage(ref BulletData bulletData)
    {
        _enemyManager.enemyData.currentEnemyName = gameObject.transform.parent.name;

        switch (_enemyManager.enemyData.currentEnemyName)
        {

            case PlayerData.chibi:
                bulletData.currentEnemyBulletDamage = bulletData.chibiEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.chibiEnemyAttackDamage;
                break;
            case PlayerData.mino:
                bulletData.currentEnemyBulletDamage = bulletData.minoEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.minoEnemyAttackDamage;
                break;
            case PlayerData.bigMonster:
                bulletData.currentEnemyBulletDamage = bulletData.bigMonsterEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.bigMonsterEnemyAttackDamage;
                break;
            case PlayerData.orc:
                bulletData.currentEnemyBulletDamage = bulletData.orcEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.orcEnemyAttackDamage;
                break;
            case PlayerData.beholder:
                bulletData.currentEnemyBulletDamage = bulletData.beholderEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.beholderEnemyAttackDamage;
                break;
            case PlayerData.femaleZombie:
                bulletData.currentEnemyBulletDamage = bulletData.femaleZombieEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.femaleZombieEnemyAttackDamage;
                break;
            case PlayerData.doctor:
                bulletData.currentEnemyBulletDamage = bulletData.doctorEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.doctorEnemyAttackDamage;
                break;
            case PlayerData.giant:
                bulletData.currentEnemyBulletDamage = bulletData.giantEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.giantEnemyAttackDamage;
                break;
            case PlayerData.bone:
                bulletData.currentEnemyBulletDamage = bulletData.boneEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.boneEnemyAttackDamage;
                break;
            case PlayerData.clothyBone:
                bulletData.currentEnemyBulletDamage = bulletData.clothyBoneEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.clothyBoneEnemyAttackDamage;
                break;
            case PlayerData.chestMonster:
                bulletData.currentEnemyBulletDamage = bulletData.chestMonsterEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.chestMonsterEnemyAttackDamage;
                break;
            case PlayerData.chestMonster2:
                bulletData.currentEnemyBulletDamage = bulletData.chestMonster2EnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.chestMonster2EnemyAttackDamage;
                break;
            default:
                bulletData.currentEnemyBulletDamage = bulletData.chibiEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.chibiEnemyAttackDamage;
                break;
        }
    }

    
    public void Attack(ref PlayerData _playerData, ref Slider _topCanvasHealthBarSlider,
                                   ref Slider healthBarSlider, ref GameObject _healthBarObject,
                                   ref Transform _particleTransform)
    {
        if (_playerData.isDecreaseHealth && _playerData.decreaseCounter == 0 && healthBarSlider.value > 0)
        {
            SetCurrentAttacker(ref _enemyManager.enemyData, ref _enemyManager.bulletData);

            PlayerManager.GetInstance.DecreaseHealth(ref _playerData, _enemyManager.bulletData.currentEnemyAttackDamage, ref _healthBarObject, ref healthBarSlider, ref _topCanvasHealthBarSlider, ref _playerData.damageHealthText);

            //Touch ParticleEffect
            GameObject particleObject = null;

            if (particleObject == null)
            {
                particleObject = PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(14);
                particleObject.transform.position = _particleTransform.transform.position;

                StartCoroutine(PlayerManager.GetInstance.DelaySetActiveFalseParticle(particleObject, 1f));
            }
            

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetEnemyHit);


            _playerData.isDecreaseHealth = false;

            _playerData.decreaseCounter++;
            StartCoroutine(DelayDecreaseCounterZero(_playerData));
        }
        else if (healthBarSlider.value <= 0 && _playerData.isDecreaseHealth)
        {
            _playerData.isPlayable = false;
            _playerData.isDying = true;
            StartCoroutine(PlayerManager.GetInstance.DelayDestroy(7f));

            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);

            _playerData.isDecreaseHealth = false;
        }
    }
    public virtual void SetCurrentAttacker(ref EnemyData enemyData, ref BulletData bulletData)
    {
        switch (enemyData.currentEnemyName)
        {
            case PlayerData.chibi:
                bulletData.currentEnemyAttackDamage = bulletData.chibiEnemyAttackDamage;
                break;
            case PlayerData.mino:
                bulletData.currentEnemyBulletDamage = bulletData.minoEnemyAttackDamage;
                break;
            case PlayerData.bigMonster:
                bulletData.currentEnemyBulletDamage = bulletData.bigMonsterEnemyAttackDamage;
                break;
            case PlayerData.orc:
                bulletData.currentEnemyBulletDamage = bulletData.orcEnemyAttackDamage;
                break;
            case PlayerData.beholder:
                bulletData.currentEnemyBulletDamage = bulletData.beholderEnemyAttackDamage;
                break;
            case PlayerData.femaleZombie:
                bulletData.currentEnemyBulletDamage = bulletData.femaleZombieEnemyAttackDamage;
                break;
            case PlayerData.doctor:
                bulletData.currentEnemyBulletDamage = bulletData.doctorEnemyAttackDamage;
                break;
            case PlayerData.giant:
                bulletData.currentEnemyBulletDamage = bulletData.giantEnemyAttackDamage;
                break;
            case PlayerData.bone:
                bulletData.currentEnemyBulletDamage = bulletData.boneEnemyAttackDamage;
                break;
            case PlayerData.clothyBone:
                bulletData.currentEnemyBulletDamage = bulletData.clothyBoneEnemyAttackDamage;
                break;
            default:
                bulletData.currentEnemyAttackDamage = bulletData.chibiEnemyAttackDamage;
                break;
        }
    }
    IEnumerator DelayDecreaseCounterZero(PlayerData _playerData)
    {
        yield return new WaitForSeconds(1f);
        _playerData.decreaseCounter = 0;
    }
    void RayBullet(float enemyFireFrequency)
    {
        if (!_enemyManager.enemyData.isDying && _enemyManager.bulletData.isFirable &&
            !playerData.isDying && _enemyManager.bulletData.enemyBulletDelayCounter == 0)
        {
            GameObject enemySpawner = GameObject.Find("EnemySpawner");

            RaycastHit hit;
            if (enemySpawner != null) 
            {
                if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), out hit, 50, enemySpawner.GetComponent<EnemySpawner>().layerMask))
                {
                    CheckEnemyBulletDamage(ref _enemyManager.bulletData);
                    _enemyManager.bulletData.enemyBulletDelayCounter += 1f;
                    _enemyManager.enemyData.isFiring = true;
                    //_enemyManager.enemyData.isWalking = false;
                    //StartCoroutine(Delay(_enemyManager.bulletData.enemyBulletDelay, 2f));
                    if (gameObject.transform.parent.parent.name == "bossEnemyTransform")
                    {
                        CreateBullet(_bulletSpawnTransform.transform,
                                 _enemyManager.bulletData.enemyBulletSpeed,
                                 1, _enemySpawner._objectPool, 0f, 1f);
                        StartCoroutine(FiringFalse(enemyFireFrequency/3));
                    }
                    else
                    {
                        CreateBullet(_bulletSpawnTransform.transform,
                                 _enemyManager.bulletData.enemyBulletSpeed,
                                 1, _enemySpawner._objectPool, 0f, 1f);
                        StartCoroutine(FiringFalse(enemyFireFrequency));
                    }
                    


                    PlayerManager.GetInstance.enemyBulletData = _enemyManager.bulletData;
                }
            }            
        }        
    }
    public IEnumerator FiringFalse(float enemyFireFrequency)
    {
        if (!_enemyManager.bulletData.isFirable)
        {
            _enemyManager.enemyData.isFiring = false;
        }
        yield return new WaitForSeconds(enemyFireFrequency);
        
        if (_enemyManager.bulletData.enemyBulletDelayCounter >= 1)
        {
            _enemyManager.bulletData.enemyBulletDelayCounter = 0;
            _enemyManager.enemyData.isFiring = true;
            _enemyManager.bulletData.isFirable = true;
            _enemyManager.enemyData.isWalking = true;            
        }        
    }

}
