using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyManager : AbstractEnemy<EnemyManager>
{    
    [Header("Health")]
    public GameObject _healthBar;
    private Slider _healthBarSlider;

    [Header("Output Sound")]
    private AudioSource _audioSource;

    [Header("Data")]
    public EnemyData[] enemyListData;
    public EnemyData enemyData;  
    public BulletData[] enemyListBulletData;
    public BulletData bulletData;
    public PlayerData playerData;
    public LevelData levelData;

    public int enemyDataNumber;
    public int enemyBulletDataNumber;

    private Transform _initTransform;
    [SerializeField] GameObject _enemyIcon;

    private EnemySpawner _enemySpawner;
    [SerializeField] GameObject _bulletCoin;

    [SerializeField] TextMeshProUGUI _damageText;
    private Rigidbody enemyRigidbody;
    private EnemyBulletManager enemyBulletManager;
    private GameObject enemySpawnerObject;
    private EnemySpawner enemySpawner;

    [SerializeField] Transform burnParticleTransformObject;

    private PlayerSoundEffect playerSFX;

    private ObjectPool playerObjectPool;
    private EnemyObjectPool enemyObjectPool;



    void Start()
    {
        playerObjectPool = PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>();

        playerSFX = FindAnyObjectByType<PlayerSoundEffect>();

        enemyData = enemyListData[enemyDataNumber];
        bulletData = enemyListBulletData[enemyBulletDataNumber];

        _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
        _healthBarSlider = _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>();

        enemyRigidbody = gameObject.transform.GetComponent<Rigidbody>();

        enemyBulletManager = gameObject.transform.GetChild(0).transform.GetComponent<EnemyBulletManager>();


        if (GameObject.Find("EnemySpawner"))
        {
            enemySpawnerObject = GameObject.Find("EnemySpawner");
            enemySpawner = enemySpawnerObject.GetComponent<EnemySpawner>();
            enemyObjectPool = enemySpawner.enemyObjectPool;
        }

        _damageText.text = "";
        _damageText.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        enemyData.isSpeedZero = false;

        _enemyIcon.GetComponent<MeshRenderer>().enabled = true;
        _initTransform = gameObject.transform;
        DataStatesOnInitial();
        _audioSource = GetComponent<AudioSource>();

        SetBackToWalkingValueForStart();
    }
    void CheckEnemyCollisionDamage()
    {
        switch (enemyData.currentEnemyName)
        {
            case PlayerData.chibi:
                bulletData.currentEnemyCollisionDamage =
                    bulletData.chibiEnemyCollisionDamage;
                break;
            case PlayerData.mino:
                bulletData.currentEnemyCollisionDamage =
                    bulletData.minoEnemyCollisionDamage;
                break;
            case PlayerData.bigMonster:
                bulletData.currentEnemyCollisionDamage =
                    bulletData.bigMonsterEnemyCollisionDamage;
                break;
            case PlayerData.orc:
                bulletData.currentEnemyCollisionDamage =
                    bulletData.orcEnemyCollisionDamage;
                break;
            case PlayerData.beholder:
                bulletData.currentEnemyCollisionDamage =
                   bulletData.beholderEnemyCollisionDamage;
                break;
            case PlayerData.femaleZombie:
                bulletData.currentEnemyCollisionDamage =
                   bulletData.femaleZombieEnemyCollisionDamage;
                break;
            case PlayerData.doctor:
                bulletData.currentEnemyCollisionDamage =
                    bulletData.doctorEnemyCollisionDamage;
                break;
            case PlayerData.giant:
                bulletData.currentEnemyCollisionDamage =
                    bulletData.giantEnemyCollisionDamage;
                break;
            case PlayerData.bone:
                bulletData.currentEnemyCollisionDamage =
                    bulletData.boneEnemyCollisionDamage;
                break;
            case PlayerData.clothyBone:
                bulletData.currentEnemyCollisionDamage =
                    bulletData.clothyBoneEnemyCollisionDamage;
                break;
            case PlayerData.chestMonster:
                bulletData.currentEnemyCollisionDamage =
                    bulletData.chestMonsterEnemyCollisionDamage;
                break;
            case PlayerData.chestMonster2:
                bulletData.currentEnemyCollisionDamage =
                    bulletData.chestMonster2EnemyCollisionDamage;
                break;
            default:
                bulletData.currentEnemyCollisionDamage =
                    bulletData.chibiEnemyCollisionDamage;
                break;
        }

    }

    public void CheckEnemyBulletDamage(ref BulletData bulletData)
    {
        enemyData.currentEnemyName = gameObject.transform.name;

        switch (enemyData.currentEnemyName)
        {
            case PlayerData.chibi:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.chibiEnemyBulletDamage;
                break;
            case PlayerData.mino:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.minoEnemyBulletDamage;
                break;
            case PlayerData.bigMonster:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.bigMonsterEnemyBulletDamage;
                break;
            case PlayerData.orc:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.orcEnemyBulletDamage;
                break;
            case PlayerData.beholder:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.beholderEnemyBulletDamage;
                break;
            case PlayerData.femaleZombie:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.femaleZombieEnemyBulletDamage;
                break;
            case PlayerData.doctor:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.doctorEnemyBulletDamage;
                break;
            case PlayerData.giant:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.giantEnemyBulletDamage;
                break;
            case PlayerData.bone:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.boneEnemyBulletDamage;
                break;
            case PlayerData.clothyBone:
                bulletData.currentEnemyBulletDamage = bulletData.clothyBoneEnemyBulletDamage;
                break;
            case PlayerData.chestMonster:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.chestMonsterEnemyBulletDamage;
                break;
            case PlayerData.chestMonster2:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.chestMonster2EnemyBulletDamage;
                break;
            default:
                PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage = bulletData.chibiEnemyBulletDamage;
                break;
        }
    }


    public void SetCurrentAttacker(ref EnemyData enemyData, ref BulletData bulletData)
    {
        switch (enemyData.currentEnemyName)
        {
            case PlayerData.chibi:
                bulletData.currentEnemyAttackDamage = bulletData.chibiEnemyAttackDamage;
                break;
            case PlayerData.mino:
                bulletData.currentEnemyAttackDamage = bulletData.minoEnemyAttackDamage;
                break;
            case PlayerData.bigMonster:
                bulletData.currentEnemyAttackDamage = bulletData.bigMonsterEnemyAttackDamage;
                break;
            case PlayerData.orc:
                bulletData.currentEnemyAttackDamage = bulletData.orcEnemyAttackDamage;
                break;
            case PlayerData.beholder:
                bulletData.currentEnemyAttackDamage = bulletData.beholderEnemyAttackDamage;
                break;
            case PlayerData.femaleZombie:
                bulletData.currentEnemyAttackDamage = bulletData.femaleZombieEnemyAttackDamage;
                break;
            case PlayerData.doctor:
                bulletData.currentEnemyAttackDamage = bulletData.doctorEnemyAttackDamage;
                break;
            case PlayerData.giant:
                bulletData.currentEnemyAttackDamage = bulletData.giantEnemyAttackDamage;
                break;
            case PlayerData.bone:
                bulletData.currentEnemyAttackDamage = bulletData.boneEnemyAttackDamage;
                break;
            case PlayerData.clothyBone:
                bulletData.currentEnemyAttackDamage = bulletData.clothyBoneEnemyAttackDamage;
                break;
            case PlayerData.chestMonster:
                bulletData.currentEnemyAttackDamage = bulletData.chestMonsterEnemyAttackDamage;
                break;
            case PlayerData.chestMonster2:
                bulletData.currentEnemyAttackDamage = bulletData.chestMonsterEnemyAttackDamage;
                break;
            default:
                bulletData.currentEnemyAttackDamage = bulletData.chibiEnemyAttackDamage;
                break;
        }
    }



    void Update()
    {
        FollowPlayer();
        DontFallDown();
    }

    void DontFallDown()
    {
        if (enemyData)
        {
            if (enemyRigidbody)
            {
                if (transform.position.y <= -0.2460114f)
                {
                    transform.position = new Vector3(transform.position.x,
                                                                 -0.2460114f,
                                                                 transform.position.z);
                    enemyRigidbody.isKinematic = true;
                }
                else if (transform.position.y > -0.2460114f)
                {

                    enemyRigidbody.isKinematic = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (!SceneController.pauseGame)
        {
            enemyBulletManager.RayBullet();
        }
        else
        {
            enemyData.isFiring = false;
            enemyData.isWalking = false;
            bulletData.isFirable = false;
        }
    }

    public void EnemyAttack(ref PlayerData _playerData, ref Slider _topCanvasHealthBarSlider,
                                  ref Slider healthBarSlider, ref GameObject _healthBarObject,
                                  ref Transform _particleTransform)
    {
        if (bulletData.currentEnemyAttackDamage != 0)
        {
            if (_playerData.isDecreaseHealth && _playerData.decreaseCounter == 0 && healthBarSlider.value > 0)
            {
                PlayerManager.GetInstance.DecreaseHealth(ref _playerData, bulletData.currentEnemyAttackDamage,
                    ref _healthBarObject, ref healthBarSlider, ref _topCanvasHealthBarSlider, ref _playerData.damageHealthText);

                //SoundEffect
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetEnemyHit);

                _playerData.decreaseCounter++;
            }
            else if (healthBarSlider.value <= 0 && _playerData.isDecreaseHealth)
            {
                _playerData.isPlayable = false;
                _playerData.isDying = true;
                StartCoroutine(PlayerManager.GetInstance.DelayPlayerDestroy(3f));

                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);

                _playerData.isDecreaseHealth = false;
            }
        }
    }


    void FollowPlayer()
    {
        if (gameObject != null && enemyData && bulletData && enemyBulletManager != null)
        {
            if (playerData.isPlayable && gameObject != null &&
                enemyBulletManager != null && !enemyData.isDying &&
                !SceneController.pauseGame)
            {
                bulletData.isFirable = true;

                if ((Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) >= .6f) &&
                    (Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) < levelData.currentEnemyDetectionDistance))
                {
                    enemyData.isWalking = true;
                    enemyData.isAttacking = false;
                    if (enemySpawner)
                    {
                        if (enemySpawner.targetTransform)
                        {
                            Movement(enemySpawner.targetTransform, _initTransform,
                                     gameObject.transform, enemyData.enemySpeed,
                                     playerData, enemyData);
                        }
                    }
                }
                else if ((Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) <= .6f))
                {
                    enemyData.isAttacking = true;

                    enemyData.isWalking = false;

                    PlayerManager.GetInstance._playerData.isDecreaseHealth = true;

                    EnemyAttack(ref playerData, ref PlayerManager.GetInstance._topCanvasHealthBarSlider,
                                  ref PlayerManager.GetInstance.playerComponents.healthBarSlider, ref PlayerManager.GetInstance._healthBarObject,
                                  ref PlayerManager.GetInstance._particleTransform);
                }
                else
                {
                    enemyData.isWalking = true;
                    enemyData.isAttacking = false;
                }

                if ((Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) > 0.1f) &&
                    (Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) < 10))
                {
                    bulletData.isFirable = true;
                    enemyData.isFiring = true;

                    bulletData.enemyBulletDelayCounter += Time.deltaTime;

                    FiringFalse(bulletData.enemyFireFrequency);
                }
                else
                {
                    enemyData.isFiring = false;
                    bulletData.isFirable = false;
                }
            }
            else if (!playerData.isPlayable)
            {
                bulletData.isFirable = false;
                enemyData.isFiring = false;
                enemyData.isAttacking = false;
                enemyData.isWalking = false;
                enemyData.isDying = false;
            }
        }
    }

    public void FiringFalse(float enemyFireFrequency)
    {
        if (bulletData.enemyBulletDelayCounter >= enemyFireFrequency)
        {
            bulletData.enemyBulletDelayCounter = 0;
            enemyData.isFiring = true;
            bulletData.isFirable = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (enemyData != null || gameObject != null)
        {
            if (collision.collider.CompareTag(SceneController.Tags.Player.ToString()) && enemyData.isTouchable)
            {
                CheckEnemyCollisionDamage();               

                TouchPlayer();

                //PlayerData
               PlayerManager.GetInstance.DecreaseHealth(ref PlayerManager.GetInstance._playerData,
                    bulletData.currentEnemyCollisionDamage,
                    ref PlayerManager.GetInstance._healthBarObject, ref PlayerManager.GetInstance.playerComponents.healthBarSlider,
                    ref PlayerManager.GetInstance._topCanvasHealthBarSlider, ref PlayerManager.GetInstance._playerData.damageHealthText);
            }
            if (collision.collider.CompareTag(SceneController.Tags.FanceWooden.ToString()) && enemyData.isTouchable)
            {
                TouchWall();
            }
            if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()) || 
                collision.collider.CompareTag(SceneController.Tags.Enemy.ToString()) || 
                collision.collider.CompareTag(SceneController.Tags.Ladder.ToString()))
            {//Ground, Ladder, Enemy
                enemyData.isGround = true;
            }
        }        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Bullet.ToString()))
        {
            WeaponBulletPower();
            TriggerBullet(enemyData.bulletDamageValue, other);
        }
        if (other.CompareTag(SceneController.Tags.Sword.ToString()))
        {
            TriggerSword(PlayerManager.GetInstance._bulletData.swordDamageValue, other);
            other.gameObject.SetActive(false);
        }
    }
    void WeaponBulletPower()
    {
        float weaponPower = 0;

        // Determine the weapon power based on the current weapon
        if (PlayerManager.GetInstance._bulletData.currentWeaponName == bulletData.weaponStruct[8].weaponName)
        {
            weaponPower = PlayerManager.GetInstance._bulletData.weaponStruct[8].power;
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == bulletData.weaponStruct[9].weaponName)
        {
            weaponPower = PlayerManager.GetInstance._bulletData.weaponStruct[9].power;
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == bulletData.weaponStruct[2].weaponName)
        {
            weaponPower = PlayerManager.GetInstance._bulletData.weaponStruct[2].power;
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == bulletData.weaponStruct[3].weaponName)
        {
            weaponPower = PlayerManager.GetInstance._bulletData.weaponStruct[3].power;
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == bulletData.weaponStruct[4].weaponName)
        {
            weaponPower = PlayerManager.GetInstance._bulletData.weaponStruct[4].power;
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == bulletData.weaponStruct[5].weaponName)
        {
            weaponPower = PlayerManager.GetInstance._bulletData.weaponStruct[5].power;
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == bulletData.weaponStruct[6].weaponName)
        {
            weaponPower = PlayerManager.GetInstance._bulletData.weaponStruct[6].power;
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == bulletData.weaponStruct[7].weaponName)
        {
            weaponPower = PlayerManager.GetInstance._bulletData.weaponStruct[7].power;
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == bulletData.weaponStruct[1].weaponName)
        {
            weaponPower = PlayerManager.GetInstance._bulletData.weaponStruct[1].power;
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == bulletData.weaponStruct[0].weaponName)
        {
            weaponPower = PlayerManager.GetInstance._bulletData.weaponStruct[0].power;
        }
        else
        {
            // Handle case where no valid weapon is selected
            return;
        }

        // Modify bullet damage based on the enemy type
        string parentName = gameObject.transform.parent.name;
        if (parentName == "bossEnemyTransform")
        {
            enemyData.bulletDamageValue = weaponPower / 4;
        }
        else if (parentName == "chestMonsterTransform")
        {
            enemyData.bulletDamageValue = weaponPower * 3;
        }
        else
        {
            enemyData.bulletDamageValue = weaponPower - enemyData.enemyDurability;
        }
    }

    public IEnumerator ShowDamage(int damageValue, float damageTextGrow, float delayDestroy)
    {

        _damageText.text = "-" + damageValue.ToString();
        yield return new WaitForSeconds(damageTextGrow);

        _damageText.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        yield return new WaitForSeconds(damageTextGrow);

        _damageText.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        yield return new WaitForSeconds(damageTextGrow);

        _damageText.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        yield return new WaitForSeconds(damageTextGrow);

        _damageText.gameObject.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        yield return new WaitForSeconds(damageTextGrow);

        _damageText.gameObject.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(damageTextGrow);
        _damageText.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);


        yield return new WaitForSeconds(delayDestroy);

        _damageText.text = "";
    }

    //Collider and Collision
    public void TouchPlayer()
    {
        if (playerData.objects[3] != null && playerData.objects[3].transform.localScale.x <= 0.0625f)
        {
            PlaySoundEffect(SoundEffectTypes.GiveHit, _audioSource);

            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                StartCoroutine(DelayStopEnemy(0f));
            }
            else
            {
                StartCoroutine(DelayStopEnemy(levelData.currentBackToWalkingValue / 3));
            }
            
        }        
    }
    public void TouchWall()
    {
        if (!enemyData.isActivateMagnet)
        {
            gameObject.transform.Rotate(0f, 180f, 0f);
        }
    }
    
    public void TriggerBullet(float bulletPower, Collider other)
    {
        PlaySoundEffect(SoundEffectTypes.GiveBulletHit, _audioSource);

        BulletOrSwordExplosionParticleWithObjectPool(other, playerData.playerBulletsExplosionObjectPoolCount);

        if (enemySpawner)
        {
            if (enemySpawner.targetTransform)
            {
                gameObject.transform.LookAt(enemySpawner.targetTransform.position);
            }
        }

        if (_healthBar != null && !enemyData.isDying)
        {
            if (_healthBarSlider.value <= 0)
            {
                EnemyData.enemyDeathCount++;

                if (burnParticleTransformObject)
                {
                    BulletOrSwordExplosionParticleWithObjectPool(other, playerData.enemyMidParticleObjectPoolCount);
                }
                         
                //enemyData.currentTopParticle.Play();
                enemyData.isTouchable = false;
                enemyData.isDying = true;
                //enemyData.isWalking = false;
                enemyData.isFiring = false;
                enemyData.isSpeedZero = true;
                if (gameObject.transform.parent.name == "bossEnemyTransform")
                {
                    EnemySpawner.bossIsDead = true;
                }


                if (PlayerManager.GetInstance._bulletData.currentBulletPackAmount - playerData.bulletAmount >= 5)
                {
                    playerData.bulletAmount += 5;
                }
                else
                {
                    playerData.bulletAmount += PlayerManager.GetInstance._bulletData.currentBulletPackAmount - playerData.bulletAmount;
                }

                //_healthBar.SetActive(false);
                //Destroy(_healthBar);
                ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue * 2);
                PlaySoundEffect(SoundEffectTypes.Death, _audioSource);
                StartCoroutine(DelayDestroy(2f));                
            }
            else
            {
                if (_healthBarSlider.value <= 50 &&
                    _healthBarSlider.value > 0)
                {
                    BulletOrSwordExplosionParticleWithObjectPool(other, playerData.enemyMidParticleObjectPoolCount);
                }
                if (_healthBarSlider.value > 50)
                {
                    BulletOrSwordExplosionParticleWithObjectPool(other, playerData.enemyMidParticleObjectPoolCount);
                }
                //enemyData.isWalking = false;
                
                
                if (gameObject.transform.parent.name == "bossEnemyTransform")
                {
                    StartCoroutine(DelayStopEnemy(0f));
                }
                else
                {
                    //enemyData.isSpeedZero = true;
                    //enemyData.isWalking = false;
                    StartCoroutine(DelayStopEnemy(levelData.currentBackToWalkingValue));
                }
               
                PlaySoundEffect(SoundEffectTypes.GetHit, _audioSource);
                PlaySoundEffect(SoundEffectTypes.BulletHit, _audioSource);
                _healthBarSlider.value -= bulletPower;
            }

            _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = _healthBarSlider.value;

            StartCoroutine(ShowDamage((int)bulletPower, 0.1f, 3f));
        }
    }

    public void TriggerSword(float swordPower, Collider other)
    {
        BulletOrSwordExplosionParticleWithObjectPool(other, playerData.playerSwordExplosionObjectPoolCount);


        if (enemySpawner)
        {
            if (enemySpawner.targetTransform)
            {
                gameObject.transform.LookAt(enemySpawner.targetTransform.position);
            }
        }

        if (_healthBar != null && !enemyData.isDying)
        {
            if (_healthBarSlider.value <= 0)
            {
                EnemyData.enemyDeathCount++;

                BulletOrSwordExplosionParticleWithObjectPool(other, playerData.enemyMidParticleObjectPoolCount);
                enemyData.isTouchable = false;
                enemyData.isDying = true;
                //enemyData.isWalking = false;

                enemyData.isFiring = false;

                enemyData.isSpeedZero = true;

                if (gameObject.transform.parent.name == "bossEnemyTransform")
                {
                    StartCoroutine(DelayStopEnemy(0f));
                }
                else
                {
                    StartCoroutine(DelayStopEnemy(levelData.currentBackToWalkingValue));
                }

                //_healthBar.SetActive(false);
                //Destroy(_healthBar);
                ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue * 2);
                PlaySoundEffect(SoundEffectTypes.Death, _audioSource);
                StartCoroutine(DelayDestroy(2f));
            }
            else
            {

                if (_healthBarSlider.value <= 50)
                {
                    BulletOrSwordExplosionParticleWithObjectPool(other, playerData.enemyMidParticleObjectPoolCount);
                }
                else if (_healthBarSlider.value > 50)
                {
                    BulletOrSwordExplosionParticleWithObjectPool(other, playerData.enemyMidParticleObjectPoolCount);
                }

                if (gameObject.transform.parent.name == "bossEnemyTransform")
                {
                    StartCoroutine(DelayStopEnemy(0f));
                }
                else
                {
                    //enemyData.isSpeedZero = true;
                    //enemyData.isWalking = false;
                    StartCoroutine(DelayStopEnemy(levelData.currentBackToWalkingValue));
                }
                PlaySoundEffect(SoundEffectTypes.GetHit, _audioSource);
                PlaySoundEffect(SoundEffectTypes.SwordHit, _audioSource);

                if (gameObject.transform.parent.name == "bossEnemyTransform")
                {
                    _healthBarSlider.value -= swordPower / 3;
                    StartCoroutine(ShowDamage((int)swordPower, 0.1f, 3f));
                }
                else
                {
                    _healthBarSlider.value -= swordPower;
                    StartCoroutine(ShowDamage((int)swordPower, 0.1f, 3f));
                }
            }

            _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = _healthBarSlider.value;
        }
    }

    void SetBackToWalkingValueForStart()
    {
        if (levelData)
        {
            levelData.currentBackToWalkingValue = levelData.backToWalkingDelays[LevelData.currentLevelId];
        }
    }

    void BulletOrSwordExplosionParticleWithObjectPool(Collider other, int objectPoolValue)
    {
        if (playerObjectPool)
        {
            if (objectPoolValue == playerData.playerBulletsExplosionObjectPoolCount)
            {
                GameObject particleObject = null;
                if (particleObject == null)
                {
                    particleObject = playerObjectPool.GetPooledObject(playerData.playerBulletsExplosionObjectPoolCount);
                    particleObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                                                                       other.gameObject.transform.position.y + .08f,
                                                                       other.gameObject.transform.position.z);
                }                

                StartCoroutine(DelaySetActiveFalseBulletOrSword(particleObject));
            }
            else if (objectPoolValue == playerData.playerSwordExplosionObjectPoolCount)
            {
                GameObject particleObject = null;
                if (particleObject == null)
                {
                    particleObject = playerObjectPool.GetPooledObject(playerData.playerSwordExplosionObjectPoolCount);
                    particleObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                                                                       other.gameObject.transform.position.y + .08f,
                                                                       other.gameObject.transform.position.z);
                }

                StartCoroutine(DelaySetActiveFalseBulletOrSword(particleObject));
            }
            
        }
        if (enemyObjectPool)
        {
            if (objectPoolValue == playerData.enemyMidParticleObjectPoolCount)
            {
                GameObject particleObject = null;
                if (particleObject == null)
                {
                    particleObject = enemyObjectPool.GetPooledObject(playerData.enemyMidParticleObjectPoolCount);
                    particleObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                                                                       other.gameObject.transform.position.y + .08f,
                                                                       other.gameObject.transform.position.z);
                }

                StartCoroutine(DelaySetActiveFalseBulletOrSword(particleObject));
            }
        }
    }

    IEnumerator DelaySetActiveFalseBulletOrSword(GameObject particleObject)
    {
        yield return new WaitForSeconds(1f);
        particleObject.SetActive(false);
    }

    public IEnumerator DelayStopEnemy(float backToWalkingValue)
    {
        yield return new WaitForSeconds(backToWalkingValue);
        
        enemyData.isWalking = true;
        enemyData.isSpeedZero = false;

    }
    public IEnumerator DelayDestroy(float delayDestroy)
    {
        //CreateDestroyParticle();
        
        yield return new WaitForSeconds(delayDestroy);

        //Destroy(gameObject);
        gameObject.SetActive(false);

        //playerData.getCurrentEnemyDead = true;

        //enemyData.isWalking = true;
        enemyData.isDying = false;
    }

    //SFX States
    public void PlaySoundEffect(SoundEffectTypes soundEffect, AudioSource audioSource)
    {
        if (soundEffect == SoundEffectTypes.GetHit)
        {
            //audioSource.PlayOneShot(enemyData.getHitClip);
        }
        else if (soundEffect == SoundEffectTypes.GiveHit)
        {
            audioSource.PlayOneShot(enemyData.giveHitClip);
        }
        else if (soundEffect == SoundEffectTypes.Death)
        {
            audioSource.PlayOneShot(enemyData.dyingClip);
        }
        else if (soundEffect == SoundEffectTypes.BulletHit)
        {
            audioSource.PlayOneShot(playerSFX.weaponAudioData.currentBulletHitClip);
        }
        else if (soundEffect == SoundEffectTypes.SwordHit)
        {
            audioSource.PlayOneShot(playerSFX.swordAudioData.currentSwordHitClip);
        }
        else if (soundEffect == SoundEffectTypes.GiveBulletHit)
        {
            audioSource.PlayOneShot(enemyData.giveBulletHitClip);
        }
    }
    public enum SoundEffectTypes
    {
        GetHit,
        GiveHit,
        Death,
        BulletHit,
        SwordHit,
        GiveBulletHit
    }

    private void DataStatesOnInitial()
    {
        if (enemyData != null)
        {
            enemyData.isTouchable = true;
        }
    }
}
