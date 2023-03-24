using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiftBoxSpawner : MonoBehaviour
{
    [SerializeField] BulletData bulletData;
    [SerializeField] PlayerData playerData;


    [Header("First Map Gift Boxes")]
    [Header("Rifle")]
    public Transform[] _firstMapRifleTransforms;

    [Header("Ak47")]
    public Transform[] _firstMapAk47Transforms;

    [Header("Axegun")]
    public Transform[] _firstMapAxegunTransforms;



    [Header("Second Map Gift Boxes")]
    [Header("Bulldog")]
    public Transform[] _secondMapBulldogTransforms;

    [Header("Cowgun")]
    public Transform[] _secondMapCowgunTransforms;

    [Header("Crystalgun")]
    public Transform[] _secondMapCrystalgunTransforms;

    [Header("Demongun")]
    public Transform[] _secondMapDemongunTransforms;

    [Header("Icegun")]
    public Transform[] _secondMapIcegunTransforms;

    [Header("Negev")]
    public Transform[] _secondMapNegevTransforms;

    [Header("Axegun")]
    public Transform[] _secondMapAxegunTransforms;


    [Header("Third Map Gift Boxes")]
    [Header("Bulldog")]
    public Transform[] _thirdMapBulldogTransforms;

    [Header("Cowgun")]
    public Transform[] _thirdMapCowgunTransforms;

    [Header("Crystalgun")]
    public Transform[] _thirdMapCrystalgunTransforms;

    [Header("Demongun")]
    public Transform[] _thirdMapDemongunTransforms;

    [Header("Icegun")]
    public Transform[] _thirdMapIcegunTransforms;

    [Header("Negev")]
    public Transform[] _thirdMapNegevTransforms;

    [Header("Axegun")]
    public Transform[] _thirdMapAxegunTransforms;


    [Header("Fourth Map Gift Boxes")]
    [Header("Bulldog")]
    public Transform[] _fourthMapBulldogTransforms;

    [Header("Cowgun")]
    public Transform[] _fourthMapCowgunTransforms;

    [Header("Crystalgun")]
    public Transform[] _fourthMapCrystalgunTransforms;

    [Header("Demongun")]
    public Transform[] _fourthMapDemongunTransforms;

    [Header("Icegun")]
    public Transform[] _fourthMapIcegunTransforms;

    [Header("Negev")]
    public Transform[] _fourthMapNegevTransforms;

    [Header("Axegun")]
    public Transform[] _fourthMapAxegunTransforms;

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
        FourthMapCreateGiftBoxes();
    }
    void FirstMapCreateGiftBoxes()
    {
        CreateWeaponGiftBox(bulletData.ak47GiftBox, _firstMapAk47Transforms);


        CreateWeaponGiftBox(bulletData.rifleGiftBox, _firstMapRifleTransforms);
        CreateWeaponGiftBox(bulletData.axegunGiftBox, _firstMapAxegunTransforms);
    }
    void SecondMapCreateGiftBoxes()
    {
        if (playerData.isCompleteFirstMap)
        {
            CreateWeaponGiftBox(bulletData.bullDogGiftBox, _secondMapBulldogTransforms);
            CreateWeaponGiftBox(bulletData.cowgunGiftBox, _secondMapCowgunTransforms);
            CreateWeaponGiftBox(bulletData.crsytalgunGiftBox, _secondMapCrystalgunTransforms);
            CreateWeaponGiftBox(bulletData.demongunGiftBox, _secondMapDemongunTransforms);
            CreateWeaponGiftBox(bulletData.icegunGiftBox, _secondMapIcegunTransforms);
            CreateWeaponGiftBox(bulletData.negevGiftBox, _secondMapNegevTransforms);
            CreateWeaponGiftBox(bulletData.axegunGiftBox, _secondMapAxegunTransforms);

            DestroyPastMapGiftBoxes(giftBoxes[0]);
        }        
    }
    void ThirdMapCreateGiftBoxes()
    {
        if (playerData.isCompleteSecondMap)
        {
            CreateWeaponGiftBox(bulletData.bullDogGiftBox, _thirdMapBulldogTransforms);
            CreateWeaponGiftBox(bulletData.cowgunGiftBox, _thirdMapCowgunTransforms);
            CreateWeaponGiftBox(bulletData.crsytalgunGiftBox, _thirdMapCrystalgunTransforms);
            CreateWeaponGiftBox(bulletData.demongunGiftBox, _thirdMapDemongunTransforms);
            CreateWeaponGiftBox(bulletData.icegunGiftBox, _thirdMapIcegunTransforms);
            CreateWeaponGiftBox(bulletData.negevGiftBox, _thirdMapNegevTransforms);
            CreateWeaponGiftBox(bulletData.axegunGiftBox, _thirdMapAxegunTransforms);
            DestroyPastMapGiftBoxes(giftBoxes[0]);
            DestroyPastMapGiftBoxes(giftBoxes[1]);
        }
    }

    void FourthMapCreateGiftBoxes()
    {
        if (playerData.isCompleteThirdMap)
        {
            CreateWeaponGiftBox(bulletData.bullDogGiftBox, _fourthMapBulldogTransforms);
            CreateWeaponGiftBox(bulletData.cowgunGiftBox, _fourthMapCowgunTransforms);
            CreateWeaponGiftBox(bulletData.crsytalgunGiftBox, _fourthMapCrystalgunTransforms);
            CreateWeaponGiftBox(bulletData.demongunGiftBox, _fourthMapDemongunTransforms);
            CreateWeaponGiftBox(bulletData.icegunGiftBox, _fourthMapIcegunTransforms);
            CreateWeaponGiftBox(bulletData.negevGiftBox, _fourthMapNegevTransforms);
            CreateWeaponGiftBox(bulletData.axegunGiftBox, _fourthMapAxegunTransforms);
            DestroyPastMapGiftBoxes(giftBoxes[0]);
            DestroyPastMapGiftBoxes(giftBoxes[1]);
            DestroyPastMapGiftBoxes(giftBoxes[2]);
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
