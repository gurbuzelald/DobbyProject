using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CharacterLockingStatement : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] BulletData bulletData;
    private ChooseCharacterController pickCharacterController;

    private string[] characterNames = new string[11];
    private string[] weaponNames = new string[10];

    public GameObject[] characterStaffs;
    public GameObject[] weaponStaffs;

    void Awake()
    {
        //ResetCharactersLocks();

        SetCharacterIDs();
        SetWeaponNames();

        SetCharacterLockingMode();
        SetWeaponLockingMode(bulletData);
    }
    

    void SetCharacterIDs()
    {
        if (characterStaffs.Length != 0)
        {
            for (int i = 0; i < characterStaffs.Length; i++)
            {
                characterNames[i] = characterStaffs[i].transform.GetChild(0).name;
            }
        }        
    }
    void SetWeaponNames()
    {
        if (weaponStaffs.Length != 0)
        {
            for (int i = 0; i < weaponStaffs.Length; i++)
            {
                weaponNames[i] = weaponStaffs[i].transform.GetChild(0).name;
            }
        }
    }

    void SetCharacterLockingMode()
    {
        if (characterStaffs.Length != 0)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                string characterName = characterNames[i];
                for (int j = 0; j < playerData.characterStruct.Length; j++)
                {
                    if (playerData.characterStruct[j].name == characterName)
                    {
                        gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = playerData.characterStruct[j].lockState.ToString();
                        break; // Exit the loop once a match is found.
                    }
                }
            }
        }
    }

    void SetWeaponLockingMode(BulletData bulletData)
    {
        int childCount = gameObject.transform.childCount;

        if (weaponStaffs.Length != 0)
        {
            for (int i = 0; i < childCount; i++)
            {
                for (int j = 0; j < bulletData.weaponStruct.Length; j++)
                {
                    if (bulletData.weaponStruct[j].weaponName == weaponNames[i])
                    {
                        gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = bulletData.weaponStruct[j].lockState.ToString();
                        break;
                    }
                }
            }
        }
    }

}
