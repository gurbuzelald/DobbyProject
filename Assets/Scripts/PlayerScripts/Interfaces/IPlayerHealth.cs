using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal interface IPlayerHealth
{
    void IncreaseHealth(int damageHealthValue, ref GameObject _healthBarObject,ref Slider _healthBarSlider, ref Slider _topCanvasHealthBarSlider, Collider other);
    void DecreaseHealth(int damageHealthValue, ref GameObject _healthBarObject, ref Slider _healthBarSlider, ref Slider _topCanvasHealthBarSlider);
    IEnumerator DelayHealthSizeBack(GameObject _healthBarObject);
}
