using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManager : AbstractEnemy<EnemyManager>
{
    [Header("Bullet")]
    public EnemyBulletManager enemyBullet;

    [Header("Health")]
    public GameObject _healthBar;

    [Header("Output Sound")]
    private AudioSource _audioSource;

    [Header("Data")]
    public EnemyData enemyData;
    public PlayerData playerData;

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

    void Start()
    {
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
        if (!enemyData.isGround)
        {
            gameObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
        if (gameObject != null)
        {
            if (playerData.isPlayable)
            {
                enemyData.enemySpeed = _initSpeed;

                Movement(clownSpawner.targetTransform, _initTransform, gameObject.transform, enemyData.isActivateMagnet, enemyData.enemySpeed, playerData, enemyData);
            }
            else
            {
                EnemyBulletManager.isFirable = false;
                enemyData.isFiring = false;
            }
        }
    }    
    private void OnCollisionEnter(Collision collision)
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
            if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneController.Tags.Enemy.ToString()) || collision.collider.CompareTag(SceneController.Tags.Ladder.ToString()))
            {//Ground, Ladder, Enemy
                enemyData.isGround = true;
            }
        }        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Magnet.ToString()))
        {
            enemyData.isActivateMagnet = true;
            if (!enemyData.isFiring)
            {
                enemyData.isWalking = true;
            }
        }

        if (other.CompareTag(SceneController.Tags.Bullet.ToString()))
        {
            TriggerBullet(2f);
        }
        if (other.CompareTag(SceneController.Tags.Sword.ToString()))
        {
            TriggerSlaveSword(32f);
        }
        if (other.CompareTag(SceneController.Tags.SlaveSword.ToString()))
        {
            TriggerSlaveSword(2f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Magnet.ToString()))
        {
            enemyData.isActivateMagnet = false;
            enemyData.isWalking = false;
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
    public void TriggerSlaveSword(float bulletPower)
    {
        gameObject.transform.LookAt(clownSpawner.targetTransform.position);
        StartCoroutine(DelayStopEnemy(3f));
        if (_healthBar != null)
        {
            if (_healthBar.transform.localScale.x <= 0.0625f)
            {
                PlayerManager.GetInstance.CreateSlaveObject();

                bottomParticle.Play();
                middleParticle.Play();
                topParticle.Play();
                enemyData.isTouchable = false;
                enemyData.isDying = true;
                enemyData.isWalking = false;
                enemyData.isFiring = false;
                enemyData.isSpeedZero = true;
                StartCoroutine(DelayStopEnemy(5f));
                Destroy(_healthBar);
                ScoreController.GetInstance.SetScore(20);
                PlaySoundEffect(SoundEffectTypes.Death, _audioSource);
                StartCoroutine(DelayDestroy(2f));
            }
            else
            {
                if (_healthBar.transform.localScale.x <= 0.125f && _healthBar.transform.localScale.x > 0.0625f)
                {
                    bottomParticle.Play();
                    middleParticle.Play();
                }
                if (_healthBar.transform.localScale.x > 0.125f)
                {
                    middleParticle.Play();
                }
                enemyData.isWalking = false;
                enemyData.isFiring = false;
                enemyData.isSpeedZero = true;
                StartCoroutine(DelayStopEnemy(3f));
                PlaySoundEffect(SoundEffectTypes.GetHit, _audioSource);
                _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / bulletPower, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
            }
            StartCoroutine(ShowDamage(100, 0.1f, 3f));
        }
    }
    public void TriggerBullet(float bulletPower)
    {
        gameObject.transform.LookAt(clownSpawner.targetTransform.position);
        enemyData.isWalking = false;
        enemyData.isSpeedZero = true;
        StartCoroutine(DelayStopEnemy(3f));
        if (_healthBar != null)
        {
            if (_healthBar.transform.localScale.x <= 0.0625f)
            {
                PlayerManager.GetInstance.CreateSlaveObject();

                bottomParticle.Play();
                middleParticle.Play();
                topParticle.Play();
                enemyData.isTouchable = false;
                enemyData.isDying = true;
                enemyData.isWalking = false;
                enemyData.isFiring = false;
                enemyData.isSpeedZero = true;
                StartCoroutine(DelayStopEnemy(5f));
                Destroy(_healthBar);
                ScoreController.GetInstance.SetScore(20);
                PlaySoundEffect(SoundEffectTypes.Death, _audioSource);
                StartCoroutine(DelayDestroy(2f));                
            }
            else
            {
                if(_healthBar.transform.localScale.x <= 0.125f && _healthBar.transform.localScale.x > 0.0625f)
                {
                    bottomParticle.Play();
                    middleParticle.Play();
                }
                if (_healthBar.transform.localScale.x > 0.125f)
                {
                    middleParticle.Play();
                }
                enemyData.isWalking = false;
                enemyData.isFiring = false;
                enemyData.isSpeedZero = true;
                StartCoroutine(DelayStopEnemy(3f));
                PlaySoundEffect(SoundEffectTypes.GetHit, _audioSource);
                _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / bulletPower, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
            }
            StartCoroutine(ShowDamage(20, 0.1f, 3f));
        }
    }   


    public IEnumerator DelayStopEnemy(float value)
    {
        yield return new WaitForSeconds(value);
        enemyData.isWalking = true;
        enemyData.isSpeedZero = false;

    }
    public IEnumerator DelayDestroy(float delayDestroy)
    {
        yield return new WaitForSeconds(delayDestroy);
        Destroy(gameObject);
        enemyData.isWalking = true;
        enemyData.isDying = false;
        CreateBulletCoin();
    }
    void CreateBulletCoin()
    {
        GameObject bulletCoin = Instantiate(_bulletCoin,
                                            new Vector3(gameObject.transform.position.x,
                                                        _bulletCoin.transform.position.y, 
                                                        gameObject.transform.position.z), 
                                            Quaternion.identity, 
                                            PlayerManager.GetInstance.bulletCoinTransform);
        bulletCoin.transform.eulerAngles = new Vector3(0f, gameObject.transform.eulerAngles.y + 90f, 90f);
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
    }
    public enum SoundEffectTypes
    {
        GetHit,
        GiveHit,
        Death,
    }

    private void DataStatesOnInitial()
    {
        if (enemyData != null)
        {
            enemyData.isTouchable = true;
            enemyData.isActivateMagnet = false;
            enemyData.isGround = true;
            _initSpeed = enemyData.enemySpeed;
        }
    }
}
