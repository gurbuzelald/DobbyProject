using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform _targetObject;
    private float _initSpeed;
    [SerializeField] GameObject _healthBar;
    private AudioSource _audioSource;
    public EnemyData enemyData;

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
            Movement();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (enemyData != null || gameObject != null)
        {
            if (PlayerManager.GetInstance._healthBar != null)
            {
                if (collision.collider.CompareTag(SceneLoadController.Tags.Player.ToString()) && PlayerManager.GetInstance._healthBar.transform.localScale.x <= 0.0625f)
                {
                    PlaySoundEffect(SoundEffectTypes.GiveHit);

                    enemyData.isWalking = false;
                    enemyData.enemySpeed = 0;
                    StartCoroutine(DelayStopEnemy());
                }
            }
            if (collision.collider.CompareTag(SceneLoadController.Tags.Bullet.ToString()))
            {
                enemyData.isWalking = false;
                enemyData.enemySpeed = 0;
                StartCoroutine(DelayStopEnemy());
                if (_healthBar != null)
                {
                    if (_healthBar.transform.localScale.x <= 0.0625f)
                    {
                        enemyData.isDying = true;
                        enemyData.isWalking = false;
                        Destroy(_healthBar);
                        ScoreController.GetInstance.SetScore(20);
                        PlaySoundEffect(SoundEffectTypes.Death);
                        StartCoroutine(DelayDestroy(4f));

                    }
                    else
                    {
                        PlaySoundEffect(SoundEffectTypes.GetHit);
                        _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / 2f, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
                    }
                }
            }
            if (collision.collider.CompareTag(SceneLoadController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneLoadController.Tags.Enemy.ToString()) || collision.collider.CompareTag(SceneLoadController.Tags.Ladder.ToString()))
            {//Ground, Ladder, Enemy
                enemyData.isGround = true;
            }
            else
            {
                //gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, 180f, gameObject.transform.eulerAngles.z);
                //_enemyData.isGround = false;
            }
        }        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(SceneLoadController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneLoadController.Tags.Enemy.ToString()) || collision.collider.CompareTag(SceneLoadController.Tags.Ladder.ToString()))
        {//Ground, Ladder, Enemy
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneLoadController.Tags.Magnet.ToString()))
        {
            enemyData.isActivateMagnet = true;
            enemyData.isWalking = true;
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

    private void Movement()
    {
        if (_targetObject != null && enemyData.isActivateMagnet)
        {
            gameObject.transform.LookAt(_targetObject.position);
            gameObject.transform.Translate(0f, 0f, enemyData.enemySpeed * Time.deltaTime);
        }
        else if (_targetObject != null && !enemyData.isActivateMagnet)
        {
           
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
    public void PlaySoundEffect(SoundEffectTypes soundEffect)
    {
        if (soundEffect == SoundEffectTypes.GetHit)
        {
            _audioSource.PlayOneShot(enemyData.getHitClip);
        }
        else if (soundEffect == SoundEffectTypes.GiveHit)
        {
            _audioSource.PlayOneShot(enemyData.giveHitClip);
        }
        else if (soundEffect == SoundEffectTypes.Death)
        {
            _audioSource.PlayOneShot(enemyData.dyingClip);
        }
    }
    public enum SoundEffectTypes
    {
        GetHit,
        GiveHit,
        Death,
    }

}
