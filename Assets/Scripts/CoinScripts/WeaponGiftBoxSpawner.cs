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
        if (levelData.currentLevel == LevelData.Levels.Level1)
        {
            CreateFirstMapGiftBoxes();
        }
        else if (levelData.currentLevel == LevelData.Levels.Level2)
        {
            CreateSecondMapGiftBoxes();
        }
        else if (levelData.currentLevel == LevelData.Levels.Level3)
        {
            CreateThirdMapGiftBoxes();
        }
        else if (levelData.currentLevel == LevelData.Levels.Level4)
        {
            CreateFourthMapGiftBoxes();
        }
        else if (levelData.currentLevel == LevelData.Levels.Level5)
        {
            CreateFifthMapGiftBoxes();
        }
    }

    void CreateFirstMapGiftBoxes()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i));
        }

        GameObject giftBox = Instantiate(bulletData.giftBoxes[0], gameObject.transform);


        CreateWeaponGiftBox(bulletData.bullDogGiftBox, giftBox.transform.GetChild(0).transform);
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

        CreateWeaponGiftBox(bulletData.currentGiftBox, giftBox.transform.GetChild(0).transform);
    }
    public void CreateThirdMapGiftBoxes()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        GameObject giftBox = Instantiate(bulletData.giftBoxes[2], gameObject.transform);

        CreateWeaponGiftBox(bulletData.demongunGiftBox, giftBox.transform.GetChild(0).transform);
    }

    public void CreateFourthMapGiftBoxes()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        GameObject giftBox = Instantiate(bulletData.giftBoxes[3], gameObject.transform);

        CreateWeaponGiftBox(bulletData.negevGiftBox, giftBox.transform.GetChild(0).transform);
    }
    public void CreateFifthMapGiftBoxes()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        GameObject giftBox = Instantiate(bulletData.giftBoxes[4], gameObject.transform);

        CreateWeaponGiftBox(bulletData.axegunGiftBox, giftBox.transform.GetChild(0).transform);
    }

}
