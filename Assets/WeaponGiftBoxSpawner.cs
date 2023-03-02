using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiftBoxSpawner : MonoBehaviour
{
    [SerializeField] BulletData bulletData;
    [SerializeField] PlayerData playerData;


    [Header("First Map Gift Boxes")]
    [Header("Rifle")]
    public Transform[] _rifleTransforms;

    [Header("Ak47")]
    public Transform[] _ak47Transforms;

    [Header("Axegun")]
    public Transform[] _firstAxegunTransforms;



    [Header("Second Map Gift Boxes")]
    [Header("Bulldog")]
    public Transform[] _bulldogTransforms;

    [Header("Cowgun")]
    public Transform[] _cowgunTransforms;

    [Header("Crystalgun")]
    public Transform[] _crystalgunTransforms;

    [Header("Demongun")]
    public Transform[] _demongunTransforms;

    [Header("Icegun")]
    public Transform[] _icegunTransforms;

    [Header("Negev")]
    public Transform[] _negevTransforms;

    [Header("Axegun")]
    public Transform[] _secondAxegunTransforms;

    [SerializeField] GameObject[] giftBoxes;

    private void Awake()
    {
        if (!playerData.isCompleteFirstMap || !playerData.isCompleteSecondMap || !playerData.isCompleteThirdMap)
        {
            FirstMapCreateGiftBoxes();
        }
    }
    private void Update()
    {
        SecondMapCreateGiftBoxes();
        ThirdMapCreateGiftBoxes();
    }
    void FirstMapCreateGiftBoxes()
    {
        CreateWeaponGiftBox(bulletData.ak47GiftBox, _ak47Transforms);


        CreateWeaponGiftBox(bulletData.rifleGiftBox, _rifleTransforms);
        CreateWeaponGiftBox(bulletData.axegunGiftBox, _firstAxegunTransforms);
    }
    void SecondMapCreateGiftBoxes()
    {
        if (playerData.isCompleteFirstMap)
        {
            CreateWeaponGiftBox(bulletData.bullDogGiftBox, _bulldogTransforms);
            CreateWeaponGiftBox(bulletData.cowgunGiftBox, _cowgunTransforms);
            CreateWeaponGiftBox(bulletData.crsytalgunGiftBox, _crystalgunTransforms);
            CreateWeaponGiftBox(bulletData.demongunGiftBox, _demongunTransforms);
            CreateWeaponGiftBox(bulletData.icegunGiftBox, _icegunTransforms);
            CreateWeaponGiftBox(bulletData.negevGiftBox, _negevTransforms);
            CreateWeaponGiftBox(bulletData.axegunGiftBox, _secondAxegunTransforms);

            DestroyPastMapGiftBoxes(giftBoxes[0]);
        }        
    }
    void ThirdMapCreateGiftBoxes()
    {
        if (playerData.isCompleteSecondMap)
        {
            DestroyPastMapGiftBoxes(giftBoxes[1]);
        }
    }


    void DestroyPastMapGiftBoxes(GameObject giftBox)
    {
        Destroy(giftBox);
    }
    public void CreateWeaponGiftBox(GameObject weaponObject, Transform[] weaponTransform)
    {
        for (int i = 0; i < weaponTransform.Length; i++)
        {
            
            GameObject _weaponObejct = Instantiate(weaponObject, weaponTransform[i].position, Quaternion.identity, weaponTransform[i]);
            _weaponObejct.transform.rotation = weaponTransform[i].rotation;
        }
    }
}
