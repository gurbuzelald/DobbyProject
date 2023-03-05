using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _cameraObjects;
    private void Start()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
        for (int i = 0; i < _cameraObjects.Length; i++)
        {
            GameObject cameraObjects = Instantiate(_cameraObjects[i], gameObject.transform);
        }
    }
}
