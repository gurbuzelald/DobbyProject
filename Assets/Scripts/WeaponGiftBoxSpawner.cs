using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiftBoxSpawner : MonoBehaviour
{
    [SerializeField] BulletData bulletData;
    [SerializeField] PlayerData playerData;


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
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i));
        }

        GameObject giftBox = Instantiate(bulletData.giftBoxes[0], gameObject.transform);
        CreateWeaponGiftBox(bulletData.ak47GiftBox, giftBox.transform.GetChild(1).transform);


        CreateWeaponGiftBox(bulletData.rifleGiftBox, giftBox.transform.GetChild(0).transform);
        CreateWeaponGiftBox(bulletData.axegunGiftBox, giftBox.transform.GetChild(2).transform);
    }
    public void CreateWeaponGiftBox(GameObject weaponObject, Transform weaponTransform)
    {
        for (int i = 0; i < weaponTransform.childCount; i++)
        {

            GameObject _weaponObejct = Instantiate(weaponObject, weaponTransform.GetChild(i).position, Quaternion.identity, weaponTransform.GetChild(i));
            _weaponObejct.transform.rotation = weaponTransform.GetChild(i).rotation;
        }
    }   
    void SecondMapCreateGiftBoxes()
    {
        if (playerData.isCompleteFirstMap)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }

            GameObject giftBox = Instantiate(bulletData.giftBoxes[1], gameObject.transform);

            CreateWeaponGiftBox(bulletData.bullDogGiftBox, giftBox.transform.GetChild(0).transform);
            CreateWeaponGiftBox(bulletData.cowgunGiftBox, giftBox.transform.GetChild(1).transform);
            CreateWeaponGiftBox(bulletData.crsytalgunGiftBox, giftBox.transform.GetChild(2).transform);
            CreateWeaponGiftBox(bulletData.demongunGiftBox, giftBox.transform.GetChild(3).transform);
            CreateWeaponGiftBox(bulletData.icegunGiftBox, giftBox.transform.GetChild(4).transform);
            CreateWeaponGiftBox(bulletData.negevGiftBox, giftBox.transform.GetChild(5).transform);
            CreateWeaponGiftBox(bulletData.axegunGiftBox, giftBox.transform.GetChild(6).transform);
        }        
    }
    void ThirdMapCreateGiftBoxes()
    {
        if (playerData.isCompleteSecondMap)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }

            GameObject giftBox = Instantiate(bulletData.giftBoxes[2], gameObject.transform);

            CreateWeaponGiftBox(bulletData.bullDogGiftBox, giftBox.transform.GetChild(0).transform);
            CreateWeaponGiftBox(bulletData.cowgunGiftBox, giftBox.transform.GetChild(1).transform);
            CreateWeaponGiftBox(bulletData.crsytalgunGiftBox, giftBox.transform.GetChild(2).transform);
            CreateWeaponGiftBox(bulletData.demongunGiftBox, giftBox.transform.GetChild(3).transform);
            CreateWeaponGiftBox(bulletData.icegunGiftBox, giftBox.transform.GetChild(4).transform);
            CreateWeaponGiftBox(bulletData.negevGiftBox, giftBox.transform.GetChild(5).transform);
            CreateWeaponGiftBox(bulletData.axegunGiftBox, giftBox.transform.GetChild(6).transform);
        }
    }

    void FourthMapCreateGiftBoxes()
    {
        if (playerData.isCompleteThirdMap)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }

            GameObject giftBox = Instantiate(bulletData.giftBoxes[3], gameObject.transform);

            CreateWeaponGiftBox(bulletData.bullDogGiftBox, giftBox.transform.GetChild(0).transform);
            CreateWeaponGiftBox(bulletData.cowgunGiftBox, giftBox.transform.GetChild(1).transform);
            CreateWeaponGiftBox(bulletData.crsytalgunGiftBox, giftBox.transform.GetChild(2).transform);
            CreateWeaponGiftBox(bulletData.demongunGiftBox, giftBox.transform.GetChild(3).transform);
            CreateWeaponGiftBox(bulletData.icegunGiftBox, giftBox.transform.GetChild(4).transform);
            CreateWeaponGiftBox(bulletData.negevGiftBox, giftBox.transform.GetChild(5).transform);
            CreateWeaponGiftBox(bulletData.axegunGiftBox, giftBox.transform.GetChild(6).transform);
        }
    }
    
}
/* 
 
 


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
 
 */