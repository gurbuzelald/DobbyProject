using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiftBoxSpawner : MonoBehaviour
{
    [SerializeField] BulletData bulletData;
    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;


    private void Awake()
    {
        if (levelData.currentMapName == LevelData.MapNames.FirstMap)
        {
            CreateFirstMapGiftBoxes();
        }
        else if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            CreateSecondMapGiftBoxes();
        }
        else if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            CreateThirdMapGiftBoxes();
        }
        else if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            CreateFourthMapGiftBoxes();
        }
    }
    void CreateFirstMapGiftBoxes()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i));
        }

        GameObject giftBox = Instantiate(bulletData.giftBoxes[0], gameObject.transform);


        CreateWeaponGiftBox(bulletData.rifleGiftBox, giftBox.transform.GetChild(0).transform);
        CreateWeaponGiftBox(bulletData.bullDogGiftBox, giftBox.transform.GetChild(1).transform);
    }
    public void CreateWeaponGiftBox(GameObject weaponObject, Transform weaponTransform)
    {
        for (int i = 0; i < weaponTransform.childCount; i++)
        {

            GameObject _weaponObejct = Instantiate(weaponObject, weaponTransform.GetChild(i).position, Quaternion.identity, weaponTransform.GetChild(i));
            _weaponObejct.transform.rotation = weaponTransform.GetChild(i).rotation;
        }
    }   
    public void CreateSecondMapGiftBoxes()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        GameObject giftBox = Instantiate(bulletData.giftBoxes[1], gameObject.transform);

        CreateWeaponGiftBox(bulletData.cowgunGiftBox, giftBox.transform.GetChild(0).transform);
        CreateWeaponGiftBox(bulletData.crsytalgunGiftBox, giftBox.transform.GetChild(1).transform);
    }
    public void CreateThirdMapGiftBoxes()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        GameObject giftBox = Instantiate(bulletData.giftBoxes[2], gameObject.transform);

        CreateWeaponGiftBox(bulletData.demongunGiftBox, giftBox.transform.GetChild(0).transform);
        CreateWeaponGiftBox(bulletData.icegunGiftBox, giftBox.transform.GetChild(1).transform);
    }

    public void CreateFourthMapGiftBoxes()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        GameObject giftBox = Instantiate(bulletData.giftBoxes[3], gameObject.transform);

        CreateWeaponGiftBox(bulletData.negevGiftBox, giftBox.transform.GetChild(0).transform);
        CreateWeaponGiftBox(bulletData.axegunGiftBox, giftBox.transform.GetChild(1).transform);
    }
    
}
