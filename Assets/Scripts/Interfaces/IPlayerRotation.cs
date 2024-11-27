using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IPlayerRotation
{
    void Rotate(ref float _touchX, ref float _touchY, ref Transform playerTransform);
    void GetMousePosition(PlayerData _playerData, ref float _touchX, ref float _touchY);
    void SensivityXSettings(float touchXValue, PlayerData _playerData, ref float _touchX);
}
