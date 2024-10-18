using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LockingStatement : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] BulletData bulletData;
    private ChooseCharacterController pickCharacterController;

    private string[] characterNames = new string[12];
    private string[] weaponNames = new string[10];

    private GameObject characterStaffs;
    private PriceSetting priceSetting;

    void Awake()
    {
        priceSetting = GameObject.FindObjectOfType<PriceSetting>();
        characterStaffs = GameObject.Find("CharacterStaffs");

        SetCharacterNames();
        SetWeaponNames();

        SetCharacterLockingMode();
        SetWeaponLockingMode(bulletData);
    }
    private void OnDisable()
    {
        gameObject.GetComponent<LockingStatement>().enabled = true;
    }

    void SetCharacterNames()
    {
        if (characterStaffs)
        {
            for (int i = 0; i < characterStaffs.transform.childCount; i++)
            {
                characterNames[i] = characterStaffs.transform.GetChild(i).GetChild(0).name;
            }
        }
    }
    void SetWeaponNames()
    {
        if (priceSetting)
        {
            if (priceSetting.weaponStaffs.Length != 0)
            {
                for (int i = 0; i < priceSetting.weaponStaffs.Length; i++)
                {
                    weaponNames[i] = priceSetting.weaponStaffs[i].transform.GetChild(0).name;
                }
            }
        }
        
    }

    void SetCharacterLockingMode()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            string characterName = characterNames[i];
            for (int j = 0; j < playerData.characterStruct.Length; j++)
            {
                if (characterName == playerData.characterStruct[j].name)
                {
                    gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = playerData.characterStruct[j].lockState.ToString();
                    break; // Exit inner loop once a match is found
                }
            }
        }
    }

    void SetWeaponLockingMode(BulletData bulletData)
    {
        int childCount = gameObject.transform.childCount;
        int weaponCount = bulletData.weaponStruct.Length;

        for (int i = 0; i < childCount; i++)
        {
            for (int j = 0; j < weaponCount; j++)
            {
                if (weaponNames[i] == bulletData.weaponStruct[j].weaponName)
                {
                    gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = bulletData.weaponStruct[j].lockState.ToString();
                    break; // Exit the inner loop once a match is found
                }
            }
        }
    }

}
