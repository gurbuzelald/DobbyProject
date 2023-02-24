using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [Header("Raycast")]
    public LayerMask layerMask;
    public PlayerData playerData;
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
        if (gameObject != null)
        {
            if (collision.collider.CompareTag(SceneController.Tags.Enemy.ToString()))
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()))
        {
            gameObject.SetActive(false);
        }
        
    }
}
