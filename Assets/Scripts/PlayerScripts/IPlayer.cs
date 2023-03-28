using UnityEngine;

internal interface IPlayer
{
    void SayHello(string value);

    #region //Shooting
    void Fire(PlayerData playerData);
    void Sword(PlayerData _playerData);

    #endregion


    #region //Camera
    void ChangeCamera();
    void ConvertToCloseCamera(GameObject cameraSpawner);
    void ConvertToFarCamera(GameObject cameraSpawner);
    void CheckCameraEulerX(PlayerData _playerData, Transform _currentCameraTransform);

    #endregion

}

