using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiftBoxSpawner : MonoBehaviour
{
    [Header("Rifle")]
    [SerializeField] GameObject _rifleObject;
    [SerializeField] Transform[] _rifleTransform;

    [Header("Pistol")]
    [SerializeField] GameObject _ak47Object;
    [SerializeField] Transform[] _pistolTransform;
    private void Awake()
    {
        CreateWeaponGiftBox(_ak47Object, _pistolTransform);
        CreateWeaponGiftBox(_rifleObject, _rifleTransform);
    }
    public void CreateWeaponGiftBox(GameObject weaponObject, Transform[] weaponTransform)
    {
        for (int i = 0; i < _pistolTransform.Length; i++)
        {
            GameObject _weaponObejct = Instantiate(weaponObject, weaponTransform[i].position, Quaternion.identity, gameObject.transform);
            _weaponObejct.transform.rotation = weaponTransform[i].rotation;
        }
    }
}
