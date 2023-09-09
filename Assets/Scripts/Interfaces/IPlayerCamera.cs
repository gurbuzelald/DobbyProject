using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IPlayerCamera
{
    #region //Camera
    void ChangeCamera();
    void ConvertToCloseCamera(GameObject cameraSpawner);
    void ConvertToFarCamera(GameObject cameraSpawner);
    void CheckCameraEulerX(PlayerData _playerData, Transform _currentCameraTransform);
    

    #endregion
}
