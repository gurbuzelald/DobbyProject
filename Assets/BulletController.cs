using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject != null)
        {
            if (other.CompareTag(SceneLoadController.Tags.Enemy.ToString()))
            {
                Destroy(gameObject);
                //gameObject.SetActive(false);
            }
        }        
    }
}
