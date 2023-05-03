using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IPlayerHealth
{
    void IncreaseHealth(int damageHealthValue, ref GameObject _healthBarObject, ref GameObject _topCanvasHealthBarObject, Collider other);
    void DecreaseHealth(int damageHealthValue, ref GameObject _healthBarObject, ref GameObject _topCanvasHealthBarObject);
    IEnumerator DelayHealthSizeBack(GameObject _healthBarObject);
}
