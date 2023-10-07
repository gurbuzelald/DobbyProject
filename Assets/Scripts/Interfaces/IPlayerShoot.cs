using System.Collections;
using UnityEngine;

internal interface IPlayerShoot
{

    #region //Shooting
    void Fire(PlayerData playerData);
    void Sword(PlayerData _playerData);


    IEnumerator DelayShowingCrosshairAlpha(CanvasGroup crosshairImage, float delay);
    IEnumerator delayFireWalkDisactivity(PlayerData _playerData, float delay);
    #endregion


    #region //Camera
    void ChangeCamera(PlayerData playerData, ref PlayerManager playerManager);
    void ConvertToCloseCamera(GameObject cameraSpawner);
    void ConvertToFarCamera(GameObject cameraSpawner);
    void CheckCameraEulerX(PlayerData _playerData, Transform _currentCameraTransform);

    #endregion


}

