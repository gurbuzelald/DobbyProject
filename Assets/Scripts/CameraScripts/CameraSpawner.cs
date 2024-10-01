using UnityEngine;

public class CameraSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _cameraObjects;
    private GameObject cameraObjects;

    public Camera cameraObject;



    private void Start()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
        for (int i = 0; i < _cameraObjects.Length; i++)
        {
            cameraObjects = Instantiate(_cameraObjects[i], gameObject.transform);
        }
    }

}

