using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform _targetObject;
    public float _enemySpeed = 0.1f;
    private float _initSpeed;
    [SerializeField] GameObject _healthBar;
    private AudioSource _audioSource;
    [SerializeField] EnemyData enemyData;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _initSpeed = _enemySpeed;
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
        if (PlayerManager.GetInstance._healthBar != null)
        {
            if (collision.collider.CompareTag(SceneLoadController.Tags.Player.ToString()) && PlayerManager.GetInstance._healthBar.transform.localScale.x <= 0.0625f)
            {
                PlaySoundEffect(SoundEffectTypes.GiveHit);

                EnemyAnimationController.isWalking = false;
                _enemySpeed = 0;
                StartCoroutine(DelayStopEnemy());
            }
        }
        if (collision.collider.CompareTag(SceneLoadController.Tags.Bullet.ToString()))
        {
            EnemyAnimationController.isWalking = false;
            _enemySpeed = 0;
            StartCoroutine(DelayStopEnemy());

            if (_healthBar.transform.localScale.x <= 0.0625f)
            {
                if (_healthBar != null)
                {
                    Destroy(_healthBar);
                    ScoreController.GetInstance.SetScore(20);
                    PlaySoundEffect(SoundEffectTypes.Death);
                }
                Destroy(gameObject);
            }
            else
            {
                PlaySoundEffect(SoundEffectTypes.GetHit);
                _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / 2f, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    
    private void Movement()
    {
        if (_targetObject != null)
        {
            gameObject.transform.LookAt(_targetObject.position);
            gameObject.transform.Translate(0f, 0f, _enemySpeed * Time.deltaTime);
        }
    }
    public IEnumerator DelayStopEnemy()
    {
        yield return new WaitForSeconds(3f);
        EnemyAnimationController.isWalking = true;
        _enemySpeed = _initSpeed;
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
