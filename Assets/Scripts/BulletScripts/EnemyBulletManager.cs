using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EnemyBulletManager : AbstractBullet<EnemyBulletManager>
{
    private EnemySpawner _enemySpawner;
    private PlayerData playerData;

    [SerializeField] Transform _bulletSpawnTransform;

    private EnemyManager _enemyManager;

    private void Awake()
    {
        _enemyManager = gameObject.transform.parent.GetComponent<EnemyManager>();

        _enemyManager.bulletData.enemyBulletDelayCounter = 0;
        _enemyManager.bulletData.isFirable = true;
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    public virtual void CheckEnemyBulletDamage(ref BulletData bulletData)
    {
        _enemyManager.enemyData.currentEnemyName = gameObject.transform.parent.name;

        switch (_enemyManager.enemyData.currentEnemyName) {

            case PlayerData.clown:
                bulletData.currentEnemyBulletDamage = bulletData.clownEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.clownEnemyAttackDamage;
                break;
            case PlayerData.monster:
                bulletData.currentEnemyBulletDamage = bulletData.monsterEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.monsterEnemyAttackDamage;
                break;
            case PlayerData.prisoner:
                bulletData.currentEnemyBulletDamage = bulletData.prisonerEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.prisonerEnemyAttackDamage;
                break;
            case PlayerData.pedroso:
                bulletData.currentEnemyBulletDamage = bulletData.pedrosoEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.pedrosoEnemyAttackDamage;
                break;
            case PlayerData.ortiz:
                bulletData.currentEnemyBulletDamage = bulletData.ortizEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.ortizEnemyAttackDamage;
                break;
            case PlayerData.skeleton:
                bulletData.currentEnemyBulletDamage = bulletData.skeletonEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.skeletonEnemyAttackDamage;
                break;
            case PlayerData.uriel:
                bulletData.currentEnemyBulletDamage = bulletData.urielEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.urielEnemyAttackDamage;
                break;
            case PlayerData.goblin:
                bulletData.currentEnemyBulletDamage = bulletData.goblinEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.goblinEnemyAttackDamage;
                break;
            case PlayerData.cop:
                bulletData.currentEnemyBulletDamage = bulletData.copEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.copEnemyAttackDamage;
                break;
            case PlayerData.laygo:
                bulletData.currentEnemyBulletDamage = bulletData.laygoEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.laygoEnemyAttackDamage;
                break;
            default:
                bulletData.currentEnemyBulletDamage = bulletData.clownEnemyBulletDamage;
                bulletData.currentEnemyAttackDamage = bulletData.clownEnemyAttackDamage;
                break;
        }
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
        GetAttackFromEnemy(ref playerData, ref PlayerManager.GetInstance._topCanvasHealthBarSlider,
                           ref PlayerManager.GetInstance.playerObjects.healthBarSlider,
                            ref PlayerManager.GetInstance._healthBarObject,
                            ref PlayerManager.GetInstance._particleTransform);
    }

    public void GetAttackFromEnemy(ref PlayerData _playerData, ref Slider _topCanvasHealthBarSlider,
                                   ref Slider healthBarSlider, ref GameObject _healthBarObject,
                                   ref Transform _particleTransform)
    {
        if (_playerData.isDecreaseHealth && _playerData.decreaseCounter == 0 && healthBarSlider.value > 0)
        {
            CheckEnemyAttackDamage(ref _enemyManager.enemyData, ref _enemyManager.bulletData);

            PlayerManager.GetInstance.DecreaseHealth(ref _playerData, _enemyManager.bulletData.currentEnemyAttackDamage, ref _healthBarObject, ref healthBarSlider, ref _topCanvasHealthBarSlider, ref _playerData.damageHealthText);

            //Touch ParticleEffect
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);

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
    public virtual void CheckEnemyAttackDamage(ref EnemyData enemyData, ref BulletData bulletData)
    {
        switch (enemyData.currentEnemyName)
        {
            case PlayerData.clown:
                bulletData.currentEnemyAttackDamage = bulletData.clownEnemyAttackDamage;
                break;
            case PlayerData.monster:
                bulletData.currentEnemyBulletDamage = bulletData.monsterEnemyAttackDamage;
                break;
            case PlayerData.prisoner:
                bulletData.currentEnemyBulletDamage = bulletData.prisonerEnemyAttackDamage;
                break;
            case PlayerData.pedroso:
                bulletData.currentEnemyBulletDamage = bulletData.pedrosoEnemyAttackDamage;
                break;
            case PlayerData.ortiz:
                bulletData.currentEnemyBulletDamage = bulletData.ortizEnemyAttackDamage;
                break;
            case PlayerData.skeleton:
                bulletData.currentEnemyBulletDamage = bulletData.skeletonEnemyAttackDamage;
                break;
            case PlayerData.uriel:
                bulletData.currentEnemyBulletDamage = bulletData.urielEnemyAttackDamage;
                break;
            case PlayerData.goblin:
                bulletData.currentEnemyBulletDamage = bulletData.goblinEnemyAttackDamage;
                break;
            case PlayerData.cop:
                bulletData.currentEnemyBulletDamage = bulletData.copEnemyAttackDamage;
                break;
            case PlayerData.laygo:
                bulletData.currentEnemyBulletDamage = bulletData.laygoEnemyAttackDamage;
                break;
            default:
                bulletData.currentEnemyAttackDamage = bulletData.clownEnemyAttackDamage;
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
                    _enemyManager.enemyData.isWalking = false;
                    StartCoroutine(Delay(_enemyManager.bulletData.enemyBulletDelay, 2f));
                    StartCoroutine(FiringFalse(enemyFireFrequency));

                    PlayerManager.GetInstance.enemyBulletData = _enemyManager.bulletData;
                    
                    return;
                }
            }            
        }        
    }
    public IEnumerator Delay(float delayValue, float delayDestroy)
    {
        yield return new WaitForSeconds(delayValue);
        CreateBullet(_bulletSpawnTransform.transform, _enemyManager.bulletData.enemyBulletSpeed, 1, _enemySpawner._objectPool, 0f, delayDestroy);
    }
    public IEnumerator FiringFalse(float enemyFireFrequency)
    {
        if (!_enemyManager.bulletData.isFirable)
        {
            _enemyManager.enemyData.isFiring = false;
        }
        yield return new WaitForSeconds(enemyFireFrequency);
        
        if (_enemyManager.bulletData.enemyBulletDelayCounter >= 1 && !_enemyManager.enemyData.isSpeedZero)
        {
            _enemyManager.bulletData.enemyBulletDelayCounter = 0;
            _enemyManager.enemyData.isFiring = false;
            _enemyManager.enemyData.isWalking = true;
        }        
    }

}
