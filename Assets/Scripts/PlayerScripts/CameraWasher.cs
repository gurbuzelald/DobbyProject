using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWasher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.transform.tag);
        if (!other.gameObject.transform.CompareTag(SceneController.Tags.Player.ToString()) && !other.gameObject.transform.CompareTag(SceneController.Tags.Enemy.ToString()))
        {
            other.gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.transform.CompareTag(SceneController.Tags.Player.ToString()) && !other.gameObject.transform.CompareTag(SceneController.Tags.Enemy.ToString()))
        {
            other.gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
