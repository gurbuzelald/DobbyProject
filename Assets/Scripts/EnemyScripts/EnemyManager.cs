using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : AbstractEnemy<EnemyManager>
{
    [Header("Bullet")]
    public EnemyBulletManager enemyBullet;

    [Header("Destination Transform")]
    [SerializeField] Transform _targetTransform;

    [Header("Health")]
    [SerializeField] GameObject _healthBar;

    [Header("Output Sound")]
    private AudioSource _audioSource;

    [Header("Data")]
    public EnemyData enemyData;
    public PlayerData playerData;

    [Header("Initial Situations")]
    private float _initSpeed;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (enemyData != null)
        {
            enemyData.isActivateMagnet = false;
            enemyData.isGround = true;
            _initSpeed = enemyData.enemySpeed;
        }
    }
    void Update()
    {
        if (gameObject != null)
        {
            if (playerData.isPlayable)
            {
                Movement(_targetTransform, gameObject.transform, enemyData.isActivateMagnet, enemyData.enemySpeed);
            }
            else
            {
                enemyData.isWalking = false;
                enemyData.isFiring = false;
            }
        }
    }    
    private void OnCollisionEnter(Collision collision)
    {
        if (enemyData != null || gameObject != null)
        {
            if (collision.collider.CompareTag(SceneLoadController.Tags.Player.ToString()))
            {
                TouchPlayer();
            }
            if (collision.collider.CompareTag(SceneLoadController.Tags.Bullet.ToString()))
            {
                TouchBullet();
            }
            if (collision.collider.CompareTag(SceneLoadController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneLoadController.Tags.Enemy.ToString()) || collision.collider.CompareTag(SceneLoadController.Tags.Ladder.ToString()))
            {//Ground, Ladder, Enemy
                enemyData.isGround = true;
            }
        }        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneLoadController.Tags.Magnet.ToString()))
        {
            enemyData.isActivateMagnet = true;
            if (!enemyData.isFiring)
            {
                enemyData.isWalking = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(SceneLoadController.Tags.Magnet.ToString()))
        {
            enemyData.isActivateMagnet = false;
            enemyData.isWalking = false;
        }
    }
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
    public void TouchBullet()
    {
        gameObject.transform.LookAt(_targetTransform.position);
        enemyData.isWalking = false;
        enemyData.enemySpeed = _initSpeed * 0f;
        StartCoroutine(DelayStopEnemy());
        if (_healthBar != null)
        {
            if (_healthBar.transform.localScale.x <= 0.0625f)
            {
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

}
