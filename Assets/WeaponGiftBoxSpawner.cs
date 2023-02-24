using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiftBoxSpawner : MonoBehaviour
{
    [SerializeField] BulletData bulletData;

    [Header("Rifle")]
    [SerializeField] Transform[] _rifleTransforms;

    [Header("Ak47")]
    [SerializeField] Transform[] _ak47Transforms;

    [Header("Bulldog")]
    [SerializeField] Transform[] _bulldogTransforms;

    [Header("Cowgun")]
    [SerializeField] Transform[] _cowgunTransforms;

    [Header("Crystalgun")]
    [SerializeField] Transform[] _crystalgunTransforms;

    [Header("Demongun")]
    [SerializeField] Transform[] _demongunTransforms;

    [Header("Icegun")]
    [SerializeField] Transform[] _icegunTransforms;

    [Header("Negev")]
    [SerializeField] Transform[] _negevTransforms;

    [Header("Axegun")]
    [SerializeField] Transform[] _axegunTransforms;

    private void Awake()
    {
        CreateWeaponGiftBox(bulletData.ak47GiftBox, _ak47Transforms);
        CreateWeaponGiftBox(bulletData.rifleGiftBox, _rifleTransforms);
        CreateWeaponGiftBox(bulletData.bullDogGiftBox, _bulldogTransforms);
        CreateWeaponGiftBox(bulletData.cowgunGiftBox, _cowgunTransforms);
        CreateWeaponGiftBox(bulletData.crsytalgunGiftBox, _crystalgunTransforms);
        CreateWeaponGiftBox(bulletData.demongunGiftBox, _demongunTransforms);
        CreateWeaponGiftBox(bulletData.icegunGiftBox, _icegunTransforms);
        CreateWeaponGiftBox(bulletData.negevGiftBox, _negevTransforms);
        CreateWeaponGiftBox(bulletData.axegunGiftBox, _axegunTransforms);
    }
    public void CreateWeaponGiftBox(GameObject weaponObject, Transform[] weaponTransform)
    {
        for (int i = 0; i < weaponTransform.Length; i++)
        {
            GameObject _weaponObejct = Instantiate(weaponObject, weaponTransform[i].position, Quaternion.identity, gameObject.transform);
            _weaponObejct.transform.rotation = weaponTransform[i].rotation;
        }
    }
}
