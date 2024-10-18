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
        CreateMapGiftBoxes(bulletData.currentGiftBox, LevelData.currentLevelId);
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
    void CreateWeaponGiftBox(GameObject weaponObject, Transform weaponTransform)
    {
        for (int i = 0; i < weaponTransform.childCount; i++)
        {

            GameObject _weaponObejct = Instantiate(weaponObject, 
                                                   weaponTransform.GetChild(i).position, 
                                                   Quaternion.identity, 
                                                   gameObject.transform);
            _weaponObejct.transform.rotation = weaponTransform.GetChild(i).rotation;
        }
    }
    void GiftBoxControllerAtStart()
    {
        if (levelData.currentLevel == LevelData.Levels.Level1)
        {
            bulletData.currentGiftBox = bulletData.weaponStruct[1].giftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level2)
        {
            bulletData.currentGiftBox = bulletData.weaponStruct[2].giftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level3)
        {
            bulletData.currentGiftBox = bulletData.weaponStruct[3].giftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level4)
        {
            bulletData.currentGiftBox = bulletData.weaponStruct[4].giftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level5)
        {
            bulletData.currentGiftBox = bulletData.weaponStruct[5].giftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level6)
        {
            bulletData.currentGiftBox = bulletData.weaponStruct[6].giftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level7)
        {
            bulletData.currentGiftBox = bulletData.weaponStruct[7].giftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level8)
        {
            bulletData.currentGiftBox = bulletData.weaponStruct[8].giftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level9)
        {
            bulletData.currentGiftBox = bulletData.weaponStruct[9].giftBox;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level10)
        {
            bulletData.currentGiftBox = bulletData.weaponStruct[9].giftBox;
        }
    }


}
