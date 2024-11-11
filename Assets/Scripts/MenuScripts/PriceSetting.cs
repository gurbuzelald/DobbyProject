using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PriceSetting : MonoBehaviour
{
    [SerializeField] PlayerData playerData;    
    [SerializeField] BulletData bulletData;    

    private string[] characterNames = new string[11];
    private string[] weaponNames = new string[10];


    public GameObject[] characterStaffs;
    public GameObject[] weaponStaffs;
    public GameObject[] weaponPriceTexts;
    public TextMeshProUGUI[] characterPriceTexts;

    private void Awake()
    {
        SetWeaponNames();
        SetWeaponPrices();

        SetCharacterNames();
        SetCharacterPrices();        
    }
    
    void SetCharacterNames()
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
    private void Update()
    {
        SetWeaponPrices();
    }
    public void SetWeaponPrices()
    {
        if (weaponStaffs.Length != 0)
        {
            Dictionary<string, (string lockState, int price)> weaponDataMap = new Dictionary<string, (string, int)>
        {
            { bulletData.weaponStruct[0].weaponName, (bulletData.weaponStruct[0].lockState, bulletData.weaponStruct[0].price) },
            { bulletData.weaponStruct[1].weaponName, (bulletData.weaponStruct[1].lockState, bulletData.weaponStruct[1].price) },
            { bulletData.weaponStruct[2].weaponName, (bulletData.weaponStruct[2].lockState, bulletData.weaponStruct[2].price) },
            { bulletData.weaponStruct[3].weaponName, (bulletData.weaponStruct[3].lockState, bulletData.weaponStruct[3].price) },
            { bulletData.weaponStruct[4].weaponName, (bulletData.weaponStruct[4].lockState, bulletData.weaponStruct[4].price) },
            { bulletData.weaponStruct[5].weaponName, (bulletData.weaponStruct[5].lockState, bulletData.weaponStruct[5].price) },
            { bulletData.weaponStruct[6].weaponName, (bulletData.weaponStruct[6].lockState, bulletData.weaponStruct[6].price) },
            { bulletData.weaponStruct[7].weaponName, (bulletData.weaponStruct[7].lockState, bulletData.weaponStruct[7].price) },
            { bulletData.weaponStruct[8].weaponName, (bulletData.weaponStruct[8].lockState, bulletData.weaponStruct[8].price) },
            { bulletData.weaponStruct[9].weaponName, (bulletData.weaponStruct[9].lockState, bulletData.weaponStruct[9].price) }
        };

            for (int i = 0; i < weaponStaffs.Length; i++)
            {
                if (weaponDataMap.TryGetValue(weaponNames[i], out var weaponData))
                {
                    // If the weapon is locked, display its price; otherwise, clear the text.
                    weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text =
                        BulletData.locked == weaponData.lockState ? weaponData.price.ToString() + " Coin" : "";
                }
                else
                {
                    weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = "No Valid";
                }
            }
        }
    }

    public void SetCharacterPrices()
    {
        if (characterStaffs.Length != 0)
        {
            for (int i = 0; i < characterPriceTexts.Length; i++)
            {
                string characterName = characterNames[i];
                for (int j = 0; j < playerData.characterStruct.Length; j++)
                {
                    if (playerData.characterStruct[j].name == characterName)
                    {
                        // Check lock state and set price text
                        if (playerData.locked == playerData.characterStruct[j].lockState)
                        {
                            characterPriceTexts[i].text = playerData.characterStruct[j].price.ToString() + " Coin";
                        }
                        else if (playerData.locked != playerData.characterStruct[j].lockState)
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break; // Exit the loop once a match is found.
                    }
                }
            }
        }
    }

}
