using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IPlayerCamera
{
    #region //Camera
    void ChangeCamera(PlayerData playerData, ref PlayerManager playerManager);
    void ConvertToCloseCamera(GameObject cameraSpawner);
    void ConvertToFarCamera(GameObject cameraSpawner);
    void CheckCameraEulerX(PlayerData _playerData, Transform _currentCameraTransform);
    

    #endregion
}
