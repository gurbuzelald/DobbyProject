using UnityEngine;

public class CameraSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _cameraObjects;
    private GameObject cameraObjects;

    private Camera cameraObject;

    private void Start()
    {
        if (gameObject.transform.childCount >= 1)
        {
            if (gameObject.transform.GetChild(0).gameObject)
            {
                Destroy(gameObject.transform.GetChild(0).gameObject);
            }
        }
        
        for (int i = 0; i < _cameraObjects.Length; i++)
        {
            cameraObjects = Instantiate(_cameraObjects[i], gameObject.transform);
        }
    }

}

