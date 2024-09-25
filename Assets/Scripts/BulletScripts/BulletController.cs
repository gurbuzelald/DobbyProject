using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [Header("Raycast")]
    public LayerMask layerMask;
    [SerializeField] float delayFalseWhenTriggerEnemy;

    public static bool AK47 { get; internal set; }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.05f, layerMask))
        {
            //Debug.Log("Test");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.transform.name == "EnemyBullet")
        {
            if (gameObject != null)
            {
                if (collision.collider.CompareTag(SceneController.Tags.Player.ToString()))
                {
                    gameObject.SetActive(false);
                }
            }
        }
        if (gameObject.transform.name == "Bullet")
        {
            if (gameObject != null)
            {
                if (collision.collider.CompareTag(SceneController.Tags.Enemy.ToString()))
                {
                    gameObject.SetActive(false);
                }
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.transform.name == "EnemyBullet(Clone)")
        {
            if (other.gameObject.CompareTag(SceneController.Tags.Player.ToString()))
            {
                gameObject.SetActive(false);
            }
        }

        if (gameObject.transform.name == "WeaponBullet(Clone)")
        {
            if (other.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()) || 
                other.gameObject.CompareTag(SceneController.Tags.WeaponBox.ToString()))
            {
                StartCoroutine(DelayFalseBulletObject(delayFalseWhenTriggerEnemy));
            }
        }
    }
    IEnumerator DelayFalseBulletObject(float value)
    {
        yield return new WaitForSeconds(value);
        gameObject.SetActive(false);
    }
}
