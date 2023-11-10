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

}
