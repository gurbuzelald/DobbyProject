using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IPlayerRotation
{
    void Rotate(ref float _touchX, ref float _touchY);
    void GetMousePosition(PlayerData _playerData, ref float _touchX, ref float _touchY);
    void SensivityXSettings(int touchXValue, PlayerController _playerController, PlayerData _playerData, ref float _touchX);
    
}
