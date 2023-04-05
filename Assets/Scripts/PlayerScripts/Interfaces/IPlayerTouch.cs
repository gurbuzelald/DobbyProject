using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IPlayerTouch
{
    void TouchEnemy(Collision collision, PlayerData _playerData, ref GameObject _healthBarObject, ref GameObject _topCanvasHealthBarObject, ref Transform _particleTransform);
}
