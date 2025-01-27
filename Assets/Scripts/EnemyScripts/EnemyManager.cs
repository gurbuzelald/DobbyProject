using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;

public class EnemyManager : AbstractEnemy<EnemyManager>
{    
    [Header("Health")]
    public GameObject _healthBar;
    private Slider _healthBarSlider;

    [Header("Output Sound")]
    private AudioSource _audioSource;

    [Header("Data")]
    public MainEnemyData mainEnemyData;
    public EnemyData enemyData;  
    public EnemyBulletData bulletData;
    public PlayerData playerData;
    public LevelData levelData;

    public int enemyChildID;
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
    private Collider isSword;

    private Collider objectCollider;
    private Rigidbody objectRigidbody;


    private void Awake()
    {
        SetEnemyDataStateLength();

        MainEnemyData.tempDeathCount = 0;
    }
    void Start()
    {
        objectCollider = GetComponent<Collider>();
        objectRigidbody = GetComponent<Rigidbody>();

        objectRigidbody.isKinematic = false;
        objectCollider.enabled = true;

        //enemyData.enemyStats[GetEnemyIndex()].currentEnemyName = gameObject.transform.name;
        if (GameObject.Find("ObjectPool"))
        {
            playerObjectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        }

        if (GameObject.Find("PlayerSFXPrefab(Clone)"))
        {
            playerSFX = GameObject.Find("PlayerSFXPrefab(Clone)").GetComponent<PlayerSoundEffect>();
        }

       
        
        _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
        _healthBarSlider = _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>();

        enemyRigidbody = gameObject.transform.GetComponent<Rigidbody>();

        enemyBulletManager = gameObject.transform.GetChild(0).transform.GetComponent<EnemyBulletManager>();

        for (int i = 0; i < gameObject.transform.parent.childCount; i++)
        {
            if (gameObject.transform.parent.GetChild(i).gameObject == gameObject)
            {
                enemyChildID = i;
            }
        }

        if (GameObject.Find("EnemySpawner"))
        {
            enemySpawnerObject = GameObject.Find("EnemySpawner");
            enemySpawner = enemySpawnerObject.GetComponent<EnemySpawner>();
            enemyObjectPool = enemySpawner.enemyObjectPool;
        }

        _damageText.text = "";
        _damageText.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        enemyData.enemyStats[GetEnemyIndex()].isSpeedZero[enemyChildID] = false;

        _enemyIcon.GetComponent<MeshRenderer>().enabled = true;
        _initTransform = gameObject.transform;
        DataStatesOnInitial();
        _audioSource = GetComponent<AudioSource>();

        SetBackToWalkingValueForStart();
    }

    private void OnEnable()
    {
        SetEnemyDataStateLength();
    }

    public void SetEnemyDataStateLength()
    {
        enemyData.enemyStats[GetEnemyIndex()].isGround = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].enemyDying = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isWalking = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isFiring = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isAttacking = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isTouchable = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isActivateMagnet = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isSpeedZero = new bool[gameObject.transform.parent.childCount];

