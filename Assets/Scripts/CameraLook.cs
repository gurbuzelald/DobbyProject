using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraLook : MonoBehaviour
{
    public PlayerData _playerData;
    public Transform _finishArrowTransform;
    [SerializeField] float lookSpeed = 1;

    private void Awake()
    {
        Instantiate(_playerData.arrowObject,
                    _finishArrowTransform.transform);
        if (Screen.width > 825)
        {
            _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x,
                                                    _finishArrowTransform.position.y,
                                                    _finishArrowTransform.position.z);
        }
        else if (Screen.width > 625)
        {
            _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x + 0.1f,
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
            _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x + 0.3f,
                                                    _finishArrowTransform.position.y,
                                                    _finishArrowTransform.position.z);

        }
        else if (Screen.width > 325)
        {
            _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x + 0.4f,
                                                    _finishArrowTransform.position.y,
                                                    _finishArrowTransform.position.z);

        }
        else if (Screen.width > 225)
        {
            _finishArrowTransform.position = new Vector3(_finishArrowTransform.position.x + 0.5f,
                                                    _finishArrowTransform.position.y,
                                                    _finishArrowTransform.position.z);

        }
        //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(gameObject.transform.position.x, Camera.main.transform.position.x)));


        //_playerData.arrowObject.transform.localScale = new Vector3(_playerData.arrowObject.transform.localScale.x * 1000, _playerData.arrowObject.transform.localScale.y * 1000, _playerData.arrowObject.transform.localScale.z * 1000);

    }
    private void Update()
    {
        Debug.Log(Screen.width);
        gameObject.transform.rotation = PlayerManager.GetInstance._currentCameraTransform.rotation;        
    }

}
