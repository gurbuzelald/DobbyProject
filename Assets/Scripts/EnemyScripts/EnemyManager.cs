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

    private void Start()
    {
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
                EnemyAnimationController.isWalking = false;
                _enemySpeed = 0;
                StartCoroutine(DelayStopEnemy());
            }
        }
        if (collision.collider.CompareTag(SceneLoadController.Tags.Bullet.ToString()))
        {
            if (_healthBar.transform.localScale.x <= 0.0625f)
            {
                if (_healthBar != null)
                {
                    Destroy(_healthBar);
                    ScoreController.GetInstance.SetScore(20);
                }
                Destroy(gameObject);
            }
            else
            {
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

}
