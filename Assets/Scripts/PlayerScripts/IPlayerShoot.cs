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




}

