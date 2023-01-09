using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWasher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(SceneController.Tags.Player.ToString()) || !other.CompareTag(SceneController.Tags.Enemy.ToString()))
        {
            other.gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(SceneController.Tags.Player.ToString()) || !other.CompareTag(SceneController.Tags.Enemy.ToString()))
        {
            other.gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
