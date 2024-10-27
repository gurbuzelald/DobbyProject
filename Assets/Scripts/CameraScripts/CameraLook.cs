using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;


//[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraLook : MonoBehaviour
{
    public PlayerData _playerData;
    public Transform _finishArrowTransform;
    private static int spawnCounter = 0;

    private void Awake()
    {
        Instantiate(_playerData.objects[0],
                    _finishArrowTransform.transform);

        FinishArrowPositionSpawner(_finishArrowTransform);
    }
    void FinishArrowPositionSpawner(Transform _finishArrowTransform)
    {
        if (spawnCounter == 0)
        {
            if (Screen.width > 2100)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 1.2f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            if (Screen.width > 2000)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 1.1f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            if (Screen.width > 1900)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 1f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 1800)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 0.9f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 1700)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 0.8f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 1600)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 0.7f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 1500)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 0.6f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 1400)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 0.5f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 1300)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 0.4f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 1200)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 0.3f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 1100)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 0.2f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 950)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x - 0.05f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 825)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 750)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x + 0.025f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 625)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x + 0.05f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 525)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x + 0.2f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 425)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x + 0.25f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 325)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x + 0.3f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else if (Screen.width > 225)
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x + 0.35f,
                                                        _finishArrowTransform.position.y,
                                                        _finishArrowTransform.position.z);
            }
            else
            {
                _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x + 0.4f,
                                                             _finishArrowTransform.position.y,
                                                             _finishArrowTransform.position.z);
            }
            spawnCounter++;
        }
        
    }
    private void Update()
    {
        if (PlayerManager.GetInstance._currentCameraTransform)
        {
            gameObject.transform.rotation = PlayerManager.GetInstance._currentCameraTransform.rotation;
        }
    }
}
