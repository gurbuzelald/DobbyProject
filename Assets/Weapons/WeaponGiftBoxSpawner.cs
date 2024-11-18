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
    public void CreateMapGiftBoxes(GameObject weaponObject, int levelID)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }

        GameObject giftBox = Instantiate(bulletData.weaponStruct[levelID].giftBoxTransform, gameObject.transform);


        CreateWeaponGiftBox(weaponObject, giftBox.transform.GetChild(0).transform);
    }
    void CreateWeaponGiftBox(GameObject weaponObject, Transform weaponTransform)
    {
        for (int i = 0; i < weaponTransform.childCount; i++)
        {

            GameObject _weaponObejct = Instantiate(weaponObject, 
                                                   weaponTransform.GetChild(i).position, 
                                                   Quaternion.identity, 
                                                   gameObject.transform.GetChild(0).GetChild(0).GetChild(0));
            _weaponObejct.transform.rotation = weaponTransform.GetChild(i).rotation;
        }
    }
    void GiftBoxControllerAtStart()
    {
        int levelIndex = Array.FindIndex(levelData.levels, level => level.id == LevelData.currentLevelId);

        // Ensure the index is valid and within the bounds of weaponStruct
        if (levelIndex >= 0 && levelIndex < bulletData.weaponStruct.Length)
        {
            bulletData.currentGiftBox = bulletData.weaponStruct[levelIndex].giftBox;
        }
        else
        {
            Debug.LogWarning("Invalid level ID or weaponStruct index.");
        }
    }
}