        enemyData.enemyStats[mainEnemyData.enemyID].bulletDamageValue = new float[gameObject.transform.parent.childCount];
    }

    // Static dictionary to map enemy names to their indices in `enemyAttackInfos`
    private static readonly Dictionary<string, int> enemyIndexMap = new Dictionary<string, int>
    {
        { PlayerData.chibi, 0 },
        { PlayerData.mino, 1 },
        { PlayerData.bigMonster, 2 },
        { PlayerData.orc, 3 },
        { PlayerData.beholder, 4 },
        { PlayerData.femaleZombie, 5 },
        { PlayerData.doctor, 6 },
        { PlayerData.giant, 7 },
        { PlayerData.bone, 8 },
        { PlayerData.clothyBone, 9 },
        { PlayerData.chestMonster, 10 },
        { PlayerData.chestMonster2, 11 },
        { PlayerData.tazo, 12 }
    };

    void SetCurrentEnemyHitDamage()
    {
        int enemyIndex = GetEnemyIndex();
        bulletData.currentEnemyHitDamage = PlayerManager.GetInstance._enemyBulletData.enemyAttackInfos[enemyIndex].hitDamage;
    }

    public void SetCurrentEnemyBulletDamage(ref EnemyBulletData bulletData)
    {
        int enemyIndex = GetEnemyIndex();
        bulletData.currentEnemyBulletDamage = PlayerManager.GetInstance._enemyBulletData.enemyAttackInfos[enemyIndex].bulletDamage;
    }

    public void SetEnemyAttackDamage(ref EnemyBulletData bulletData)
    {
        int enemyIndex = GetEnemyIndex();
        bulletData.currentEnemyAttackDamage = PlayerManager.GetInstance._enemyBulletData.enemyAttackInfos[enemyIndex].attackDamage;
    }

    // Helper function to get the enemy index, defaults to 0 if not found
    public int GetEnemyIndex()
    {
        return mainEnemyData.enemyID;
    }


    void Update()
    {
        FollowPlayer();
        DontFallDown();

        HandleEnemyDeath(isSword);
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
                                                                 1f,
                                                                 transform.position.z);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (!SceneController.pauseGame)
        {
            if (enemyBulletManager)
            {
                enemyBulletManager.RayBullet();
            }            
        }
        else
        {
            enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyChildID] = false;
            enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyChildID] = false;
            bulletData.isFirable = false;
        }
    }

    public void EnemyAttack(ref PlayerData _playerData, ref Slider _topCanvasHealthBarSlider,
                         ref Slider healthBarSlider, ref GameObject _healthBarObject,
                         ref Transform _particleTransform)
    {
        // Exit early if no damage is dealt
        if (bulletData.currentEnemyAttackDamage == 0 && !enemyData.enemyStats[GetEnemyIndex()].enemyDying[enemyChildID]) return;

        if (PlayerData.decreaseCounter == 0 && healthBarSlider.value > 0)
        {
            // Calculate damage multiplier for bosses
            int damageMultiplier = gameObject.transform.parent.name == "bossEnemyTransform" ? 2 : 1;
            int appliedDamage = bulletData.currentEnemyAttackDamage * damageMultiplier;

            // Decrease health
            PlayerManager.GetInstance.DecreaseHealth(ref _playerData, appliedDamage,
                ref _healthBarObject, ref healthBarSlider, ref _topCanvasHealthBarSlider, ref PlayerData.damageHealthText);

            // Play hit sound
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetEnemyHit);

            // Increment counter to prevent multiple decreases
            PlayerData.decreaseCounter++;
        }
    }



    void FollowPlayer()
    {
        if (enemyData == null || bulletData == null || enemyBulletManager == null) return;
        if (!PlayerManager.GetInstance) return;

        if (!PlayerData.isPlayable || enemyData.enemyStats[GetEnemyIndex()].enemyDying[enemyChildID] || SceneController.pauseGame)
        {
            // Reset states when player is not playable or enemy is dying/paused
            ResetEnemyState();
            return;
        }

        // Calculate the distance to the player once
        float distanceToPlayer = Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position);

        // Handle movement or attack based on distance
        if (distanceToPlayer >= 0.6f && distanceToPlayer < levelData.currentEnemyDetectionDistance)
        {
            // Enemy moves towards the player
            enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyChildID] = true;
            enemyData.enemyStats[GetEnemyIndex()].isAttacking[enemyChildID] = false;
            bulletData.isFirable = true;

            if (enemySpawner?.targetTransform != null)
            {
                Movement(enemySpawner.targetTransform, _initTransform, gameObject.transform,
                         enemyData.enemyStats[GetEnemyIndex()].enemySpeed,
                         playerData, enemyData);
            }
        }
        else if (distanceToPlayer < 1)
        {
            // Enemy attacks the player
            enemyData.enemyStats[GetEnemyIndex()].isAttacking[enemyChildID] = true;
            enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyChildID] = false;
            PlayerData.isDecreaseHealth = true;

            EnemyAttack(ref playerData, ref PlayerManager.GetInstance._topCanvasHealthBarSlider,
                        ref PlayerManager.GetInstance.playerComponents.healthBarSlider, ref PlayerManager.GetInstance._healthBarObject,
                        ref PlayerManager.GetInstance._particleTransform);
        }
        else
        {
            // Enemy is idle or beyond detection range
            enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyChildID] = true;
            enemyData.enemyStats[GetEnemyIndex()].isAttacking[enemyChildID] = false;
        }

        // Handle firing based on distance
        if (distanceToPlayer > 0.1f && distanceToPlayer < 10f)
        {
            bulletData.isFirable = true;
            enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyChildID] = true;

            bulletData.enemyBulletDelayCounter += Time.deltaTime;
            FiringFalse(bulletData.enemyFireFrequency);
        }
        else
        {
            enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyChildID] = false;
            bulletData.isFirable = false;
        }
    }

    // Helper function to reset enemy state when player is unplayable or paused
    void ResetEnemyState()
    {
        bulletData.isFirable = false;
        enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyChildID] = false;
        enemyData.enemyStats[GetEnemyIndex()].isAttacking[enemyChildID] = false;
        enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyChildID] = false;
    }


    public void FiringFalse(float enemyFireFrequency)
    {
        if (bulletData.enemyBulletDelayCounter >= enemyFireFrequency)
        {
            enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyChildID] = true;
            bulletData.isFirable = true;

            bulletData.enemyBulletDelayCounter = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (enemyData != null || gameObject != null)
        {
            if (collision.collider.CompareTag(SceneController.Tags.Player.ToString()) &&
                enemyData.enemyStats[GetEnemyIndex()].isTouchable[enemyChildID])
            {
                SetCurrentEnemyHitDamage();               

                TouchPlayer();

                //PlayerData
                if (gameObject.transform.parent.name == "bossEnemyTransform")
                {
                    PlayerManager.GetInstance.DecreaseHealth(ref PlayerManager.GetInstance._playerData,
                    bulletData.currentEnemyHitDamage*2,
                    ref PlayerManager.GetInstance._healthBarObject, ref PlayerManager.GetInstance.playerComponents.healthBarSlider,
                    ref PlayerManager.GetInstance._topCanvasHealthBarSlider, ref PlayerData.damageHealthText);
                }
                else
                {
                    PlayerManager.GetInstance.DecreaseHealth(ref PlayerManager.GetInstance._playerData,
                    bulletData.currentEnemyHitDamage,
                    ref PlayerManager.GetInstance._healthBarObject, ref PlayerManager.GetInstance.playerComponents.healthBarSlider,
                    ref PlayerManager.GetInstance._topCanvasHealthBarSlider, ref PlayerData.damageHealthText);
                }
                
            }
            if (collision.collider.CompareTag(SceneController.Tags.FanceWooden.ToString()) &&
                enemyData.enemyStats[GetEnemyIndex()].isTouchable[enemyChildID])
            {
                TouchWall();
            }
            if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()) || 
                collision.collider.CompareTag(SceneController.Tags.Enemy.ToString()) || 
                collision.collider.CompareTag(SceneController.Tags.Ladder.ToString()))
            {//Ground, Ladder, Enemy
                enemyData.enemyStats[GetEnemyIndex()].isGround[enemyChildID] = true;
            }
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Bullet.ToString()))
        {
            WeaponBulletPower();
            TriggerBullet(enemyData.enemyStats[GetEnemyIndex()].bulletDamageValue[enemyChildID], other);
        }
        if (other.CompareTag(SceneController.Tags.Sword.ToString()))
        {
            other.gameObject.SetActive(false);
            TriggerSword(PlayerManager.GetInstance._playerData.characterStruct[PlayerData.currentCharacterID].swordDamageValue, other);
        }
    }
    void WeaponBulletPower()
    {
        float weaponPower = 0;
        int currentWeaponID = BulletData.currentWeaponID;

        // weaponStruct dizisinde currentWeaponName ile eşleşen silahı bul.
        BulletData.WeaponStruct selectedWeapon = PlayerManager.GetInstance._bulletData.weaponStruct
            .FirstOrDefault(weapon => weapon.id == currentWeaponID);

        // Eğer mevcut silah yoksa fonksiyondan çık.
        if (selectedWeapon.weaponObject == null)
        {
            return;
        }

        // Silah gücünü belirle.
        weaponPower = selectedWeapon.power;


        // Modify bullet damage based on the enemy type
        string parentName = gameObject.transform.parent.name;
        if (parentName == "bossEnemyTransform")
        {
            enemyData.enemyStats[GetEnemyIndex()].bulletDamageValue[enemyChildID] = weaponPower / 4;
        }
        else if (parentName == "chestMonsterTransform" || parentName == "tazoTransform")
        {
            enemyData.enemyStats[GetEnemyIndex()].bulletDamageValue[enemyChildID] = weaponPower * 3;
        }
        else
        {
            enemyData.enemyStats[GetEnemyIndex()].bulletDamageValue[enemyChildID] =
                                weaponPower - enemyData.enemyStats[GetEnemyIndex()].enemyDurability;
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
                DelayStopEnemy();
            }
            else
            {
                Invoke("DelayStopEnemy", levelData.currentBackToWalkingValue / 3);
            }
            
        }        
    }
    public void TouchWall()
    {
        if (!enemyData.enemyStats[GetEnemyIndex()].isActivateMagnet[enemyChildID])
        {
            gameObject.transform.Rotate(0f, 180f, 0f);
        }
    }

    public void TriggerBullet(float bulletPower, Collider other)
    {
        TriggerHit(bulletPower, other, playerData.playerBulletsExplosionObjectPoolCount, SoundEffectTypes.BulletHit, false);       
    }

    public void TriggerSword(float swordPower, Collider other)
    {
        TriggerHit(swordPower, other, playerData.playerSwordExplosionObjectPoolCount, SoundEffectTypes.SwordHit, true);
    }

    // Shared method for handling bullet and sword hit logic
    private void TriggerHit(float power, Collider other, int explosionPoolCount, SoundEffectTypes hitSound, bool isSword)
    {
        // Play sound effect for bullet or sword hit
        PlaySoundEffect(SoundEffectTypes.GiveBulletHit, _audioSource);
        BulletOrSwordExplosionParticleWithObjectPool(other, explosionPoolCount);

        // Face the enemy towards the target
        if (enemySpawner?.targetTransform != null)
        {
            gameObject.transform.LookAt(enemySpawner.targetTransform.position);
        }

        // Handle enemy death if health is zero
        HandleEnemyDeath(other, isSword);

        // Handle enemy hit and update health
        HandleEnemyHit(power, other, isSword, hitSound);

        // Update health bar slider value
        _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = _healthBarSlider.value;
    }
    

    // Handles the enemy's death logic
    void HandleEnemyDeath(Collider other = null, bool isSword = true)
    {
        if (_healthBar == null || enemyData.enemyStats[GetEnemyIndex()].enemyDying[enemyChildID] || !_healthBarSlider) return;

        
        if (_healthBarSlider.value == 0)
        {

            objectRigidbody.isKinematic = true;
            objectCollider.enabled = false;

            PlaySoundEffect(SoundEffectTypes.Death, _audioSource);

            ActivateSwordButton();

            if (other)
            {    
                if (burnParticleTransformObject || isSword)
                {
                    BulletOrSwordExplosionParticleWithObjectPool(other, playerData.enemyMidParticleObjectPoolID);
                }
            }
            EnemyDeathParticle();

            enemyData.enemyStats[GetEnemyIndex()].isTouchable[enemyChildID] = false;
            enemyData.enemyStats[GetEnemyIndex()].enemyDying[enemyChildID] = true;
            enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyChildID] = false;
            enemyData.enemyStats[GetEnemyIndex()].isSpeedZero[enemyChildID] = true;


            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                EnemySpawner.bossIsDead = true;
                DelayStopEnemy();
            }
            else
            {
                Invoke("DelayStopEnemy", levelData.currentBackToWalkingValue);
            }

            // Update player's bullet count for bullets only
            if (!isSword)
            {
                int bulletDiff = BulletData.currentBulletPackAmount - PlayerData.bulletAmount;
                PlayerData.bulletAmount += Mathf.Min(5, bulletDiff);
            }

            // Update score
            ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue * 2);
            return;
        }
    }
    void ActivateSwordButton()
    {
        if (MainEnemyData.tempDeathCount % 3 == 0 && MainEnemyData.tempDeathCount != 0)
        {
            JoystickCanvasManager.isSwordable = true;
            MainEnemyData.tempDeathCount = 0;
        }
        else if (!JoystickCanvasManager.isSwordable)
        {
            MainEnemyData.tempDeathCount++;
        }
    }

    // Handles the enemy hit reaction
    private void HandleEnemyHit(float power, Collider other, bool isSword, SoundEffectTypes hitSound)
    {
        if (_healthBarSlider.value > 0)
        {
            BulletOrSwordExplosionParticleWithObjectPool(other, playerData.enemyMidParticleObjectPoolID);
        }

        // Stop enemy temporarily based on whether it's a boss
        float delay = gameObject.transform.parent.name == "bossEnemyTransform" ? 0f : levelData.currentBackToWalkingValue;
        Invoke("DelayStopEnemy", delay);

        // Play hit sound effects
        PlaySoundEffect(SoundEffectTypes.GetHit, _audioSource);
        PlaySoundEffect(hitSound, _audioSource);

        // Apply damage, adjust for sword or bullet, boss takes reduced damage from swords
        if (Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) > 3)
        {
            if (isSword && gameObject.transform.parent.name == "bossEnemyTransform")
            {
                _healthBarSlider.value -= power / 6;
                StartCoroutine(ShowDamage((int)power / 6, 0.1f, 3f));
            }
            else
            {
                _healthBarSlider.value -= power / 2;
                StartCoroutine(ShowDamage((int)power / 2, 0.1f, 3f));
            }
        }
        else if (Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) > 2)
        {
            if (isSword && gameObject.transform.parent.name == "bossEnemyTransform")
            {
                _healthBarSlider.value -= power / 4;
                StartCoroutine(ShowDamage((int)power / 4, 0.1f, 3f));
            }
            else
            {
                _healthBarSlider.value -= power / 1.5f;
                StartCoroutine(ShowDamage((int)(power / 1.5f), 0.1f, 3f));
            }
        }
        else
        {
            
            if (isSword && gameObject.transform.parent.name == "bossEnemyTransform")
            {
                _healthBarSlider.value -= power / 3;
                StartCoroutine(ShowDamage((int)power / 3, 0.1f, 3f));
            }
            else
            {
                _healthBarSlider.value -= power;
                StartCoroutine(ShowDamage((int)power, 0.1f, 3f));
            }
        }
        
    }


    void SetBackToWalkingValueForStart()
    {
        if (levelData)
        {
            levelData.currentBackToWalkingValue = levelData.levelStates[levelData.currentLevelId].backToWalkingDelay;
        }
    }

    void BulletOrSwordExplosionParticleWithObjectPool(Collider other, int objectPoolValue)
    {
        if (enemyData.enemyStats[GetEnemyIndex()].enemyDying[enemyChildID])
        {
            HandleObjectPooling(other, objectPoolValue, true);
        }
        else
        {
            HandleObjectPooling(other, objectPoolValue, false);
        }
    }

    void HandleObjectPooling(Collider other, int objectPoolValue, bool isDying)
    {
        GameObject particleObject = null;

        if (playerObjectPool)
        {
            particleObject = GetPooledObjectFromPlayer(objectPoolValue, other);
            if (particleObject != null)
            {
                StartCoroutine(DelaySetActiveFalseBulletOrSword(particleObject, .5f));
            }
        }

        if (enemyObjectPool)
        {
            particleObject = GetPooledObjectFromEnemy(objectPoolValue, other);
            if (particleObject != null)
            {
                StartCoroutine(DelaySetActiveFalseBulletOrSword(particleObject, .5f));
            }
        }
    }

    GameObject GetPooledObjectFromPlayer(int objectPoolValue, Collider other)
    {
        GameObject particleObject = null;

        if (objectPoolValue == playerData.playerBulletsExplosionObjectPoolCount)
        {
            particleObject = playerObjectPool.GetPooledObject(playerData.playerBulletsExplosionObjectPoolCount);
            SetParticlePosition(particleObject, other, 0);
        }
        else if (objectPoolValue == playerData.playerSwordExplosionObjectPoolCount)
        {
            particleObject = playerObjectPool.GetPooledObject(playerData.playerSwordExplosionObjectPoolCount);
            SetParticlePosition(particleObject, other, 0f);
        }

        return particleObject;
    }

    GameObject GetPooledObjectFromEnemy(int objectPoolValue, Collider other)
    {
        GameObject particleObject = null;

        if (objectPoolValue == playerData.enemyMidParticleObjectPoolID)
        {
            particleObject = enemyObjectPool.GetPooledObject(playerData.enemyMidParticleObjectPoolID);
            SetParticlePosition(particleObject, other, 0);
        }

        return particleObject;
    }

    void SetParticlePosition(GameObject particleObject, Collider other, float zOffset)
    {
        if (particleObject != null)
        {
            particleObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                                                            other.gameObject.transform.position.y + 0.08f,
                                                            other.gameObject.transform.position.z + zOffset);
        }
    }

    void EnemyDeathParticle()
    {
        GameObject particleObject = null;
        particleObject = playerObjectPool.GetPooledObject(playerData.enemyDeathParticleOjectPoolID);
        particleObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                            gameObject.transform.position.y + .5f,
                                                            gameObject.transform.position.z);
        StartCoroutine(DelaySetActiveFalseBulletOrSword(particleObject, 2));
    }


    IEnumerator DelaySetActiveFalseBulletOrSword(GameObject particleObject, float  delayValue)
    {
        yield return new WaitForSeconds(delayValue);
        if (particleObject)
        {
            particleObject.SetActive(false);
        }
    }

    public void DelayStopEnemy()
    {
        enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyChildID] = true;
    }

    //SFX States
    public void PlaySoundEffect(SoundEffectTypes soundEffect, AudioSource audioSource)
    {
        if (audioSource)
        {
            if (playerSFX)
            {
                if (soundEffect == SoundEffectTypes.GetHit)
                {
                    //audioSource.PlayOneShot(enemyData.getHitClip);
                }
                else if (soundEffect == SoundEffectTypes.GiveHit)
                {
                    audioSource.PlayOneShot(mainEnemyData.giveHitClip);
                }
                else if (soundEffect == SoundEffectTypes.Death)
                {
                    audioSource.PlayOneShot(mainEnemyData.dyingClip);
                }
                else if (soundEffect == SoundEffectTypes.BulletHit)
                {
                    audioSource.PlayOneShot(playerSFX.characterAudioData.currentBulletHitClip);
                }
                else if (soundEffect == SoundEffectTypes.SwordHit)
                {
                    audioSource.PlayOneShot(playerSFX.characterAudioData.currentSwordHitClip);
                }
                else if (soundEffect == SoundEffectTypes.GiveBulletHit)
                {
                    audioSource.PlayOneShot(mainEnemyData.giveBulletHitClip);
                }
            }            
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
            enemyData.enemyStats[GetEnemyIndex()].isTouchable[enemyChildID] = true;
        }
    }
}
