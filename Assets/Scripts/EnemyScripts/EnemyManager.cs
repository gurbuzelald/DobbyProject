using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class EnemyManager : AbstractEnemy<EnemyManager>
{    
    [Header("Health")]
    public GameObject _healthBar;
    private Slider _healthBarSlider;

    [Header("Output Sound")]
    private AudioSource _audioSource;

    [Header("Data")]
    public MainEnemyData mainEnemyData;
    public EnemyData[] enemyListData;
    public EnemyData enemyData;  
    public EnemyBulletData bulletData;
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
    private Collider isSword;

    private int enemyID;

    void Start()
    {

        enemyData.enemyStats[GetEnemyIndex()].currentEnemyName = gameObject.transform.name;

        playerObjectPool = PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>();

        playerSFX = FindAnyObjectByType<PlayerSoundEffect>();

        //enemyData = enemyListData[enemyDataNumber];

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

        SetEnemyDataStateLength();

        _damageText.text = "";
        _damageText.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        enemyData.enemyStats[GetEnemyIndex()].isSpeedZero[enemyDataNumber] = false;

        _enemyIcon.GetComponent<MeshRenderer>().enabled = true;
        _initTransform = gameObject.transform;
        DataStatesOnInitial();
        _audioSource = GetComponent<AudioSource>();

        SetBackToWalkingValueForStart();
    }

    void SetEnemyDataStateLength()
    {
        enemyData.enemyStats[GetEnemyIndex()].isGround = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].enemyDying = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isWalking = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isFiring = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isAttacking = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isTouchable = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isActivateMagnet = new bool[gameObject.transform.parent.childCount];
        enemyData.enemyStats[GetEnemyIndex()].isSpeedZero = new bool[gameObject.transform.parent.childCount];

        enemyData.enemyStats[GetEnemyIndex()].bulletDamageValue = new float[gameObject.transform.parent.childCount];
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

    public void SetEnemyAttackDamage(ref EnemyData enemyData, ref EnemyBulletData bulletData)
    {
        int enemyIndex = GetEnemyIndex();
        bulletData.currentEnemyAttackDamage = PlayerManager.GetInstance._enemyBulletData.enemyAttackInfos[enemyIndex].attackDamage;
    }

    // Helper function to get the enemy index, defaults to 0 if not found
    public int GetEnemyIndex()
    {
        return enemyIndexMap.TryGetValue(gameObject.name, out int index) ? index : 0;
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
            enemyBulletManager.RayBullet();
        }
        else
        {
            enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyDataNumber] = false;
            enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyDataNumber] = false;
            bulletData.isFirable = false;
        }
    }

    public void EnemyAttack(ref PlayerData _playerData, ref Slider _topCanvasHealthBarSlider,
                         ref Slider healthBarSlider, ref GameObject _healthBarObject,
                         ref Transform _particleTransform)
    {
        // Exit early if no damage is dealt
        if (bulletData.currentEnemyAttackDamage == 0 && !enemyData.enemyStats[GetEnemyIndex()].enemyDying[enemyDataNumber]) return;

        if (_playerData.decreaseCounter == 0 && healthBarSlider.value > 0)
        {
            // Calculate damage multiplier for bosses
            int damageMultiplier = gameObject.transform.parent.name == "bossEnemyTransform" ? 2 : 1;
            int appliedDamage = bulletData.currentEnemyAttackDamage * damageMultiplier;

            // Decrease health
            PlayerManager.GetInstance.DecreaseHealth(ref _playerData, appliedDamage,
                ref _healthBarObject, ref healthBarSlider, ref _topCanvasHealthBarSlider, ref _playerData.damageHealthText);

            // Play hit sound
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetEnemyHit);

            // Increment counter to prevent multiple decreases
            _playerData.decreaseCounter++;
        }
    }



    void FollowPlayer()
    {
        if (enemyData == null || bulletData == null || enemyBulletManager == null) return;

        if (!playerData.isPlayable || enemyData.enemyStats[GetEnemyIndex()].enemyDying[enemyDataNumber] || SceneController.pauseGame)
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
            enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyDataNumber] = true;
            enemyData.enemyStats[GetEnemyIndex()].isAttacking[enemyDataNumber] = false;
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
            enemyData.enemyStats[GetEnemyIndex()].isAttacking[enemyDataNumber] = true;
            enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyDataNumber] = false;
            playerData.isDecreaseHealth = true;

            EnemyAttack(ref playerData, ref PlayerManager.GetInstance._topCanvasHealthBarSlider,
                        ref PlayerManager.GetInstance.playerComponents.healthBarSlider, ref PlayerManager.GetInstance._healthBarObject,
                        ref PlayerManager.GetInstance._particleTransform);
        }
        else
        {
            // Enemy is idle or beyond detection range
            enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyDataNumber] = true;
            enemyData.enemyStats[GetEnemyIndex()].isAttacking[enemyDataNumber] = false;
        }

        // Handle firing based on distance
        if (distanceToPlayer > 0.1f && distanceToPlayer < 10f)
        {
            bulletData.isFirable = true;
            enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyDataNumber] = true;

            bulletData.enemyBulletDelayCounter += Time.deltaTime;
            FiringFalse(bulletData.enemyFireFrequency);
        }
        else
        {
            enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyDataNumber] = false;
            bulletData.isFirable = false;
        }
    }

    // Helper function to reset enemy state when player is unplayable or paused
    void ResetEnemyState()
    {
        bulletData.isFirable = false;
        enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyDataNumber] = false;
        enemyData.enemyStats[GetEnemyIndex()].isAttacking[enemyDataNumber] = false;
        enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyDataNumber] = false;
    }


    public void FiringFalse(float enemyFireFrequency)
    {
        if (bulletData.enemyBulletDelayCounter >= enemyFireFrequency)
        {
            enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyDataNumber] = true;
            bulletData.isFirable = true;

            bulletData.enemyBulletDelayCounter = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (enemyData != null || gameObject != null)
        {
            if (collision.collider.CompareTag(SceneController.Tags.Player.ToString()) &&
                enemyData.enemyStats[GetEnemyIndex()].isTouchable[enemyDataNumber])
            {
                SetCurrentEnemyHitDamage();               

                TouchPlayer();

                //PlayerData
                if (gameObject.transform.parent.name == "bossEnemyTransform")
                {
                    PlayerManager.GetInstance.DecreaseHealth(ref PlayerManager.GetInstance._playerData,
                    bulletData.currentEnemyHitDamage*2,
                    ref PlayerManager.GetInstance._healthBarObject, ref PlayerManager.GetInstance.playerComponents.healthBarSlider,
                    ref PlayerManager.GetInstance._topCanvasHealthBarSlider, ref PlayerManager.GetInstance._playerData.damageHealthText);
                }
                else
                {
                    PlayerManager.GetInstance.DecreaseHealth(ref PlayerManager.GetInstance._playerData,
                    bulletData.currentEnemyHitDamage,
                    ref PlayerManager.GetInstance._healthBarObject, ref PlayerManager.GetInstance.playerComponents.healthBarSlider,
                    ref PlayerManager.GetInstance._topCanvasHealthBarSlider, ref PlayerManager.GetInstance._playerData.damageHealthText);
                }
                
            }
            if (collision.collider.CompareTag(SceneController.Tags.FanceWooden.ToString()) &&
                enemyData.enemyStats[GetEnemyIndex()].isTouchable[enemyDataNumber])
            {
                TouchWall();
            }
            if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()) || 
                collision.collider.CompareTag(SceneController.Tags.Enemy.ToString()) || 
                collision.collider.CompareTag(SceneController.Tags.Ladder.ToString()))
            {//Ground, Ladder, Enemy
                enemyData.enemyStats[GetEnemyIndex()].isGround[enemyDataNumber] = true;
            }
        }        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Bullet.ToString()))
        {
            WeaponBulletPower();
            TriggerBullet(enemyData.enemyStats[GetEnemyIndex()].bulletDamageValue[enemyDataNumber], other);
        }
        if (other.CompareTag(SceneController.Tags.Sword.ToString()))
        {
            TriggerSword(PlayerManager.GetInstance._playerData.characterStruct[PlayerData.currentCharacterID].swordDamageValue, other);
        }
    }
    void WeaponBulletPower()
    {
        float weaponPower = 0;
        string currentWeaponName = PlayerManager.GetInstance._bulletData.currentWeaponName;

        // weaponStruct dizisinde currentWeaponName ile eşleşen silahı bul.
        BulletData.WeaponStruct selectedWeapon = PlayerManager.GetInstance._bulletData.weaponStruct
            .FirstOrDefault(weapon => weapon.weaponName == currentWeaponName);

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
            enemyData.enemyStats[GetEnemyIndex()].bulletDamageValue[enemyDataNumber] = weaponPower / 4;
        }
        else if (parentName == "chestMonsterTransform")
        {
            enemyData.enemyStats[GetEnemyIndex()].bulletDamageValue[enemyDataNumber] = weaponPower * 3;
        }
        else
        {
            enemyData.enemyStats[GetEnemyIndex()].bulletDamageValue[enemyDataNumber] =
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
        if (!enemyData.enemyStats[GetEnemyIndex()].isActivateMagnet[enemyDataNumber])
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
    private void HandleEnemyDeath(Collider other = null, bool isSword = true)
    {
        if (_healthBar == null || enemyData.enemyStats[GetEnemyIndex()].enemyDying[enemyDataNumber]) return;


        if (_healthBarSlider.value == 0)
        {
            PlaySoundEffect(SoundEffectTypes.Death, _audioSource);

            if (other)
            {
                if (burnParticleTransformObject || isSword)
                {
                    BulletOrSwordExplosionParticleWithObjectPool(other, playerData.enemyMidParticleObjectPoolID);
                }
            }
            EnemyDeathParticle();

            enemyData.enemyStats[GetEnemyIndex()].isTouchable[enemyDataNumber] = false;
            enemyData.enemyStats[GetEnemyIndex()].enemyDying[enemyDataNumber] = true;
            enemyData.enemyStats[GetEnemyIndex()].isFiring[enemyDataNumber] = false;
            enemyData.enemyStats[GetEnemyIndex()].isSpeedZero[enemyDataNumber] = true;


            if (gameObject.transform.parent.name == "bossEnemyTransform")
            {
                EnemySpawner.bossIsDead = true;
                StartCoroutine(DelayStopEnemy(0f));
            }
            else
            {
                StartCoroutine(DelayStopEnemy(levelData.currentBackToWalkingValue));
            }

            // Update player's bullet count for bullets only
            if (!isSword)
            {
                int bulletDiff = PlayerManager.GetInstance._bulletData.currentBulletPackAmount - playerData.bulletAmount;
                playerData.bulletAmount += Mathf.Min(5, bulletDiff);
            }

            // Update score
            ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue * 2);
            return;
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
        StartCoroutine(DelayStopEnemy(delay));

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
            levelData.currentBackToWalkingValue = levelData.levelStates[LevelData.currentLevelId].backToWalkingDelay;
        }
    }

    void BulletOrSwordExplosionParticleWithObjectPool(Collider other, int objectPoolValue)
    {
        if (enemyData.enemyStats[GetEnemyIndex()].enemyDying[enemyDataNumber])
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

    public IEnumerator DelayStopEnemy(float backToWalkingValue)
    {
        yield return new WaitForSeconds(backToWalkingValue);
        
        enemyData.enemyStats[GetEnemyIndex()].isWalking[enemyDataNumber] = true;
        enemyData.enemyStats[GetEnemyIndex()].isSpeedZero[enemyDataNumber] = false;

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
            enemyData.enemyStats[GetEnemyIndex()].isTouchable[enemyDataNumber] = true;
        }
    }
}
