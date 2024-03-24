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

    [Header("Particle Burning Effect")]
    public ParticleSystem bottomParticle;
    public ParticleSystem middleParticle;
    public ParticleSystem topParticle;

    private Transform _initTransform;
    [SerializeField] GameObject _enemyIcon;

    private EnemySpawner clownSpawner;
    [SerializeField] GameObject _bulletCoin;

    [SerializeField] TextMeshProUGUI _damageText;
    private Rigidbody enemyRigidbody;
    private EnemyBulletManager enemyBulletManager;
    private GameObject enemySpawnerObject;
    private EnemySpawner enemySpawner;


    void Start()
    {
        enemyData = enemyListData[enemyDataNumber];
        bulletData = enemyListBulletData[enemyBulletDataNumber];

        enemyData.isWalkable = true;
        _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
        _healthBarSlider = _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>();

        enemyRigidbody = gameObject.transform.GetComponent<Rigidbody>();

        enemyBulletManager = gameObject.transform.GetChild(2).transform.GetComponent<EnemyBulletManager>();

        enemySpawnerObject = GameObject.Find("EnemySpawner");
        enemySpawner = enemySpawnerObject.GetComponent<EnemySpawner>();

        _damageText.text = "";
        _damageText.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        clownSpawner = FindObjectOfType<EnemySpawner>();
        _enemyIcon.GetComponent<MeshRenderer>().enabled = true;
        _initTransform = gameObject.transform;
        DataStatesOnInitial();
        _audioSource = GetComponent<AudioSource>();
    }   
    void Update()
    {
        WeaponBulletPower(); 

        if (!enemyData.isFiring && !enemyData.isDying && 
            (Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) > 0.5f))
        {
            enemyData.isWalking = true;
        }
        if (!enemyData.isGround)
        {
            enemyRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
        if (enemyData.isGround)
        {
            enemyRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        FollowPlayer();

        enemyData.enemySpeed = levelData.currentEnemySpeed;
    }

    void FollowPlayer()
    {
        if (gameObject != null)
        {
            if (playerData.isPlayable && gameObject != null && enemyBulletManager != null)
            {
                bulletData.isFirable = true;
                //enemyData.isFiring = true;


                if ((Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) > 0.1f) &&
                    (Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) < levelData.currentEnemyDetectionDistance) &&
                    enemyData.isWalkable && !enemyData.isDying)
                {
                    enemyData.enemySpeed = _initSpeed;
                    enemyData.isWalking = true;
                    enemyData.isAttacking = false;
                    enemyData.isFiring = false;
                    enemyData.isDying = false;
                    //Debug.Log("Test");
                    Movement(clownSpawner.targetTransform, _initTransform, gameObject.transform, enemyData.enemySpeed, playerData, enemyData);
                }
                else if ((Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) <= 0.1f) && !enemyData.isDying &&
                          playerData.isPlayable)
                {
                    //Debug.Log("Test");
                    enemyData.isAttacking = true;

                    playerData.isDecreaseHealth = true;

                    playerData.currentEnemyName = gameObject.name;

                    enemyData.isWalking = false;
                    enemyData.isDying = false;
                    enemyData.isFiring = false;
                    
                    //When Enemy touched player, enemy will get a animation to here.
                    //enemyData.isWalking = false;
                }
                else if ((Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) > 0.4f) &&
                    (Vector3.Distance(gameObject.transform.position, PlayerManager.GetInstance.gameObject.transform.position) < 10f) &&
                    !enemyData.isDying && !playerData.isDying)
                {
                    enemyData.isFiring = true;
                    enemyData.isAttacking = false;
                    enemyData.isDying = false;
                    enemyData.isWalking = false;

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
    
    void FixedUpdate()
    {
        //RayBullet();
    }
    void RayBullet()
    {
        if (!enemyData.isDying)
        {
            
            RaycastHit hit;
            if (bulletData.isFirable)
            {
                if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward),
                    out hit, 10f, enemySpawner.layerMask))
                {
                    Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);

                    enemyData.isFiring = true;
                    enemyData.isWalking = false;

                    StartCoroutine(gameObject.transform.GetChild(2).GetComponent<EnemyBulletManager>()
                                   .Delay(bulletData.enemyBulletDelay, 2f));

                    StartCoroutine(gameObject.transform.GetChild(2).GetComponent<EnemyBulletManager>().FiringFalse(bulletData.enemyFireFrequency));
                }
                else
                {
                    Debug.DrawRay(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                }
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
            TriggerSword(PlayerManager.GetInstance._bulletData.swordDamageValue);
            other.gameObject.SetActive(false);
        }
    }
    void WeaponBulletPower()
    {
        if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.ak47)
        {
            enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.ak47Power;
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.m4a4)
        {
            enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.m4a4Power;
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.bulldog)
        {
            enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.bulldogPower;
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.cow)
        {
            enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.cowPower;
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.crystal)
        {
            enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.crystalPower;
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.demon)
        {
            enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.demonPower;
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.ice)
        {
            enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.icePower;
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.negev)
        {
            enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.negevPower;
        }
        else if(PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.axe)
        {
            enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.axePower;
        }
        else if (PlayerManager.GetInstance._bulletData.currentWeaponName == BulletData.pistol)
        {
            enemyData.bulletDamageValue = PlayerManager.GetInstance._bulletData.pistolPower;
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


        yield return new WaitForSeconds(3f);

        _damageText.text = "";
    }

    //Collider and Collision
    public void TouchPlayer()
    {
        if (playerData.objects[3] != null && playerData.objects[3].transform.localScale.x <= 0.0625f)
        {
            PlaySoundEffect(SoundEffectTypes.GiveHit, _audioSource);

            enemyData.isWalking = false;
            enemyData.isFiring = false;
            StartCoroutine(DelayStopEnemy(3f));
        }        
    }
    public void TouchWall()
    {
        if (!enemyData.isActivateMagnet)
        {
            gameObject.transform.Rotate(0f, 180f, 0f);
        }
    }
    public void TriggerSword(float swordPower)
    {
        gameObject.transform.LookAt(clownSpawner.targetTransform.position);
        StartCoroutine(DelayStopEnemy(3f));
        if (_healthBar != null)
        {
            if (_healthBarSlider.value <= 0)
            {
                bottomParticle.Play();
                middleParticle.Play();
                topParticle.Play();
                enemyData.isTouchable = false;
                enemyData.isDying = true;
                //enemyData.isWalking = false;
                enemyData.isFiring = false;
                enemyData.isSpeedZero = true;
                StartCoroutine(DelayStopEnemy(5f));
                Destroy(_healthBar);
                ScoreController.GetInstance.SetScore(10);
                PlaySoundEffect(SoundEffectTypes.Death, _audioSource);
                StartCoroutine(DelayDestroy(2f));
            }
            else
            {
               
                if (_healthBarSlider.value <= 50)
                {
                    bottomParticle.Play();
                    middleParticle.Play();
                }
                else if (_healthBarSlider.value > 50)
                {
                    middleParticle.Play();
                }
                //enemyData.isWalking = false;
                enemyData.isFiring = false;
                enemyData.isSpeedZero = true;
                StartCoroutine(DelayStopEnemy(3f));
                PlaySoundEffect(SoundEffectTypes.GetHit, _audioSource);
                PlaySoundEffect(SoundEffectTypes.SwordHit, _audioSource);

                _healthBarSlider.value -= swordPower;

            }

            _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = _healthBarSlider.value;

            StartCoroutine(ShowDamage((int)swordPower, 0.1f, 3f));
        }
    }
    public void TriggerBullet(float bulletPower, Collider other)
    {
        StartCoroutine(TriggerBulletParticleCreater(other));

        gameObject.transform.LookAt(clownSpawner.targetTransform.position);
        //enemyData.isWalking = false;
        enemyData.isSpeedZero = true;
        //StartCoroutine(DelayStopEnemy(3f));
        if (_healthBar != null)
        {
            if (_healthBarSlider.value <= 0)
            {
                bottomParticle.Play();
                middleParticle.Play();
                topParticle.Play();
                enemyData.isTouchable = false;
                enemyData.isDying = true;
                //enemyData.isWalking = false;
                enemyData.isFiring = false;
                enemyData.isSpeedZero = true;
                StartCoroutine(DelayStopEnemy(5f));
                Destroy(_healthBar);
                ScoreController.GetInstance.SetScore(10);
                PlaySoundEffect(SoundEffectTypes.Death, _audioSource);
                StartCoroutine(DelayDestroy(2f));                
            }
            else
            {
                if (_healthBarSlider.value <= 50 &&
                    _healthBarSlider.value > 0)
                {
                    bottomParticle.Play();
                    middleParticle.Play();
                }
                if (_healthBarSlider.value > 50)
                {
                    middleParticle.Play();
                }
                //enemyData.isWalking = false;
                enemyData.isFiring = false;
                
                enemyData.isSpeedZero = true;
                StartCoroutine(DelayStopEnemy(3f));
                PlaySoundEffect(SoundEffectTypes.GetHit, _audioSource);
                PlaySoundEffect(SoundEffectTypes.BulletHit, _audioSource);
                _healthBarSlider.value -= bulletPower;
            }

            _healthBar.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = _healthBarSlider.value;

            StartCoroutine(ShowDamage((int)bulletPower, 0.1f, 3f));
        }
    }   
    IEnumerator TriggerBulletParticleCreater(Collider other)
    {
        yield return new WaitForSeconds(0.0002f);
        GameObject touchParticle = Instantiate(enemyData._enemyTouchParticle, 
                                               new Vector3(other.gameObject.transform.position.x, 
                                                           other.gameObject.transform.position.y + .08f,
                                                           other.gameObject.transform.position.z), 
                                               Quaternion.identity, 
                                               gameObject.transform);
        enemyData.isWalkable = false;

        yield return new WaitForSeconds(1f);

        enemyData.isWalkable = true;

        Destroy(touchParticle, 0.01f);
    }


    public IEnumerator DelayStopEnemy(float value)
    {
        yield return new WaitForSeconds(value);
        //enemyData.isWalking = true;
        enemyData.isSpeedZero = false;

    }
    public IEnumerator DelayDestroy(float delayDestroy)
    {
        StartCoroutine(CreateDestroyParticle());
        
        yield return new WaitForSeconds(delayDestroy);
        Destroy(gameObject);
        
        //enemyData.isWalking = true;
        enemyData.isDying = false;
    }
    IEnumerator CreateDestroyParticle() {
        Transform currentBulletCoinTransform = gameObject.transform;

        yield return new WaitForSeconds(2f);

        GameObject enemyDestroyParticle = Instantiate(enemyData._enemyDestroyParticle,
                            new Vector3(currentBulletCoinTransform.position.x,
                                        enemyData._playerBulletObject.transform.position.y,
                                        currentBulletCoinTransform.position.z),
                            Quaternion.identity);

        Destroy(enemyDestroyParticle, 2f);
    }
    

    //SFX States
    public void PlaySoundEffect(SoundEffectTypes soundEffect, AudioSource audioSource)
    {
        if (soundEffect == SoundEffectTypes.GetHit)
        {
            audioSource.PlayOneShot(enemyData.getHitClip);
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
            audioSource.PlayOneShot(enemyData.bulletHitClip);
        }
        else if (soundEffect == SoundEffectTypes.SwordHit)
        {
            audioSource.PlayOneShot(enemyData.swordHitClip);
        }
    }
    public enum SoundEffectTypes
    {
        GetHit,
        GiveHit,
        Death,
        BulletHit,
        SwordHit,
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
