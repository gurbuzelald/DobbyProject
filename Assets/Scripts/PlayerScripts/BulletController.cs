using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject != null)
        {
            if (collision.collider.CompareTag(SceneLoadController.Tags.Enemy.ToString()))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
