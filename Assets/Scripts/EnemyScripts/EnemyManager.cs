using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private ClownSpawner clownSpawner;

    void Start()
    {
        clownSpawner = FindObjectOfType<ClownSpawner>();
        _enemyIcon.GetComponent<MeshRenderer>().enabled = true;
        _initTransform = gameObject.transform;
        DataStatesOnInitial();
        _audioSource = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        if (gameObject != null)
        {
            if (playerData.isPlayable)
            {
                enemyData.enemySpeed = _initSpeed;

                Movement(clownSpawner.targetTransform, _initTransform, gameObject.transform, enemyData.isActivateMagnet, enemyData.enemySpeed);
            }
            else
            {
                enemyData.isWalking = false;
                enemyData.isFiring = false;
                enemyData.enemySpeed = 0f;
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
            TriggerBullet();
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

    //Collider and Collision
    public void TouchPlayer()
    {
        if (PlayerManager.GetInstance._healthBar != null && PlayerManager.GetInstance._healthBar.transform.localScale.x <= 0.0625f)
        {
            PlaySoundEffect(SoundEffectTypes.GiveHit, _audioSource);

            enemyData.isWalking = false;
            enemyData.isFiring = false;
            enemyData.enemySpeed = _initSpeed * 0f;
            StartCoroutine(DelayStopEnemy());
        }        
    }
    public void TouchWall()
    {
        if (!enemyData.isActivateMagnet)
        {
            gameObject.transform.Rotate(0f, 180f, 0f);
        }
    }
    public void TriggerBullet()
    {
        gameObject.transform.LookAt(clownSpawner.targetTransform.position);
        enemyData.isWalking = false;
        enemyData.enemySpeed = _initSpeed * 0f;
        StartCoroutine(DelayStopEnemy());
        if (_healthBar != null)
        {
            if (_healthBar.transform.localScale.x <= 0.0625f)
            {
                bottomParticle.Play();
                middleParticle.Play();
                topParticle.Play();
                enemyData.isTouchable = false;
                enemyData.isDying = true;
                enemyData.isWalking = false;
                enemyData.isFiring = false;
                Destroy(_healthBar);
                ScoreController.GetInstance.SetScore(20);
                PlaySoundEffect(SoundEffectTypes.Death, _audioSource);
                StartCoroutine(DelayDestroy(4f));
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
                PlaySoundEffect(SoundEffectTypes.GetHit, _audioSource);
                _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / 2f, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
            }
        }
    }   


    public IEnumerator DelayStopEnemy()
    {
        yield return new WaitForSeconds(3f);
        enemyData.isWalking = true;
        enemyData.enemySpeed = _initSpeed;
    }
    public IEnumerator DelayDestroy(float delayDestroy)
    {
        yield return new WaitForSeconds(delayDestroy);
        Destroy(gameObject);
        enemyData.isWalking = true;
        enemyData.isDying = false;
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
