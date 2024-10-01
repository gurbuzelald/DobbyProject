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

    [Header("Initial Situations")]
    private float _initSpeed;    

    private Transform _initTransform;
    [SerializeField] GameObject _enemyIcon;

    private EnemySpawner clownSpawner;
    [SerializeField] GameObject _bulletCoin;

    [SerializeField] TextMeshProUGUI _damageText;
    private Rigidbody enemyRigidbody;
    private EnemyBulletManager enemyBulletManager;
    private GameObject enemySpawnerObject;
    private EnemySpawner enemySpawner;

    [SerializeField] Transform burnParticleTransformObject;

    /*private ParticleSystem bottomParticleSystem;
    private ParticleSystem middleParticleSystem;
    private ParticleSystem topParticleSystem;*/

    private PlayerSoundEffect playerSFX;

    private ObjectPool objectPool;


    void Start()
    {
        objectPool = PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>();

        playerSFX = FindAnyObjectByType<PlayerSoundEffect>();

        enemyData = enemyListData[enemyDataNumber];
        bulletData = enemyListBulletData[enemyBulletDataNumber];

        enemyData.isWalkable = true;
        _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
        _healthBarSlider = _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>();

        enemyRigidbody = gameObject.transform.GetComponent<Rigidbody>();

        enemyBulletManager = gameObject.transform.GetChild(0).transform.GetComponent<EnemyBulletManager>();

        enemySpawnerObject = GameObject.Find("EnemySpawner");
        enemySpawner = enemySpawnerObject.GetComponent<EnemySpawner>();

        _damageText.text = "";
        _damageText.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        enemyData.isSpeedZero = false;

        clownSpawner = FindObjectOfType<EnemySpawner>();
        _enemyIcon.GetComponent<MeshRenderer>().enabled = true;
        _initTransform = gameObject.transform;
        DataStatesOnInitial();
        _audioSource = GetComponent<AudioSource>();

        SetPlayerWeaponExplosionParticle();

        SetBackToWalkingValueForStart();
    }
    void Update()
    {
        WeaponBulletPower(); 

        if (!enemyData.isDying && 
            (Vector3.Distance(gameObject.transform.position,
            PlayerManager.GetInstance.gameObject.transform.position) <= levelData.enemyDetectionDistances[LevelData.currentLevelCount])
            && !enemyData.isSpeedZero)
        {
            enemyData.isWalking = true;
            enemyData.isWalkable = true;
        }

        CheckGroundEnemy();
        
        FollowPlayer();

        if (levelData.isLevelUp && LevelData.levelCanBeSkipped)
        {
            enemyData = enemyListData[enemyDataNumber];
            bulletData = enemyListBulletData[enemyBulletDataNumber];
        }
        if (levelData)
        {
            SetCurrentBackToWalkingValue();
        }
        if (PlayerManager.GetInstance._bulletData != null && enemyData != null)
        {
            SetPlayerWeaponExplosionParticle();
        }

        if (playerData.enemyBulletHitActivate)
        {
            PlaySoundEffect(SoundEffectTypes.GiveBulletHit, _audioSource);

            playerData.enemyBulletHitActivate = false;
        }
    }


    void CheckGroundEnemy()
    {
        if (!enemyData.isGround && enemyRigidbody)
        {
            enemyRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
        if (enemyData.isGround && enemyRigidbody)
        {
            enemyRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
    void SetPlayerWeaponExplosionParticle()
    {
        if (PlayerData.currentBulletExplosionIsChanged)
        {         
            PlayerData.currentBulletExplosionIsChanged = false;
        }
        if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.pistol)
        {
            playerData.currentBulletExplosionParticle = playerData.weaponBulletExplosionParticles[0];
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.axe)
        {
            playerData.currentBulletExplosionParticle = playerData.weaponBulletExplosionParticles[1];
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.bulldog)
        {
            playerData.currentBulletExplosionParticle = playerData.weaponBulletExplosionParticles[2];
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.cow)
        {
            playerData.currentBulletExplosionParticle = playerData.weaponBulletExplosionParticles[3];
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.crystal)
        {
            playerData.currentBulletExplosionParticle = playerData.weaponBulletExplosionParticles[4];
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.demon)
        {
            playerData.currentBulletExplosionParticle = playerData.weaponBulletExplosionParticles[5];
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.ice)
        {
            playerData.currentBulletExplosionParticle = playerData.weaponBulletExplosionParticles[6];
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.electro)
        {
            playerData.currentBulletExplosionParticle = playerData.weaponBulletExplosionParticles[7];
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.ak47)
        {
            playerData.currentBulletExplosionParticle = playerData.weaponBulletExplosionParticles[8];
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.m4a4)
        {
            playerData.currentBulletExplosionParticle = playerData.weaponBulletExplosionParticles[9];
        }
        else
        {
            playerData.currentBulletExplosionParticle = playerData.weaponBulletExplosionParticles[0];
        }
    }

    void FollowPlayer()
    {
        if (gameObject != null && enemyData && bulletData)
        {
            if (playerData.isPlayable && gameObject != null && enemyBulletManager != null)
            {
                bulletData.isFirable = true;

                if ((Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) > 0.1f) &&
                    (Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) < levelData.currentEnemyDetectionDistance) &&
                    enemyData.isWalkable && !enemyData.isDying && !enemyData.isSpeedZero)
                {
                    enemyData.enemySpeed = _initSpeed;
                    enemyData.isWalking = true;
                    enemyData.isAttacking = false;
                    enemyData.isFiring = false;
                    enemyData.isDying = false;

                    Movement(clownSpawner.targetTransform, _initTransform, gameObject.transform, enemyData.enemySpeed, playerData, enemyData);
                }
                else if ((Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) <= 0.1f) && !enemyData.isDying &&
                          playerData.isPlayable)
                {
                    enemyData.isAttacking = true;

                    playerData.isDecreaseHealth = true;

                    enemyData.currentEnemyName = gameObject.name;

                    enemyData.isWalking = false;
                    enemyData.isDying = false;
                    enemyData.isFiring = false;
                    
                    //When Enemy touched player, enemy will get a animation to here.
                }
                else if ((Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) > 0.1f) &&
                    (Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) < 30f) &&
                    !enemyData.isDying && !playerData.isDying && !SceneController.pauseGame)
                {
                    enemyData.isFiring = true;
                    enemyData.isAttacking = false;
                    enemyData.isDying = false;
                    //enemyData.isWalking = false;

                }
                else
                {
                    enemyData.isAttacking = false;
                    enemyData.isWalking = false;
                    enemyData.isFiring = false;
                }
            }
            else if (!playerData.isPlayable || gameObject != null || enemyBulletManager != null)
            {
                bulletData.isFirable = false;
                enemyData.isFiring = false;
                enemyData.isAttacking = false;
                enemyData.isWalking = false;
                enemyData.isDying = false;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (enemyData != null || gameObject != null)
        {
            if (collision.collider.CompareTag(SceneController.Tags.Player.ToString()) && enemyData.isTouchable)
            {
                TouchPlayer();
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
        if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.ak47)
        {
            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.ak47Power / 4;
            }
            else if (gameObject.transform.name == PlayerData.laygo)
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.ak47Power / 2;
            }
            else
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.ak47Power - enemyData.enemyDurability;
            }
            
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.m4a4)
        {
            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.m4a4Power / 4;
            }
            else if (gameObject.transform.name == PlayerData.laygo)
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.m4a4Power / 2;
            }
            else
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.m4a4Power - enemyData.enemyDurability;
            }
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.bulldog)
        {
            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.bulldogPower / 4;
            }
            else if (gameObject.transform.name == PlayerData.laygo)
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.bulldogPower / 2;
            }
            else
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.bulldogPower - enemyData.enemyDurability;
            }
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.cow)
        {
            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.cowPower / 4;
            }
            else if (gameObject.transform.name == PlayerData.laygo)
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.cowPower / 2;
            }
            else
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.cowPower - enemyData.enemyDurability;
            }
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.crystal)
        {
            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.crystalPower / 4;
            }
            else if (gameObject.transform.name == PlayerData.laygo)
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.crystalPower / 2;
            }
            else
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.crystalPower - enemyData.enemyDurability;
            }
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.demon)
        {
            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.demonPower / 4;
            }
            else if (gameObject.transform.name == PlayerData.laygo)
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.demonPower / 2;
            }
            else
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.demonPower - enemyData.enemyDurability;
            }
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.ice)
        {
            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.icePower / 4;
            }
            else if (gameObject.transform.name == PlayerData.laygo)
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.icePower / 2;
            }
            else
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.icePower - enemyData.enemyDurability;
            }
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.electro)
        {
            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.electroPower / 4;
            }
            else if (gameObject.transform.name == PlayerData.laygo)
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.electroPower / 2;
            }
            else
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.electroPower - enemyData.enemyDurability;
            }
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.axe)
        {
            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.axePower / 4;
            }
            else if (gameObject.transform.name == PlayerData.laygo)
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.axePower / 2;
            }
            else
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.axePower - enemyData.enemyDurability;
            }
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.pistol)
        {
            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.pistolPower / 4;
            }
            else if (gameObject.transform.name == PlayerData.laygo)
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.pistolPower / 2;
            }
            else
            {
                enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.pistolPower - enemyData.enemyDurability;
            }
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
                enemyData.isWalking = false;
                //enemyData.isSpeedZero = true;

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
        BulletOrSwordExplosionParticleWithObjectPool(other, 8);

        gameObject.transform.LookAt(clownSpawner.targetTransform.position);

        if (_healthBar != null)
        {
            if (_healthBarSlider.value <= 0)
            {
                EnemyData.enemyDeathCount++;

                if (burnParticleTransformObject)
                {
                    BulletOrSwordExplosionParticleWithObjectPool(other, 10);
                    BulletOrSwordExplosionParticleWithObjectPool(other, 11);
                }
                         
                //enemyData.currentTopParticle.Play();
                enemyData.isTouchable = false;
                enemyData.isDying = true;
                //enemyData.isWalking = false;
                enemyData.isFiring = false;
                enemyData.isSpeedZero = true;


                if (PlayerManager.GetInstance._bulletData.currentBulletPack - playerData.bulletAmount >= 5)
                {
                    playerData.bulletAmount += 5;
                }
                else
                {
                    playerData.bulletAmount += PlayerManager.GetInstance._bulletData.currentBulletPack - playerData.bulletAmount;
                }
                

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
                    BulletOrSwordExplosionParticleWithObjectPool(other, 10);
                    BulletOrSwordExplosionParticleWithObjectPool(other, 11);
                    BulletOrSwordExplosionParticleWithObjectPool(other, 12);
                }
                if (_healthBarSlider.value > 50)
                {
                    BulletOrSwordExplosionParticleWithObjectPool(other, 11);
                }
                //enemyData.isWalking = false;
                
                
                if (gameObject.transform.parent.name == "bossEnemyTransform")
                {
                    StartCoroutine(DelayStopEnemy(0f));
                }
                else
                {
                    //enemyData.isSpeedZero = true;
                    enemyData.isWalking = false;
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
        BulletOrSwordExplosionParticleWithObjectPool(other, 9);

        gameObject.transform.LookAt(clownSpawner.targetTransform.position);

        if (_healthBar != null)
        {
            if (_healthBarSlider.value <= 0)
            {
                EnemyData.enemyDeathCount++;

                BulletOrSwordExplosionParticleWithObjectPool(other, 10);
                BulletOrSwordExplosionParticleWithObjectPool(other, 11);
                BulletOrSwordExplosionParticleWithObjectPool(other, 12);
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


                Destroy(_healthBar);
                ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue * 2);
                PlaySoundEffect(SoundEffectTypes.Death, _audioSource);
                StartCoroutine(DelayDestroy(2f));
            }
            else
            {

                if (_healthBarSlider.value <= 50)
                {
                    BulletOrSwordExplosionParticleWithObjectPool(other, 10);
                    BulletOrSwordExplosionParticleWithObjectPool(other, 11);
                }
                else if (_healthBarSlider.value > 50)
                {
                    BulletOrSwordExplosionParticleWithObjectPool(other, 11);
                }

                if (gameObject.transform.parent.name == "bossEnemyTransform")
                {
                    StartCoroutine(DelayStopEnemy(0f));
                }
                else
                {
                    //enemyData.isSpeedZero = true;
                    enemyData.isWalking = false;
                    StartCoroutine(DelayStopEnemy(levelData.currentBackToWalkingValue));
                }
                PlaySoundEffect(SoundEffectTypes.GetHit, _audioSource);
                PlaySoundEffect(SoundEffectTypes.SwordHit, _audioSource);

                if (gameObject.transform.parent.name == "bossEnemyTransform")
                {
                    _healthBarSlider.value -= swordPower / 3;
                }
                else
                {
                    _healthBarSlider.value -= swordPower;
                }
            }

            _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = _healthBarSlider.value;

            StartCoroutine(ShowDamage((int)swordPower, 0.1f, 3f));
        }
    }

    void SetBackToWalkingValueForStart()
    {
        if (levelData)
        {
            levelData.currentBackToWalkingValue = levelData.backToWalkingDelays[LevelData.currentLevelCount];
        }
    }
    void SetCurrentBackToWalkingValue()
    {
        if (levelData)
        {
            if (levelData.isLevelUp && LevelData.levelCanBeSkipped)
            {
                levelData.currentBackToWalkingValue = levelData.backToWalkingDelays[LevelData.currentLevelCount];
            }
        }        
    }

    void BulletOrSwordExplosionParticleWithObjectPool(Collider other, int objectPoolValue)
    {
        if (objectPool)
        {
            if (objectPoolValue == 8)
            {
                GameObject particleObject = null;
                particleObject = objectPool.GetPooledObject(8);
                particleObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                                                                   other.gameObject.transform.position.y + .08f,
                                                                   other.gameObject.transform.position.z);

                StartCoroutine(DelaySetActiveFalseBulletOrSword(particleObject));
            }
            else if (objectPoolValue == 9)
            {
                GameObject particleObject = null;
                particleObject = objectPool.GetPooledObject(9);
                particleObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                                                                   other.gameObject.transform.position.y + .08f,
                                                                   other.gameObject.transform.position.z);

                StartCoroutine(DelaySetActiveFalseBulletOrSword(particleObject));
            }
            else if (objectPoolValue == 10)
            {
                GameObject particleObject = null;
                particleObject = objectPool.GetPooledObject(10);
                particleObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                                                                   other.gameObject.transform.position.y + .08f,
                                                                   other.gameObject.transform.position.z);

                StartCoroutine(DelaySetActiveFalseBulletOrSword(particleObject));
            }
            else if (objectPoolValue == 11)
            {
                GameObject particleObject = null;
                particleObject = objectPool.GetPooledObject(11);
                particleObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                                                                   other.gameObject.transform.position.y + .08f,
                                                                   other.gameObject.transform.position.z);

                StartCoroutine(DelaySetActiveFalseBulletOrSword(particleObject));
            }
            else if (objectPoolValue == 12)
            {
                GameObject particleObject = null;
                particleObject = objectPool.GetPooledObject(12);
                particleObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                                                                   other.gameObject.transform.position.y + .08f,
                                                                   other.gameObject.transform.position.z);

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
    void CreateDestroyParticle() {
        Transform currentBulletCoinTransform = gameObject.transform;
        
        GameObject particleObject = PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(5);
        particleObject.transform.position = new Vector3(currentBulletCoinTransform.transform.position.x,
                                                        currentBulletCoinTransform.transform.position.y + .5f,
                                                        currentBulletCoinTransform.transform.position.z);

        StartCoroutine(DelaySetActiveFalseParticle(particleObject));
    }
    IEnumerator DelaySetActiveFalseParticle(GameObject particleObject)
    {
        yield return new WaitForSeconds(2f);
        particleObject.SetActive(false);
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
            //enemyData.isActivateMagnet = false;
            enemyData.isGround = true;
            _initSpeed = enemyData.enemySpeed;
        }
    }
}
