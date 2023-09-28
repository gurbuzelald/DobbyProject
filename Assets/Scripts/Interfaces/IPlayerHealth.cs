using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal interface IPlayerHealth
{
    void IncreaseHealth(int damageHealthValue, ref GameObject _healthBarObject,ref Slider _healthBarSlider, ref Slider _topCanvasHealthBarSlider, Collider other);
    void DecreaseHealth(ref PlayerData playerData, int damageHealthValue, ref GameObject _healthBarObject, ref Slider _healthBarSlider, ref Slider _topCanvasHealthBarSlider, ref TextMeshProUGUI damageHealthText);
    IEnumerator DelayDamageHealthTextEnableFalse(TextMeshProUGUI damageHealthText);
    IEnumerator DelayHealthSizeBack(GameObject _healthBarObject);
}
