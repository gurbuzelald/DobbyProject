using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiftBoxSpawner : MonoBehaviour
{
    [SerializeField] BulletData bulletData;
    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;
    private IEnumerator Start()
    {
        GiftBoxControllerAtStart();
        yield return new WaitForSeconds(1f);
        CreateMapGiftBoxes(bulletData.currentGiftBox, LevelUpController.currentLevelCount);
    }
    public void CreateMapGiftBoxes(GameObject weaponObject, int levelCount)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        GameObject giftBox = Instantiate(bulletData.giftBoxes[levelCount], gameObject.transform);


        CreateWeaponGiftBox(weaponObject, giftBox.transform.GetChild(0).transform);
    }
    public void CreateWeaponGiftBox(GameObject weaponObject, Transform weaponTransform)
    {
        for (int i = 0; i < weaponTransform.childCount; i++)
        {

            GameObject _weaponObejct = Instantiate(weaponObject, 
                                                   weaponTransform.GetChild(i).position, 
                                                   Quaternion.identity, 
                                                   weaponTransform.GetChild(i));
            _weaponObejct.transform.rotation = weaponTransform.GetChild(i).rotation;
        }
    }
    void GiftBoxControllerAtStart()
    {
        if (levelData.currentLevel == LevelData.Levels.Level1)
        {
            bulletData.currentGiftBox = bulletData.cowGiftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level3)
        {
            bulletData.currentGiftBox = bulletData.demonGiftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level4)
        {
            bulletData.currentGiftBox = bulletData.negevGiftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level5)
        {
            bulletData.currentGiftBox = bulletData.axeGiftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level6)
        {
            bulletData.currentGiftBox = bulletData.crsytalGiftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level7)
        {
            bulletData.currentGiftBox = bulletData.iceGiftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level8)
        {
            bulletData.currentGiftBox = bulletData.pistolGiftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level9)
        {
            bulletData.currentGiftBox = bulletData.ak47GiftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level10)
        {
            bulletData.currentGiftBox = bulletData.m4a4GiftBox;
        }
    }


}
