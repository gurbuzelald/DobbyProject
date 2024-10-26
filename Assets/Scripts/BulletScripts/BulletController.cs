using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [Header("Raycast")]
    public LayerMask layerMask;
    [SerializeField] float delayFalseWhenTriggerEnemy;

    public static bool ShotGun { get; internal set; }

    public int damageValue;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.transform.name == "EnemyBullet")
        {
            if (gameObject != null)
            {
                if (collision.gameObject.CompareTag(SceneController.Tags.Player.ToString()))
                {
                    gameObject.SetActive(false);
                }
            }
        }
        if (gameObject.transform.tag == "Bullet")
        {
            if (gameObject != null)
            {
                if (collision.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()))
                {
                    gameObject.SetActive(false);
                }
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.transform.tag == "Bullet")
        {
            if (other.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()) || 
                other.gameObject.CompareTag(SceneController.Tags.WeaponBox.ToString()))
            {
                StartCoroutine(DelayFalseBulletObject(delayFalseWhenTriggerEnemy));
            }
            if (other.gameObject.CompareTag(SceneController.Tags.Wall.ToString()))
            {
                gameObject.SetActive(false);
            }
        }
        else if (gameObject.transform.tag == "EnemyBullet")
        {
            if (other.gameObject.CompareTag(SceneController.Tags.Player.ToString()))
            {
                gameObject.SetActive(false);
            }
        }
    }
    IEnumerator DelayFalseBulletObject(float value)
    {
        yield return new WaitForSeconds(value);
        gameObject.SetActive(false);
    }
}
