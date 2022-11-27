using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWasher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(SceneLoadController.Tags.Player.ToString()) || !other.CompareTag(SceneLoadController.Tags.Enemy.ToString()))
        {
            other.gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(SceneLoadController.Tags.Player.ToString()) || !other.CompareTag(SceneLoadController.Tags.Enemy.ToString()))
        {
            other.gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
