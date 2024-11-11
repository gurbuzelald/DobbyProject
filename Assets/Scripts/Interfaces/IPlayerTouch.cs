using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal interface IPlayerTouch
{
    void TouchEnemy(PlayerData _playerData, 
                    ref Slider _healthBarSlider, 
                    ref Slider _topCanvasHealthBarSlider);
}
