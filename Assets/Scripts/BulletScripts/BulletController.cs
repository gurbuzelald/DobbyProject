using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [Header("Raycast")]
    public LayerMask layerMask;
    [SerializeField] float delayFalseWhenTriggerEnemy;

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
                Invoke("DelayFalseBulletObject", delayFalseWhenTriggerEnemy);
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
    void DelayFalseBulletObject()
    {
        gameObject.SetActive(false);
    }
}
