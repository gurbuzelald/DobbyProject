using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [SerializeField] float objectZPosition;
    void Update()
    {
        gameObject.transform.position = new Vector3(PlayerManager.GetInstance.gameObject.transform.position.x, 
                                                    gameObject.transform.position.y,
                                                    PlayerManager.GetInstance.gameObject.transform.position.z - objectZPosition);
        /*
         _miniMapTransform.position = new Vector3(_currentCameraTransform.transform.position.x,
                                                    _miniMapTransform.position.y,
                                                    _currentCameraTransform.transform.position.z);
        _miniMapTransform.eulerAngles = new Vector3(_miniMapTransform.eulerAngles.x,
                                                    gameObject.transform.eulerAngles.y,
                                                    _miniMapTransform.eulerAngles.z);
         */
    }
}
